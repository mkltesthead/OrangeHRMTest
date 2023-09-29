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
        [TestCategory("Navigation")]
        [DataRow(NavigationPanelPage.AdminSelector, NavigationPanelPage.AdminHeaderSelector)]
        [DataRow(NavigationPanelPage.PIMSelector, NavigationPanelPage.PIMHeaderSelector)]
        [DataRow(NavigationPanelPage.LeaveSelector, NavigationPanelPage.LeaveHeaderSelector)]
        [DataRow(NavigationPanelPage.TimeSelector, NavigationPanelPage.TimeHeaderSelector)]
        [DataRow(NavigationPanelPage.RecruitmentSelector, NavigationPanelPage.RecruitmentHeaderSelector)]
        [DataRow(NavigationPanelPage.MyInfoSelector, NavigationPanelPage.MyInfoHeaderSelector)]
        [DataRow(NavigationPanelPage.PerformanceSelector, NavigationPanelPage.PerformanceHeaderSelector)]
        [DataRow(NavigationPanelPage.DashboardSelector, NavigationPanelPage.DashboardHeaderSelector)]
        [DataRow(NavigationPanelPage.DirectorySelector, NavigationPanelPage.DirectoryHeaderSelector)]
        [DataRow(NavigationPanelPage.MaintenanceSelector, NavigationPanelPage.MaintenanceHeaderSelector)]
        [DataRow(NavigationPanelPage.ClaimSelector, NavigationPanelPage.ClaimHeaderSelector)]
        [DataRow(NavigationPanelPage.BuzzSelector, NavigationPanelPage.BuzzHeaderSelector)]
        public async Task TestPageHeaderIsVisible(string elementSelector, string headerSelector)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync(elementSelector);

            var headerText = await _page.InnerTextAsync(headerSelector);
            Console.WriteLine($"Actual Header Text: {headerText}");

            bool isHeaderVisible = await _navigationPanelPage.IsHeaderVisibleAsync(headerSelector);
            Assert.IsTrue(isHeaderVisible, $"The header is not visible for element: {elementSelector}");
        }
    }
}