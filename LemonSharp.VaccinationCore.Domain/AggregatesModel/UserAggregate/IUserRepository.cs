using LemonSharp.VaccinationCore.Domain.SeedWork;

namespace LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;

public interface IUserRepository: IRepository<User>
{
    Task<User> GetAsync(Guid id);
    
    User Add(User user);
    
    void Update(User user);
}
