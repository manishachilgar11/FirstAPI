using FirstAPI.Model;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace FirstAPI.Repository
{
    public class StuRepo : IstuRepo
    {
        private string _connectionString;
        public StuRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        }
    public IEnumerable<Student12> GetMethod()
        {
            SqlConnection con = new Sqlconnection(_connectionString);
            con.open();
            string query = "Select*from Student12";
            Sql Command cmd = new Sql Command(query, con);
            Sql DataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Student12 stu = new Student12();
            }
        }
        public void AddStudent12(Student12 student12)
        {

        }
        public void DeleteStudent12(int id)
        {

        }


    }