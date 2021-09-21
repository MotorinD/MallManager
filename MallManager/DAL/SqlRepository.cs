using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using MallManager.Managers;
using MallManager.Interfaces;
using System.Data;
using System.ComponentModel.DataAnnotations;
using MallManager.DAL.Entities;
using System.Reflection;
using MallManager.Additional;

namespace MallManager.DAL
{
    /// <summary>
    /// Универсальный класс для предоставлению доступа к данным указанного типа в БД SQL Server
    /// </summary>
    public class SqlRepository<TEntity> : IBaseRepository<TEntity> 
        where TEntity : BaseEntity, new()
    {
        private SqlConnection _sqlConnection => (SqlConnection)ManagerHelper.DBConnection.GetConnection();

        /// <summary>
        /// Получить весь список сущностей
        /// </summary>
        public List<TEntity> GetList()
        {
            var entityName = typeof(TEntity).Name;
            var sqlCommandText = $"SELECT * FROM {entityName}";

            var cmd = new SqlCommand(sqlCommandText, this._sqlConnection);
            var adapter = new SqlDataAdapter(cmd);
            var ds = new DataSet();

            this.ExecuteActionAndCloseConnection(() => adapter.Fill(ds));

            var res = ds.Tables[0].ToList<TEntity>();

            return res;
        }

        /// <summary>
        /// Получить один объект сущности по идентификатору
        /// </summary>
        /// <param name="id"></param>
        public TEntity Get(int id)
        {
            var entityName = typeof(TEntity).Name;
            var sqlCommandText = $"SELECT * FROM {entityName} where Id = {id}";

            var cmd = new SqlCommand(sqlCommandText, this._sqlConnection);
            var adapter = new SqlDataAdapter(cmd);
            var ds = new DataSet();

            this.ExecuteActionAndCloseConnection(() => adapter.Fill(ds));

            var res = ds.Tables[0].ToList<TEntity>().FirstOrDefault();

            return res;
        }

        /// <summary>
        /// Добавить новую сущность
        /// </summary>
        public void Add(TEntity entity)
        {
            var entityName = typeof(TEntity).Name;
            var propertyesArr = typeof(TEntity).GetProperties();

            var sqlParamNameList = new List<string>();
            var sqlValueNameList = new List<string>();

            foreach (var property in propertyesArr)
            {
                //в бд для всех сущностей автоинкремент, не указываем первичный ключ
                if (Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) is KeyAttribute)
                    continue;

                sqlParamNameList.Add(property.Name);
                sqlValueNameList.Add($"@{property.Name}");
            }

            var sqlParamNameString = string.Join(',', sqlParamNameList);
            var sqlValueNameString = string.Join(',', sqlValueNameList);

            var sqlCommandText = $"INSERT INTO {entityName} ({sqlParamNameString}) values ({sqlValueNameString})";
            var cmd = new SqlCommand(sqlCommandText, this._sqlConnection);

            this.AddParametersToSqlCommand(entity, propertyesArr, cmd);
            this.ExecuteActionAndCloseConnection(() => cmd.ExecuteNonQuery());
        }

        /// <summary>
        /// Редактировать сущность
        /// </summary>
        public void Edit(TEntity entity)
        {
            var entityName = typeof(TEntity).Name;
            var propertyesArr = typeof(TEntity).GetProperties();

            var sqlParamWithValueNameList = new List<string>();

            PropertyInfo keyProp = null;
            foreach (var property in propertyesArr)
            {
                if (Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) is KeyAttribute)
                {
                    keyProp = property;
                    continue;
                }

                sqlParamWithValueNameList.Add($"{property.Name} = @{property.Name}");
            }

            var sqlParamWithValueNameString = string.Join(", ", sqlParamWithValueNameList);
            var sqlCommandText = $"UPDATE {entityName} Set {sqlParamWithValueNameString} where {keyProp.Name} = @{keyProp.Name}";
            var cmd = new SqlCommand(sqlCommandText, this._sqlConnection);

            this.AddParametersToSqlCommand(entity, propertyesArr, cmd);
            this.ExecuteActionAndCloseConnection(() => cmd.ExecuteNonQuery());
        }

        /// <summary>
        /// Удалить сущность по идентификатору
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var entityName = typeof(TEntity).Name;
            var cmd = new SqlCommand($"Delete from {entityName} where Id = @Id", this._sqlConnection);

            cmd.Parameters.AddWithValue("@Id", id);
            this.ExecuteActionAndCloseConnection(() => cmd.ExecuteNonQuery());
        }

        private void AddParametersToSqlCommand(TEntity entity, PropertyInfo[] propertyesArr, SqlCommand cmd)
        {
            for (int i = 0; i < propertyesArr.Length; i++)
            {
                var property = entity.GetType().GetProperty(propertyesArr[i].Name);

                if (property is null)
                    cmd.Parameters.AddWithValue($"@{propertyesArr[i].Name}", System.DBNull.Value);
                else
                    cmd.Parameters.AddWithValue($"@{propertyesArr[i].Name}", property.GetValue(entity));
            }
        }

        private void ExecuteActionAndCloseConnection(Action action)
        {
            try
            {
                this._sqlConnection.Open();
                action();
            }
            finally
            {
                this._sqlConnection.Close();
            }
        }
    }
}
