namespace MallManager.Managers
{
    /// <summary>
    /// Обслуживающий класс для доступа к различным менеджерам/сервисам приложения
    /// </summary>
    public static class ManagerHelper
    {
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

        private static LocalizationManager _localization;
        public static LocalizationManager Localization
        {
            get
            {
                if (_localization is null)
                    _localization = new LocalizationManager();

                return _localization;
            }
        }

        private static MapperManager _mapper;
        public static MapperManager Mapper
        {
            get
            {
                if (_mapper is null)
                    _mapper = new MapperManager();

                return _mapper;
            }
        }
    }
}
