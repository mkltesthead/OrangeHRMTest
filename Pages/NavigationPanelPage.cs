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

        // Admin Element Methods
        public async Task GoToAdminPageAsync()
        {
            await _page.ClickAsync(AdminSelector);
        }
        public async Task<bool> IsAdminHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(AdminHeaderSelector);
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

        // Time Element Methods
        public async Task GoToTimePageAsync()
        {
            await _page.ClickAsync(TimeSelector);
        }
        public async Task<bool> IsTimeHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(TimeHeaderSelector);
        }

        // Recruitment Element Methods
        public async Task GoToRecruitmentPageAsync()
        {
            await _page.ClickAsync(RecruitmentSelector);
        }
        public async Task<bool> IsRecruitmentHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(RecruitmentHeaderSelector);
        }

        // My Info Element Methods
        public async Task GoToMyInfoPageAsync()
        {
            await _page.ClickAsync(MyInfoSelector);
        }
        public async Task<bool> IsMyInfoHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(MyInfoHeaderSelector);
        }

        // My Info Element Methods
        public async Task GoToPerformancePageAsync()
        {
            await _page.ClickAsync(PerformanceSelector);
        }
        public async Task<bool> IsPerformanceHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(PerformanceHeaderSelector);
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

        // Directory Element Methods
        public async Task GoToDirectoryPageAsync()
        {
            await _page.ClickAsync(DirectorySelector);
        }
        public async Task<bool> IsDirectoryHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(DirectoryHeaderSelector);
        }

        // Maintenance Element Methods
        public async Task GoToMaintenancePageAsync()
        {
            await _page.ClickAsync(MaintenanceSelector);
        }
        public async Task<bool> IsMaintenanceHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(MaintenanceHeaderSelector);
        }

        // Claim Element Methods
        public async Task GoToClaimPageAsync()
        {
            await _page.ClickAsync(ClaimSelector);
        }
        public async Task<bool> IsClaimHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(ClaimHeaderSelector);
        }

        // Buzz Element Methods
        public async Task GoToBuzzPageAsync()
        {
            await _page.ClickAsync(BuzzSelector);
        }
        public async Task<bool> IsBuzzHeaderVisibleAsync()
        {
            return await _page.IsVisibleAsync(BuzzHeaderSelector);
        }
    }
}
