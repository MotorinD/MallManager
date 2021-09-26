using System;
using System.Configuration;

namespace MallManager.Managers
{
    /// <summary>
    /// Менеджер доступа к данным конфигурационного файла
    /// </summary>
    public class AppConfigManager
    {
        public string GetDBConnectionString()
        {
            try
            {
                return Properties.Settings.Default.ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Trying Read ConnectionString from AppConfig", ex);
            }
        }
    }
}
