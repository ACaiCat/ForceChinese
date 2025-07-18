using System.Globalization;
using System.Reflection;
using GetText;
using MonoMod.RuntimeDetour;
using Terraria.Localization;
using TerrariaApi.Server;
using TShockAPI;


namespace ForceChinese
{
    [ApiVersion(2, 1)]
    public class Main : TerrariaPlugin
    {
        public override string Author => "Cai";
        
        public override string Description => "强制使用简体中文作为服务器语言";

        public override string Name => "ForceChineseLang(强制简体中文)";

        public override Version Version => new(1, 3, 0);

        public Main(Terraria.Main game) : base(game)
        {
        }

        private readonly Hook _langHook = new (typeof(TShock).Assembly.GetType("TShockAPI.I18n")!.GetProperty(
            "TranslationCultureInfo",
            BindingFlags.NonPublic | BindingFlags.Static)!.GetGetMethod(nonPublic:true)!, ()=>  new CultureInfo("zh-CN"));
        public override void Initialize()
        {
            if (LanguageManager.Instance.ActiveCulture != GameCulture.FromLegacyId(7))
            {
                LanguageManager.Instance.SetLanguage(7);
            }
            _langHook.Apply();
            var path = (string)typeof(TShock).Assembly.GetType("TShockAPI.I18n")!.GetProperty(
                "TranslationsDirectory",
                BindingFlags.NonPublic | BindingFlags.Static)!.GetValue(null)!;
            typeof(TShock).Assembly.GetType("TShockAPI.I18n")!.GetField(
                "C",
                BindingFlags.Public | BindingFlags.Static)!.SetValue(null, new Catalog("TShockAPI", path, new CultureInfo("zh-CN")));
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _langHook.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
