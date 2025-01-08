using Sample.Datahub.Models.Domain;
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
        public TeamDTO Create(AddTeamDTO input)
        {
            var team = new Team()
            {
                Name = input.Name
            };
            team = _data.Create(team);
            var output = new TeamDTO()
            {
                Id = team.Id,
                Name = team.Name
            };
            return output;
        }
        public TeamDTO Update(Guid id, AddTeamDTO input)
        {
            var team = _data.GetById(id);
            if (team == null)
            {
                return null;
            }
            team.Name = input.Name;
            team = _data.Update(team);
            var output = new TeamDTO()
            {
                Id = team.Id,
                Name = input.Name
            };
            return output;
        }
        public bool Delete(Guid id)
        {
            var team = _data.GetById(id);
            if (team == null)
            {
                return false;
            }
            _data.Delete(team);
            return true;
        }
    }
}
