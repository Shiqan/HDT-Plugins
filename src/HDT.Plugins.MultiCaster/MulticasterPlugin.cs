using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;
using System;
using System.Reflection;
using System.Windows.Controls;

namespace HDT.Plugins.Multicaster
{
    public class MulticasterPlugin : IPlugin
    {
        private MulticasterWidget _widget;

        public string Author => "Shiqan";

        public string ButtonText => "Settings";

        public string Description => "Show number of spells for Multicaster.";

        public MenuItem MenuItem => null;

        public string Name => "Multicaster counter";

        public void OnButtonPress()
        {
        }

        public void OnLoad()
        {
            _widget = new MulticasterWidget();
            Core.OverlayCanvas.Children.Add(_widget);

            var plugin = new MulticasterTracker(_widget);

            GameEvents.OnInMenu.Add(plugin.InMenu);
            GameEvents.OnGameStart.Add(plugin.OnGameStart);

            GameEvents.OnPlayerPlay.Add(plugin.OnPlayerPlay);
            GameEvents.OnPlayerHandMouseOver.Add(plugin.OnMouseOver);
        }

        public void OnUnload() => Core.OverlayCanvas.Children.Remove(_widget);

        public void OnUpdate()
        {
        }

        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    }
}