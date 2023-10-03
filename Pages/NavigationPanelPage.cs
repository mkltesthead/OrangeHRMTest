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
            if (screens.ContainsKey(screen))
                return $"text={screen}";
            else
                return "";
        }

        public static string getHeaderSelector(string screen)
        {
            if (screens.ContainsKey(screen))
                return $"h6.oxd-text:has-text('{(screens[screen] == "" ? screen : screens[screen])}')";
            else
                return "";
        }

        public async Task GoToPageAsyncDict(string screen)
        {
            await _page.ClickAsync(getScreenSelector(screen));
        }

        public async Task<bool> IsHeaderVisibleAsyncDict(string screen)
        {
            return await _page.IsVisibleAsync(getHeaderSelector(screen));
        }
    }
}