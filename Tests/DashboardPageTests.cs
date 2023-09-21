using OrangeHRMTests;

namespace OrangeHRMTest.Tests
{
    [TestClass]
    public class DashboardPageTests
    {
        private IBrowser? _browser;
        private IBrowserContext? _context;
        private IPage? _page;
        private LoginPage? _loginPage; // POM Created for Login Page

        private DashboardPage? _dashboardPage; // POM started for the Dashboard Page

        [TestInitialize]
        public async Task Setup()
        {
            // Initialize browser, context, and page
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync();
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            // Navigate and log in to the application
            _loginPage = new LoginPage(_page);
            // await _loginPage.Navigate();
            await _loginPage.Login("admin", "admin123", expectSuccess: true);

            // Navigate to Dashboard Page after login
            _dashboardPage = new DashboardPage(_page);
            await _dashboardPage.Navigate();
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            // Close browser after tests
            await _browser.CloseAsync();
        }

        [TestMethod]
        [TestCategory("Ignore")]
        public async Task TestSystemUsersFunctionality1()
        {
            // Your test steps for a specific functionality on the SystemUsers page
        }

        [TestMethod]
        [TestCategory("Ignore")]
        public async Task TestSystemUsersFunctionality2()
        {
            // Your test steps for another functionality on the SystemUsers page
        }
    }
}