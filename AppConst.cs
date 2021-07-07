using UserAgent = TvMazeWebApp.DataProvider.ColdmindRestIgniter.CldUserAgents.Agent;

namespace TvMazeWebApp
{
    public class AppConst
    {
        public const string DB_NAME = "themaze.db";

        public enum LogLevel
        {
            None,
            Warnings,
            Minimal,
            Verbose,
        }

        /// <summary>
        /// Default user agent for Rest Consumer Client
        /// </summary>
        public const UserAgent DEFAULT_USER_AGENT = UserAgent.Chrome;
    }
}
