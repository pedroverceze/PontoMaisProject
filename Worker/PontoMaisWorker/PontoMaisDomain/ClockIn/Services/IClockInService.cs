using PontoMaisDomain.ClockIn.Dto;
using PontoMaisDomain.ClockIn.Entities;

namespace PontoMaisDomain.ClockIn.Services
{
    public interface IClockInService
    {
        Task Input(ClockingRequest request, Guid correlationId);
    }
}