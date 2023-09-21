namespace OrangeHRMTests
{

    public class DashboardPage
    {
        private readonly IPage _page;

        public DashboardPage(IPage page)
        {
            _page = page;
        }

        public async Task Navigate()
        {
            await _page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index");
        }

        // Side panel menu items
        public async Task ClickOnMenuItem(string menuItemName)
        {
            await _page.ClickAsync($"text={menuItemName}");
        }

        // Brand logo
        public async Task<bool> IsBrandLogoVisible()
        {
            return await _page.IsVisibleAsync("src=\"/web/images/orange.png?v=1689053487449\"");
        }

        // Logout
        public async Task Logout()
        {
            await _page.ClickAsync("css_selector_for_logout"); // Replace with the appropriate selector
        }

        // Support
        public async Task OpenSupport()
        {
            await _page.ClickAsync("css_selector_for_support"); // Replace with the appropriate selector
        }

        // Update password
        public async Task OpenUpdatePasswordPage()
        {
            await _page.ClickAsync("css_selector_for_update_password"); // Replace with the appropriate selector
        }

        // Check if on Dashboard view
        public async Task<bool> IsOnDashboardView()
        {
            return await _page.IsVisibleAsync("view-dashboard");
        }

        // ... more methods based on further interactions or validations.
    }
}