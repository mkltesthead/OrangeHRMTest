namespace OrangeHRMTest.Tests
{
    [TestClass]
    public class AdminCRUDTests
    {
        private IBrowser? _browser;
        private IBrowserContext? _context;
        private IPage? _page;

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
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            // Close browser after tests
            await _browser.CloseAsync();
        }

        [TestMethod]
        public async Task Locations()
        {
            // Login
            await _page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            await _page.GetByPlaceholder("Username").ClickAsync();
            await _page.GetByPlaceholder("Username").FillAsync("Admin");
            await _page.GetByPlaceholder("Password").ClickAsync();
            await _page.GetByPlaceholder("Password").FillAsync("admin123");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            // Navigate to Admin > Organization > Locations
            await _page.GetByRole(AriaRole.Link, new() { Name = "Admin" }).ClickAsync();
            await _page.GetByText("Organization").ClickAsync();
            await _page.GetByRole(AriaRole.Menuitem, new() { Name = "Locations" }).ClickAsync();

            // Search for AAA
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