using Sample.Services.DTOs;

namespace Sample.Services.Interfaces
{
    public interface ITeamServices
    {
        List<TeamDTO> Get();
        TeamDTO GetById(Guid id);
        TeamDTO Create(AddTeamDTO input);
        TeamDTO Update(Guid id, AddTeamDTO input);
        bool Delete(Guid id);
    }
}
