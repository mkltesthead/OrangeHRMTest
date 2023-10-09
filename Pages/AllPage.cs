using System.Xml.Linq;

namespace OrangeHRMTest.Pages
{
    public class AllPage
    {
        private readonly IPage _page;

        public AllPage(IPage page)
        {
            _page = page;
        }

        // The keys of this dictionary are all the screens which have controls to select sub-screens across the top
        // For each key the corresponding value is a second dictionary
        //
        // The keys of the second dictionary are all the options across the top of the page
        // If the control isn't a dropdown then the corresponding value is an array containing 2 strings 0) the type of heading 1) the heading text
        // If the type of heading is "" then "h6" is used
        // If the heading text is "" then the key is used
        // If the control is a drop down then the corresponding value is a third dictionary
        //
        // The keys of the third dictionary are the drop down options
        // The corresponding values of the third dictionary are arrays containing 2 strings 0) the type of heading 1) the heading text
        // If the type of heading is "" then "h6" is used
        // If the heading text is "" then the key is used 
        public static Dictionary<string, object> allElements = new Dictionary<string, object>() {
            {"Admin"      , new Dictionary<string, object>() {
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
                {"Nationalities"     , new string[] { "", "" } },
                {"Corporate Branding", new string[] { "", "" } },
                {"Configuration "    , new Dictionary<string, string[]>{ { "Email Configuration", new string[] { "p", "" } },
                                                                         { "Email Subscriptions", new string[] { "", "" } },
                                                                         { "Localization", new string[] { "", "" } },
                                                                         { "Language Packages", new string[] { "", "" } },
                                                                         { "Modules", new string[] { "", "Module Configuration" } },
                                                                         { "Social Media Authentication", new string[] { "h4", "Launching Soon" } },
                                                                         { "Register OAuth Client", new string[   ] { "", "OAuth Client List" } },
                                                                         { "LDAP Configuration", new string[] { "", "" } } } } }
            },
            {"PIM"        , new Dictionary<string, object>() {
                {"Configuration "    , new Dictionary<string, string[]>{ { "Optional Fields", new string[] { "p", "" } },
                                                                         { "Custom Fields", new string[] { "", "" } },
                                                                         { "Data Import", new string[] { "p", "" } },
                                                                         { "Reporting Methods", new string[] { "p", "" } },
                                                                         { "Termination Reasons", new string[] { "p", "" } } } },
                {"Employee List"     , new string[] { "h5", "Employee Information" } },
                {"Add Employee"      , new string[] { "", "" } },
                {"Reports"           , new string[] { "h5", "Employee Reports" } } }
            },
            {"Leave"      , new Dictionary<string, object>() {
                {"Apply"             , new string[] { "", "Apply Leave" } },
                {"My Leave"          , new string[] { "h5", "My Leave List" } },
                {"Entitlements "     , new Dictionary<string, string[]>{ { "Add Entitlements", new string[] { "p", "Add Leave Entitlement" } },
                                                                         { "Employee Entitlements", new string[] { "h5", "Leave Entitlements" } },
                                                                         { "My Entitlements", new string[] { "h5", "My Leave Entitlements" } } } },
                {"Reports "          , new Dictionary<string, string[]>{ { "Leave Entitlements and Usage Report", new string[] { "h5", "" } },
                                                                         { "My Leave Entitlements and Usage Report", new string[] { "h5", "" } } } },
                {"Configure "        , new Dictionary<string, string[]>{ { "Leave Period", new string[] { "p", "" } },
                                                                         { "Leave Types", new string[] { "", "" } },
                                                                         { "Work Week", new string[] { "p", "" } },
                                                                         { "Holidays", new string[] { "h5", "" } } } },
                {"Leave List"        , new string[] { "", "" } },
                {"Assign Leave"      , new string[] { "", "" } } }
            },
            {"Time"       , new Dictionary<string, object>() {
                {"Timesheets "       , new Dictionary<string, string[]>{ { "My Timesheets", new string[] { "", "My Timesheet" } },
                                                                         { "Employee Timesheets", new string[] { "", "Select Employee" } } } },
                {"Attendance "       , new Dictionary<string, string[]>{ { "My Records", new string[] { "h5", "My Attendance Records" } },
                                                                         { "Punch In/Out", new string[] { "", "Punch In" } },
                                                                         { "Employee Records", new string[] { "h5", "Employee Attendance Records" } },
                                                                         { "Configuration", new string[] { "", "Attendance Configuration" } } } },
                {"Reports "          , new Dictionary<string, string[]>{ { "Project Reports", new string[] { "h5", "Project Report" } },
                                                                         { "Employee Reports", new string[] { "h5", "Employee Report" } },
                                                                         { "Attendance Summary", new string[] { "h5", "Attendance Total Summary Report" } } } },
                {"Project Info "     , new Dictionary<string, string[]>{ { "Customers", new string[] { "", "" } },
                                                                         { "Projects", new string[] { "h5", "" } } } } }
            },
            {"Recruitment", new Dictionary<string, object>() {
                {"Candidates"        , new string[] { "h5", "" } },
                {"Vacancies"         , new string[] { "h5", "" } } }
            },
            {"Performance", new Dictionary<string, object>() {
                {"Configure "        , new Dictionary<string, string[]>{ { "KPIs", new string[] { "h5", "Key Performance Indicators for Job Title" } },
                                                                         { "Trackers", new string[] { "h5", "Performance Trackers" } } } },
                {"Manage Reviews "   , new Dictionary<string, string[]>{ { "Manage Reviews", new string[] { "h5", "Manage Performance Reviews" } },
                                                                         { "My Reviews", new string[] { "", "" } },
                                                                         { "Employee Reviews", new string[] { "h5", "" } } } },
                {"My Trackers"       , new string[] { "", "My Performance Trackers" } },
                {"Employee Trackers" , new string[] { "h5", "Employee Performance Trackers" } } }
            },
            {"Claim"      , new Dictionary<string, object>() {
                {"Configuration "    , new Dictionary<string, string[]>{ { "Events", new string[] { "h5", "" } },
                                                                         { "Expense Types", new string[] { "h5", "" } } } },
                {"Submit Claim"      , new string[] { "", "Create Claim Request" } },
                {"My Claims"         , new string[] { "h5", "" } },
                {"Employee Claims"   , new string[] { "h5", "" } },
                {"Assign Claim"      , new string[] { "", "Create Claim Request" } } }
            }
        };

