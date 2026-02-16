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

        [HttpGet("GetAll", Name = "GetAllDoctors")]
        public ActionResult<Response<DoctorDto>> GetAll()
        {
            var doctors = _context.DbDoctor.Select(x =>
            new DoctorDto
            {
                DocId = x.DocId,
                DocName = x.DocName,
                DocPhone = x.DocPhone,
                DocSpecialization = x.DocSpecialization,
            });
            if (doctors == null || !doctors.Any())
            {
                return Ok(new Response<object>
                {
                    Code = 200,
                    Success = true,
                    Message = "Doctors not  found.",
                    Data = null,
                    Pagination = null,

                });
            }
            var res = new Response<object>
            {
                Code = 200,
                Success = true,
                Message = "All doctors data fetched successfully.",
                Data = new { resultSet = doctors },
                Pagination = null
            };
            return Ok(res);
        }

        [HttpGet("{id:int}", Name = "GetDoctorById")]
        public ActionResult<Response<DoctorDto>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var foundDoctor = _context.DbDoctor.FirstOrDefault(x => x.DocId == id);

            if (foundDoctor == null)
            {
                return NotFound(new Response<object>
                {
                    Code = 404,
                    Success = false,
                    Message = "Doctor not found",
                    Data = null,
                    Pagination = null
                });
            }
            var doctorDto = new DoctorDto
            {
                DocId = foundDoctor.DocId,
                DocName = foundDoctor.DocName,
                DocPhone = foundDoctor.DocPhone,
                DocSpecialization = foundDoctor.DocSpecialization,
            };
            return Ok(new Response<object>
            {
                Code = 200,
                Success = true,
                Message = "Doctor Data fetched by id successfully.",
                Data = new { resultSet = doctorDto },
                Pagination = null
            });
        }
        [HttpPost(Name = "CreateDoctor")]
        public ActionResult<Response<DoctorDto>> Create([FromBody] DoctorDto entity)
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

            var doctorDto = new DoctorDto
            {
                DocId = newDoctor.DocId,
                DocName = newDoctor.DocName,
                DocPhone = newDoctor.DocPhone,
                DocSpecialization = newDoctor.DocSpecialization
            };

            return Ok(new Response<object>
            {
                Code = 201,
                Success = true,
                Message = "User created Sucessfully.",
                Data = new { resultSet = doctorDto },
                Pagination = null
            });
        }

        [HttpPut("{id:int}", Name = "UpdateDoctorById")]
        public ActionResult<Response<DoctorDto>> Update([FromBody] DoctorDto entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var foundDoctor = _context.DbDoctor.FirstOrDefault(x => x.DocId == entity.DocId);
            if (foundDoctor == null)
            {
                return NotFound(new Response<object>
                {
                    Code = 404,
                    Success = true,
                    Message = "Doctor not found.",
                    Data = null,
                    Pagination = null,

                });
            }
            foundDoctor.DocName = entity.DocName;
            foundDoctor.DocPhone = entity.DocPhone;
            foundDoctor.DocSpecialization = entity.DocSpecialization;
            _context.SaveChanges();

            var updatedDoctorDto = new DoctorDto
            {
                DocId = foundDoctor.DocId,
                DocName = foundDoctor.DocName,
                DocPhone = foundDoctor.DocPhone,
                DocSpecialization = foundDoctor.DocSpecialization
            };
            return Ok(new Response<object>
            {
                Code = 200,
                Success = true,
                Message = "Doctor updated successfully.",
                Data = new { resultSet = updatedDoctorDto },
                Pagination = null,

            });

        }

        [HttpDelete("{id:int}", Name = "DeleteDoctorById")]
        public ActionResult<Response<DoctorDto>> DeleteById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var foundDoctor = _context.DbDoctor.FirstOrDefault(x => x.DocId == id);
            if (foundDoctor == null)
            {
                return NotFound(new Response<object>
                {
                    Code = 404,
                    Success = false,
                    Message = "Doctor not found.",
                    Data = null,
                    Pagination = null

                });
            }
            _context.DbDoctor.Remove(foundDoctor);
            _context.SaveChanges();
            var doctorDto = new DoctorDto
            {
                DocId = foundDoctor.DocId,
                DocName = foundDoctor.DocName,
                DocPhone = foundDoctor.DocPhone,
                DocSpecialization = foundDoctor.DocSpecialization
            };
            return Ok(new Response<object>
            {
                Code = 200,
                Success = true,
                Message = "Doctor Deleted Successfully.",
                Data = new { resultSet = doctorDto },
                Pagination = null

            });
        }

    }
}
