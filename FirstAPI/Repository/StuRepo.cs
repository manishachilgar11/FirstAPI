using FirstAPI.Model;
using FirstAPI.Model;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Data.SqlClient;

namespace FirstAPI.Repository
{
    public class StuRepo : IstuRepo
    {
        private String _connectionString;

        public StuRepo(IConfiguration configuratation)
        {
            _connectionString = configuratation.GetConnectionString("DefaultConnection");
        }
        public IEnumerable<Student12> GetMethod()
        {
            //Ado.net Code
            List<Student12> student12 = new List<Student12>();
            SqlConnection con=new SqlConnection();
            String query = "Select*From Student12";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Student12 stu = new Student12()
                {
                    Student_id = Convert.ToInt32(reader["id"]),
                    Student_name = reader["Name"].ToString(),
                    location = reader["location"].ToString(),
                    ISActive = Convert.ToBoolean(reader["IsActive"]),
                    Email_Id = reader["Email_Id"].ToString(),
                    Fees = Convert.ToInt32(reader["Fees"])
                 //DefaultConnection
                };
                //Select*From Student12
                student12.Add(stu);
            }
            return student12;
        }
        public Student12 GetById(int id)
        {
            Student12 stu = null;
            SqlConnection con = new SqlConnection(_connectionString);
            String query = "Select*from student12 where ID=@id";
            con.Open() ;
            SqlCommand cmd=new SqlCommand(query, con);
            SqlDataReader reader=cmd.ExecuteReader();
            if(reader.Read())
            {
                Student12 student = new Student12()
                {
                    Student_id= Convert.ToInt32(reader["id"]),
                    Student_name = reader["Name"].ToString(),
                    location = reader["location"].ToString(),
                    Email_Id = reader["Emaili_id"].ToString(),
                    Fees = Convert.ToInt32(reader["Fees"]),
                };
            }
         }
        public void AddStudent1(Student12 student1)
        {

           
        }

        public void DeleteStudent1(int id)
        {

        }
        public void UpdateStudent1(Student12 student1)
        {
            
        }
    }
}