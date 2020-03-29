using CustomerApi.Controllers;
using CustomerApi.Interface;
using CustomerLibrary;
using Moq;
using Serilog;
using System;
using Xunit;

namespace CustomerApi.moq
{

    public class CustomerControllerTest
    {
        private readonly CustomersController _sut;
        private CustomerDbSettings settings = new CustomerDbSettings { CollectionName = "Test", ConnectionString = "Test", DatabaseName = "Test" };
        private readonly Mock<ICustomerService> _customerServiceMock = new Mock<ICustomerService>();
        private readonly Mock<ILogger> _logger = new Mock<ILogger>();
        
        public CustomerControllerTest()
        {
            _sut = new CustomersController(_customerServiceMock.Object);
        }

        [Fact]
        public void GetById_Should_Return_Customer_When_Customer_exists()
        {
            //Arrange
            var customerId = Guid.NewGuid().ToString();
            string Name = "Epsilon";
            var customerDTO = new Customer
            {
                Id = customerId,
                ContactName = Name
            };
            _customerServiceMock.Setup(x => x.Get(customerId)).Returns(customerDTO);
            //Act
            var customer = _sut.Get(customerId);

            //Assert
            Assert.Equal(customerId, customer.Value.Id);
            Assert.Equal(Name, customer.Value.ContactName);
        }

        [Fact]
        public void GetById_Should_Return_Nothing_When_Customer_does_not_exists()
        {
            //Arrange

            _customerServiceMock.Setup(x => x.Get(It.IsAny<Guid>().ToString())).Returns(() => null);
            //Act
            var customer = _sut.Get(Guid.NewGuid().ToString());

            //Assert
            Assert.Null(customer.Value);

        }

        [Fact(Skip = "This Test is broken need to find how to get log info")]
        public void GetById_Should_Return_Apropriate_Message_When_Customer_exists() 
        {
            //Arrange
            var customerId = "5e644ee9c7f6b61974a11c27";
            string Name = "Epsilon";
            var customerDTO = new Customer
            {
                Id = customerId,
                ContactName = Name
            };
            _customerServiceMock.Setup(x => x.Get(customerId)).Returns(customerDTO);
            //Act
            var customer = _sut.Get(customerId);

            //Assert
            _logger.Verify(x =>
            x.Information("Retrieved a customer with id : " + customerId),Times.Once);

        }
    }
}
