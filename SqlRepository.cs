using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudlackova_test_12._12
{
    class SqlRepository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Zamestnanci;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Vypis> GetVypis()
        {
            List<Vypis> vypis = new List<Vypis>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "SELECT * FROM Zamestnanci";
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            var vypisy = new Vypis()
                            {
                                Id = Convert.ToInt32(sqlDataReader["Id"]),
                                FirstName = Convert.ToString(sqlDataReader["FirstName"]),
                                LastName = Convert.ToString(sqlDataReader["LastName"]),
                                BirthDate = Convert.ToDateTime(sqlDataReader["BirthDate"]),
                                Phone = Convert.ToString(sqlDataReader["Phone"]),
                                Email = Convert.ToString(sqlDataReader["Email"]),

                            };
                            vypis.Add(vypisy);
                        }
                    }
                }
                sqlConnection.Close();
            }
            return vypis;
        }
    }
}
