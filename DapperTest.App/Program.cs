using System;
using DapperTest.DB_Lib;

namespace DapperTest.App
{
    internal static class Program
    {
        private static void Main()
        {
            var db = new DbPerson();
            foreach (var person in db.GetAllPersons())
            {
                Console.WriteLine($"{person.Id}: {person.Name}, {person.IsActive}");
            }

            foreach (var person in db.GetTable("table_persons"))
            {
                Console.WriteLine($"{person.id}: {person.name}, {person.is_active}");
            }
        }
    }
}