        public static string getElementSelector(Dictionary<string, object> elements, string element)
        {
            return elements.ContainsKey(element) ? $"{(elements[element] is Array ? "a" : "span")}[class='oxd-topbar-body-nav-tab-item']:text('{element}')" : "";
        }

        public static string getSubelementSelector(Dictionary<string, object> elements, string element, string subelement)
        {
            string returnValue = "";
            if (elements.ContainsKey(element) && elements[element] is not Array)
            {
                Dictionary<string, string[]> subelements = (Dictionary<string, string[]>) elements[element];
                returnValue = subelements.ContainsKey(subelement) ? $"a[class='oxd-topbar-body-nav-tab-link']:text('{subelement}')" : "";
            }
            return returnValue;
        }

        public static string getSubelementHeaderSelector(Dictionary<string, object> elements, string element, string subelement)
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
        public async Task GoToElementPageAsync(Dictionary<string, object> elements, string element)
        {
            await _page.ClickAsync(getElementSelector(elements, element));
        }

        // Methods to interact with elements on the page
        public async Task GoToSubelementPageAsync(Dictionary<string, object> elements, string element, string subelement)
        {
            await _page.ClickAsync(getSubelementSelector(elements, element, subelement));
        }

        // Example verification method
        public async Task<bool> IsElementPageVisibleAsync(Dictionary<string, object> elements, string element)
        {
            return await _page.IsVisibleAsync(getElementSelector(elements, element));
        }

        public async Task<string> GetElementPageHeaderText(Dictionary<string, object> elements, string element)
        {
            return await _page.InnerTextAsync(getElementSelector(elements, element));
        }

        public async Task<string> GetSublementPageHeaderText(Dictionary<string, object> elements, string element, string subelement)
        {
            return await _page.InnerTextAsync(getSubelementHeaderSelector(elements, element, subelement));
        }
    }
}