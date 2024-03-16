using Microsoft.AspNetCore.Mvc;
using Mission10.Data;
using System.Collections.Generic;
using System.Linq;

namespace Mission10.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private readonly BowlerContext _context;

        public BowlerController(BowlerContext context)
        {
            _context = context;
        }

        public IEnumerable<Bowler> Bowlers => _context.Bowlers;

        [HttpGet]
        public IEnumerable<Bowler> GetBowlersWithTeams()
        {
            var query = (from bowler in _context.Bowlers
                                              join team in _context.Teams on bowler.TeamId equals team.TeamId
                                              select new Bowler
                                              {
                                                  BowlerId = bowler.BowlerId,
                                                  BowlerLastName = bowler.BowlerLastName,
                                                  BowlerFirstName = bowler.BowlerFirstName,
                                                  BowlerMiddleInit = bowler.BowlerMiddleInit,
                                                  BowlerAddress = bowler.BowlerAddress, 
                                                  BowlerCity = bowler.BowlerCity,
                                                  BowlerState = bowler.BowlerState,
                                                  BowlerZip = bowler.BowlerZip,
                                                  BowlerPhoneNumber = bowler.BowlerPhoneNumber,
                                                  TeamId = team.TeamId,
                                                  TeamName = team.TeamName
                                              }).ToList();

            var BowlingData = query.ToList();

            return BowlingData;
        }
    }
}
