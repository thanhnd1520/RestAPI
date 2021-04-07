using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MS_3_NDTHANH.Data
{
    public class DatabaseConnector
    {
        //public static string connectionString;
        string connectionString = "User Id=nvmanh; Host=103.124.92.43;  port = 3306;  password=12345678;  Database=MS3_8_NDThanh_CukCuk;  Character Set=utf8";
        IDbConnection _dbConnection;

        public DatabaseConnector()
        {
            _dbConnection = new MySqlConnection(connectionString);
        }
        public IEnumerable<T> get<T>()
        {
            string className = typeof(T).Name;
            var sql = $"Select * From {className} LIMIT 10";
            var entity = _dbConnection.Query<T>(sql).ToList();
            return entity;
        }
        public T getById<T>(object id)
        {
            string className = typeof(T).Name;
            var sql = $"Select * From {className} Where {className}Id = '{id.ToString()}'";
            var entity = _dbConnection.Query<T>(sql).FirstOrDefault();
            return entity;
        }

        public int insert<T>(T t)
        {
            string className = typeof(T).Name;
            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();
            var storName = $"Proc_Insert{className}";
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(t);
                if (propertyName.Equals("CustomerGroupId"))
                    propertyValue = property.GetValue(t).ToString();
                parameters.Add($"@{propertyName}", propertyValue);
            }

            var effectRows = _dbConnection.Execute(storName,parameters,commandType: CommandType.StoredProcedure);
            return effectRows;
        }
        public int deleteById<T>(Guid Id)
        {
            string className = typeof(T).Name;
            var storName = $"Proc_Delete{className}";
            var sql = $"DELETE FROM {className} WHERE {className}Id = '{Id.ToString()}'";
            //var effectRows = _dbConnection.Execute(storName, Id.ToString(), commandType: CommandType.StoredProcedure);
            var effectRows = _dbConnection.Execute(sql);
            return effectRows;
        }

        public void updateById<T>(Guid Id)
        {
            
        }
    }
}
