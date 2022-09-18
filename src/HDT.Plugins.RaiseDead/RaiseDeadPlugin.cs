using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;
using System;
using System.Reflection;
using System.Windows.Controls;

namespace HDT.Plugins.RaiseDead
{
    public class RaiseDeadPlugin : IPlugin
    {
        private RaiseDeadWidget _widget;

        public string Author => "Shiqan";

        public string ButtonText => "Settings";

        public string Description => "Show raise dead pool.";

        public MenuItem MenuItem => null;

        public string Name => "Raise Dead Pool";

        public void OnButtonPress()
        {
        }

        public void OnLoad()
        {
            _widget = new RaiseDeadWidget();
            Core.OverlayCanvas.Children.Add(_widget);

            var plugin = new RaiseDeadTracker(_widget);

            GameEvents.OnInMenu.Add(plugin.InMenu); 
            GameEvents.OnPlayerPlayToGraveyard.Add(plugin.OnPlayerPlayToGraveyard);
            GameEvents.OnPlayerHandMouseOver.Add(plugin.OnMouseOver);
        }

        public void OnUnload() => Core.OverlayCanvas.Children.Remove(_widget);

        public void OnUpdate()
        {
        }

        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    }
}