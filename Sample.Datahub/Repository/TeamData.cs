using Sample.Datahub.Models.Domain;

namespace Sample.Datahub.Repository
{
    public class TeamData:ITeamData
    {
        private readonly SampleDbContext _context;
        public TeamData(SampleDbContext context)
        {
            _context = context;
        }
        public List<Team> Get()
        {
            var teams = _context.Teams.ToList();
            return teams;
        }
        public Team GetById(Guid id)
        {
            var team = _context.Teams.FirstOrDefault(t => t.Id == id);
            return team;
        }

    }
}
