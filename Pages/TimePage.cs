namespace OrangeHRMTest.Pages
{
    public class TimePage
    {
        private readonly IPage _page;

        public TimePage(IPage page)
        {
            _page = page;
        }

        // The keys of this dictionary are all the options across the top of the page
        // If the control isn't a dropdown then the corresponding value is an array containing 2 strings 0) the type of heading 1) the heading text
        // If the type of heading is "" then "h6" is used
        // If the heading text is "" then the key is used
        // If the control is a drop down then the corresponding value is a second dictionary
        // The keys of the second dictionary are the drop down options
        // The corresponding values of the second dictionary are arrays containing 2 strings 0) the type of heading 1) the heading text
        // If the type of heading is "" then "h6" is used
        // If the heading text is "" then the key is used
        public static Dictionary<string, object> elements = new Dictionary<string, object>() {
            {"Timesheets "  , new Dictionary<string, string[]>{ { "My Timesheets", new string[] { "", "My Timesheet" } },
                                                                { "Employee Timesheets", new string[] { "", "Select Employee" } } } },
            {"Attendance "  , new Dictionary<string, string[]>{ { "My Records", new string[] { "h5", "My Attendance Records" } },
                                                                { "Punch In/Out", new string[] { "", "Punch In" } },
                                                                { "Employee Records", new string[] { "h5", "Employee Attendance Records" } },
                                                                { "Configuration", new string[] { "", "Attendance Configuration" } } } },
            {"Reports "     , new Dictionary<string, string[]>{ { "Project Reports", new string[] { "h5", "Project Report" } },
                                                                { "Employee Reports", new string[] { "h5", "Employee Report" } },
                                                                { "Attendance Summary", new string[] { "h5", "Attendance Total Summary Report" } } } },
            {"Project Info ", new Dictionary<string, string[]>{ { "Customers", new string[] { "", "" } },
                                                                { "Projects", new string[] { "h5", "" } } } }
        };

        public static string getElementSelector(string element)
        {
            return elements.ContainsKey(element) ? $"{(elements[element] is Array ? "a" : "span")}[class='oxd-topbar-body-nav-tab-item']:text('{element}')" : "";
        }

        public static string getSubelementSelector(string element, string subelement)
        {
            string returnValue = "";
            if (elements.ContainsKey(element) && elements[element] is not Array)
            {
                Dictionary<string, string[]> subelements = (Dictionary<string, string[]>) elements[element];
                returnValue = subelements.ContainsKey(subelement) ? $"a[class='oxd-topbar-body-nav-tab-link']:text('{subelement}')" : "";
            }
            return returnValue;
        }

        public static string getSubelementHeaderSelector(string element, string subelement)
        {
            string returnValue = "";
            if (elements.ContainsKey(element) && elements[element] is not Array)
            {
                Dictionary<string, string[]> subelements = (Dictionary<string, string[]>) elements[element];
                if (subelements.ContainsKey(subelement))
                {
                    string[] details = subelements[subelement];
                    returnValue = $"{(details[0] == "" ? "h6" : details[0])}.oxd-text:has-text('{(details[1] == "" ? subelement : details[1])}')";
                }
            }
            return returnValue;
        }

        // Methods to interact with elements on the page
        public async Task GoToElementPageAsync(string element)
        {
            await _page.ClickAsync(getElementSelector(element));
        }

        // Methods to interact with elements on the page
        public async Task GoToSubelementPageAsync(string element, string subelement)
        {
            await _page.ClickAsync(getSubelementSelector(element, subelement));
        }

        // Example verification method
        public async Task<bool> IsElementPageVisibleAsync(string element)
        {
            return await _page.IsVisibleAsync(getElementSelector(element));
        }

        public async Task<string> GetElementPageHeaderText(string element)
        {
            return await _page.InnerTextAsync(getElementSelector(element));
        }

        public async Task<string> GetSublementPageHeaderText(string element, string subelement)
        {
            return await _page.InnerTextAsync(getSubelementHeaderSelector(element, subelement));
        }
    }
}
