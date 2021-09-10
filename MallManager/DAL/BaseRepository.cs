using System.Configuration;

namespace MallManager.DAL
{
    public class BaseRepository
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MallManager.Properties.Settings.MallManagerDbConnectionString"].ConnectionString;
            }
        }
    }
}
