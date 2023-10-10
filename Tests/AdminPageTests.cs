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
        private AdminPage? _AdminPage; // POM created for the Admin Page
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
        [TestCategory("Admin Page Elements")]
        [DataRow("Nationalities")]
        [DataRow("Corporate Branding")]

        public async Task TestElementPageVisible(string element)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("Admin");

            // Create a AdminPage object
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

            // Create a AdminPage object
            _AdminPage = new AdminPage(_page);

            if (AdminPage.elements.ContainsKey(element))
            {
                if (AdminPage.elements[element] is Array)
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
                    Dictionary<string, string[]> subelements = (Dictionary<string, string[]>)AdminPage.elements[element];
                    foreach (string subelement in subelements.Keys)
                    {
                        Console.WriteLine($"The sub-element is {subelement}.");

                        // Navigate to the element page
                        await _AdminPage.GoToElementPageAsync(element);

                        // Navigate to the sub-element
                        await _AdminPage.GoToSubelementPageAsync(element, subelement);

                        // Get the text on the element page header
                        var headerText = await _AdminPage.GetSublementPageHeaderText(element, subelement);
                        Console.WriteLine($"Actual Header Text: {headerText}");
                        string expected = subelements[subelement][1] == "" ? subelement : subelements[subelement][1];
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

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("Admin Page Elements")]
        [TestCategory("CRUD")]

        public async Task Locations()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("Admin");

            Dictionary<string, string[]> subelements = (Dictionary<string, string[]>)AdminPage.elements["Organization "];

            // Create a AdminPage object
            _AdminPage = new AdminPage(_page);

            // Navigate to the element page
            await _AdminPage.GoToElementPageAsync("Organization ");

            // Navigate to the sub-element
            await _AdminPage.GoToSubelementPageAsync("Organization ", "Locations");

            // Get the text on the element page header
            var headerText = await _AdminPage.GetSublementPageHeaderText("Organization ", "Locations");
            Console.WriteLine($"Actual Header Text: {headerText}");
            string expected = subelements["Locations"][1] == "" ? "Locations" : subelements["Locations"][1];
            Assert.AreEqual(expected, headerText, false, $"The header {expected} was not found.");

            // Perform verifications or interactions on the element page
            bool isElementPageVisible = await _AdminPage.IsElementPageVisibleAsync("Organization ");
            Assert.IsTrue(isElementPageVisible, $"The {"Organization "} page is not visible.");

            // Search for AAA
            await _page.GetByRole(AriaRole.Button, new() { Name = "Reset" }).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox).Nth(1).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox).Nth(1).FillAsync("AAA");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

            // Verify that no records found
            await _page.Locator("span").Filter(new() { HasText = "No Records Found" }).ClickAsync();

            // Press the Add button
            await _page.GetByRole(AriaRole.Button, new() { Name = " Add" }).ClickAsync();

            // Populate the Name, City, Country and Phone fields
            await _page.Locator("div:nth-child(2) > .oxd-input").First.ClickAsync();
            await _page.Locator("div:nth-child(2) > .oxd-input").First.FillAsync("AAA");
            await _page.Locator("div:nth-child(2) > .oxd-grid-2 > div > .oxd-input-group > div:nth-child(2) > .oxd-input").First.ClickAsync();
            await _page.Locator("div:nth-child(2) > .oxd-grid-2 > div > .oxd-input-group > div:nth-child(2) > .oxd-input").First.FillAsync("BBB");
            await _page.Locator("form i").ClickAsync();
            await _page.GetByText("Afghanistan").ClickAsync();
            await _page.Locator("div:nth-child(5) > .oxd-input-group > div:nth-child(2) > .oxd-input").ClickAsync();
            await _page.Locator("div:nth-child(5) > .oxd-input-group > div:nth-child(2) > .oxd-input").FillAsync("999");

            // Press the Save button
            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

            // Search for AAA
            await _page.GetByRole(AriaRole.Button, new() { Name = "Reset" }).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox).Nth(1).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox).Nth(1).FillAsync("AAA");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

            // Verify that one record is found
            await _page.GetByText("(1) Record Found").ClickAsync();

            // Check the Name, City, Country, Phone and Number of Employees
            await _page.GetByText("AAA").ClickAsync();
            await _page.GetByText("BBB").ClickAsync();
            await _page.GetByText("Afghanistan").ClickAsync();
            await _page.GetByText("999").ClickAsync();
            await _page.GetByText("0", new() { Exact = true }).ClickAsync();

            // Press the Edit button
            await _page.GetByRole(AriaRole.Button, new() { Name = "" }).ClickAsync();

            // Update the Country
            await _page.Locator("form i").ClickAsync();
            await _page.GetByText("Albania").ClickAsync();

            // Press the Save button
            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

            // Search for AAA
            await _page.GetByRole(AriaRole.Button, new() { Name = "Reset" }).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox).Nth(1).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox).Nth(1).FillAsync("AAA");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

            // Check the Name, City, Country, Phone and Number of Employees
            await _page.GetByText("AAA").ClickAsync();
            await _page.GetByText("BBB").ClickAsync();
            await _page.GetByText("Albania").ClickAsync();
            await _page.GetByText("999").ClickAsync();
            await _page.GetByText("0", new() { Exact = true }).ClickAsync();

            // Press the Delete button
            await _page.GetByRole(AriaRole.Button, new() { Name = "" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = " Yes, Delete" }).ClickAsync();

            // Search for AAA
            await _page.GetByRole(AriaRole.Button, new() { Name = "Reset" }).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox).Nth(1).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox).Nth(1).FillAsync("AAA");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

            // Verify that no records found
            await _page.Locator("span").Filter(new() { HasText = "No Records Found" }).ClickAsync();
        }
    }
}