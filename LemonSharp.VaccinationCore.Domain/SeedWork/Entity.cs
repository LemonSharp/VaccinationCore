namespace LemonSharp.VaccinationCore.Domain.SeedWork
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }


        public bool IsTransient()
        {
            return Id == default;
        }
    }
}
