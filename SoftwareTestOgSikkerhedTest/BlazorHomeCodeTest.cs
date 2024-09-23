using Bunit;
using Bunit.TestDoubles;
using SoftwareTestOgSikkerhed.Components.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareTestOgSikkerhedTest
{
    public class BlazorHomeCodeTest
    {
        [Fact]
        public void HomePageCode_UserIsNotLoggedIn_OnSucces()
        {
            //Arange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetNotAuthorized();

            var cut = ctx.RenderComponent<Home>();

            //Act
            var isAuthenticated = cut.Instance.IsAuthenticated;
            var isAdmin = cut.Instance.IsAdmin;

            //Assert
            Assert.False(isAuthenticated);
            Assert.False(isAdmin);
        }

        [Fact]
        public void HomePageCode_UserIsLoggedIn_OnSucces()
        {
            //Arange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("Test@test.test");

            var cut = ctx.RenderComponent<Home>();

            //Act
            var isAuthenticated = cut.Instance.IsAuthenticated;
            var isAdmin = cut.Instance.IsAdmin;

            //Assert
            Assert.True(isAuthenticated);
            Assert.False(isAdmin);
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
            var isAuthenticated = cut.Instance.IsAuthenticated;
            var isAdmin = cut.Instance.IsAdmin;

            //Assert
            Assert.True(isAuthenticated);
            Assert.True(isAdmin);
        }
    }
}
