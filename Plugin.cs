using System.Data;
using Terraria.Localization;
using TerrariaApi.Server;
using TShockAPI;


namespace ForceChinese
{
    [ApiVersion(2, 1)]
    public class Main : TerrariaPlugin
    {
        public override string Author
        {
            get
            {
                return "Cai";
            }
        }


        public override string Description
        {
            get
            {
                return "强制使用简体中文作为服务器语言";
            }
        }

        public override string Name
        {
            get
            {
                return "ForceChineseLang(强制简体中文)";
            }
        }

        public override Version Version
        {
            get
            {
                return new Version(1, 2, 0, 0);
            }
        }

        public Main(Terraria.Main game) : base(game)
        {
            LanguageManager.Instance.SetLanguage(7);
            if (Terraria.Program.LaunchParameters.ContainsKey("-lang"))
            {
                Terraria.Program.LaunchParameters["-lang"] = "7";
                
            }
            else
            {
                Terraria.Program.LaunchParameters.Add("-lang", "7");

            }
            Console.WriteLine(
                "[ForceChineseLang]已强制修改语言选项!\n" +
                "*如需使用其他语言请移除此插件!\n" +
                "*本插件为免费插件");
            base.Order = int.MinValue;
        }

        public override void Initialize()
        {

        }


       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }
    }
}
