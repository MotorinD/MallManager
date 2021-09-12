using System;
using System.Configuration;

namespace MallManager.Managers
{
    public class AppConfigManager
    {
        public string GetDBConnectionString()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["MallManager.Properties.Settings.MallManagerDbConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Trying Read ConnectionString from AppConfig", ex);
            }
        }
    }
}
