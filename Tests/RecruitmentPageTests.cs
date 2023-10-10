using OrangeHRMTest.Pages;

namespace OrangeHRMTest.Tests
{
    [TestClass]
    public class RecruitmentPageTests
    {
        private IBrowser? _browser;
        private IBrowserContext? _context;
        private IPage? _page;
        private LoginPage? _loginPage; // POM created for Login Page
        private NavigationPanelPage? _navigationPanelPage; // POM created for the NavigationPanel
        private RecruitmentPage? _RecruitmentPage; // POM created for the Recruitment Page
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
        [TestCategory("Recruitment Page Elements")]
        [DataRow("Candidates")]
        [DataRow("Vacancies")]

        public async Task TestElementPageVisible(string element)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("Recruitment");

            // Create a RecruitmentPage object
            _RecruitmentPage = new RecruitmentPage(_page);

            // Navigate to the element page
            await _RecruitmentPage.GoToElementPageAsync(element);

            // Get the text on the element page header
            var headerText = await _RecruitmentPage.GetElementPageHeaderText(element);
            Console.WriteLine($"Actual Header Text: {headerText}");

            // Perform verifications or interactions on the element page
            bool isElementPageVisible = await _RecruitmentPage.IsElementPageVisibleAsync(element);
            Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("Recruitment Page Elements")]
        [DataRow("Candidates")]
        [DataRow("Vacancies")]

        public async Task TestElementPageVisible2(string element)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("Recruitment");

            // Create a RecruitmentPage object
            _RecruitmentPage = new RecruitmentPage(_page);

            if (AdminPage.elements.ContainsKey(element))
            {
                if (AdminPage.elements[element] is Array)
                {
                    // Navigate to the element page
                    await _RecruitmentPage.GoToElementPageAsync(element);

                    // Get the text on the element page header
                    var headerText = await _RecruitmentPage.GetElementPageHeaderText(element);
                    Console.WriteLine($"Actual Header Text: {headerText}");
                    Assert.AreEqual(element, headerText, false, $"The header {element} was not found.");

                    // Perform verifications or interactions on the element page
                    bool isElementPageVisible = await _RecruitmentPage.IsElementPageVisibleAsync(element);
                    Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
                }
                else
                {
                    Console.WriteLine($"The element {element} has multiple choices.");
                    Dictionary<string, string[]> subelements = (Dictionary<string, string[]>)RecruitmentPage.elements[element];
                    foreach (string subelement in subelements.Keys)
                    {
                        Console.WriteLine($"The sub-element is {subelement}.");

                        // Navigate to the element page
                        await _RecruitmentPage.GoToElementPageAsync(element);

                        // Navigate to the sub-element
                        await _RecruitmentPage.GoToSubelementPageAsync(element, subelement);

                        // Get the text on the element page header
                        var headerText = await _RecruitmentPage.GetSublementPageHeaderText(element, subelement);
                        Console.WriteLine($"Actual Header Text: {headerText}");
                        string expected = subelements[subelement][1] == "" ? subelement : subelements[subelement][1];
                        Assert.AreEqual(expected, headerText, false, $"The header {expected} was not found.");

                        // Perform verifications or interactions on the element page
                        bool isElementPageVisible = await _RecruitmentPage.IsElementPageVisibleAsync(element);
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