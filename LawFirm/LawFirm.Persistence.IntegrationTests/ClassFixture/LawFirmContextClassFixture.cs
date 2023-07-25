using AutoFixture;
using LawFirm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawFirm.Persistence.IntegrationTests.ClassFixture;

public class LawFirmContextClassFixture
{
    public LawFirmContext Context { get; private set; }
    private Fixture _fixture;

    public LawFirmContextClassFixture()
    {
        var options = new DbContextOptionsBuilder<LawFirmContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        Context = new LawFirmContext(options);

        _fixture = new Fixture();

        SeedData();
    }

    private void SeedData()
    {
        Context.Client.Add(_fixture.Create<Client>());

        Context.SaveChanges();
    }
}