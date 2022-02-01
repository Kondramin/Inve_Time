using System.Data;
using System.Threading.Tasks;

namespace Inve_Time.Interfaces.Services
{
    public interface IParserFromExcelService
    {
        /// <summary>Connecting to Excel file and parsing data</summary>
        /// <param name="path">Path to Excel file</param>
        /// <returns>Data table with data</returns>
        DataTable GetDataFromExele(string path);

        /// <summary>Connecting to Excel file and parsing data async</summary>
        /// <param name="path">Path to Excel file</param>
        /// <returns>Data table with data</returns>
        Task<DataTable> GetDataFromExeleAsync(string path);

        /// <summary>Saving parsed data</summary>
        /// <param name="data">Data table with data</param>
        void SaveDataInDataBase(DataTable data);

        /// <summary>Saving parsed data async</summary>
        /// <param name="data">Data table with data</param>
        /// <returns></returns>
        Task SaveDataInDataBaseAsync(DataTable data);
    }
}
