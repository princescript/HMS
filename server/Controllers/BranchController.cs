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
        

        [HttpGet("GetAll", Name = "Get All Data Api")]
        public ActionResult<IEnumerable<BranchDto>> GetAllBranch()
        {
            var branches = _context.DbBranch.Select(x => new BranchDto
            {
                BranchId = x.BranchId,
                BranchName = x.BranchName,
                BranchCity = x.BranchCity,
                BranchAddress = x.BranchAddress,

            });

            if (branches == null)
            {
                return NoContent();
            }
            return Ok(branches);
        }


        [HttpGet("{id:int}",Name ="Get Branch by Id")]
        public ActionResult<BranchDto> GetBranchByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var branch = _context.DbBranch.FirstOrDefault(x => x.BranchId == id);

            if (branch == null)
                return NotFound("Branch not found.");

            return Ok(new BranchDto
            {
                BranchId = branch.BranchId,
                BranchName = branch.BranchName,
                BranchCity = branch.BranchCity,
                BranchAddress = branch.BranchAddress,
            });
                
        }


        [HttpPost("Create")]
        public ActionResult<BranchDto> CreateBranch(BranchDto entity)
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
        
        [HttpPut("{id:int}")]
        public ActionResult UpdateBranch(BranchDto entity)
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
            return Ok();
        }
        #endregion

        [HttpDelete("{id:int}",Name ="Delete By ID")]
        public ActionResult DeleteByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var branch = _context.DbBranch.FirstOrDefault(x=>x.BranchId == id);
            if (branch == null) return NotFound("No Branch Found");
            _context.DbBranch.Remove(branch);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
