namespace OrangeHRMTest.Pages
{
    public class NavigationPanelPage
    {
        private readonly IPage? _page;

        public NavigationPanelPage(IPage page)
        {
            _page = page;
        }

        public static Dictionary<string, string> screens = new Dictionary<string, string>() {
            {"Admin"      , ""                    },
            {"PIM"        , ""                    },
            {"Leave"      , ""                    },
            {"Time"       , ""                    },
            {"Recruitment", ""                    },
            {"My Info"    , "PIM"                 },
            {"Performance", ""                    },
            {"Dashboard"  , ""                    },
            {"Directory"  , ""                    },
            {"Maintenance", "Administrator Access"},
            {"Claim"      , ""                    },
            {"Buzz"       , ""                    }
        };

        public static string getScreenSelector(string screen)
        {
            return screens.ContainsKey(screen) ? $"text={screen}" : "";
        }

        public static string getHeaderSelector(string screen)
        {
            return screens.ContainsKey(screen) ? $"h6.oxd-text:has-text('{(screens[screen] == "" ? screen : screens[screen])}')" : "";
        }

        public async Task GoToPageAsync(string screen)
        {
            await _page.ClickAsync(getScreenSelector(screen));
        }

        public async Task<bool> IsHeaderVisibleAsync(string screen)
        {
            return await _page.IsVisibleAsync(getHeaderSelector(screen));
        }
    }
}