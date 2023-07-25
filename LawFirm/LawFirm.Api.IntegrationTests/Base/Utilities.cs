using AutoFixture;
using LawFirm.Domain.Entities;
using LawFirm.Persistence;

namespace LawFirm.Api.IntegrationTests.Base;

public static class Utilities
{
    public static void InitializeDbForTests(LawFirmContext context)
    {
        var fixture = new Fixture();

        context.Client.Add(fixture.Create<Client>());

        context.SaveChanges();
    }
}