using Application.Common.Models.Interface;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace PCBuilderTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void PCComponent_Creation_With_Associated_Tags_And_PriceComponent()
        {
            //Arrange
            var dbContext = new Moq.Mock<ApplicationDbContext>();
            //var pcComponentRepo = new PCComponentRepository(dbContext.Object);


            //Act



            //Assert
            //Assert.IsNotNull(pcComponentRepo);
        }
    }
}