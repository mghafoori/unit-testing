using DataAccess;
using Business;
using Poco;
using System;
using Xunit;
using Moq;

namespace UnitTests
{
    public class ApplicantLogicTests
    {
        [Fact]
        public void Test_Id_LessThan_1_Should_Throw_Exception()
        {
            // Arrange
            var dataLayer = new ApplicantDataLayer();
            var logic = new ApplicantLogic(dataLayer);

            // Act 
            Func<int, Applicant> getMethod = id => logic.GetApplicant(id);

            // Assert
            Assert.Throws<ArgumentException>(() => getMethod(0));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(256)]
        public void Test_Id_Equal_1_Should_Return_Applicant_1(int id)
        {
            // Arrange
            var dataLayerMock = new Mock<IApplicantDataLayer>();
            dataLayerMock
                .Setup(mock => mock.GetApplicant(It.IsAny<int>()))
                .Returns(new Applicant { Id = 1, Name = $"Name {id}", Email = $"{id}@test.com" });
            var logic = new ApplicantLogic(dataLayerMock.Object);

            // Act 
            var applicant = logic.GetApplicant(id);

            // Assert
            Assert.Equal($"Name {id}", applicant.Name);
        }

        [Fact]
        public void Test_Id_GreaterThan_1000_Should_Return_Applicant_GreaterThan_1000()
        {
            // Arrange
            var dataLayerMock = new Mock<IApplicantDataLayer>();
            dataLayerMock
                .Setup(mock => mock.GetApplicant(It.IsAny<int>()))
                .Returns(new Applicant { Id = 1001, Name = "Name 1001", Email = "1001@test.com" });
            var logic = new ApplicantLogic(dataLayerMock.Object);

            // Act 
            var applicant = logic.GetApplicant(5);

            // Assert
            Assert.Equal($"Name 1001", applicant.Name);
        }
    }
}
