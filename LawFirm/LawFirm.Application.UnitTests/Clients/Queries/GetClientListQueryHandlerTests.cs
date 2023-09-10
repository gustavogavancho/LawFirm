using AutoFixture;
using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Clients.Models;
using LawFirm.Application.Features.Clients.Queries.GetClientList;
using LawFirm.Application.Profiles;
using LawFirm.Domain.Entities;
using Moq;

namespace LawFirm.Application.UnitTests.Clients.Queries;

public class GetClientListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IClientRepository> _mockClientRepository;
    private readonly Fixture _fixture;

    public GetClientListQueryHandlerTests()
    {
        _mockClientRepository = new Mock<IClientRepository>();
        var configurationProvider = new MapperConfiguration(x => x.AddProfile<MappingProfile>());
        _mapper = configurationProvider.CreateMapper();
        _fixture = new Fixture();
    }

    [Fact]
    public async Task GetClientListTest()
    {
        //Arrange
        var handler = new GetClientListQueryHandler(_mapper, _mockClientRepository.Object);
        _mockClientRepository.Setup(x => x.ListAllAsync()).ReturnsAsync(_fixture.Create<IReadOnlyList<Client>>());

        //Act
        var result = await handler.Handle(new GetClientListQuery(), CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<List<ClientVm>>(result);
        Assert.Equal(3, result.Count);
    }
}