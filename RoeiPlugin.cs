using Newtonsoft.Json;
using System;


namespace Oxide.Plugins 
{

        [Info("RoeiPlugin", "Roei", "0.0.2")]
        class RoeiPlugin : RoeiPluginCnfg
        {
            public RoeiPluginCnfg Rpc = new RoeiPlugin();
            public bool ConsoleLog = true;

            [ChatCommand("Ping")]
            void Ping(BasePlayer player)
            {
                SendReply(player, "Pong");
            }
            [ChatCommand("Clan Create")]
            void Pong(BasePlayer player)
            {
                SendReply(player, "clan Created");
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
                    Puts(Roei.ConfigData.ConsoleMsg);
                }

            }

            [ConsoleCommand("Repo")]
            void Repo(ConsoleSystem.Arg arg)
            {
                Puts(ConsoleMsg);
            }

            void Init()
            {
                Puts("Server Online");
            }
        }
}
namespace Oxide.Plugins
{
    [Info("RoeiConfig", "Roei", "0.0.2")]
    public class RoeiPluginCnfg : RustPlugin
    {
        
        public ConfigData configData { get; set; }

        public class ConfigData{

            public string ConsoleMsg = "Hi";            

        }


        private bool LoadConfigVars()
        {
            try
            {
                configData = Config.ReadObject<ConfigData>();
            } catch{
                return false;
            }
            SaveConfig(configData);
            return true;

        }

        void Init(){

            if(!LoadConfigVars()){
                Puts("Error found in the config file please delete the file or check the syntax and try to fix it");
                return;
            }
            if(!GenerateCnfg()){
                configData = new ConfigData();
                SaveConfig(configData);
            }
        }
        private bool GenerateCnfg()
        {

            try
            {
                configData = Config.ReadObject<ConfigData>();
            }
            catch
            {
                return false;
            }
            return true;

        }
        public void SaveConfig(ConfigData config)
        {
            Config.WriteObject(config, true);
        }

        [ConsoleCommand("Cnfgtest")]
        void CnfgTest(ConsoleSystem.Arg args)
        {
            Puts(ConfigData.ConsoleMsg);

        }


    }
}
