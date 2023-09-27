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
        [TestCategory("TestAdmin")]
        [TestCategory("Navigation")]
        public async Task TestAdminPageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToAdminPageAsync();

            var adminHeaderText = await _page.InnerTextAsync(NavigationPanelPage.AdminHeaderSelector);
            Console.WriteLine($"Actual Directory Header Text: {adminHeaderText}");

            bool isAdminHeaderVisible = await _navigationPanelPage.IsAdminHeaderVisibleAsync();
            Assert.IsTrue(isAdminHeaderVisible, "The Admin header is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("TestLeave")]
        [TestCategory("Navigation")]
        public async Task TestleavePageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToLeavePageAsync();

            var leaveHeaderText = await _page.InnerTextAsync(NavigationPanelPage.LeaveHeaderSelector);
            Console.WriteLine($"Actual Directory Header Text: {leaveHeaderText}");

            bool isLeaveHeaderVisible = await _navigationPanelPage.IsLeaveHeaderVisibleAsync();
            Assert.IsTrue(isLeaveHeaderVisible, "The Leave header is not visible.");
        }


        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("TestDirectory")]
        [TestCategory("Navigation")]
        public async Task TestDirectoryPageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToDirectoryPageAsync();

            var directoryHeaderText = await _page.InnerTextAsync(NavigationPanelPage.DirectoryHeaderSelector);
            Console.WriteLine($"Actual Directory Header Text: {directoryHeaderText}");

            bool isDirectoryHeaderVisible = await _navigationPanelPage.IsDirectoryHeaderVisibleAsync();
            Assert.IsTrue(isDirectoryHeaderVisible, "The Directory header is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("TestDashboard")]
        [TestCategory("Navigation")]
        public async Task TestDashboardPageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToDashboardPageAsync();

            var dashboardHeaderText = await _page.InnerTextAsync(NavigationPanelPage.DashboardHeaderSelector);
            Console.WriteLine($"Actual Dashboard Header Text: {dashboardHeaderText}");

            bool isDashboardHeaderVisible = await _navigationPanelPage.IsDashboardHeaderVisibleAsync();
            Assert.IsTrue(isDashboardHeaderVisible, "The Dashboard header is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("TestPIM")]
        [TestCategory("Navigation")]
        public async Task TestPIMPageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPIMPageAsync();

            var pimHeaderText = await _page.InnerTextAsync(NavigationPanelPage.PIMHeaderSelector);
            Console.WriteLine($"Actual PIM Header Text: {pimHeaderText}");

            bool isPIMHeaderVisible = await _navigationPanelPage.IsPIMHeaderVisibleAsync();
            Assert.IsTrue(isPIMHeaderVisible, "The PIM header is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("TestTime")]
        [TestCategory("Navigation")]
        public async Task TestTimePageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToTimePageAsync();

            var timeHeaderText = await _page.InnerTextAsync(NavigationPanelPage.TimeHeaderSelector);
            Console.WriteLine($"Actual Time Header Text: {timeHeaderText}");

            bool isTimeHeaderVisible = await _navigationPanelPage.IsTimeHeaderVisibleAsync();
            Assert.IsTrue(isTimeHeaderVisible, "The Time header is not visible.");
        }
    }
}