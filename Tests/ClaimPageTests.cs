using OrangeHRMTest.Pages.Claims;

namespace OrangeHRMTest.Tests
{
    [TestClass]
    public class ClaimPageTests
    {
        private IBrowser? _browser;
        private IBrowserContext? _context;
        private IPage? _page;
        private LoginPage? _loginPage; // POM created for Login Page
        private NavigationPanelPage? _navigationPanelPage; // POM created for the NavigationPanel
        private ClaimPage? _ClaimPage; // POM created for the Claim Page
        private SubmitClaimPage? _SubmitClaimPage;//POM created for the Submit Claim Page
        [TestInitialize]
        public async Task Setup()
        {
            // Initialize browser, context, and page
            var playwright = await Playwright.CreateAsync();

            bool demo = true;
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
        [TestCategory("Claim Page Elements")]
        [DataRow("Submit Claim")]
        [DataRow("My Claims")]
        [DataRow("Employee Claims")]
        [DataRow("Assign Claim")]

        public async Task TestElementPageVisible(string element)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("Claim");

            // Create a ClaimPage object
            _ClaimPage = new ClaimPage(_page);

            // Navigate to the element page
            await _ClaimPage.GoToElementPageAsync(element);

            // Get the text on the element page header
            var headerText = await _ClaimPage.GetElementPageHeaderText(element);
            Console.WriteLine($"Actual Header Text: {headerText}");

            // Perform verifications or interactions on the element page
            bool isElementPageVisible = await _ClaimPage.IsElementPageVisibleAsync(element);
            Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("Claim Page Elements")]
        [DataRow("Configuration ")]
        [DataRow("Submit Claim")]
        [DataRow("My Claims")]
        [DataRow("Employee Claims")]
        [DataRow("Assign Claim")]

        public async Task TestElementPageVisible2(string element)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("Claim");

            // Create a ClaimPage object
            _ClaimPage = new ClaimPage(_page);

            if (AdminPage.elements.ContainsKey(element))
            {
                if (AdminPage.elements[element] is Array)
                {
                    // Navigate to the element page
                    await _ClaimPage.GoToElementPageAsync(element);

                    // Get the text on the element page header
                    var headerText = await _ClaimPage.GetElementPageHeaderText(element);
                    Console.WriteLine($"Actual Header Text: {headerText}");
                    Assert.AreEqual(element, headerText, false, $"The header {element} was not found.");

                    // Perform verifications or interactions on the element page
                    bool isElementPageVisible = await _ClaimPage.IsElementPageVisibleAsync(element);
                    Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
                }
                else
                {
                    Console.WriteLine($"The element {element} has multiple choices.");
                    Dictionary<string, string[]> subelements = (Dictionary<string, string[]>)ClaimPage.elements[element];
                    foreach (string subelement in subelements.Keys)
                    {
                        Console.WriteLine($"The sub-element is {subelement}.");

                        // Navigate to the element page
                        await _ClaimPage.GoToElementPageAsync(element);

                        // Navigate to the sub-element
                        await _ClaimPage.GoToSubelementPageAsync(element, subelement);

                        // Get the text on the element page header
                        var headerText = await _ClaimPage.GetSublementPageHeaderText(element, subelement);
                        Console.WriteLine($"Actual Header Text: {headerText}");
                        string expected = subelements[subelement][1] == "" ? subelement : subelements[subelement][1];
                        Assert.AreEqual(expected, headerText, false, $"The header {expected} was not found.");

                        // Perform verifications or interactions on the element page
                        bool isElementPageVisible = await _ClaimPage.IsElementPageVisibleAsync(element);
                        Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"The element {element} does not exist on the Admin page.");
            }
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("Claim Page Elements")]

        public async Task TestSubmitClaim()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("Claim");

            // Create a ClaimPage object
            _ClaimPage = new ClaimPage(_page);
            _SubmitClaimPage = new SubmitClaimPage(_page);
            await _ClaimPage.GoToElementPageAsync("Submit Claim");
            await _SubmitClaimPage.FillOutSubmitClaimDetailsAsync("Travel Allowance", "Afghanistan Afghani", "This is test claim");
            await _SubmitClaimPage.SubmitFormAsync();

            //await _SubmitClaimPage.ValidateClaimCreated();




        }
    }
}