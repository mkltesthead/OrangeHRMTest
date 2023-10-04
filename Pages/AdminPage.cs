namespace OrangeHRMTest.Pages
{
    public class AdminPage
    {
        private readonly IPage _page;

        public AdminPage(IPage page)
        {
            _page = page;
        }

        // The keys of this dictionary are all the options across the top of the page
        // If the control isn't a dropdown then the corresponding value is an empty dictionary
        // If the control is a drop down then the corresponding value is a second dictionary
        // The keys of the second dictionary are the drop down options
        // The corresponding values of the second dictionary are arrays containing 2 strings 0) the type of heading 1) the heading text
        // If the type of heading is "" then "h6" is used
        // If the heading text is "" then the key is used
        public static Dictionary<string, Dictionary<string, string[]>> elements = new Dictionary<string, Dictionary<string, string[]>>() {
            {"User Management "  , new Dictionary<string, string[]>{ { "Users", new string[] { "h5", "System Users" } } } },
            {"Job "              , new Dictionary<string, string[]>{ { "Job Titles", new string[] { "", "" } },
                                                                     { "Pay Grades", new string[] { "", "" } },
                                                                     { "Employment Status", new string[] { "", "" } },
                                                                     { "Job Categories", new string[] { "", "" } },
                                                                     { "Work Shifts", new string[] { "", "" } } } },
            {"Organization "     , new Dictionary<string, string[]>{ { "General Information", new string[] { "", "" } },
                                                                     { "Locations", new string[] { "h5", "" } },
                                                                     { "Structure", new string[] { "", "Organization Structure" } } } },
            {"Qualifications "   , new Dictionary<string, string[]>{ { "Skills", new string[] { "", "" } },
                                                                     { "Education", new string[] { "", "" } },
                                                                     { "Licenses", new string[] { "", "" } },
                                                                     { "Languages", new string[] { "", "" } },
                                                                     { "Memberships", new string[] { "", "" } } } },
            {"Nationalities"     , new Dictionary<string, string[]>{ } },
            {"Corporate Branding", new Dictionary<string, string[]>{ } },
            {"Configuration "    , new Dictionary<string, string[]>{ { "Email Configuration", new string[] { "p", "" } },
                                                                     { "Email Subscriptions", new string[] { "", "" } },
                                                                     { "Localization", new string[] { "", "" } },
                                                                     { "Language Packages", new string[] { "", "" } },
                                                                     { "Modules", new string[] { "", "Module Configuration" } },
                                                                     { "Social Media Authentication", new string[] { "h4", "Launching Soon" } },
                                                                     { "Register OAuth Client", new string[   ] { "", "OAuth Client List" } },
                                                                     { "LDAP Configuration", new string[] { "", "" } } } }
        };

        public static string getElementSelector(string element)
        {
            return elements.ContainsKey(element) ? $"{(elements[element].Count == 0 ? "a" : "span")}[class='oxd-topbar-body-nav-tab-item']:text('{element}')" : "";
        }

        public static string getSubelementSelector(string element, string subelement)
        {
            return (elements.ContainsKey(element) && elements[element].ContainsKey(subelement)) ? $"a[class='oxd-topbar-body-nav-tab-link']:text('{subelement}')" : "";
        }

        public static string getSubelementHeaderSelector(string element, string subelement)
        { 
            return (elements.ContainsKey(element) && elements[element].ContainsKey(subelement)) ? $"{(elements[element][subelement][0] == "" ? "h6" : elements[element][subelement][0])}.oxd-text:has-text('{(elements[element][subelement][1] == "" ? subelement : elements[element][subelement][1])}')" : "";
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
