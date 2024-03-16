// Import necessary libraries
using Microsoft.AspNetCore.Mvc;
using Mission10.Data;
using System.Collections.Generic;
using System.Linq;

// Define the BowlerController class
namespace Mission10.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        // Define a private variable to hold the BowlerContext
        private readonly BowlerContext _context;

        // Constructor to initialize the BowlerContext
        public BowlerController(BowlerContext context)
        {
            _context = context;
        }

        // Define a property to access the list of bowlers
        public IEnumerable<Bowler> Bowlers => _context.Bowlers;

        // GET endpoint to retrieve bowlers along with their teams
        [HttpGet]
        public IEnumerable<Bowler> GetBowlersWithTeams()
        {
            // Query to join the Bowlers and Teams tables and filter by specific team names
            var query = (from bowler in _context.Bowlers
                         join team in _context.Teams on bowler.TeamId equals team.TeamId
                         where team.TeamName == "Marlins" || team.TeamName == "Sharks"
                         select new Bowler
                         {
                             // Map bowler and team properties to the new Bowler object
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

            // Convert the query results to a list
            var BowlingData = query.ToList();

            // Return the list of bowlers with their teams
            return BowlingData;
        }
    }
}
