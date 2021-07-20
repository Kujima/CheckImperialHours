using CheckImperialHours.Lib;
using CheckImperialHours.TwitchBot;
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

            // Création du bot 
            Bot bot = new Bot();
            bot.Connect();

            while (true)
            {
                // Message 15min avant le prochain reset 
                time = 15;
                Thread.Sleep(ResetImperial.GetTimeToSleepUntilNextWarning(15));
                bot.WarningReset(15);

                // Message 5min avant le prochain reset 
                time = 5;
                Thread.Sleep(ResetImperial.GetTimeToSleepUntilNextWarning(5));
                bot.WarningReset(5);

                // Message lors du prochain reset 
                Thread.Sleep(ResetImperial.GetTimeToSleepUntilNextWarning(0));
                bot.WarningReset(0);
            }
        }
    }
}