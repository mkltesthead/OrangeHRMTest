using System.Xml.Linq;

namespace OrangeHRMTest.Pages
{
    public class AllPageTree
    {
        private readonly IPage _page;

        public AllPageTree(IPage page)
        {
            _page = page;
        }

        // This dictionary stores details about screens, sub-screens and their expected headings
        // It mimics a tree structure
        // The branches (nodes with child nodes) are nodes with values which are 2 element arrays
        // The leaves (nodes without child nodes) are nodes with values which are 4 element arrays
        // The keys are the ids of the nodes
        // The values are arrays where:
        //     1st element is the parent node's id
        //     2nd element is the node's name
        //     3rd element is the type of heading. If it is "" then "h6" is used
        //     4th element is the heading text. If it is "" then the node's name is used
        public static Dictionary<string, string[]> allElements = new Dictionary<string, string[]>() {
            { "01", new string[] { "00", "Admin" } },
                { "02", new string[] { "01", "User Management " } },
                    { "03", new string[] { "02", "Users", "h5", "System Users" } },
                { "04", new string[] { "01", "Job " } },
                    { "05", new string[] { "04", "Job Titles", "", "" } },
                    { "06", new string[] { "04", "Pay Grades", "", "" } },
                    { "07", new string[] { "04", "Employment Status", "", "" } },
                    { "08", new string[] { "04", "Job Categories", "", "" } },
                    { "09", new string[] { "04", "Work Shifts", "", "" } },
                { "10", new string[] { "01", "Organization " } },
                    { "11", new string[] { "10", "General Information", "", "" } },
                    { "12", new string[] { "10", "Locations", "h5", "" } },
                    { "13", new string[] { "10", "Structure", "", "Organization Structure" } },
                { "14", new string[] { "01", "Qualifications " } },
                    { "15", new string[] { "14", "Skills", "", "" } },
                    { "16", new string[] { "14", "Education", "", "" } },
                    { "17", new string[] { "14", "Licenses", "", "" } },
                    { "18", new string[] { "14", "Languages", "", "" } },
                    { "19", new string[] { "14", "Memberships", "", "" } },
                { "20", new string[] { "01", "Nationalities", "", "" } },
                { "21", new string[] { "01", "Corporate Branding", "", "" } },
                { "22", new string[] { "01", "Configuration " } },
                    { "23", new string[] { "22", "Email Configuration", "p", "" } },
                    { "24", new string[] { "22", "Email Subscriptions", "", "" } },
                    { "25", new string[] { "22", "Localization", "", "" } },
                    { "26", new string[] { "22", "Language Packages", "", "" } },
                    { "27", new string[] { "22", "Modules", "", "Module Configuration" } },
                    { "28", new string[] { "22", "Social Media Authentication", "h4", "Launching Soon" } },
                    { "29", new string[] { "22", "Register OAuth Client", "", "OAuth Client List" } },
                    { "30", new string[] { "22", "LDAP Configuration", "", "" } },
            { "31", new string[] { "00", "PIM" } },
                { "32", new string[] { "31", "Configuration " } },
                    { "33", new string[] { "32", "Optional Fields", "p", "" } },
                    { "34", new string[] { "32", "Custom Fields", "", "" } },
                    { "35", new string[] { "32", "Data Import", "p", "" } },
                    { "36", new string[] { "32", "Reporting Methods", "p", "" } },
                    { "37", new string[] { "32", "Termination Reasons", "p", "" } },
                { "38", new string[] { "31", "Employee List", "h5", "Employee Information" } },
                { "39", new string[] { "31", "Add Employee", "", "" } },
                { "40", new string[] { "31", "Reports", "h5", "Employee Reports" } },
            { "41", new string[] { "00", "Leave" } },
                { "42", new string[] { "41", "Apply", "", "Apply Leave" } },
                { "43", new string[] { "41", "My Leave", "h5", "My Leave List" } },
                { "44", new string[] { "41", "Entitlements " } },
                    { "45", new string[] { "44", "Add Entitlements", "p", "Add Leave Entitlement" } },
                    { "46", new string[] { "44", "Employee Entitlements", "h5", "Leave Entitlements" } },
                    { "47", new string[] { "44", "My Entitlements", "h5", "My Leave Entitlements" } },
                { "48", new string[] { "41", "Reports " } },
                    { "49", new string[] { "48", "Leave Entitlements and Usage Report", "h5", "" } },
                    { "50", new string[] { "48", "My Leave Entitlements and Usage Report", "h5", "" } },
                { "51", new string[] { "41", "Configure " } },
                    { "52", new string[] { "51", "Leave Period", "p", "" } },
                    { "53", new string[] { "51", "Leave Types", "", "" } },
                    { "54", new string[] { "51", "Work Week", "p", "" } },
                    { "55", new string[] { "51", "Holidays", "h5", "" } },
                { "56", new string[] { "41", "Leave List", "", "" } },
                { "57", new string[] { "41", "Assign Leave", "", "" } },
            { "58", new string[] { "00", "Time" } },
                { "59", new string[] { "58", "Timesheets " } },
                    { "60", new string[] { "59", "My Timesheets", "", "My Timesheet" } },
                    { "61", new string[] { "59", "Employee Timesheets", "", "Select Employee" } },
                { "62", new string[] { "58", "Attendance " } },
                    { "63", new string[] { "62", "My Records", "h5", "My Attendance Records" } },
                    { "64", new string[] { "62", "Punch In/Out", "", "Punch (In|Out)" } },
                    { "65", new string[] { "62", "Employee Records", "h5", "Employee Attendance Records" } },
                    { "66", new string[] { "62", "Configuration", "", "Attendance Configuration" } },
                { "67", new string[] { "58", "Reports " } },
                    { "68", new string[] { "67", "Project Reports", "h5", "Project Report" } },
                    { "69", new string[] { "67", "Employee Reports", "h5", "Employee Report" } },
                    { "70", new string[] { "67", "Attendance Summary", "h5", "Attendance Total Summary Report" } },
                { "71", new string[] { "58", "Project Info " } },
                    { "72", new string[] { "71", "Customers", "", "" } },
                    { "73", new string[] { "71", "Projects", "h5", "" } },
            { "74", new string[] { "00", "Recruitment" } },
                { "75", new string[] { "74", "Candidates", "h5", "" } },
                { "76", new string[] { "74", "Vacancies", "h5", "" } },
            { "77", new string[] { "00", "Performance" } },
                { "78", new string[] { "77", "Configure " } },
                    { "79", new string[] { "78", "KPIs", "h5", "Key Performance Indicators for Job Title" } },
                    { "80", new string[] { "78", "Trackers", "h5", "Performance Trackers" } },
                { "81", new string[] { "77", "Manage Reviews " } },
                    { "82", new string[] { "81", "Manage Reviews", "h5", "Manage Performance Reviews" } },
                    { "83", new string[] { "81", "My Reviews", "", "" } },
                    { "84", new string[] { "81", "Employee Reviews", "h5", "" } },
                { "85", new string[] { "77", "My Trackers", "", "My Performance Trackers" } },
                { "86", new string[] { "77", "Employee Trackers", "h5", "Employee Performance Trackers" } },
            { "87", new string[] { "00", "Claim" } },
                { "88", new string[] { "87", "Configuration " } },
                    { "89", new string[] { "88", "Events", "h5", "" } },
                    { "90", new string[] { "88", "Expense Types", "h5", "" } },
                { "91", new string[] { "87", "Submit Claim", "", "Create Claim Request" } },
                { "92", new string[] { "87", "My Claims", "h5", "" } },
                { "93", new string[] { "87", "Employee Claims", "h5", "" } },
                { "94", new string[] { "87", "Assign Claim", "", "Create Claim Request" } }
        };

