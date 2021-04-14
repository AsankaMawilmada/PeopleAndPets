using FluentAssertions;
using NSubstitute;
using PeopleAndPets.Core.Application.People.Dtos;
using PeopleAndPets.Core.Interfaces.Services;
using PeopleAndPets.Core.Tests.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static PeopleAndPets.Core.Application.People.GroupedCats;

namespace PeopleAndPets.Core.Tests.Application
{
    public class GroupedCatsTests
    {
        [Fact]
        public async Task WhenServiceReturnsSixPersons_HandlerShouldReturnTwoGroups()
        {
            // Arrange
            var peopleService = Substitute.For<IPeopleService>();
            peopleService.GetPeopleAsync().Returns(MockSourceData.People);

            // Act
            var handler = new QueryHandler(peopleService);
            var expected = await handler.Handle(new Query(), new System.Threading.CancellationToken());

            // Assert
            expected
                .Should()
                .BeOfType<List<GenderGroupEnvelope>>()
                .And
                .HaveCount(2);
        }

        [Fact]
        public async Task WhenServiceReturnsSixPersons_HandlerShouldReturnExpectedResultsInExpectedOrder()
        {
            // Arrange
            var peopleService = Substitute.For<IPeopleService>();
            peopleService.GetPeopleAsync().Returns(MockSourceData.People);

            // Act
            var handler = new QueryHandler(peopleService);
            var expected = await handler.Handle(new Query(), new System.Threading.CancellationToken());

            // Assert
            expected.First().Gender.Should().BeEquivalentTo("Male");
            expected.First().Pets[0].Should().BeEquivalentTo("Garfield");
            expected.First().Pets[1].Should().BeEquivalentTo("Jim");
            expected.First().Pets[2].Should().BeEquivalentTo("Max");
            expected.First().Pets[3].Should().BeEquivalentTo("Tom");

            expected.Last().Gender.Should().BeEquivalentTo("Female");
            expected.Last().Pets[0].Should().BeEquivalentTo("Garfield");
            expected.Last().Pets[1].Should().BeEquivalentTo("Tabby");
            expected.Last().Pets[2].Should().BeEquivalentTo("Simba");
        }
    }
}
