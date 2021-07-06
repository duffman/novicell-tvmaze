/**
 *  
 *  Simple logging class for logging data
 *  to the CLI
 */

using System;
using Microsoft.Extensions.Logging;
using TheMaze.Utils.Logging;

namespace TheMaze.Utils
{
    public interface ILogger
    {
        public void logGreen(string label, Object data);
        public void logPurple(string label, Object data);
    }
}
