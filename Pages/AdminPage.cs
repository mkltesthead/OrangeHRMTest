﻿namespace OrangeHRMTest.Pages
{
    public class AdminPage
    {
        private readonly IPage _page;

        public AdminPage(IPage page)
        {
            _page = page;
        }

        public static Dictionary<string, string> elements = new Dictionary<string, string>() {
            {"Nationalities"     , ""},
            {"Corporate Branding", ""}
        };

        public static string getElementSelector(string element)
        {
            return elements.ContainsKey(element) ? $"a[class='oxd-topbar-body-nav-tab-item']:text('{element}')" : "";
        }

        // Methods to interact with elements on the page
        public async Task GoToElementPageAsync(string element)
        {
            await _page.ClickAsync(getElementSelector(element));
        }

        // Example verification method
        public async Task<bool> IsElementPageVisibleAsync(string element)
        {
            return await _page.IsVisibleAsync(getElementSelector(element));
        }

        public async Task<string> GetElementPageHeaderText(string element)
        {
            return await _page.InnerTextAsync(getElementSelector(element));
        }
    }
}
