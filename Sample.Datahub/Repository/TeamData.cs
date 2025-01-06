using Sample.Datahub.Models.Domain;

namespace Sample.Datahub.Repository
{
    public class TeamData : ITeamData
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
        public Team Create(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return team;
        }
        public Guid? GetTeamIdByName(string name)
        {

            var team = _context.Teams.FirstOrDefault(x => x.Name == name);
            if (team != null)
            {
                return team.Id;
            }
            return null;

        }
        public Team Update(Team team)
        {
            _context.SaveChanges();
            return team;
        }
    }
}