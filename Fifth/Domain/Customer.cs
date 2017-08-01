using System;
using Fifth.Extensions;

namespace Fifth.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }

        public string SqlValuesString()
        {
            return $"\'{this.FirstName}, \'{this.Surname}, \'{this.BirthDate.ToDbDate()}, \'{this.Phone}, \'{this.EMail}";
        }

        public static string SqlKeysString()
        {
            return "FirstName, Surname, BirthDate, Phone, [E-Mail]";
        }

        public string SqlUpdateString()
        {
            return $"UPDATE Customers " +
                   $"SET Surname=\'{Surname}, FirstName=\'{FirstName}, BirthDate=\'{BirthDate.ToDbDate()}, Phone=\'{Phone}, [E-Mail]=\'{EMail} " +
                   $"WHERE Id={Id};";
        }
    }
}
