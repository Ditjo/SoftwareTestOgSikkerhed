using Bunit;
using SoftwareTestOgSikkerhed.Components.Pages;
using Bunit.TestDoubles;

namespace SoftwareTestOgSikkerhedTest
{
    public class BlazorHomeViewTest
    {
        [Fact]
        public void HomePageView_UserIsNotLoggedIn_OnSucces()
        {
            //Arange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetNotAuthorized();

            var cut = ctx.RenderComponent<Home>();

            //Act
            var paraElm = cut.Find("p");

            //Assert
            var paraElmText = paraElm.TextContent;
            Assert.Equal("You are NOT logged in!", paraElmText);
        }

        [Fact]
        public void HomePageView_UserIsLoggedIn_OnSucces()
        {
            //Arange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();

            authContext.SetAuthorized("test@test.com", AuthorizationState.Authorized);
            var cut = ctx.RenderComponent<Home>();

            //Act
            var paraElm = cut.Find("p");

            //Assert
            var paraElmText = paraElm.TextContent;
            Assert.Equal("You are logged in!", paraElmText);
        }

        [Fact]
        public void HomePageView_UserIsLoggedInAsAdmin_OnSucces()
        {
            //Arange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();

            authContext.SetRoles("Admin");
            authContext.SetAuthorized("test@test.com");
            var cut = ctx.RenderComponent<Home>();

            //Act
            var paraElms = cut.FindAll("p");

            //Assert
            Assert.Contains(paraElms, paraElm => paraElm.TextContent == "You are logged in!");

            Assert.Contains(paraElms, paraElm => paraElm.TextContent == "You are Admin");
        }
    }
}