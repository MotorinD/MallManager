using System;
using System.Data.Common;
using System.Data.SqlClient;
namespace MallManager.Managers
{
    /// <summary>
    /// Менеджер доступа к подключению к БД
    /// </summary>
    public class DBConnectionManager
    {
        private readonly string _connectionString;
        private DbConnection _dbConnection;

        public DBConnectionManager()
        {
            this._connectionString = Properties.Settings.Default.ConnectionString;
            this.InitConnectionToDB();
        }

        public DbConnection GetConnection()
        {
            return this._dbConnection;
        }

        private void InitConnectionToDB()
        {
            try
            {
                this.InitMSSqlConnection();
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Trying Set Connection to DB", ex);
            }
        }

        private void InitMSSqlConnection()
        {
            this._dbConnection = new SqlConnection(this._connectionString);
        }
    }
}
