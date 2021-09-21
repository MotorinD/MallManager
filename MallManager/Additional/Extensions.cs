using MallManager.DAL.Entities;
using MallManager.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;

namespace MallManager.Additional
{
    /// <summary>
    /// Обслуживающий класс с методами расширения
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Привести содерджимое DataTable к списку указанного типа.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable table)
            where T : BaseEntity, new()
        {
            var properties = typeof(T).GetProperties().ToList();
            var result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        /// <summary>
        /// Сформировать объект указанного типа на основе данных из DataRow
        /// </summary>
        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties = null)
            where T : BaseEntity, new()
        {
            if (properties is null)
                properties = typeof(T).GetProperties().ToList();

            var item = new T();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(System.DayOfWeek))
                {
                    var day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                    property.SetValue(item, day, null);
                }
                else
                {
                    if (row[property.Name] == DBNull.Value)
                        property.SetValue(item, null, null);
                    else
                        property.SetValue(item, row[property.Name], null);
                }
            }
            return item;
        }

        /// <summary>
        /// Получить строковое представление описания для элемента перечисления (атрибут Description у enum)
        /// </summary>
        public static string GetDescription<T>(this T enumerationValue)
            where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                return "";
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }

        /// <summary>
        /// Сформировать список моделей описание-значение на основе указанного перечисления
        /// </summary>
        public static List<EnumModel> GetEnumValuesAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T is not System.Enum");

            var enumValList = new List<EnumModel>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumValList.Add(new EnumModel
                {
                    Name = (attributes.Length > 0) ? attributes[0].Description : e.ToString(),
                    Value = (int)e
                });
            }

            return enumValList;
        }
    }
}
