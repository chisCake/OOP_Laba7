using System;
using System.Collections.Generic;
using System.IO;

namespace OOP_Laba7 {
	public enum LogType {
		INFO,
		WARNING,
		EXCEPTION
	}

	class Logger {
		public static bool isRunning = false;

		public static void Init() {
			if (!isRunning)
				isRunning = true;
		}

		public static void Log(string msg, LogType type = LogType.INFO, Dictionary<string, string> data = null) {
			using var sw = new StreamWriter("info.log", true);
			string date = DateTime.Now.ToString("G");
			string msgType = type switch
			{
				LogType.INFO => "INFO",
				LogType.WARNING => "WARNING",
				LogType.EXCEPTION => "EXCEPTION",
				_ => "UNKNOWN",
			};
			sw.WriteLine($"{date}, {msgType}: {msg}");
			if (isRunning)
				Console.WriteLine($"{date}, {msgType}: {msg}");
			if (data != null && data.Count != 0) {
				foreach (var item in data) {
					sw.WriteLine($"\t{item.Key}: {item.Value}");
					if (isRunning)
						Console.WriteLine($"\t{item.Key}: {item.Value}");
				}
			}
		}

		public static void Log(Exception exception) {
			using var sw = new StreamWriter("info.log", true);
			string date = DateTime.Now.ToString("G");
			sw.WriteLine($"{date}, EXCEPTION:\n\t{exception.Message}\n{exception.StackTrace}");
			if (isRunning)
				Console.WriteLine($"{date}, EXCEPTION:\n\t{exception.Message}\n{exception.StackTrace}");
		}
	}
}
