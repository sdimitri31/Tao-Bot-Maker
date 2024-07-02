using System;
using System.Diagnostics;

namespace Tao_Bot_Maker.Helpers
{
    public static class Logger
    {
        public static event Action<string, TraceEventType> LogMessageReceived;

        // Méthode pour ajouter des messages de log avec un niveau
        public static void Log(string message, TraceEventType level = TraceEventType.Information)
        {
            // Ajouter un timestamp et le niveau au message de log
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}]: {message}";
            Console.WriteLine(logEntry);

            // Déclencher l'événement
            LogMessageReceived?.Invoke(logEntry, level);
        }
    }
}
