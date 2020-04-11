using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio
{
    class DataAcces
    {
        public List<Person> GetPeople(string item)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("SampleDB")))
            {
                var output = connection.Query<Person>("dbo.portfolio_GetPeopleByInput  @input", new { input = item }).ToList();
                return output;
            }
        }
        public List<Person> GetALLPeople(string Firstname, string Lastname, string job, string phone, string email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("SampleDB")))
            {
                var output = connection.Query<Person>("dbo.poerfolio_GetPeopleByAllParams @FirstName, @LastName, @Job, @Phone, @Mail",
                    new { FirstName = Firstname, LastName = Lastname, Job = job, Phone = phone, Mail = email }).ToList();
                return output;
            }
        }
        public List<Person> ListAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("SampleDB")))
            {
                var output = connection.Query<Person>("dbo.poerfolio_GetEveryOne").ToList();
                return output;
            }
        }

        public void Insert(string firstName, string lastName, string Job, string phone, string email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("SampleDB")))
            {
                List<Person> people = new List<Person>();
                people.Add(new Person { Firstname = firstName, Lastname = lastName, Job = Job, Phone = phone, Email = email });
                connection.Execute("dbo.portfolio_Insert @FirstName, @LastName, @Job, @Phone, @Email  ", people);
            }
        }
    }
}
