namespace OrangeHRMTest.Pages.PIM
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
        private const string UpdateFirstNameSelector = "input[placeholder='Type for hints...']";
        private const string DeleteButtonSelector = "button[class='oxd-icon-button oxd-table-cell-action-space']";

        // Methods to interact with elements
        public async Task FillOutEmployeeDetailsAsync(string firstName, string lastName)
        {
            await _page.FillAsync(FirstNameSelector, firstName);
            await _page.FillAsync(LastNameSelector, lastName);
            //await _page.FillAsync(EmailSelector, email);
        }

        public async Task SubmitFormAsync()
        {
            await _page.ClickAsync(SubmitButtonSelector);
        }
        public async Task DeleteButtonAsync()
        {
            await _page.ClickAsync(DeleteButtonSelector);
        }
        public async Task UpdateEmployeeDetailsAsync(string firstName)
        {
            await _page.FillAsync(UpdateFirstNameSelector, firstName);
        }

        public async Task FillOutEditEmployeeDetailsAsync(string firstName1)
        {
            await _page.FillAsync(FirstNameSelector, firstName1);
        }
    }
}