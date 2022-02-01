using ClosedXML.Excel;
using Inve_Time.DataBase.Context;
using Inve_Time.Entities.Entities;
using Inve_Time.Interfaces.Repositories;
using Inve_Time.Interfaces.Services;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Inve_Time.Services.Services
{
    internal class ParserFromExcelService : IParserFromExcelService
    {
        private readonly IRepository<ProductInvented> _ProductInventedRepository;
        private readonly IRepository<Product> _ProductRepository;
        private readonly InveTimeDB _Db;


        public ParserFromExcelService(
            IRepository<ProductInvented> productInventedRepository,
            IRepository<Product> productRepository,
            InveTimeDB db
            )
        {
            _ProductInventedRepository = productInventedRepository;
            _ProductRepository = productRepository;
            _Db = db;
        }



        public DataTable GetDataFromExele(string path)
        {
            var dt = new DataTable();


            using (var workBook = new XLWorkbook(path))
            {
                var workSheet = workBook.Worksheet(1);

                bool firstRow = true;

                foreach (var row in workSheet.Rows())
                {
                    if (firstRow)
                    {
                        foreach (var cell in row.Cells())
                        {
                            if (!string.IsNullOrEmpty(cell.Value.ToString()))
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            else
                            {
                                break;
                            }
                        }
                        firstRow = false;
                    }
                    else
                    {
                        int i = 0;
                        var toInsert = dt.NewRow();
                        foreach (var cell in row.Cells(1, dt.Columns.Count))
                        {
                            try
                            {
                                toInsert[i] = cell.Value.ToString();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            i++;
                        }
                        dt.Rows.Add(toInsert);
                    }
                }

                return dt;
            }
        }

        public async Task<DataTable> GetDataFromExeleAsync(string path)
        {
            var dt = await Task.Run(() => GetDataFromExele(path));
            return dt;
        }

        public void SaveDataInDataBase(DataTable data)
        {
            _ProductInventedRepository.AutoSaveChanges = false;
            
            foreach (DataRow dataRow in data.Rows)
            {
                var cells = dataRow.ItemArray;
                var product = FindExistingOrCreateNewProduct(cells[0].ToString(), cells[1].ToString(), cells[2].ToString());
                var productToInventory = new ProductInvented()
                {
                    AmountData = (Int32)cells[3],
                    ProductInfoId = product.Id,
                    ProductInfo = product
                };

                _ProductInventedRepository.Add(productToInventory);
            }

            _Db.SaveChanges();
        }

        public async Task SaveDataInDataBaseAsync(DataTable data)
        {
            _ProductInventedRepository.AutoSaveChanges = false;

            foreach (DataRow dataRow in data.Rows)
            {
                var cells = dataRow.ItemArray;
                var product = FindExistingOrCreateNewProduct(cells[0].ToString(), cells[1].ToString(), cells[2].ToString());
                var productToInventory = new ProductInvented()
                {
                    AmountData = (Int32)cells[3],
                    ProductInfoId = product.Id,
                    ProductInfo = product
                };

                await _ProductInventedRepository.AddAsync(productToInventory);
            }

            await _Db.SaveChangesAsync();
        }



        private Product FindExistingOrCreateNewProduct(string barcode, string vendorCode , string productName)
        {
            if (_ProductRepository.Items.Any(prod => prod.Name == productName))
            {
                var result_1 = _ProductRepository.Items.FirstOrDefault(prod => prod.Name == productName);

                return result_1;
            }
            var product = new Product() 
            {
                Name = productName,
                Barcode = barcode,
                VendorCode = vendorCode
            };
            _ProductRepository.Add(product);
            _Db.SaveChanges();
            var result_2 = _ProductRepository.Items.FirstOrDefault(prod => prod.Name == productName);
        
            return result_2;
        }


    }
}
