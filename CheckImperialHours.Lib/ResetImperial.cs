using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckImperialHours.Lib
{
    /// <summary>
    /// Class permettant de retourner les informations sur le prochain reset imperial
    /// </summary>
    public static class ResetImperial
    {
        #region Properties

        /// <summary>
        /// Contient les heures des reset sur une journée
        /// </summary>
        private static List<int> HourReset = new List<int>() { 2, 5, 8, 11, 14, 15, 17, 20, 23 };

        #endregion

        #region public methods

        /// <summary>
        /// Retourne l'heure du prochain reset
        /// </summary>
        /// <returns></returns>
        public static int GetNextHourReset()
        {
            int hourNextReset = 0;

            DateTime dateTime = DateTime.Now;
            int hourNow = dateTime.Hour;

            if (hourNow < 2 || hourNow == 23)
            {
                hourNextReset = 2;
            }
            else
            {
                for (int i = 0; i < HourReset.Count; i++)
                {
                    if (HourReset[i] <= hourNow && hourNow < HourReset[i + 1])
                    {
                        hourNextReset = HourReset[i + 1];
                        break;
                    }
                }
            }
            return hourNextReset;
        }

        /// <summary>
        /// Retourne le nombre de minutes en millisecondes à attendre avant la prochaine alerte
        /// </summary>
        /// <returns></returns>
        public static int GetTimeToSleepUntilNextWarning(int minuteUntilReset)
        {
            int timeUntilNextWarning = 0;

            // Récupération de l'heure courante
            DateTime dateTimeNow = DateTime.Now;

            // Récupération de l'heure du prochain warning 
            int hourNextReset = GetNextHourReset();
            int hourNextWarning = hourNextReset - 1;
            int minuteNextWarning = 60 - minuteUntilReset;


            if (dateTimeNow.Hour == 23)
            {
                timeUntilNextWarning = timeUntilNextWarning + (60 - dateTimeNow.Second);
                timeUntilNextWarning = timeUntilNextWarning + (59 - dateTimeNow.Minute);

                timeUntilNextWarning = timeUntilNextWarning + 3600;
                timeUntilNextWarning = timeUntilNextWarning + 45 * 60;

                return timeUntilNextWarning;
            }
            else
            {
                int totalSecNow = 0;
                totalSecNow = totalSecNow + dateTimeNow.Hour * 3600;
                totalSecNow = totalSecNow + dateTimeNow.Minute * 60;
                totalSecNow = totalSecNow + dateTimeNow.Second;

                int totalSecNextWarning = 0;
                totalSecNextWarning = totalSecNextWarning + hourNextWarning * 3600;
                totalSecNextWarning = totalSecNextWarning + minuteNextWarning * 60;

                // On regarde la différence entre les deux heures 
                timeUntilNextWarning = totalSecNextWarning - totalSecNow;
                timeUntilNextWarning = timeUntilNextWarning * 1000;

                return timeUntilNextWarning;
            }

            #endregion

        }
    }
}
