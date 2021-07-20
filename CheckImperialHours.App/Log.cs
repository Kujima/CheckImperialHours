using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckImperialHours.App
{
    public static class Log
    {
        /// <summary>
        /// Permet d'afficher la date sur tous logs
        /// </summary>
        /// <param name="text"></param>
        public static void DisplayLog(string text)
        {
            Console.WriteLine(DateTime.Now + " - " + text);
        }

        /// <summary>
        /// Méthode permettant d'afficher le titre et la version de l'application 
        /// </summary>
        public static void DisplayIntro()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                      CheckImperialHours.App                       ");
            Console.WriteLine("                               V0.01                               ");
            Console.WriteLine("-------------------------------------------------------------------");
        }
    }
}
