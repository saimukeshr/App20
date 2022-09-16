using App20.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App20.Helpers
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            //Establishing the conection
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Details>().Wait();
           
        }

        // Show the registers
        public Task<List<Details>> GetorderDetailsAsync()
        {
            return _database.Table<Details>().ToListAsync();
        }

        // Save registers
        public Task<int> SaveOrderDetailsAsync(Details detail)
        {
            return _database.InsertAsync(detail);
        }

        // Delete registers
        public Task<int> DeleteOrderDetailsAsync(Details detail)
        {
            return _database.DeleteAsync(detail);
        }

        // Save registers
        public Task<int> UpdateOrderDetailsAsync(Details detail)
        {
            return _database.UpdateAsync(detail);
        }

    }

}
