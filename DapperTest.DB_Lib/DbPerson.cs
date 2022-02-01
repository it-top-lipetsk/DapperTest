using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper;
using DapperTest.Model;
using MySql.Data.MySqlClient;

namespace DapperTest.DB_Lib
{
    public class DbPerson
    {
        private readonly string _str;
        
        public DbPerson()
        {
            _str = GetConnectionString("connection_to_db.txt");
        }

        private static string GetConnectionString(string path)
        {
            return File.ReadAllText(path);
        }

        public List<Person> GetAllPersons()
        {
            using var db = new MySqlConnection(_str);
            var sql = "SELECT * FROM table_persons";
            var persons = db.Query<Person>(sql);
            return persons.ToList();
        }

        public List<dynamic> GetTable(string table)
        {
            using var db = new MySqlConnection(_str);
            var sql = $"SELECT * FROM {table}";
            var persons = db.Query(sql);
            return persons.ToList();
        }
    }
}