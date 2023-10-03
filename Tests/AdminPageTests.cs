namespace OrangeHRMTest.Tests
{
    [TestClass]
    public class AdminPageTests
    {
        private IBrowser? _browser;
        private IBrowserContext? _context;
        private IPage? _page;
        private LoginPage? _loginPage; // POM created for Login Page
        private NavigationPanelPage? _navigationPanelPage; // POM created for the NavigationPanel
        private AdminPage? _AdminPage; // POM created for the PIM Page
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
            await _loginPage.GoToLoginPage();
            await _loginPage.Login("admin", "admin123", expectSuccess: true);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            // Close browser after tests
            await _browser.CloseAsync();
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("Admin Page Elements")]
        [DataRow("Nationalities")]
        [DataRow("Corporate Branding")]

        public async Task TestElementPageVisible(string element)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("Admin");

            // Create a PIMPage object
            _AdminPage = new AdminPage(_page);

            // Navigate to the element page
            await _AdminPage.GoToElementPageAsync(element);

            // Get the text on the element page header
            var headerText = await _AdminPage.GetElementPageHeaderText(element);
            Console.WriteLine($"Actual Header Text: {headerText}");

            // Perform verifications or interactions on the element page
            bool isElementPageVisible = await _AdminPage.IsElementPageVisibleAsync(element);
            Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
        }
    }
}