﻿using LawFirm.Api.IntegrationTests.Base;
using LawFirm.Application.Features.Clients.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
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

        var token = JwtTokenProvider.JwtSecurityTokenHandler.WriteToken(
            new JwtSecurityToken(
                JwtTokenProvider.Issuer,
                JwtTokenProvider.Issuer,
                new List<Claim> { new(ClaimTypes.Role, "Admin"), },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: JwtTokenProvider.SigningCredentials
            )
        );

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.GetAsync("/api/client");

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<List<ClientVm>>(responseString);

        Assert.IsType<List<ClientVm>>(result);
        Assert.NotEmpty(result);
    }
}