using Bunit;
using SoftwareTestOgSikkerhed.Components.Pages;
using Bunit.TestDoubles;

namespace SoftwareTestOgSikkerhedTest
{
    public class BlazorViewTest
    {
        [Fact]
        public void LoginPage_UserIsNotLoggedIn_OnSucces()
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
        public void LoginPage_UserIsLoggedIn_OnSucces()
        {
            //Arange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();

            authContext.SetAuthorized("test@test.com", AuthorizationState.Authorized);

            //Act
            var cut = ctx.RenderComponent<Home>();
            var paraElm = cut.Find("p");

            //Assert
            var paraElmText = paraElm.TextContent;
            Assert.Equal("You are logged in!", paraElmText);
        }

        [Fact]
        public void LoginPage_UserIsLoggedInAsAdmin_OnSucces()
        {
            //Arange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();

            authContext.SetRoles("Admin");
            authContext.SetAuthorized("test@test.com", AuthorizationState.Authorized);

            //Act
            var cut = ctx.RenderComponent<Home>();
            var paraElms = cut.FindAll("p");

            //Assert
            Assert.Contains(paraElms, paraElm => paraElm.TextContent == "You are logged in!");
            Assert.Contains(paraElms, paraElm => paraElm.TextContent == "You are Admin");
        }

        //[Fact]
        //public void TestLogin()
        //{
        //    //Arange
        //    using var ctx = new TestContext();
        //    var cut = ctx.RenderComponent<Counter>();
        //    var paraElm = cut.Find("p");
        //    //Act
        //    cut.Find("button").Click();

        //    //Assert
        //    var paraElmText = paraElm.TextContent;
        //    paraElmText.MarkupMatches("Current count: 1");
        //}
    }
}