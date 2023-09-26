namespace OrangeHRMTests
{

    public class Navigation
    {
        private readonly IPage _page;

        public DashboardPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToAdmin()
        {
            await _page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index");
        }

        // Check if on Dashboard view
        public async Task<bool> IsOnDashboardView()
        {
            return await _page.IsVisibleAsync("view-dashboard");
        }

        // ... more methods based on further interactions or validations.
    }
}
