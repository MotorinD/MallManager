using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallManager.Managers
{
    public class ManagerHelper
    {
        private static AppConfigManager _appConfig;
        public static AppConfigManager AppConfig
        {
            get
            {
                if (_appConfig is null)
                    _appConfig = new AppConfigManager();

                return _appConfig;
            }
        }

        private static DBConnectionManager _dbConnection;
        public static DBConnectionManager DBConnection
        {
            get
            {
                if (_dbConnection is null)
                    _dbConnection = new DBConnectionManager();

                return _dbConnection;
            }
        }


        private static EntityManager _entity;
        public static EntityManager Entity
        {
            get
            {
                if (_entity is null)
                    _entity = new EntityManager();

                return _entity;
            }
        }

        private static DataManager _data;
        public static DataManager Data
        {
            get
            {
                if (_data is null)
                    _data = new DataManager();

                return _data;
            }
        }
    }
}
