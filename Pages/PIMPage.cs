namespace OrangeHRMTest.Pages
{
    public class PIMPage
    {
        private readonly IPage _page;

        public PIMPage(IPage page)
        {
            _page = page;
        }

        // Define selectors for elements on the PIM page
        private const string EmployeeListSelector = "a[class='oxd-topbar-body-nav-tab-item']:text('Employee List')";
        private const string AddEmployeeSelector = "a[class='oxd-topbar-body-nav-tab-item']:text('Add Employee')";
        private const string ReportsSelector = "a[class='oxd-topbar-body-nav-tab-item']:text('Reports')";

        // Methods to interact with elements on the page
        public async Task GoToEmployeeListPageAsync()
        {
            await _page.ClickAsync(EmployeeListSelector);
        }

        public async Task GoToAddEmployeePageAsync()
        {
            await _page.ClickAsync(AddEmployeeSelector);
        }

        public async Task GoToReportsPageAsync()
        {
            await _page.ClickAsync(ReportsSelector);
        }

        // Example verification method
        public async Task<bool> IsEmployeeListPageVisibleAsync()
        {
            return await _page.IsVisibleAsync(EmployeeListSelector);
        }

        public async Task<string> GetEmployeeListPageHeaderText()
        {
            return await _page.InnerTextAsync(PIMPage.EmployeeListSelector);
        }

        public async Task<bool> IsAddEmployeePageVisibleAsync()
        {
            return await _page.IsVisibleAsync(AddEmployeeSelector);
        }

        public async Task<string> GetAddEmployeePageHeaderText()
        {
            return await _page.InnerTextAsync(PIMPage.AddEmployeeSelector);
        }

        public async Task<bool> IsReportsPageVisibleAsync()
        {
            return await _page.IsVisibleAsync(ReportsSelector);
        }

        public async Task<string> GetReportsPageHeaderText()
        {
            return await _page.InnerTextAsync(PIMPage.ReportsSelector);
        }
        // Add more methods for other interactions and verifications as needed
    }
}
