using Newtonsoft.Json;
using System;


namespace Oxide.Plugins 
{
    namespace RoeiPluginCnfg.ConfigData
    {

        [Info("RoeiPlugin", "Roei", "0.0.1")]
        class RoeiPlugin : RustPlugin
        {

            public bool ConsoleLog = true;

            [ChatCommand("Ping")]
            void Ping(BasePlayer player)
            {
                SendReply(player, "Pong");
            }
            [ChatCommand("Pong")]
            void Pong(BasePlayer player)
            {
                SendReply(player, "Ping");
            }

            [ConsoleCommand("Test")]
            void Test(ConsoleSystem.Arg arg)
            {
                if (ConsoleLog)
                {
                    ConsoleLog = false;
                    Puts($"{!ConsoleLog} hase been changed to {ConsoleLog}");
                    ConsoleLog = true;
                    Puts($"{!ConsoleLog} hase been changed to {ConsoleLog}");
                    Puts(RoeiPluginCnfg.ConfigData.ConsoleMsg);
                }

            }

            [ConsoleCommand("Repo")]
            void Repo(ConsoleSystem.Arg arg)
            {
                Puts(RoeiPluginCnfg.ConfigData.ConsoleMsg);
            }

            void Init()
            {
                Puts("Server Online");
            }
        }
    }
}
