using Microsoft.AspNetCore.Mvc;
using server.DTOs.Department;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly HmsdbContext _context;
        public DepartmentController(HmsdbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll", Name ="GetAllDepartments")]
        public ActionResult<IEnumerable<DepartmentDto>> GetAll()
        {

            var departments = _context.DbDepartment.Select(x => new DepartmentDto
            {
                DepartId = x.DepartId,
                DepartName = x.DepartName,
                DepartDescription = x.DepartDescription,
            }).ToList();

            if(departments == null ||  !departments.Any())
            {
                return NoContent();
            }
            return Ok(departments);                    
        }

        [HttpGet("{id:int}", Name = "GetDepartmentById")]
        public ActionResult<DepartmentDto> GetByID(int id) 
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var foundDepartment = _context.DbDepartment.FirstOrDefault(x => x.DepartId == id); 

            if(foundDepartment == null)
            {
                return NotFound("Department not Found.");
            }
            return Ok(new DepartmentDto
            {
                DepartId = foundDepartment.DepartId,
                DepartName = foundDepartment.DepartName,
                DepartDescription = foundDepartment.DepartDescription
            });
        }

        [HttpPost(Name="CreateDepartment")]
        public ActionResult<DepartmentDto> Create([FromBody] DepartmentDto entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newDepartment = new Department
            {
                DepartName = entity.DepartName,
                DepartDescription = entity.DepartDescription
            };
            _context.DbDepartment.Add(newDepartment);
            _context.SaveChanges();
            entity.DepartId = newDepartment.DepartId;
            return Ok(entity);
        }
        [HttpPut("{id:int}", Name = "UpdateDepartmentById")]
        public ActionResult Update([FromBody] DepartmentDto entity) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var foundDepartment = _context.DbDepartment.FirstOrDefault(x=>x.DepartId==entity.DepartId);
            if (foundDepartment == null) 
            {
                return NotFound("Department not found.");
            }
            foundDepartment.DepartName = entity.DepartName;
            foundDepartment.DepartDescription =entity.DepartDescription;
            _context.SaveChanges();
            return Ok("Department updated Successfully.");

        
        }
   
        [HttpDelete("{id:int}", Name = "DeleteDepartmentById")]
        public ActionResult DeleteByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var foundDepartment = _context.DbDepartment.FirstOrDefault(x => x.DepartId == id);

            if (foundDepartment == null)
            {
                return NotFound("Department not Found");
            }
            _context.DbDepartment.Remove(foundDepartment);
            _context.SaveChanges();
            return Ok("Department deleted Sucessfully.");
        }

    }
}
