namespace OrangeHRMTest.Pages
{
    public class AdminPage
    {
        private readonly IPage _page;

        public AdminPage(IPage page)
        {
            _page = page;
        }

        /*
        public static Dictionary<string, string[][]> elements = new Dictionary<string, string[][]>() {
            {"User Management"   , new string[][]{ new string[] { "Users", "System Users" } } },
            {"Job"               , new string[][]{ new string[] { "Job Titles" },
                                                   new string[] { "Pay Grades" },
                                                   new string[] { "Employment Status" },
                                                   new string[] { "Job Categories" },
                                                   new string[] { "Work Shifts" } } },
            {"Organization"      , new string[][]{ new string[] { "General Information" },
                                                   new string[] { "Locations" },
                                                   new string[] { "Structure", "Organization Structure" } } },
            {"Qualifications"    , new string[][]{ new string[] { "Skills" },
                                                   new string[] { "Education" },
                                                   new string[] { "Licenses" },
                                                   new string[] { "Languages" },
                                                   new string[] { "Memberships" } } },
            {"Nationalities"     , new string[][]{ } },
            {"Corporate Branding", new string[][]{ } },
            {"Configuration"     , new string[][]{ new string[] { "Email Configuration" },
                                                   new string[] { "Email Subscriptions" },
                                                   new string[] { "Localization" },
                                                   new string[] { "Language Packages" },
                                                   new string[] { "Modules", "Module Configuration" },
                                                   new string[] { "Social Media Authentication", "Launching Soon" },
                                                   new string[] { "Register OAuth Client", "OAuth Client List" },
                                                   new string[] { "LDAP Configuration" } } }
        };
        */

        public static Dictionary<string, Dictionary<string, string>> elements = new Dictionary<string, Dictionary<string, string>>() {
            {"User Management "  , new Dictionary<string, string>{ { "Users", "System Users" } } },
            {"Job "              , new Dictionary<string, string>{ { "Job Titles", "" },
                                                                   { "Pay Grades", "" },
                                                                   { "Employment Status", "" },
                                                                   { "Job Categories", "" },
                                                                   { "Work Shifts", "" } } },
            {"Organization "     , new Dictionary<string, string>{ { "General Information", "" },
                                                                   { "Locations", "" },
                                                                   { "Structure", "Organization Structure" } } },
            {"Qualifications "   , new Dictionary<string, string>{ { "Skills", "" },
                                                                   { "Education", "" },
                                                                   { "Licenses", "" },
                                                                   { "Languages", "" },
                                                                   { "Memberships", "" } } },
            {"Nationalities"     , new Dictionary<string, string>{ } },
            {"Corporate Branding", new Dictionary<string, string>{ } },
            {"Configuration "    , new Dictionary<string, string>{ { "Email Configuration", "" },
                                                                   { "Email Subscriptions", "" },
                                                                   { "Localization", "" },
                                                                   { "Language Packages", "" },
                                                                   { "Modules", "Module Configuration" },
                                                                   { "Social Media Authentication", "Launching Soon" },
                                                                   { "Register OAuth Client", "OAuth Client List" },
                                                                   { "LDAP Configuration", "" } } }
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
            string header = "h6";
            if ((element == "User Management " && subelement == "Users") || (element == "Organization " && subelement == "Locations"))
            {
                header = "h5";
            }
            else if ((element == "Configuration " && subelement == "Email Configuration"))
            {
                header = "p";
            }
            else if ((element == "Configuration " && subelement == "Social Media Authentication"))
            {
                header = "h4";
            }
            return (elements.ContainsKey(element) && elements[element].ContainsKey(subelement)) ? $"{header}.oxd-text:has-text('{(elements[element][subelement] == "" ? subelement : elements[element][subelement])}')" : "";
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
