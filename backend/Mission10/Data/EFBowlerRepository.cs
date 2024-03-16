
namespace Mission10.Data
{
    public class EFBowlerRepository : IBowlerRepository
    {
        private BowlerContext _context;

        public EFBowlerRepository(BowlerContext context)
        {
            _context = context;
        }

        public IEnumerable<Bowler> Bowlers => _context.Bowlers;
    }
}
