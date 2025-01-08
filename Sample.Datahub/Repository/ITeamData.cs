using Sample.Datahub.Models.Domain;

namespace Sample.Datahub.Repository
{
    public interface ITeamData
    {
        List<Team> Get();
        Team GetById(Guid id);
        Team Create(Team team);
        Guid? GetTeamIdByName(string name);
        Team Update(Team team);
        void Delete(Team team);
    }
}
