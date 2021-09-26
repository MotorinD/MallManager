using System;
using System.ComponentModel;
using System.Globalization;

namespace MallManager.Enums
{
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter(Type type) : base(type) { }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value != null)
                {
                    var fi = value.GetType().GetField(value.ToString());
                    if (fi != null)
                    {
                        var attribute = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                        return attribute.Length > 0 && !string.IsNullOrEmpty(attribute[0].Description) ? attribute[0].Description : value.ToString();
                    }
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }


    }
}
