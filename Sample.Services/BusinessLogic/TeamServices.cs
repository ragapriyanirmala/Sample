using Sample.Datahub.Repository;
using Sample.Services.DTOs;
using Sample.Services.Interfaces;

namespace Sample.Services.BusinessLogic
{
    public class TeamServices : ITeamServices
    {
        private readonly ITeamData _data;
        public TeamServices(ITeamData data)
        {
            _data = data;
        }
        public List<TeamDTO> Get()
        {
            var teamdata = _data.Get();
            var team = new List<TeamDTO>();
            foreach (var item in teamdata)
            {
                team.Add(new TeamDTO()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return team;
        }
        public TeamDTO GetById(Guid id)
        {
            var teamdata = _data.GetById(id);
            var team = new TeamDTO()
            {
                Id = teamdata.Id,
                Name = teamdata.Name
            };
            return team;
        }
    }
}
