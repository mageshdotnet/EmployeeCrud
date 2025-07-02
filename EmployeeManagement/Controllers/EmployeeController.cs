using EmployeeManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeController( ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //Create Employee
        [HttpPost]
        public IActionResult CreateEmployee([FromBody]Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return Ok();
        }

        //Update Employee
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Get All Employee
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var employee = _dbContext.Employees.ToList();
            return Ok(employee);
        }


        //Get Employee By Id
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            if(id <=0)
            {
                return BadRequest("Invalid Id");
            }

            var emp = _dbContext.Employees.FirstOrDefault(x =>x.EmpId == id);

            if(id ==null)
            {
                return NotFound($"No EmpId found ID{id}");
            }
            return Ok(emp);
        }

      
        //Delete Employee
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            if(id ==0)
            {
                return BadRequest();
            }
            var emp = _dbContext.Employees.FirstOrDefault(x => x.EmpId == id);
            if(emp == null)
            {
                return NotFound($"Employee ID not found -{id}");
            }
            _dbContext.Employees.Remove(emp);
            _dbContext.SaveChanges();
            return NoContent();

        }
    }
}
