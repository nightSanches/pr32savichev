﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace savichev32pr.Classes
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public static IEnumerable<Manufacturer> AllManufacrurers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            DataTable recordQuery = Classes.DBConnection.Connection("SELECT * FROM [dbo].[Manufacturer]");
            foreach(DataRow row in recordQuery.Rows)
            {
                manufacturers.Add(new Manufacturer()
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = row[1].ToString(),
                    CountryCode = Convert.ToInt32(row[2]),
                    Phone = row[3].ToString(),
                    Mail = row[4].ToString()
                });
            }
            return manufacturers;
        }

        public void Save(bool Update = false)
        {
            if(Update == false)
            {
                Classes.DBConnection.Connection("INSERT INTO [dbo].[Manufacturer]([Name], [CountryCode], [Phone], [Mail]) " +
                    $"VALUES (N'{this.Name}'), '{this.CountryCode}', '{this.Phone}', '{this.Mail}')");

                this.Id = Manufacturer.AllManufacrurers().Where(
                    x => x.Name == this.Name &&
                    x.CountryCode == this.CountryCode &&
                    x.Phone == this.Phone &&
                    x.Mail == this.Mail).First().Id;
                    
            }
        }

        public void Delete() =>
            Classes.DBConnection.Connection($"DELETE FROM [dbo].[Manufacturer] WHERE [Id] = {this.Id}");
    }
}
