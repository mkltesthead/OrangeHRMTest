using Microsoft.Playwright;

namespace OrangeHRMTest.Tests
{
    [TestClass]

    public class LoginPageTests
    {
        private IPlaywright? _playwright;
        private IBrowser? _browser;
        private IPage? _page;

        [TestInitialize]
        public async Task Initialize()
        {
            _playwright = await Playwright.CreateAsync();

            bool demo = false;
            BrowserTypeLaunchOptions options = new BrowserTypeLaunchOptions();
            if (demo)
            {
                options.Headless = false;
                options.SlowMo = 1000;
            }
            //_browser = await _playwright.Chromium.LaunchAsync(options);
            //_browser = await _playwright.Firefox.LaunchAsync(options);
            _browser = await _playwright.Webkit.LaunchAsync(options);

            _page = await _browser.NewPageAsync();
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await _browser.CloseAsync();
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("LogInSuccess")]
        public async Task TestLoginSuccess()
        {
            var loginPage = new LoginPage(_page);
            await loginPage.GoToLoginPage();
            await loginPage.Login("admin", "admin123", expectSuccess: true);
            // Check if the dashboard is visible
            bool isDashboardVisible = await loginPage.IsDashboardVisible();
            Assert.IsTrue(isDashboardVisible, "Expected 'Dashboard' heading was not found");
        }

        [TestMethod]
        [TestCategory("NegativeTest")]
        [TestCategory("TestInvalidLogin")]
        public async Task TestInvalidLogin()
        {
            var loginPage = new LoginPage(_page);

            // Navigate to the login page using the constant URL
            await loginPage.GoToLoginPage();

            // Attempt to login with invalid credentials
            await loginPage.Login("invalidUsername", "invalidPassword", expectSuccess: false);

            // Wait for a short period to ensure that any potential login processing has completed
            await _page.WaitForTimeoutAsync(2000);

            // Check if the "Invalid credentials" message is displayed
            bool isInvalidCredentialsMessageDisplayed = await loginPage.IsInvalidCredentialsMessageDisplayed();
            Assert.IsTrue(isInvalidCredentialsMessageDisplayed, "Expected 'Invalid credentials' message was not displayed.");
        }
    }
}
