using Newtonsoft.Json.Linq;

namespace Fifth.Domain
{
    public class Customer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public string birthDate { get; set; }
        public string phone { get; set; }
        public string eMail { get; set; }

        public Customer(int id, string firstName, string surname, string birthDate, string phone, string eMail)
        {
            this.id = id;
            this.firstName = firstName;
            this.surname = surname;
            this.birthDate = birthDate;
            this.phone = phone;
            this.eMail = eMail;
        }

        public Customer()
        {

        }

        public Customer(JToken jsonData)
        {
            this.firstName = (string)jsonData["firstName"];
            this.surname = (string)jsonData["surname"];
            this.birthDate = (string)jsonData["birthDate"];
            this.phone = (string)jsonData["phone"];
            this.eMail = (string)jsonData["eMail"];
        }
    }
}
