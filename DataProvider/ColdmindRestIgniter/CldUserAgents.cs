using System.Collections.Generic;

namespace TvMazeWebApp.DataProvider.ColdmindRestIgniter
{
    public static class CldUserAgents
    {
        public enum Agent
        {
            ColdmindRC,
            Chrome,
            Firefox,
            Edge,
            IE_6,
            IE_7,
            IE_8,
            IE_9,
            IE_10,
            IE_11,
            iPad,
            iPhone,
            Google_Bot,
            Bing_Bot,
            Samsung_Phone,
            Samsung_Galaxy_Note_3,
            Samsung_Galaxy_Note_4,
            Nexus,
            HTC,
            Curl,
            WGet,
            Lynx,
            Pippi_Longstocking
        }

        public static Dictionary<Agent, string> UserAgents = new Dictionary<Agent, string>
        {
            {Agent.ColdmindRC, "Coldmind HTTP Client/0.7.2"},
            {
                Agent.Chrome,
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36"
            },
            {Agent.Firefox, "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:53.0) Gecko/20100101 Firefox/53.0"},
            {
                Agent.Edge,
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393"
            },
            {Agent.IE_6, "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1)"},
            {Agent.IE_7, "Mozilla/5.0 (Windows; U; MSIE 7.0; Windows NT 6.0; en-US)"},
            {
                Agent.IE_8,
                "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)"
            },
            {Agent.IE_9, "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.0; Trident/5.0;  Trident/5.0)"},
            {Agent.IE_10, "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0; MDDCJS)"},
            {Agent.IE_11, "Mozilla/5.0 (compatible, MSIE 11, Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko"},
            {
                Agent.iPad,
                "Mozilla/5.0 (iPad; CPU OS 8_4_1 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Version/8.0 Mobile/12H321 Safari/600.1.4"
            },
            {
                Agent.iPhone,
                "Mozilla/5.0 (iPhone; CPU iPhone OS 10_3_1 like Mac OS X) AppleWebKit/603.1.30 (KHTML, like Gecko) Version/10.0 Mobile/14E304 Safari/602.1"
            },
            {Agent.Google_Bot, "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)"},
            {Agent.Bing_Bot, "Mozilla/5.0 (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)"},
            {
                Agent.Samsung_Phone,
                "Mozilla/5.0 (Linux; Android 6.0.1; SAMSUNG SM-G570Y Build/MMB29K) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/44.0.2403.133 Mobile Safari/537.36"
            },
            {
                Agent.Samsung_Galaxy_Note_3,
                "Mozilla/5.0 (Linux; Android 5.0; SAMSUNG SM-N900 Build/LRX21V) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/2.1 Chrome/34.0.1847.76 Mobile Safari/537.36"
            },
            {
                Agent.Samsung_Galaxy_Note_4,
                "Mozilla/5.0 (Linux; Android 6.0.1; SAMSUNG SM-N910F Build/MMB29M) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/44.0.2403.133 Mobile Safari/537.36"
            },
            {
                Agent.Nexus,
                "Mozilla/5.0 (Linux; U; Android-4.0.3; en-us; Galaxy Nexus Build/IML74K) AppleWebKit/535.7 (KHTML, like Gecko) CrMo/16.0.912.75 Mobile Safari/535.7"
            },
            {
                Agent.HTC,
                "Mozilla/5.0 (Linux; Android 7.0; HTC 10 Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.83 Mobile Safari/537.36"
            },
            {Agent.Curl, "curl/7.35.0"},
            {Agent.WGet, "Wget/1.15 (linux-gnu)"},
            {Agent.Lynx, "Lynx/2.8.8pre.4 libwww-FM/2.14 SSL-MM/1.4.1 GNUTLS/2.12.23"},
            {Agent.Pippi_Longstocking, "Pippi Longstocking/1.6 ALPHA"}
        };


        public static string GetElementAt(Agent agent, int idx)
        {
            /* for (int i = 0; i < UserAgents.Count; i++)
             {
                 foreach (var pair in UserAgents)
                 {
                     sum += pair.Value;
                 }
             }
            */

            return "Kalle";
        }


        public static string AsString(this Agent value)
        {
            var index = (int) value;
            return index > -1 && index < UserAgents.Count ? GetElementAt(value, index) : null;
        }
    }
}