using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;
using System;
using System.Windows.Controls;

namespace HDT.Plugins.Macaw
{
    public class BrilliantMacawPlugin : IPlugin
    {
        private LastBattlecryWidget _widget;

        public string Author => "Shiqan";

        public string ButtonText => "Settings";

        public string Description => "Show last battlecry for Brilliant Macaw.";

        public MenuItem MenuItem => null;

        public string Name => "Brilliant Macaw Indicator";

        public void OnButtonPress()
        {
        }

        public void OnLoad()
        {
            _widget = new LastBattlecryWidget();
            Core.OverlayCanvas.Children.Add(_widget);

            var plugin = new LastBattlecryTracker(_widget);

            GameEvents.OnInMenu.Add(plugin.OnInMenu);
            GameEvents.OnGameStart.Add(plugin.OnGameStart);
            GameEvents.OnPlayerPlay.Add(plugin.OnPlayerPlay);
            GameEvents.OnPlayerHandMouseOver.Add(plugin.OnMouseOver);
        }

        public void OnUnload() => Core.OverlayCanvas.Children.Remove(_widget);

        public void OnUpdate()
        {
        }

        public Version Version => new Version(1, 0, 0);
    }
}