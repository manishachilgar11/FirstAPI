using FirstAPI.Model;
using FirstAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IstuRepo _repo;

      public StudentController(IstuRepo repo)
        {
            _repo=repo;
        }
 
        [HttpGet]
        public IActionResult GetMethod()
        {
            var data = _repo.GetMethod();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var data = _repo.GetById(id);
                if(data==null)
                {
                    return NotFound();
                }
            return Ok(data);
            }
        
        [HttpPost]
        public IActionResult AddStudent1(Student12 student1)
        {
            _repo.AddStudent1(student1);
            return Ok("Student Added successfully.");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent1(int id,Student12 student1)
        {
            _repo.UpdateStudent1(student1);
            return Ok("Student1 created Sucessfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent1(int id)
        {
            _repo.DeleteStudent1(id);
            return Ok("Product deleted Sucessfully");
        }

    }
    
}
