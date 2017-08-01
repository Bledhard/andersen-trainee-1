using System;
using AndersenTrainee1.Extensions;

namespace AndersenTrainee1.Domain
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
                   $"SET Surname=\'{this.Surname}, FirstName=\'{this.FirstName}, BirthDate=\'{this.BirthDate.ToDbDate()}, Phone=\'{this.Phone}, [E-Mail]=\'{this.EMail} " +
                   $"WHERE Id={Id};";
        }
    }
}