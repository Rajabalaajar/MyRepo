using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace _2c2pAssignment.Logger
{
    public class AppLogger
    {
        static string LogFile = "";
        static string TraceFile = "";
        static Timer timer = new Timer();
        public static void InitilizeLogger()
        {
            string LogFolder = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(LogFolder))
            {
                Directory.CreateDirectory(LogFolder);
            }
            LogFile = LogFolder + "\\Log_" + DateTime.Now.Ticks.ToString() + ".txt";
            TraceFile = LogFolder + "\\Trace_" + DateTime.Now.Ticks.ToString() + ".txt";
            timer.Interval = 400000;
            timer.Elapsed += Timer_Elapsed;
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string Dir = Path.GetDirectoryName(LogFile);
            string FileNameLog = Dir + "\\Log_" + DateTime.Now.Ticks.ToString() + ".txt";
            string FileNameTrace = Dir + "\\Trace_" + DateTime.Now.Ticks.ToString() + ".txt";
            File.Create(FileNameLog);
            File.Create(FileNameTrace);
            LogFile = FileNameLog;
            TraceFile = FileNameTrace;
        }

        public static void Log(Exception ex)
        {
            File.AppendAllText(LogFile, DateTime.Now.ToString() + "****************Exception***************\r\n");
            File.AppendAllText(LogFile, ex.Message + "\r\n");
            File.AppendAllText(LogFile, ex.StackTrace + "\r\n");
        }
        public static void Trace(string ex)
        {
            File.AppendAllText(LogFile, DateTime.Now.ToString() + ex + "\r\n");
        }
    }
}
