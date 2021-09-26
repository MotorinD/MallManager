using System;
using System.Globalization;
using System.Threading;

namespace MallManager.Managers
{
    /// <summary>
    /// Менеджер, реализующий методы для поддержки многоязычности системы
    /// </summary>
    public class LocalizationManager
    {
        /// <summary>
        /// Выставить значение культуры соответствующее указанному в конфиге языку
        /// </summary>
        /// <exception cref="ArgumentNullException">В конфиге не указан используемый язык</exception>
        /// <exception cref="ArgumentOutOfRangeException">В конфиге указано некорректное значение используемого языка</exception>
        public void SetCultureFromSetting()
        {
            try
            {
                var languageName = Properties.Settings.Default.Language;
                this.SetCultureByLanguageName(languageName);
            }
            catch(ArgumentNullException ex)
            {
                //todo warning and logging
                throw;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //todo warning and logging
                throw;
            }

        }

        private void SetCultureByLanguageName(string languageName)
        {
            if (string.IsNullOrWhiteSpace(languageName))
                throw new ArgumentNullException(nameof(languageName));

            switch (languageName)
            {
                case string language when language.ToLower().Contains("ru"):
                    {
                        this.SetCulture("ru-RU");
                        break;
                    }

                case string language when language.ToLower().Contains("en"):
                    {
                        this.SetCulture("en-US");
                        break;
                    }

                default: throw new ArgumentOutOfRangeException(nameof(languageName), languageName, null);
            }
        }

        private void SetCulture(string cultureName)
        {
            var culture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
