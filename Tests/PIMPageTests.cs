namespace OrangeHRMTest.Tests
{
    [TestClass]
    public class PIMPageTests
    {
        private IBrowser? _browser;
        private IBrowserContext? _context;
        private IPage? _page;
        private LoginPage? _loginPage; // POM created for Login Page
        private NavigationPanelPage? _navigationPanelPage; // POM created for the NavigationPanel
        private PIMPage? _PIMPage; // POM created for the PIM Page
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
        [TestCategory("PIM Page Elements")]

        public async Task TestEmployeeListPageVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsyncDict("PIM");

            // Create a PIMPage object
            _PIMPage = new PIMPage(_page);

            // Navigate to the Employee List page
            await _PIMPage.GoToEmployeeListPageAsync();

            // Get the text on the Employee List page header
            var headerText = await _PIMPage.GetEmployeeListPageHeaderText();
            Console.WriteLine($"Actual Header Text: {headerText}");

            // Perform verifications or interactions on the Employee List page
            bool isEmployeeListPageVisible = await _PIMPage.IsEmployeeListPageVisibleAsync();
            Assert.IsTrue(isEmployeeListPageVisible, "The Employee List page is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("PIM Page Elements")]

        public async Task TestAddEmployeePageVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsyncDict("PIM");

            // Create a PIMPage object
            _PIMPage = new PIMPage(_page);

            // Navigate to the Employee List page
            await _PIMPage.GoToAddEmployeePageAsync();

            // Get the text on the Employee List page header
            var headerText = await _PIMPage.GetAddEmployeePageHeaderText();
            Console.WriteLine($"Actual Header Text: {headerText}");

            // Perform verifications or interactions on the Employee List page
            bool isAddEmployeePageVisible = await _PIMPage.IsAddEmployeePageVisibleAsync();
            Assert.IsTrue(isAddEmployeePageVisible, "The Add Employee page is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("PIM Page Elements")]

        public async Task TestReportsPageVisible()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsyncDict("PIM");

            // Create a PIMPage object
            _PIMPage = new PIMPage(_page);

            // Navigate to the Employee List page
            await _PIMPage.GoToReportsPageAsync();

            // Get the text on the Employee List page header
            var headerText = await _PIMPage.GetReportsPageHeaderText();
            Console.WriteLine($"Actual Header Text: {headerText}");

            // Perform verifications or interactions on the Employee List page
            bool isReportsPageVisible = await _PIMPage.IsReportsPageVisibleAsync();
            Assert.IsTrue(isReportsPageVisible, "The Reports page is not visible.");
        }
    }
}