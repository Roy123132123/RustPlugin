namespace Oxide.Plugins
{
    [Info("RoeiConfig", "Roei", "0.0.1")]
    public class RoeiPluginCnfg : RustPlugin
    {
        
        public ConfigData configData { get; set; }

        public class ConfigData{

            public static string ConsoleMsg = "Hi";            

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