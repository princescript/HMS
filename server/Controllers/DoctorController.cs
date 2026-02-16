using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.DTOs.Doctor;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly HmsdbContext _context;

        public DoctorController(HmsdbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll",Name ="GetAllDoctors")]
        public ActionResult<IEnumerable<DoctorDto>> GetAll()
        {
            var  doctors = _context.DbDoctor.Select(x =>
            new DoctorDto {
                DocId = x.DocId,
                DocName = x.DocName,
                DocPhone = x.DocPhone,
                DocSpecialization = x.DocSpecialization,
            });
            if (doctors == null||!doctors.Any())
            {
                return NoContent();
            }
            var res = new Response<object>
            {
                Code = 200,
                Sucess = true,
                Message = "no msg",
                Data = new {resultSet=doctors.ToList() },
                Pagination = null
            };
            return Ok(res);
        }

        [HttpGet("{id:int}", Name = "GetDoctorById")]
        public ActionResult<DoctorDto> GetById(int id) 
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            var foundDoctor = _context.DbDoctor.FirstOrDefault(x=>x.DocId == id);

            if(foundDoctor == null)
            {
                return NotFound("No doctor found.");
            }
            return Ok(new DoctorDto
            {
                DocId = foundDoctor.DocId,
                DocName = foundDoctor.DocName,
                DocPhone = foundDoctor.DocPhone,
                DocSpecialization = foundDoctor.DocSpecialization,
            });
        }
        [HttpPost(Name ="CreateDoctor")]
        public ActionResult<DoctorDto> Create([FromBody] DoctorDto entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newDoctor = new Doctor
            {
                DocName = entity.DocName,
                DocPhone = entity.DocPhone,
                DocSpecialization = entity.DocSpecialization,
            };
            _context.DbDoctor.Add(newDoctor);
            _context.SaveChanges();
            entity.DocId = newDoctor.DocId;
            return (entity);
        }

        [HttpPut("{id:int}", Name = "UpdateDoctorById")]
        public ActionResult Update([FromBody] DoctorDto entity)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var foundDoctor = _context.DbDoctor.FirstOrDefault(x => x.DocId == entity.DocId);
            if (foundDoctor == null)
            {
                return NotFound("No doctor found.");
            }
            foundDoctor.DocName = entity.DocName;
            foundDoctor.DocPhone = entity.DocPhone;
            foundDoctor.DocSpecialization = entity.DocSpecialization;
            _context.SaveChanges();
            return Ok("Doctor updated Successfully");
       
        }

        [HttpDelete("{id:int}",Name ="DeleteDoctorById")]
        public ActionResult DeleteById(int id )
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            var foundDoctor = _context.DbDoctor.FirstOrDefault(x=>x.DocId ==id);
            if(foundDoctor == null)
            {
                return NotFound("No doctor found");
            }
            _context.DbDoctor.Remove(foundDoctor);
            _context.SaveChanges();
            return Ok("Doctor deleted Sucessfully.");
        }

    }
}
