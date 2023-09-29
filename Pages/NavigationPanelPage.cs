namespace OrangeHRMTest.Pages
{
    public class NavigationPanelPage
    {
        private readonly IPage _page;

        // Define Selectors for the elements in the navigation panel

        public const string AdminSelector = "text=Admin";
        public const string AdminHeaderSelector = "h6.oxd-text:has-text('Admin')";

        public const string PIMSelector = "text=PIM";
        public const string PIMHeaderSelector = "h6.oxd-text:has-text('PIM')";

        public const string LeaveSelector = "text=Leave";
        public const string LeaveHeaderSelector = "h6.oxd-text:has-text('Leave')";

        public const string TimeSelector = "text=Time";
        public const string TimeHeaderSelector = "h6.oxd-text:has-text('Time')";

        public const string RecruitmentSelector = "text=Recruitment";
        public const string RecruitmentHeaderSelector = "h6.oxd-text:has-text('Recruitment')";

        public const string MyInfoSelector = "text=My Info";
        public const string MyInfoHeaderSelector = "h6.oxd-text:has-text('PIM')";

        public const string PerformanceSelector = "text=Performance";
        public const string PerformanceHeaderSelector = "h6.oxd-text:has-text('Performance')";

        public const string DashboardSelector = "text=Dashboard";
        public const string DashboardHeaderSelector = "h6.oxd-text:has-text('Dashboard')";

        public const string DirectorySelector = "text=Directory";
        public const string DirectoryHeaderSelector = "h6.oxd-text:has-text('Directory')";

        public const string MaintenanceSelector = "text=Maintenance";
        public const string MaintenanceHeaderSelector = "h6.oxd-text:has-text('Administrator Access')";

        public const string ClaimSelector = "text=Claim";
        public const string ClaimHeaderSelector = "h6.oxd-text:has-text('Claim')";

        public const string BuzzSelector = "text=Buzz";
        public const string BuzzHeaderSelector = "h6.oxd-text:has-text('Buzz')";

        public NavigationPanelPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToPageAsync(string elementSelector)
        {
            await _page.ClickAsync(elementSelector);
        }

        public async Task<bool> IsHeaderVisibleAsync(string elementHeaderSelector)
        {
            return await _page.IsVisibleAsync(elementHeaderSelector);
        }
    }
}