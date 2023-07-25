﻿using LawFirm.Api.IntegrationTests.Base;
using LawFirm.Application.Features.Clients.Queries.GetClientList;
using System.Text.Json;

namespace LawFirm.Api.IntegrationTests.Controllers;

public class ClientControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public ClientControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ReturnsClientList()
    {
        var client = _factory.GetAnonymousClient();

        var response = await client.GetAsync("/api/client");

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<List<ClientListVm>>(responseString);

        Assert.IsType<List<ClientListVm>>(result);
        Assert.NotEmpty(result);
    }
}