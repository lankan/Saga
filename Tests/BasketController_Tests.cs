using Xunit;
using Moq;
using DataLayer;
using DataLayer.Models;
using System.Linq;
using Services.Controllers;
using Tests.Stubs;

namespace Tests
{
    public class BasketController_Tests
    {
        [Fact]
        public void Get_test()
        {
            // Get Stubs 
            var stub_data = Basket_Stub.getBokingStubData();
            //

            // Mock 
            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(x => x.getAllBaskets()).Returns(() => stub_data);
            // 

            // Controller Instance 
            BasketController controller = new BasketController(repository.Object);
            // 

            // Get Result 
            var result = controller.Get();
            // End 

            // Assert  - should be 20
            Assert.Equal(stub_data.Count(), result.Count()); 
        }

        [Theory]
        [InlineData("0002b3be-4f0b-418a-b7dd-670494981a89")]
        public void Get_byId(string transactionId)
        {
            // Get Stubs
            Basket stub_data = Basket_Stub.getBokingStubData().Where(x => x.TransactionNumber == transactionId).FirstOrDefault();
            //
            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(x => x.getBasketById(transactionId)).Returns(stub_data);
            // 

            // Controller Instance 
            BasketController controller = new BasketController(repository.Object);
            // 

            // Get Result 
            Basket result = controller.Get(transactionId);
            // End 

            //Assert 
            Assert.Equal(stub_data, result); 
            //
        }
    }
}
