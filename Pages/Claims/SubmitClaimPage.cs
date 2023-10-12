namespace OrangeHRMTest.Pages.Claims
{
    internal class SubmitClaimPage
    {
        private readonly IPage _page;

        public SubmitClaimPage(IPage page)
        {
            _page = page;
        }

        // Define selectors for elements on the Submit Claim page  button.myClass:has-text("Submit")'
        private const string EventDropdownSelector = "div.oxd-select-text-input";
        private const string CountryDropDownSelector = "div.oxd-select-text-input";
        private const string RemarksSelector = "textarea";
        private const string SubmitButtonSelector = "button[type='submit']";

        private const string ReferenceIDLabelSelector = "Reference id";
        private const string ReferenceIDInputFieldSelector = "oxd-input oxd-input--active";

        // Methods to interact with elements
        public async Task FillOutSubmitClaimDetailsAsync(string eventName, string country, string remarks)
        {
            var eventdropwdown = _page.Locator(EventDropdownSelector).Nth(0);
            await eventdropwdown.ClickAsync();
            await _page.GetByText(eventName).ClickAsync();
            var countrydropwdown = _page.Locator(CountryDropDownSelector).Nth(1);
            await countrydropwdown.ClickAsync();
            await _page.GetByText(country).ClickAsync();
            await _page.FillAsync(RemarksSelector, remarks);
        }

        public async Task SubmitFormAsync()
        {
            await _page.ClickAsync(SubmitButtonSelector);
        }

        public async Task ValidateClaimCreated()
        {
            await _page.IsVisibleAsync(ReferenceIDLabelSelector);
            var referenceID = _page.Locator(ReferenceIDInputFieldSelector).Nth(1);
            //string? innervalue = referenceID.InnerTextAsync();
            Console.WriteLine(referenceID.InputValueAsync);

            Console.ReadKey();
        }
        // Add any additional methods or verifications as needed
    }
}

