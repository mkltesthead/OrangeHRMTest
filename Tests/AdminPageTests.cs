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

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("Admin Page Elements")]
        [DataRow("User Management ")]
        [DataRow("Job ")]
        [DataRow("Organization ")]
        [DataRow("Qualifications ")]
        [DataRow("Nationalities")]
        [DataRow("Corporate Branding")]
        [DataRow("Configuration ")]

        public async Task TestElementPageVisible2(string element)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("Admin");

            // Create a PIMPage object
            _AdminPage = new AdminPage(_page);

            if (AdminPage.elements.ContainsKey(element))
            {
                if (AdminPage.elements[element].Count == 0)
                {
                    // Navigate to the element page
                    await _AdminPage.GoToElementPageAsync(element);

                    // Get the text on the element page header
                    var headerText = await _AdminPage.GetElementPageHeaderText(element);
                    Console.WriteLine($"Actual Header Text: {headerText}");
                    Assert.AreEqual(element, headerText, false, $"The header {element} was not found.");

                    // Perform verifications or interactions on the element page
                    bool isElementPageVisible = await _AdminPage.IsElementPageVisibleAsync(element);
                    Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
                }
                else
                {
                    Console.WriteLine($"The element {element} has multiple choices.");
                    foreach (string subelement in AdminPage.elements[element].Keys)
                    {
                        Console.WriteLine($"The sub-element is {subelement}.");

                        // Navigate to the element page
                        await _AdminPage.GoToElementPageAsync(element);

                        // Navigate to the sub-element
                        await _AdminPage.GoToSubelementPageAsync(element, subelement);

                        // Get the text on the element page header
                        var headerText = await _AdminPage.GetSublementPageHeaderText(element, subelement);
                        Console.WriteLine($"Actual Header Text: {headerText}");
                        string expected = AdminPage.elements[element][subelement] == "" ? subelement : AdminPage.elements[element][subelement];
                        Assert.AreEqual(expected, headerText, false, $"The header {expected} was not found.");

                        // Perform verifications or interactions on the element page
                        bool isElementPageVisible = await _AdminPage.IsElementPageVisibleAsync(element);
                        Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"The element {element} does not exist on the Admin page.");
            }
        }
    }
}