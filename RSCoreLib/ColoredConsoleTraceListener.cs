using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RSCoreLib
    {
    public class ColoredConsoleTraceListener : ConsoleTraceListener
        {
        Dictionary<TraceEventType, ConsoleColor> EventColors = new Dictionary<TraceEventType, ConsoleColor>();

        public ColoredConsoleTraceListener ()
            {
            EventColors.Add(TraceEventType.Verbose, ConsoleColor.DarkGray);
            //eventColor.Add(TraceEventType.Information, ConsoleColor.Gray); //Use default
            EventColors.Add(TraceEventType.Warning, ConsoleColor.Yellow);
            EventColors.Add(TraceEventType.Error, ConsoleColor.Red);
            EventColors.Add(TraceEventType.Critical, ConsoleColor.Magenta);
            EventColors.Add(TraceEventType.Start, ConsoleColor.DarkCyan);
            EventColors.Add(TraceEventType.Stop, ConsoleColor.DarkCyan);
            }

        public override void TraceEvent (TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
            {
            TraceEvent(eventCache, source, eventType, id, "{0}", message);
            }

        public override void TraceEvent (TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
            {
            ConsoleColor colorToUse;
            if(EventColors.TryGetValue(eventType, out colorToUse))
                {
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = colorToUse;
                base.TraceEvent(eventCache, source, eventType, id, format, args);
                Console.ForegroundColor = originalColor;
                return;
                }

            base.TraceEvent(eventCache, source, eventType, id, format, args);
            }
        }
    }
