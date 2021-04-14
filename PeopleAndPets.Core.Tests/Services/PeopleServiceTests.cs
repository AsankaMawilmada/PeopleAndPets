using FluentAssertions;
using Newtonsoft.Json;
using NSubstitute;
using PeopleAndPets.Core.Constants;
using PeopleAndPets.Core.Interfaces.Services.Models;
using PeopleAndPets.Core.Services;
using PeopleAndPets.Core.Tests.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PeopleAndPets.Core.Tests.Services
{
    public class PeopleServiceTests
    {
        [Fact]
        public async Task WhenSourceDoesNotReturnStatusCodeOk_ServiceShouldReturnNull()
        {
            // Arrange
            var httpClientFactory = Substitute.For<IHttpClientFactory>();
            var moqMessageHandler = new MoqHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.InternalServerError
            });
            var moqHttpClient = new HttpClient(moqMessageHandler);

            httpClientFactory.CreateClient().Returns(moqHttpClient);

            // Act
            var service = new PeopleService(httpClientFactory, OptionsBuilder.AppSettingsConfig());
            var expected = await service.GetPeopleAsync();

            // Assert
            expected.Should().BeNull();
        }

        [Fact]
        public async Task WhenSourceReturnsStatusCodeOk_ServiceShouldNotReturnNull()
        {
            // Arrange
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
            var moqMessageHandler = new MoqHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(MockSourceData.People), Encoding.UTF8, ContentTypeConstants.ApplicationJson)
            });
            var moqHttpClient = new HttpClient(moqMessageHandler);

            httpClientFactoryMock.CreateClient().Returns(moqHttpClient);

            // Act
            var service = new PeopleService(httpClientFactoryMock, OptionsBuilder.AppSettingsConfig());
            var expected = await service.GetPeopleAsync();

            // Assert
            expected.Should().NotBeNull();
        }

        [Fact]
        public async Task WhenSourceReturnsSixPersons_ServiceShouldReturnSixPersonsWithExpectedType()
        {
            // Arrange
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
            var moqMessageHandler = new MoqHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(MockSourceData.People), Encoding.UTF8, ContentTypeConstants.ApplicationJson)
            });
            var moqHttpClient = new HttpClient(moqMessageHandler);

            httpClientFactoryMock.CreateClient().Returns(moqHttpClient);

            // Act
            var service = new PeopleService(httpClientFactoryMock, OptionsBuilder.AppSettingsConfig());
            var expected = await service.GetPeopleAsync();

            // Assert
            expected
                .Should()
                .BeOfType<List<Person>>()
                .And
                .HaveCount(6);
        }

        [Fact]
        public async Task WhenSourceReturnsSixPersons_FirstPersonServiceReturnsShouldBeExpected()
        {
            // Arrange
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
            var moqMessageHandler = new MoqHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(MockSourceData.People), Encoding.UTF8, ContentTypeConstants.ApplicationJson)
            });
            var moqHttpClient = new HttpClient(moqMessageHandler);

            httpClientFactoryMock.CreateClient().Returns(moqHttpClient);

            // Act
            var service = new PeopleService(httpClientFactoryMock, OptionsBuilder.AppSettingsConfig());
            var expected = await service.GetPeopleAsync();

            // Assert
            expected.First().Name.Should().BeEquivalentTo("Bob");
            expected.First().Gender.Should().BeEquivalentTo("Male");
            expected.First().Age.Should().Be(23);
            expected.First().Pets.Should().HaveCount(2);
            expected.First().Pets[0].Name.Should().BeEquivalentTo("Garfield");
            expected.First().Pets[0].Type.Should().BeEquivalentTo("Cat");
            expected.First().Pets[1].Name.Should().BeEquivalentTo("Fido");
            expected.First().Pets[1].Type.Should().BeEquivalentTo("Dog");
        }

        [Fact]
        public async Task WhenSourceReturnsAPersonWithNullPets_ServiceShouldReturnSamePersonWithNullPets()
        {
            // Arrange
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
            var moqMessageHandler = new MoqHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(MockSourceData.People), Encoding.UTF8, ContentTypeConstants.ApplicationJson)
            });
            var moqHttpClient = new HttpClient(moqMessageHandler);

            httpClientFactoryMock.CreateClient().Returns(moqHttpClient);

            // Act
            var service = new PeopleService(httpClientFactoryMock, OptionsBuilder.AppSettingsConfig());
            var expected = await service.GetPeopleAsync();

            // Assert
            expected[2].Name.Should().BeEquivalentTo("Steve");
            expected[2].Gender.Should().BeEquivalentTo("Male");
            expected[2].Age.Should().Be(45);
            expected[2].Pets.Should().BeNull();
        }
    }
}
