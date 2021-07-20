using CheckImperialHours.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace CheckImperialHours.TwitchBot
{
    public class Bot
    {
        #region Properties

        /// <summary>
        /// chaine de connection du bot
        /// </summary>
        private ConnectionCredentials creds = new ConnectionCredentials(TwitchInfo.ChannelName, TwitchInfo.BotToken);

        /// <summary>
        /// Client twitch
        /// </summary>
        private TwitchClient Client;

        #endregion

        #region Public methods

        /// <summary>
        /// Connecter le bot au channel de la chaine twitch
        /// </summary>
        public void Connect()
        {

            Client = new TwitchClient();
            Client.Initialize(creds, TwitchInfo.ChannelName);
            Client.OnChatCommandReceived += Client_OnChatCommandReceived;

            Client.Connect();
            Client.OnConnected += Client_OnConnected;
        }



        /// <summary>
        /// Déconnecter le bot du channel de la chaine twitch
        /// </summary>
        public void Disconnet()
        {
            Client.Disconnect();
        }

        /// <summary>
        /// Envoie un message dans le chat alertant que le prochain reset est dans tant de temps
        /// </summary>
        /// <param name="minuteUtilReset"></param>
        public void WarningReset(int minuteUtilReset)
        {
            string msg = ""; 

            if (minuteUtilReset == 0)
            {
                 msg = $"!piano @SHALLIK  C'EST L'HEURE DU RESET IMPERIAL !!";
            }
            else
            {
                msg = $"!piano @SHALLIK ATTENTION, prochain reset impérial dans{minuteUtilReset} minutes, {minuteUtilReset} minutes !!";                  
            }
            Client.SendMessage(TwitchInfo.ChannelName, msg);
            DisplayLog($"Message send : {msg}");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Permet d'afficher la date sur tous logs
        /// </summary>
        /// <param name="text"></param>
        private void DisplayLog(string text)
        {
            Console.WriteLine(DateTime.Now + " - " + text);
        }

        private void GetNextResetImperial()
        {
            int hourNextReset = ResetImperial.GetNextHourReset();
            Client.SendMessage(TwitchInfo.ChannelName, $"!piano Le prochain reset imperial est à {hourNextReset} h !!");
            DisplayLog($"Commande demandé !resetImperial : Le prochain reset imperial est à { hourNextReset} h!!");
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Evenement lors de la connexion du bot au channel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            DisplayLog($"Bot connecté au tchat de la chaine {TwitchInfo.ChannelName}");
        }

        /// <summary>
        /// Evenement lorsque le bot capte une commande
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="inputC"></param>
        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs inputC)
        {
            switch (inputC.Command.CommandText)  
            {
                case "resetimperial":

                    GetNextResetImperial();
                    break;

                default:
                    break;
            }
        }

        #endregion
    }
}
