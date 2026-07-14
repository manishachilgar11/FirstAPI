using FirstAPI.Model;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

namespace FirstAPI.Repository
{
    public interface IstuRepo
    {
        IEnumerable<Student12> GetMethod();
        Student12 GetById(int id);

        void AddStudent1(Student12 student1);

        void UpdateStudent1(Student12 student1);

        void DeleteStudent1(int id);

    }
}
