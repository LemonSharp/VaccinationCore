using LemonSharp.VaccinationCore.Domain.AggregatesModel.UserAggregate;
using LemonSharp.VaccinationCore.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace LemonSharp.VaccinationCore.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly VaccinationCoreContext _context;

    public IUnitOfWork UnitOfWork => _context;


    public UserRepository(VaccinationCoreContext context)
    {
        _context = context;
    }

    public Task<User> GetAsync(Guid id)
    {
        return _context.Users
            .Include(x => x.VaccinationPlan)
            .Include(x => x.AppointmentRecords)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public User Add(User user)
    {
        _context.Users.Add(user);
        return user;
    }

    public void Update(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }
}
