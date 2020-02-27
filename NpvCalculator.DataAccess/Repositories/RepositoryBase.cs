using System;
using System.Collections.Generic;
using System.Text;
using NpvCalculator.DataAccess.Entities;
using SQLite;

namespace NpvCalculator.DataAccess.Repositories
{
    public class RepositoryBase<T> where T: class
    {

        public static string ConnectionString => Environment.CurrentDirectory + @"\NpvCalculator.sqlite";
        public static SQLiteAsyncConnection GetSQLiteConnection()
        {
            var sqlLiteConnection = new SQLiteConnectionString(ConnectionString);
            return new SQLiteAsyncConnection(sqlLiteConnection);
        }
    }
}
