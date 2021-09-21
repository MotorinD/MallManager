using System.Windows.Forms;

namespace MallManager.Forms
{
    /// <summary>
    /// Обслуживающий класс для валидации контролов
    /// </summary>
    public static class ControlValidation
    {
        /// <summary>
        /// Проверка введенного значения в TextBox на наличие и соответствие типу Decimal с выставлением предупреждений
        /// </summary>
        public static bool CheckControlTextIsExistAndDecimal(TextBoxBase textBoxBaseControl,ErrorProvider errorProvider)
        {
            if (string.IsNullOrWhiteSpace(textBoxBaseControl.Text))
            {
                errorProvider.SetError(textBoxBaseControl, "Введите значение");
                return false;
            }
            else
            {
                if (!decimal.TryParse(textBoxBaseControl.Text, out _))
                {
                    errorProvider.SetError(textBoxBaseControl, "Значение должно быть числом");
                    return false;
                }
            }

            return true;
        }
    }
}
