using System.Collections.Generic;
using System.Threading.Tasks;
using Dnd_project_for_application_work.Application_Layer.DTOs;
using Dnd_project_for_application_work.Application_Layer.Services;
using Dnd_project_for_application_work.Domain_Layer;
using Dnd_project_for_application_work.Domain_Layer.IRepositories;
using Moq;
using Xunit;

namespace Dnd_project_for_application_work.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetAllCharactersAsync_ReturnsCharacterDtos()
        {
            var mockCharacterRepo = new Mock<ICharacterRepository>();
            var mockAlignmentRepo = new Mock<IAlignmentRepository>();
            var mockRaceRepo = new Mock<IRaceRepository>();
            var mockClassRepo = new Mock<IClassRepository>();

            var characters = new List<Character>
            {
                new Character
                {
                    CharacterId = 1,
                    CharacterName = "TestChar",
                    Alignment = new Alignment { AlignmentName = "Good" },
                    Class = new Class { ClassName = "Wizard" },
                    Race = new Race { RaceName = "Elf" }
                }
            };

            mockCharacterRepo.Setup(r => r.GetAllCharacterAsync())
                .ReturnsAsync(characters);

            var service = new CharacterService(
                mockCharacterRepo.Object,
                mockAlignmentRepo.Object,
                mockRaceRepo.Object,
                mockClassRepo.Object
            );

            var result = await service.GetAllCharactersAsync();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("TestChar", result.First().CharacterName);
            Assert.Equal("Good", result.First().AlignmentName);
            Assert.Equal("Wizard", result.First().ClassName);
            Assert.Equal("Elf", result.First().RaceName);
        }
    }
}
