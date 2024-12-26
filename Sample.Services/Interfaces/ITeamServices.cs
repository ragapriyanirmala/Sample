using Sample.Services.DTOs;

namespace Sample.Services.Interfaces
{
    public interface ITeamServices
    {
        List<TeamDTO> Get();
        TeamDTO GetById(Guid id);
    }
}
