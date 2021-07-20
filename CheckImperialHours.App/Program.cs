using System;
using System.Collections.Generic;
using System.Threading;

namespace CheckImperialHours.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.DisplayIntro();
            int time = 0;

            while (true)
            {
                Log.DisplayLog($"Le prochaine reset sera à {ResetImperial.GetNextHourReset()} heure");

                // Message 15min avant le prochain reset 
                time = 15;
                Thread.Sleep(ResetImperial.GetTimeToSleepUntilNextWarning(15));
                Log.DisplayLog($"!piano @Shallik  ATTENTION, prochain reset impérial dans {time} minutes, {time} minutes !!");

                // Message 5min avant le prochain reset 
                time = 5;
                Thread.Sleep(ResetImperial.GetTimeToSleepUntilNextWarning(5));
                Log.DisplayLog($"!piano @Shallik  ATTENTION, prochain reset impérial dans {time} minutes, {time} minutes !!");

                // Message lors du prochain reset 
                Thread.Sleep(ResetImperial.GetTimeToSleepUntilNextWarning(0));
                Log.DisplayLog($"!piano @Shallik  C'EST L'HEURE DU RESET IMPERIAL !!");
            }
        }
    }
}