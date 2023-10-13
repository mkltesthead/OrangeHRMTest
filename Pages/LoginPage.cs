namespace OrangeHRMTest.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        // Element locators
        private string UsernameFieldSelector => "[placeholder='username']";
        private string PasswordFieldSelector => "[placeholder='password']";
        private string LoginButtonSelector => ".oxd-button.orangehrm-login-button:text('Login')";
        private string DashboardHeadingSelector => "h6.oxd-text.oxd-text--h6.oxd-topbar-header-breadcrumb-module:text('Dashboard')";
        private string InvalidCredentialsMessageSelector => "p.oxd-text.oxd-text--p.oxd-alert-content-text:text('Invalid credentials')";

        public const string LoginUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";


        public async Task GoToLoginPage()
        {
            await _page.GotoAsync(LoginUrl);
        }

        public async Task EnterUsername(string username)
        {
            await _page.ClickAsync(UsernameFieldSelector);
            await _page.FillAsync(UsernameFieldSelector, username);
        }

        public async Task EnterPassword(string password)
        {
            await _page.ClickAsync(PasswordFieldSelector);
            await _page.FillAsync(PasswordFieldSelector, password);
        }
        public async Task ClickLogin()
        {
            await _page.WaitForSelectorAsync(LoginButtonSelector);
            await _page.ClickAsync(LoginButtonSelector);
        }
        public async Task WaitForDashboard()
        {
            await _page.WaitForSelectorAsync(DashboardHeadingSelector);
        }
        public async Task<bool> IsDashboardVisible()
        {
            var dashboardElement = await _page.QuerySelectorAsync(DashboardHeadingSelector);
            return dashboardElement != null;
        }

        public async Task<bool> IsInvalidCredentialsMessageDisplayed()
        {
            var invalidCredentialsElement = await _page.QuerySelectorAsync(InvalidCredentialsMessageSelector);
            return invalidCredentialsElement != null;
        }

        public async Task WaitForInvalidCredentialsMessage()
        {
            await _page.WaitForSelectorAsync(InvalidCredentialsMessageSelector);
        }

        public async Task Login(string username, string password, bool expectSuccess = true)
        {
            await EnterUsername(username);
            await EnterPassword(password);
            await ClickLogin();

            if (expectSuccess)
                await WaitForDashboard();
            // Optionally, you could wait for the error message if a successful login is not expected
            else
                await WaitForInvalidCredentialsMessage();
        }
    }
}