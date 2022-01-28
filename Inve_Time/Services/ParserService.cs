using ClosedXML.Excel;
using Inve_Time.Services.ServiceInterfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Inve_Time.Services
{
    internal class ParserService : IParserService
    {
        //private readonly IRepository<ProductInvented> _ProductInventedRepository;
        //private readonly InveTimeDB _Db;



        public ParserService(/*IRepository<ProductInvented> ProductInventedRepository, InveTimeDB db*/)
        {
            //_ProductInventedRepository = ProductInventedRepository;
            //_Db = db;
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
            //_ProductInventedRepository.AutoSaveChanges = false;
            //foreach (DataRow row in data.Rows)
            //{
            //    var cells = row.ItemArray;
            //    var product = new ProductInvented()
            //    {
            //        Barcode = cells[0].ToString(),
            //        VendorCode = cells[1].ToString(),
            //        Name = cells[2].ToString(),
            //        AmountData = Convert.ToInt32(cells[3])
            //    };

            //    _ProductInventedRepository.Add(product);

            //}
            //_Db.SaveChanges();
        }

        public async Task SaveDataInDataBaseAsync(DataTable data)
        {
            //_ProductInventedRepository.AutoSaveChanges = false;

            //foreach (DataRow row in data.Rows)
            //{

            //    var cells = row.ItemArray;
            //    var product = new ProductInvented()
            //    {
            //        Barcode = cells[0].ToString(),
            //        VendorCode = cells[1].ToString(),
            //        Name = cells[2].ToString(),
            //        AmountData = Convert.ToInt32(cells[3])
            //    };

            //    await _ProductInventedRepository.AddAsync(product);

            //}
            //await _Db.SaveChangesAsync();
        }

    }
}

