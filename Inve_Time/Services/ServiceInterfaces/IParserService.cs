using System.Data;
using System.Threading.Tasks;

namespace Inve_Time.Services.ServiceInterfaces
{
    interface IParserService
    {
        /// <summary>
        /// Connecting to Exele file and parsing data
        /// </summary>
        /// <param name="path">Path to Exele file</param>
        /// <returns>Datatable with data</returns>
        DataTable GetDataFromExele(string path);

        /// <summary>
        /// Connecting to Exele file and parsing data async
        /// </summary>
        /// <param name="path">Path to Exele file</param>
        /// <returns>Datatable with data</returns>
        Task<DataTable> GetDataFromExeleAsync(string path);

        /// <summary>
        /// Saving parsed data
        /// </summary>
        /// <param name="data">Datatable with data</param>
        void SaveDataInDataBase(DataTable data);

        /// <summary>
        /// Saving parsed data async
        /// </summary>
        /// <param name="data">Datatable with data</param>
        /// <returns></returns>
        Task SaveDataInDataBaseAsync(DataTable data);
    }
}
