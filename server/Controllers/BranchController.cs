using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DTOs.Branch;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly HmsdbContext _context;
        public BranchController(HmsdbContext context)
        {
            _context = context;
        }


        [HttpGet("GetAll",Name ="GetAllBranches")]
        public ActionResult<IEnumerable<BranchDto>> GetAll()
        {
            var branches = _context.DbBranch.Select(x => new BranchDto
            {
                BranchId = x.BranchId,
                BranchName = x.BranchName,
                BranchCity = x.BranchCity,
                BranchAddress = x.BranchAddress,

            });

            if (branches == null || !branches.Any())
            {
                return NoContent();
            }

            return Ok(branches);
        }


        [HttpGet("{id:int}",Name ="GetBranchById")]
        public ActionResult<BranchDto> GetByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var foundBranch = _context.DbBranch.FirstOrDefault(x => x.BranchId == id);

            if (foundBranch == null)
                return NotFound("Branch not found.");

            return Ok(new BranchDto
            {
                BranchId = foundBranch.BranchId,
                BranchName = foundBranch.BranchName,
                BranchCity = foundBranch.BranchCity,
                BranchAddress = foundBranch.BranchAddress,
            });
                
        }


        [HttpPost(Name ="CreateBranch")]
        public ActionResult<BranchDto> Create(BranchDto entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newbranch = new Branch()
            {
                BranchName = entity.BranchName,
                BranchCity = entity.BranchCity,
                BranchAddress = entity.BranchAddress,
            };
            _context.DbBranch.Add(newbranch);
            _context.SaveChanges();
            entity.BranchId = newbranch.BranchId;
            return Ok(entity);
        }
        #region
        
        [HttpPut("{id:int}",Name ="UpdateBranchById")]
        public ActionResult Update(BranchDto entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var foundBranch = _context.DbBranch.FirstOrDefault(x=>x.BranchId == entity.BranchId);

            if (foundBranch == null)
            {
                return NotFound();
            }

            foundBranch.BranchName = entity.BranchName;
            foundBranch.BranchCity = entity.BranchCity;
            foundBranch.BranchAddress = entity.BranchAddress;

            //_context.DbBranch.Entry(foundBranch).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok("Branch updated Successfully.");
        }
        #endregion

        [HttpDelete("{id:int}",Name ="DeleteBranchByID")]
        public ActionResult DeleteByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var foundBranch = _context.DbBranch.FirstOrDefault(x=>x.BranchId == id);
            if (foundBranch == null) return NotFound("No Branch Found");
            _context.DbBranch.Remove(foundBranch);
            _context.SaveChanges();
            return Ok("Branch deleted successfully");

        }
    }
}
