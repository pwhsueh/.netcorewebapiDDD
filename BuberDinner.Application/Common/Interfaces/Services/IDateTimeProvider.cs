namespace BuberDinner.Application.Common.Interfaces.Services
{
    public interface IDatetimeProvider
    {
        DateTime UtcNow { get; }
    }

}