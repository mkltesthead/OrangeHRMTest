namespace OrangeHRMTest.Pages
{
    public class AddEmployeePage
    {
        private readonly IPage _page;

        public AddEmployeePage(IPage page)
        {
            _page = page;
        }

        // Define selectors for elements on the Add Employee page
        private const string FirstNameSelector = "input[name='firstName']";
        private const string LastNameSelector = "input[name='lastName']";
        private const string EmailSelector = "input[name='email']";
        private const string SubmitButtonSelector = "button[type='submit']";

        // Methods to interact with elements
        public async Task FillOutEmployeeDetailsAsync(string firstName, string lastName, string email)
        {
            await _page.FillAsync(FirstNameSelector, firstName);
            await _page.FillAsync(LastNameSelector, lastName);
            await _page.FillAsync(EmailSelector, email);
        }

        public async Task SubmitFormAsync()
        {
            await _page.ClickAsync(SubmitButtonSelector);
        }

        // Add any additional methods or verifications as needed
    }

}