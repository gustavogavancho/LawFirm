using AutoFixture;
using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Clients.Commands.CreateClient;
using LawFirm.Application.Profiles;
using LawFirm.Domain.Entities;
using Moq;

namespace LawFirm.Application.UnitTests.Clients.Commands;

public class CreateClientCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IClientRepository> _mockClientRepository;
    private readonly Fixture _fixture;

    public CreateClientCommandHandlerTests()
    {
        _mockClientRepository = new Mock<IClientRepository>();
        var configurationProvider = new MapperConfiguration(x => x.AddProfile<MappingProfile>());
        _mapper = configurationProvider.CreateMapper();
        _fixture = new Fixture();
    }

    [Fact]
    public async Task CreateClientTest()
    {
        //Arrange
        var clientCommand = _fixture.Create<CreateClientCommand>();
        clientCommand.Email = "g@gmail.com";
        var handler = new CreateClientCommandHandler(_mapper, _mockClientRepository.Object);
        _mockClientRepository.Setup(x => x.AddAsync(It.IsAny<Client>())).ReturnsAsync(_fixture.Create<Client>());

        //Act
        var result = await handler.Handle(clientCommand, CancellationToken.None);

        //Assert
        Assert.IsType<Guid>(result);
        Assert.NotEqual(Guid.Empty, result);
    }
}