using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;
using System;
using System.Windows.Controls;

namespace HDT.Plugins.Rommath
{
    public class GrandMagisterRommathPlugin : IPlugin
    {
        private GrandMagisterRommathWidget _widget;

        public string Author => "Shiqan";

        public string ButtonText => "Settings";

        public string Description => "Show spells for Grand Magister Rommath.";

        public MenuItem MenuItem => null;

        public string Name => "Grand Magister Rommath Tracker";

        public void OnButtonPress()
        {
        }

        public void OnLoad()
        {
            _widget = new GrandMagisterRommathWidget();
            Core.OverlayCanvas.Children.Add(_widget);

            var plugin = new GrandMagisterRommathTracker(_widget);

            GameEvents.OnInMenu.Add(plugin.OnInMenu);
            GameEvents.OnGameStart.Add(plugin.OnGameStart);
            GameEvents.OnPlayerGet.Add(plugin.OnPlayerGet);
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