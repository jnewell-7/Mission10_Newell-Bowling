using BowlingLeague.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlingLeagueController : ControllerBase
    {
        private readonly BowlingDbContext _bowlingContext;
        
        public BowlingLeagueController(BowlingDbContext temp)
        {
            _bowlingContext = temp;
        }
        
        [HttpGet(Name = "GetBowlingLeague")]
        public async Task<ActionResult<IEnumerable<Bowling>>> Get()
        {
            var bowlingList = await _bowlingContext.Bowlers
                .Include(b => b.Team) 
                .Where(b => b.Team != null && 
                            (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")) // ✅ Filters Marlins & Sharks
                .ToListAsync();

            return Ok(bowlingList);
        }
    }
}