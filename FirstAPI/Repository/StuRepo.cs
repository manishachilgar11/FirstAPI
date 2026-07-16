using FirstAPI.Model;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Data.SqlClient;

namespace FirstAPI.Repository
{
   
    public class StuRepo : IstuRepo
    {
        private String _connectionString;

        public StuRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IEnumerable<Student12> GetMethod()
        {
            List<Student12> students = new List<Student12>();
            SqlConnection con=new SqlConnection(_connectionString);
            string query = "Select*from Student12";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Student12 student = new Student12()
                {
                    Student_id = Convert.ToInt32(reader["ID"]),
                    Student_name = reader["Student_Name"].ToString(),
                    location = reader["location"].ToString(),
                    ISActive = Convert.ToBoolean(reader["ISActive"]),
                    Email_Id = reader["Email_Id"].ToString(),
                    Fees = Convert.ToInt32(reader["Fees"])
                };
                students.Add(student);
            }
            con.Close();
            return students;
        }
        public Student12 GetById(int id)
        {
            Student12 students = null;
            SqlConnection con = new SqlConnection(_connectionString);
            String query = "Select*From Student12 Where Id=@id";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Student12 stu = new Student12()
                {
                    Student_id = Convert.ToInt32(reader["ID"]),
                    Student_name = reader["Student_Name"].ToString(),
                    location = reader["location"].ToString(),
                    ISActive = Convert.ToBoolean(reader["ISActive"]),
                    Email_Id = reader["Email_Id"].ToString(),
                    Fees = Convert.ToInt32(reader["Fees"])
                };
                students = stu;
            }
            con.Close();
            return students;
        }
        public void AddStudent1(Student12 student1)
        {
            SqlConnection con = new SqlConnection(_connectionString);
           String query = "Insert into Student12(Student_id,Student_Name,location,ISActive,Email_Id,Fees)"
             + "Values(@Student_id,@Student_Name,@location,@Email_Id,@Fees)";
            con.Open();
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Student_id", student1.Student_id);
            cmd.Parameters.AddWithValue("@Student_Name",student1.Student_name);
            cmd.Parameters.AddWithValue("@location", student1.location);
            cmd.Parameters.AddWithValue("@ISActive", student1.ISActive);
            cmd.Parameters.AddWithValue("@Emai_Id", student1.Email_Id);
            cmd.Parameters.AddWithValue("@Fees",student1.Fees);
            cmd.ExecuteNonQuery();
            con.Close();
        }
         public void UpdateStudent1(Student12 student1)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            string query = "Update Student12 Set Student_Name=@Student_Name,"
            + "location=@location,ISActive=@ISActive,Email_Id=@Email_Id,Fees=@Fees Where Student_id=@Student_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Student_id", student1.Student_id);
            cmd.Parameters.AddWithValue("@Student_Name", student1.Student_name);
            cmd.Parameters.AddWithValue("@location", student1.location);
            cmd.Parameters.AddWithValue("@ISActive", student1.ISActive);
            cmd.Parameters.AddWithValue("@Emai_Id", student1.Email_Id);
            cmd.Parameters.AddWithValue("@Fees", student1.Fees);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteStudent1(int id)
        {


        }
    }
}