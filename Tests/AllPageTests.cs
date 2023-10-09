namespace OrangeHRMTest.Tests
{
    [TestClass]
    public class AllPageTests
    {
        private IBrowser? _browser;
        private IBrowserContext? _context;
        private IPage? _page;
        private LoginPage? _loginPage; // POM created for Login Page
        private NavigationPanelPage? _navigationPanelPage; // POM created for the NavigationPanel
        private AllPage? _AllPage; // POM created for the All Page

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

        [DataRow("Admin", "User Management ")]
        [DataRow("Admin", "Job ")]
        [DataRow("Admin", "Organization ")]
        [DataRow("Admin", "Qualifications ")]
        [DataRow("Admin", "Nationalities")]
        [DataRow("Admin", "Corporate Branding")]
        [DataRow("Admin", "Configuration ")]

        [DataRow("PIM", "Configuration ")]
        [DataRow("PIM", "Employee List")]
        [DataRow("PIM", "Add Employee")]
        [DataRow("PIM", "Reports")]

        [DataRow("Leave", "Apply")]
        [DataRow("Leave", "My Leave")]
        [DataRow("Leave", "Entitlements")]
        [DataRow("Leave", "Reports ")]
        [DataRow("Leave", "Configure ")]
        [DataRow("Leave", "Leave List")]
        [DataRow("Leave", "Assign Leave")]

        [DataRow("Time", "Timesheets ")]
        [DataRow("Time", "Attendance ")]
        [DataRow("Time", "Reports ")]
        [DataRow("Time", "Project Info ")]

        [DataRow("Recruitment", "Candidates")]
        [DataRow("Recruitment", "Vacancies")]

        [DataRow("Performance", "Configure ")]
        [DataRow("Performance", "Manage Reviews ")]
        [DataRow("Performance", "My Trackers")]
        [DataRow("Performance", "Employee Trackers")]

        [DataRow("Claim", "Configuration ")]
        [DataRow("Claim", "Submit Claim")]
        [DataRow("Claim", "My Claims")]
        [DataRow("Claim", "Employee Claims")]
        [DataRow("Claim", "Assign Claim")]

        public async Task TestElementPageVisible2(string screen, string element)
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
            await _navigationPanelPage.GoToPageAsync(screen);

            // Create a AllPage object
            _AllPage = new AllPage(_page);

            if (AllPage.allElements.ContainsKey(screen))
            {
                Dictionary<string, object> elements = (Dictionary<string, object>) AllPage.allElements[screen];
                if (elements.ContainsKey(element))
                {
                    if (elements[element] is Array)
                    {
                        // Navigate to the element page
                        await _AllPage.GoToElementPageAsync(elements, element);

                        // Get the text on the element page header
                        var headerText = await _AllPage.GetElementPageHeaderText(elements, element);
                        Console.WriteLine($"Actual Header Text: {headerText}");
                        Assert.AreEqual(element, headerText, false, $"The header {element} was not found.");

                        // Perform verifications or interactions on the element page
                        bool isElementPageVisible = await _AllPage.IsElementPageVisibleAsync(elements, element);
                        Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
                    }
                    else
                    {
                        Console.WriteLine($"The element {element} has multiple choices");
                        Dictionary<string, string[]> subelements = (Dictionary<string, string[]>)elements[element];
                        foreach (string subelement in subelements.Keys)
                        {
                            Console.WriteLine($"The sub-element is {subelement}");

                            // Navigate to the element page
                            await _AllPage.GoToElementPageAsync(elements, element);

                            // Navigate to the sub-element
                            await _AllPage.GoToSubelementPageAsync(elements, element, subelement);

                            // Get the text on the element page header
                            var headerText = await _AllPage.GetSublementPageHeaderText(elements, element, subelement);
                            Console.WriteLine($"Actual Header Text: {headerText}");
                            string expected = subelements[subelement][1] == "" ? subelement : subelements[subelement][1];
                            Assert.AreEqual(expected, headerText, false, $"The header {expected} was not found.");

                            // Perform verifications or interactions on the element page
                            bool isElementPageVisible = await _AllPage.IsElementPageVisibleAsync(elements, element);
                            Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"The {screen} screeen does not have a {element} element");
                }
            }
            else
            {
                Console.WriteLine($"There is no {screen} screeen");
            }
        }

        [TestMethod]
        [TestCategory("PositiveTest")]

        public async Task TestElementPageVisible3()
        {
            _navigationPanelPage = new NavigationPanelPage(_page);
                
            // Create a AllPage object
            _AllPage = new AllPage(_page);

            foreach (string screen in AllPage.allElements.Keys)
            {
                await _navigationPanelPage.GoToPageAsync(screen);
                Console.WriteLine($"\nThe screen is {screen}");

                Dictionary<string, object> elements = (Dictionary<string, object>)AllPage.allElements[screen];
                foreach (string element in elements.Keys)
                {
                    Console.WriteLine($"    The element is {element}");
                    if (elements[element] is Array)
                    {
                        // Navigate to the element page
                        await _AllPage.GoToElementPageAsync(elements, element);

                        // Get the text on the element page header
                        var headerText = await _AllPage.GetElementPageHeaderText(elements, element);
                        Console.WriteLine($"    Actual header text: {headerText}");
                        Assert.AreEqual(element, headerText, false, $"The header {element} was not found");

                        // Perform verifications or interactions on the element page
                        bool isElementPageVisible = await _AllPage.IsElementPageVisibleAsync(elements, element);
                        Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible");
                    }
                    else
                    {
                        Dictionary<string, string[]> subelements = (Dictionary<string, string[]>)elements[element];
                        foreach (string subelement in subelements.Keys)
                        {
                            Console.WriteLine($"        The sub-element is {subelement}");

                            // Navigate to the element page
                            await _AllPage.GoToElementPageAsync(elements, element);

                            // Navigate to the sub-element
                            await _AllPage.GoToSubelementPageAsync(elements, element, subelement);

                            // Get the text on the element page header
                            var headerText = await _AllPage.GetSublementPageHeaderText(elements, element, subelement);
                            Console.WriteLine($"        Actual header text: {headerText}");
                            string expected = subelements[subelement][1] == "" ? subelement : subelements[subelement][1];
                            Assert.AreEqual(expected, headerText, false, $"The header {expected} was not found");

                            // Perform verifications or interactions on the element page
                            bool isElementPageVisible = await _AllPage.IsElementPageVisibleAsync(elements, element);
                            Assert.IsTrue(isElementPageVisible, $"The {element} page is not visible");
                        }
                    }
                }
            }
        }
    }
}