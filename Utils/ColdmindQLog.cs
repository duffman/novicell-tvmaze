// ColdmindQLog
//~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-
// Author : Patrik Forsberg
// Email  : patrik.forsberg@coldmind.com
// Date   : 2019-05-07
// GitHub : https://github.com/duffman
//
// <summary>
// Quick And Dirty Logging Service supporting CLI Colors
// for rich logging, all dependencies are contained in
// this single file for portability reasons.
//
// The lo11gger can be resolved from a container in DI
// environments but can also be used without an instance
// through the static functions
// </summary>
// <license>
// This software is subject to the LGPL v2 License, please
// find the full license attached in LICENCE.md
// </license>

using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;

namespace Coldmind.Utils
{
	public interface IColdmindQLog
	{
		void LogGreen(string label, object data);
		void LogMagenta(string label, object data);
		void Log(string label, object data);
	}

	public class ColdmindQLog : IColdmindQLog
	{
		private static double _startTick = 0;
		private static Stopwatch _stopWatch = new Stopwatch();
		private static bool _watchRunning = false;

		/// <summary>
		/// Stopwatch functionality used to measure execution times
		/// since this is statically typed only 
		/// </summary>
		public static void StartWatch()
		{
			_stopWatch.Restart();
		}

		public static void ShowStopwatchResult(string label = "")
		{
			_stopWatch.Stop();

			label = label.Length > 0 ? label : "Elapsed Time";
	
			TimeSpan ts = _stopWatch.Elapsed;

			var elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				ts.Hours, ts.Minutes, ts.Seconds,
				ts.Milliseconds / 10);
			
			var result = string.Format("{0} :: {0}", label, elapsedTime);
			
			LogGreen(result);
		}
		
		/// <summary>
		///     WriteLine with color
		/// </summary>
		/// <param name="text"></param>
		/// <param name="color"></param>
		public static void WriteLine(string text, ConsoleColor? color = null)
		{
			if (color.HasValue)
			{
				var oldColor = Console.ForegroundColor;
				if (color == oldColor)
				{
					Console.WriteLine(text);
				}
				else
				{
					Console.ForegroundColor = color.Value;
					Console.WriteLine(text);
					Console.ForegroundColor = oldColor;
				}
			}
			else
			{
				Console.WriteLine(text);
			}
		}

		/// <summary>
		///     Base method for color console logging
		/// </summary>
		/// <param name="label"></param>
		/// <param name="color"></param>
		/// <param name="data"></param>
		private static void baseLog(string label, ConsoleColor textColor,
			ConsoleColor backColor, object data = null)
		{
			var bgColor = Console.BackgroundColor;
			var fgColor = Console.ForegroundColor;

			Console.ForegroundColor = textColor;
			Console.BackgroundColor = backColor;

			var dataValue = data ?? string.Empty;

			try
			{
				if (!(data is string))
				{
					dataValue = data != null ? data.ToString() : "";
				}
				else
				{
					dataValue = JsonSerializer.Serialize(data);
				}
				
				Console.WriteLine($"{data} :: {dataValue}");
			}
			catch (Exception exception)
			{
				dataValue = "<INVALID PARAMETER>";
				Console.WriteLine("${data} :: {exception.Message}");
			}
			finally
			{
				Console.ForegroundColor = bgColor;
				Console.BackgroundColor = fgColor;
			}
		}


		/// <summary>
		/// Log green text
		/// </summary>
		/// <param name="label"></param>
		/// <param name="data"></param>
		public static void Log(string label, object data = null)
		{
			baseLog(label, Console.ForegroundColor, Console.BackgroundColor, data);
		}

		/// <summary>
		/// Log green text
		/// </summary>
		/// <param name="label"></param>
		/// <param name="data"></param>
		public static void LogGreen(string label, object data = null)
		{
			baseLog(label, ConsoleColor.Green, Console.BackgroundColor, data);
		}

		void IColdmindQLog.LogGreen(string label, object data)
		{
			LogGreen(label, data);
		}

		/// <summary>
		/// Log Magenta text
		/// </summary>
		/// <param name="label"></param>
		/// <param name="data"></param>
		public void LogMagenta(string label, object data = null)
		{
			baseLog(label, ConsoleColor.Magenta, Console.BackgroundColor, data);
		}

		void IColdmindQLog.Log(string label, object data)
		{
			Log(label, data);
		}

		/// <summary>
		///     Writes out a line with a specific color as a string
		/// </summary>
		/// <param name="text">Text to write</param>
		/// <param name="color">A console color. Must match ConsoleColors collection names (case insensitive)</param>
		public static void WriteLine(string text, string color)
		{
			if (string.IsNullOrEmpty(color))
			{
				WriteLine(text);
				return;
			}

			if (!Enum.TryParse(color, true, out ConsoleColor col))
				WriteLine(text);
			else
				WriteLine(text, col);
		}

