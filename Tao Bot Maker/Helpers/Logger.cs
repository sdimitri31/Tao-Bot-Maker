using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Tao_Bot_Maker.Controller;
using Tao_Bot_Maker.Model;

namespace Tao_Bot_Maker.Helpers
{
    public static class Logger
    {
        private static readonly object lockObject = new object();
        public const string FOLDER_NAME = "Logs"; 
        private static readonly string logFilePath = Path.Combine(FOLDER_NAME, $"{DateTime.Now:yyyy-MM-dd}.log");

        public static event Action<string, TraceEventType> LogMessageReceived;

        public static void Log(string message, TraceEventType level = TraceEventType.Information)
        {
            string logEntry = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss.fff} [{level}]: {message}";
            Console.WriteLine(logEntry);

            int flagShowLevel = SettingsController.GetSettingValue<int>(Settings.SETTING_SHOWLOGLEVEL);
            if (IsLevelEnabled(level, flagShowLevel))
                LogMessageReceived?.Invoke(logEntry, level);

            bool isSaveLog = SettingsController.GetSettingValue<bool>(Settings.SETTING_SAVELOG);
            int flagSaveLevel = SettingsController.GetSettingValue<int>(Settings.SETTING_SAVELOGLEVEL);
            if (isSaveLog && IsLevelEnabled(level, flagSaveLevel)) 
                Write(logEntry);
        }

        private static bool IsLevelEnabled(TraceEventType level, int flag)
        {
            switch (level)
            {
                case TraceEventType.Information:
                    return (flag & 1) != 0;
                case TraceEventType.Warning:
                    return (flag & 2) != 0;
                case TraceEventType.Error:
                    return (flag & 4) != 0;
                case TraceEventType.Verbose:
                    return (flag & 8) != 0;
                default:
                    return true;
            }
        }

        private static void Write(string logEntry)
        {
            lock (lockObject)
            {
                try
                {
                    // Ensure the logs directory exists
                    if (!Directory.Exists(FOLDER_NAME))
                    {
                        Directory.CreateDirectory(FOLDER_NAME);
                    }

                    // Append the log entry to the file
                    File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to write log entry: {ex.Message}");
                }
            }
        }

    }
}
