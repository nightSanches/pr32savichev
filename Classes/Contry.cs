using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace savichev32pr.Classes
{
    public class Contry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static IEnumerable<Contry> AllCountries()
        {
            List<Contry> countries = new List<Contry>();
            DataTable request = DBConnection.Connection("SELECT * FROM [dbo].[Country]");
            foreach (DataRow row in request.Rows)
            {
                countries.Add(new Contry()
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = row[1].ToString()
                });
            }
            return countries;
        }
    }
}