        public static Dictionary<string, string> getChildren(string parentId)
        {
            Dictionary<string, string> returnDictionary = new Dictionary<string, string>();
            foreach (string childId in allElements.Keys)
            {
                if (allElements[childId][0] == parentId)
                {
                    returnDictionary.Add(allElements[childId][1], childId);
                }
            }
            return returnDictionary;
        }

        public static string getElementSelector(string elementId)
        {
            return allElements.ContainsKey(elementId) ? $"{(allElements[elementId].Length == 4 ? "a" : "span")}[class='oxd-topbar-body-nav-tab-item']:text('{allElements[elementId][1]}')" : "";
        }

        public static string getSubelementSelector(string subelementId)
        {
            string returnValue = "";
            if (allElements.ContainsKey(subelementId) && allElements[subelementId].Length == 4)
            {
                returnValue = $"a[class='oxd-topbar-body-nav-tab-link']:text('{allElements[subelementId][1]}')";
            }
            return returnValue;
        }

        public static string getSubelementHeaderSelector(string subelementId)
        {
            string returnValue = "";
            if (allElements.ContainsKey(subelementId) && allElements[subelementId].Length == 4)
            {
                string[] details = allElements[subelementId];
                //returnValue = $"{(details[2] == "" ? "h6" : details[2])}.oxd-text:has-text('{(details[3] == "" ? details[1] : details[3])}')";
                returnValue = $"{(details[2] == "" ? "h6" : details[2])}.oxd-text:text-matches('{(details[3] == "" ? details[1] : details[3])}')";
            }
            return returnValue;
        }

        // Methods to interact with elements on the page
        public async Task GoToElementPageAsync(string elementId)
        {
            await _page.ClickAsync(getElementSelector(elementId));
        }

        // Methods to interact with elements on the page
        public async Task GoToSubelementPageAsync(string subelementId)
        {
            await _page.ClickAsync(getSubelementSelector(subelementId));
        }

        // Example verification method
        public async Task<bool> IsElementPageVisibleAsync(string elementId)
        {
            return await _page.IsVisibleAsync(getElementSelector(elementId));
        }

        public async Task<string> GetElementPageHeaderText(string elementId)
        {
            return await _page.InnerTextAsync(getElementSelector(elementId));
        }

        public async Task<string> GetSublementPageHeaderText(string subelementId)
        {
            return await _page.InnerTextAsync(getSubelementHeaderSelector(subelementId));
        }
    }
}