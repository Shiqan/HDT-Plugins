using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;
using System;
using System.Reflection;
using System.Windows.Controls;

namespace HDT.Plugins.CommanderSivara
{
    public class SivaraPlugin : IPlugin
    {
        private SivaraWidget _widget;

        public string Author => "Shiqan";

        public string ButtonText => "Settings";

        public string Description => "Show cards for Commander Sivara.";

        public MenuItem MenuItem => null;

        public string Name => "Commander Sivara Tracker";

        public void OnButtonPress()
        {
        }

        public void OnLoad()
        {
            _widget = new SivaraWidget();
            Core.OverlayCanvas.Children.Add(_widget);

            var plugin = new SivaraTracker(_widget);

            GameEvents.OnInMenu.Add(plugin.InMenu);
            GameEvents.OnGameStart.Add(plugin.OnGameStart);

            GameEvents.OnPlayerPlay.Add(plugin.OnPlay);
            GameEvents.OnPlayerDraw.Add(plugin.OnGet);
            GameEvents.OnPlayerGet.Add(plugin.OnGet);
            GameEvents.OnPlayerHandMouseOver.Add(plugin.OnMouseOver);
        }

        public void OnUnload() => Core.OverlayCanvas.Children.Remove(_widget);

        public void OnUpdate()
        {
        }

        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    }
}