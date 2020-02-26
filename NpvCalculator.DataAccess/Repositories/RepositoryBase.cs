using System;
using System.Collections.Generic;
using System.Text;
using NpvCalculator.DataAccess.Entities;
using SQLite;

namespace NpvCalculator.DataAccess.Repositories
{
    public class RepositoryBase<T> where T: class
    {
        public SQLiteConnection GetSQLiteConnection()
        {
            var dbPath = Environment.CurrentDirectory + @"\NpvDb.db";
            var sQLiteConnection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            return sQLiteConnection;
        }
    }
}
