namespace OrangeHRMTest.Tests
{
    [TestClass]
    public class NavigationPanelPageTests
    {
        private IBrowser? _browser;
        private IBrowserContext? _context;
        private IPage? _page;
        private LoginPage? _loginPage; // POM created for Login Page
        private NavigationPanelPage? _navigationPanelPage; // POM created for the NavigationPanel

        [TestInitialize]
        public async Task Setup()
        {
            // Initialize browser, context, and page
            var playwright = await Playwright.CreateAsync();

            bool demo = false;
            BrowserTypeLaunchOptions options = new BrowserTypeLaunchOptions();
            if (demo)
            {
                options.Headless = false;
                options.SlowMo = 1000;
            }
            _browser = await playwright.Chromium.LaunchAsync(options);
            //_browser = await playwright.Firefox.LaunchAsync(options);
            //_browser = await playwright.Webkit.LaunchAsync(options);

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
        [TestCategory("Navigation")]
        [DataRow("Admin")]
        [DataRow("PIM")]
        [DataRow("Leave")]
        [DataRow("Time")]
        [DataRow("Recruitment")]
        [DataRow("My Info")]
        [DataRow("Performance")]
        [DataRow("Dashboard")]
        [DataRow("Directory")]
        [DataRow("Maintenance")]
        [DataRow("Claim")]
        [DataRow("Buzz")]
        public async Task TestPageHeaderIsVisibleDict(string screen)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync(screen);

            var headerText = await _page.InnerTextAsync(NavigationPanelPage.getHeaderSelector(screen));
            Console.WriteLine($"Actual Header Text: {headerText}");

            bool isHeaderVisible = await _navigationPanelPage.IsHeaderVisibleAsync(screen);
            Assert.IsTrue(isHeaderVisible, $"The header is not visible for element: {screen}");
        }
    }
}