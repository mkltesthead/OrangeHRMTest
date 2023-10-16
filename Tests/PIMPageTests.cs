using OrangeHRMTest.Pages;
using OrangeHRMTest.Pages.PIM;

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
        [TestCategory("PIM Page Elements")]
        [DataRow("Employee List")]
        [DataRow("Add Employee")]
        [DataRow("Reports")]

        public async Task TestElementPageVisible(string element)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("PIM");

            // Create a PIMPage object
            _PIMPage = new PIMPage(_page);

            // Navigate to the element page
            await _PIMPage.GoToElementPageAsync(element);

            // Get the text on the element page header
            var headerText = await _PIMPage.GetElementPageHeaderText(element);
            Console.WriteLine($"Actual Header Text: {headerText}");

            // Perform verifications or interactions on the element page
            bool isElementPageVisible = await _PIMPage.IsElementPageVisibleAsync(element);
            Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
        }

        [TestMethod]
        [TestCategory("PositiveTest")]
        [TestCategory("PIM Page Elements")]
        [DataRow("Configuration ")]
        [DataRow("Employee List")]
        [DataRow("Add Employee")]
        [DataRow("Reports")]

        public async Task TestElementPageVisible2(string element)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("PIM");

            // Create a PIMPage object
            _PIMPage = new PIMPage(_page);

            if (AdminPage.elements.ContainsKey(element))
            {
                if (AdminPage.elements[element] is Array)
                {
                    // Navigate to the element page
                    await _PIMPage.GoToElementPageAsync(element);

                    // Get the text on the element page header
                    var headerText = await _PIMPage.GetElementPageHeaderText(element);
                    Console.WriteLine($"Actual Header Text: {headerText}");
                    Assert.AreEqual(element, headerText, false, $"The header {element} was not found.");

                    // Perform verifications or interactions on the element page
                    bool isElementPageVisible = await _PIMPage.IsElementPageVisibleAsync(element);
                    Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
                }
                else
                {
                    Console.WriteLine($"The element {element} has multiple choices.");
                    Dictionary<string, string[]> subelements = (Dictionary<string, string[]>)PIMPage.elements[element];
                    foreach (string subelement in subelements.Keys)
                    {
                        Console.WriteLine($"The sub-element is {subelement}.");

                        // Navigate to the element page
                        await _PIMPage.GoToElementPageAsync(element);

                        // Navigate to the sub-element
                        await _PIMPage.GoToSubelementPageAsync(element, subelement);

                        // Get the text on the element page header
                        var headerText = await _PIMPage.GetSublementPageHeaderText(element, subelement);
                        Console.WriteLine($"Actual Header Text: {headerText}");
                        string expected = subelements[subelement][1] == "" ? subelement : subelements[subelement][1];
                        Assert.AreEqual(expected, headerText, false, $"The header {expected} was not found.");

                        // Perform verifications or interactions on the element page
                        bool isElementPageVisible = await _PIMPage.IsElementPageVisibleAsync(element);
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
        [TestCategory("PIM Page Elements")]
        public async Task OperationsOnPIMPage()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync("PIM");

            _PIMPage = new PIMPage(_page);

            //Navigate to Add Employee
            await _PIMPage.GoToElementPageAsync("Add Employee");
            
            //Adding Employee on PIMPage
            await _page.GetByPlaceholder("First name").ClickAsync();
            await _page.GetByPlaceholder("First name").FillAsync("mohit");
            await _page.GetByPlaceholder("Last Name").ClickAsync();
            await _page.GetByPlaceholder("Last Name").FillAsync("ahuja");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();

            //Verify employee is added
            await _page.GetByRole(AriaRole.Heading, new() { Name = "mohit ahuja" }).ClickAsync();

            //Created object for AddEmployeePage
           AddEmployeePage addEmployeePage = new AddEmployeePage(_page);

            //Navigate to Employee List
             await _page.GetByRole(AriaRole.Link, new() { Name = "Employee List" }).ClickAsync();
            
            //Search the record added
            await _page.GetByPlaceholder("Type for hints...").First.ClickAsync();
            await _page.GetByPlaceholder("Type for hints...").First.FillAsync("mohit");
            await _page.GetByRole(AriaRole.Option, new() { Name = "mohit ahuja" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

            //Update the first name of the record and submit
            await _page.GetByRole(AriaRole.Button, new() { Name = "" }).ClickAsync();
            await _page.GetByPlaceholder("First name").ClickAsync();
            await _page.GetByPlaceholder("First name").FillAsync("mohittest");
            await addEmployeePage.SubmitFormAsync();

            //Navigate to Employee List and search for the updated record
            await _page.GetByRole(AriaRole.Link, new() { Name = "Employee List" }).ClickAsync();
            await _page.GetByPlaceholder("Type for hints...").First.ClickAsync();
            await _page.GetByPlaceholder("Type for hints...").First.FillAsync("mohittest");
            await _page.GetByText("mohittest ahuja", new() { Exact = true }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

            //Press the delete button
            await _page.GetByRole(AriaRole.Button, new() { Name = "" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = " Yes, Delete" }).ClickAsync();

            //Again search for the record
            await _page.GetByRole(AriaRole.Link, new() { Name = "Employee List" }).ClickAsync();
            await _page.GetByPlaceholder("Type for hints...").First.ClickAsync();
            await _page.GetByPlaceholder("Type for hints...").First.FillAsync("mohittest");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

            //No records found
            await _page.Locator("span").Filter(new() { HasText = "No Records Found" }).ClickAsync();
        }


    }
}