		/// <summary>
		///     Write with color
		/// </summary>
		/// <param name="text"></param>
		/// <param name="color"></param>
		public static void Write(string text, ConsoleColor? color = null)
		{
			if (color.HasValue)
			{
				var oldColor = Console.ForegroundColor;
				if (color == oldColor)
				{
					Console.Write(text);
				}
				else
				{
					Console.ForegroundColor = color.Value;
					Console.Write(text);
					Console.ForegroundColor = oldColor;
				}
			}
			else
			{
				Console.Write(text);
			}
		}

		/// <summary>
		///     Writes out a line with color specified as a string
		/// </summary>
		/// <param name="text">Text to write</param>
		/// <param name="color">A console color. Must match ConsoleColors collection names (case insensitive)</param>
		public static void Write(string text, string color)
		{
			if (string.IsNullOrEmpty(color))
			{
				Write(text);
				return;
			}

			if (!Enum.TryParse(color, true, out ConsoleColor col))
				Write(text);
			else
				Write(text, col);
		}

		#region Wrappers and Templates

		/// <summary>
		///     Writes a line of header text wrapped in a in a pair of lines of dashes:
		///     -----------
		///     Header Text
		///     -----------
		///     and allows you to specify a color for the header. The dashes are colored
		/// </summary>
		/// <param name="headerText">Header text to display</param>
		/// <param name="wrapperChar">wrapper character (-)</param>
		/// <param name="headerColor">Color for header text (yellow)</param>
		/// <param name="dashColor">Color for dashes (gray)</param>
		public static void WriteWrappedHeader(string headerText,
			char wrapperChar = '-',
			ConsoleColor headerColor = ConsoleColor.Yellow,
			ConsoleColor dashColor = ConsoleColor.DarkGray)
		{
			if (string.IsNullOrEmpty(headerText))
				return;

			var line = new string(wrapperChar, headerText.Length);

			WriteLine(line, dashColor);
			WriteLine(headerText, headerColor);
			WriteLine(line, dashColor);
		}

		private static readonly Lazy<Regex> colorBlockRegEx = new Lazy<Regex>(
			() => new Regex("\\[(?<color>.*?)\\](?<text>[^[]*)\\[/\\k<color>\\]", RegexOptions.IgnoreCase),
			true);

		/// <summary>
		///     Allows a string to be written with embedded color values using:
		///     This is [red]Red[/red] text and this is [cyan]Blue[/blue] text
		/// </summary>
		/// <param name="text">Text to display</param>
		/// <param name="baseTextColor">Base text color</param>
		public static void WriteEmbeddedColorLine(string text, ConsoleColor? baseTextColor = null)
		{
			if (baseTextColor == null)
				baseTextColor = Console.ForegroundColor;

			if (string.IsNullOrEmpty(text))
			{
				WriteLine(string.Empty);
				return;
			}

			var at = text.IndexOf("[");
			var at2 = text.IndexOf("]");
			if (at == -1 || at2 <= at)
			{
				WriteLine(text, baseTextColor);
				return;
			}

			while (true)
			{
				var match = colorBlockRegEx.Value.Match(text);
				if (match.Length < 1)
				{
					Write(text, baseTextColor);
					break;
				}

				// write up to expression
				Write(text.Substring(0, match.Index), baseTextColor);

				// strip out the expression
				var highlightText = match.Groups["text"].Value;
				var colorVal = match.Groups["color"].Value;

				Write(highlightText, colorVal);

				// remainder of string
				text = text.Substring(match.Index + match.Value.Length);
			}

			Console.WriteLine();
		}

		#endregion

		#region Success, Error, Info, Warning Wrappers

		/// <summary>
		///     Write a Success Line - green
		/// </summary>
		/// <param name="text">Text to write out</param>
		public static void WriteSuccess(string text)
		{
			WriteLine(text, ConsoleColor.Green);
		}

		/// <summary>
		///     Write a Error Line - Red
		/// </summary>
		/// <param name="text">Text to write out</param>
		public static void WriteError(string text)
		{
			WriteLine(text, ConsoleColor.Red);
		}

		/// <summary>
		///     Write a Warning Line - Yellow
		/// </summary>
		/// <param name="text">Text to Write out</param>
		public static void WriteWarning(string text)
		{
			WriteLine(text, ConsoleColor.DarkYellow);
		}


		/// <summary>
		///     Write a Info Line - dark cyan
		/// </summary>
		/// <param name="text">Text to write out</param>
		public static void WriteInfo(string text)
		{
			WriteLine(text, ConsoleColor.DarkCyan);
		}

		#endregion

		public void LogException(string label, Exception exception)
		{
			var bgColor = Console.BackgroundColor;
			var fgColor = Console.ForegroundColor;

			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;

			Console.WriteLine($"{label} ::: {exception.Message}");

			Console.BackgroundColor = bgColor;
			Console.ForegroundColor = fgColor;
		}
	}
}