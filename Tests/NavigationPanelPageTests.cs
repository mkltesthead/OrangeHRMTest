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
            Console.WriteLine($"Actual Admin Header Text: {adminHeaderText}");

            bool isAdminHeaderVisible = await _navigationPanelPage.IsAdminHeaderVisibleAsync();
            Assert.IsTrue(isAdminHeaderVisible, "The Admin header is not visible.");
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
        [TestCategory("TestLeave")]
        [TestCategory("Navigation")]
        public async Task TestleavePageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToLeavePageAsync();

            var leaveHeaderText = await _page.InnerTextAsync(NavigationPanelPage.LeaveHeaderSelector);
            Console.WriteLine($"Actual Leave Header Text: {leaveHeaderText}");

            bool isLeaveHeaderVisible = await _navigationPanelPage.IsLeaveHeaderVisibleAsync();
            Assert.IsTrue(isLeaveHeaderVisible, "The Leave header is not visible.");
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

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("TestRecruitment")]
        [TestCategory("Navigation")]
        public async Task TestRecruitmentPageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToRecruitmentPageAsync();

            var recruitmentHeaderText = await _page.InnerTextAsync(NavigationPanelPage.RecruitmentHeaderSelector);
            Console.WriteLine($"Actual Recruitment Header Text: {recruitmentHeaderText}");

            bool isRecruitmentHeaderVisible = await _navigationPanelPage.IsRecruitmentHeaderVisibleAsync();
            Assert.IsTrue(isRecruitmentHeaderVisible, "The Recruitment header is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("TestMyInfo")]
        [TestCategory("Navigation")]
        public async Task TestMyInfoPageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToMyInfoPageAsync();

            var myInfoHeaderText = await _page.InnerTextAsync(NavigationPanelPage.MyInfoHeaderSelector);
            Console.WriteLine($"Actual My Info Header Text: {myInfoHeaderText}");

            bool isMyInfoHeaderVisible = await _navigationPanelPage.IsMyInfoHeaderVisibleAsync();
            Assert.IsTrue(isMyInfoHeaderVisible, "The My Info header is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("TestPerformance")]
        [TestCategory("Navigation")]
        public async Task TestPerformancePageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPerformancePageAsync();

            var performanceHeaderText = await _page.InnerTextAsync(NavigationPanelPage.PerformanceHeaderSelector);
            Console.WriteLine($"Actual Performance Header Text: {performanceHeaderText}");

            bool isPerformanceHeaderVisible = await _navigationPanelPage.IsPerformanceHeaderVisibleAsync();
            Assert.IsTrue(isPerformanceHeaderVisible, "The Performance header is not visible.");
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
        [TestCategory("TestMaintenance")]
        [TestCategory("Navigation")]
        public async Task TestMaintenancePageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToMaintenancePageAsync();

            var maintenanceHeaderText = await _page.InnerTextAsync(NavigationPanelPage.MaintenanceHeaderSelector);
            Console.WriteLine($"Actual Maintenance Header Text: {maintenanceHeaderText}");

            bool isMaintenanceHeaderVisible = await _navigationPanelPage.IsMaintenanceHeaderVisibleAsync();
            Assert.IsTrue(isMaintenanceHeaderVisible, "The Maintenance header is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("TestClaim")]
        [TestCategory("Navigation")]
        public async Task TestClaimPageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToClaimPageAsync();

            var claimHeaderText = await _page.InnerTextAsync(NavigationPanelPage.ClaimHeaderSelector);
            Console.WriteLine($"Actual Claim Header Text: {claimHeaderText}");

            bool isClaimHeaderVisible = await _navigationPanelPage.IsClaimHeaderVisibleAsync();
            Assert.IsTrue(isClaimHeaderVisible, "The Claim header is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("TestBuzz")]
        [TestCategory("Navigation")]
        public async Task TestBuzzPageHeaderIsVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToBuzzPageAsync();

            var buzzHeaderText = await _page.InnerTextAsync(NavigationPanelPage.BuzzHeaderSelector);
            Console.WriteLine($"Actual Buzz Header Text: {buzzHeaderText}");

            bool isBuzzHeaderVisible = await _navigationPanelPage.IsBuzzHeaderVisibleAsync();
            Assert.IsTrue(isBuzzHeaderVisible, "The Buzz header is not visible.");
        }
    }
}