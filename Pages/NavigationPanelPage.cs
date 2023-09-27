namespace OrangeHRMTest.Pages
{
    public class NavigationPanelPage
    {
        private readonly IPage _page;

        // Define Selectors for the elements in the navigation panel

        public const string AdminSelector = "text=Admin";
        public const string AdminHeaderSelector = "h6.oxd-text:has-text('Admin')";

        public const string DirectorySelector = "text=Directory";
        public const string DirectoryHeaderSelector = "h6.oxd-text:has-text('Directory')";

        public const string DashboardSelector = "text=Dashboard";
        public const string DashboardHeaderSelector = "h6.oxd-text:has-text('Dashboard')";

        public const string PIMSelector = "text=PIM";
        public const string PIMHeaderSelector = "h6.oxd-text:has-text('PIM')";

        public const string LeaveSelector = "text=Leave";
        public const string LeaveHeaderSelector = "h6.oxd-text:has-text('Leave')";

        public const string TimeSelector = "text=Time";
        public const string TimeHeaderSelector = "h6.oxd-text:has-text('Time')";

        public NavigationPanelPage(IPage page)
        {
            _page = page;
        }

        // Admin Element Methods
        public async Task GoToAdminPageAsync()
        {
            await _page.ClickAsync(AdminSelector);
        }
        public async Task<bool> IsAdminHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(AdminHeaderSelector);
        }

        // Directory Element Methods
        public async Task GoToDirectoryPageAsync()
        {
            await _page.ClickAsync(DirectorySelector);
        }
        public async Task<bool> IsDirectoryHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(DirectoryHeaderSelector);
        }

        // Dashboard Element Methods
        public async Task GoToDashboardPageAsync()
        {
            await _page.ClickAsync(DashboardSelector);
        }
        public async Task<bool> IsDashboardHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(DashboardHeaderSelector);
        }

        // PIM Element Methods
        public async Task GoToPIMPageAsync()
        {
            await _page.ClickAsync(PIMSelector);
        }
        public async Task<bool> IsPIMHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(PIMHeaderSelector);
        }

        // Leave Element Methods
        public async Task GoToLeavePageAsync()
        {
            await _page.ClickAsync(LeaveSelector);
        }
        public async Task<bool> IsLeaveHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(LeaveHeaderSelector);
        }
        // ... more methods based on further interactions or validations.

        // Time Element Methods
        public async Task GoToTimePageAsync()
        {
            await _page.ClickAsync(TimeSelector);
        }
        public async Task<bool> IsTimeHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(TimeHeaderSelector);
        }
    }
}
