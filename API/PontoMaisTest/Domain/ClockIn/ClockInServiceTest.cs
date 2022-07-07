using Xunit;
using Moq;
using PontoMaisDomain.ClockIn.Repositories;
using PontoMaisDomain.Employees.Repositories;
using Microsoft.Extensions.Logging;
using PontoMaisDomain.ClockIn.Services;
using AutoFixture;
using System;
using PontoMaisDomain.ClockIn.Entities;
using System.Linq;
using System.Collections.Generic;
using PontoMaisDomain.ClockIn.Dto;
using FluentAssertions;

namespace PontoMaisTest.Domain.ClockIn;

public class ClockInServiceTest
{
    private readonly Mock<IClockingRepository> _clockingRepository;
    private readonly Mock<IEmployeeRepository> _employeeRepository;
    private readonly Mock<ILogger<ClockInService>> _logger;
    private Fixture _fixture;
    private readonly ClockInService _clockingService;
    private readonly Guid employeeId;

    public ClockInServiceTest()
    {
        _clockingRepository = new Mock<IClockingRepository>();
        _employeeRepository = new Mock<IEmployeeRepository>();
        _logger = new Mock<ILogger<ClockInService>>();
        _fixture = new Fixture();
        employeeId = Guid.NewGuid();
        _clockingService = new ClockInService(_clockingRepository.Object,
                                              _employeeRepository.Object,
                                              _logger.Object);

        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
               .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public void GetEmployee_ShouldBeSuccess()
    {
        int day = 05, mounth = 07, year = 2022;
        var clocking = CreateClocking();

        _clockingRepository.Setup(s => s.GetByEmployee(employeeId, day, mounth, year))
        .Returns(clocking);

        var result = _clockingService.GetByEmployee(employeeId, day, mounth, year);

        result.Should().BeEquivalentTo(CreateList(clocking));
    }

    private Clocking CreateClocking()
    => _fixture.Build<Clocking>()
       .With(i => i.Id, employeeId)
       .Create();

   private List<ClockingList> CreateList(Clocking clocking){
      List<ClockingList> list = new List<ClockingList>();

      foreach(var item in clocking.ClockingEvents){

                var entrype = ((double)item.EntryType) == 1 ? "Entrada" : "Saida";

                list.Add(new ClockingList{
                    EntryType =  entrype,
                    Day = item.EventTime.Day,
                    Mounth = item.EventTime.Month,
                    Hour = item.EventTime.TimeOfDay
                });
            }

            return list;
   }

}
