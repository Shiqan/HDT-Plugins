﻿using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Hearthstone;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace HDT.Plugins.CommanderSivara
{
    public partial class SivaraWidget
    {
        public SivaraWidget()
        {
            InitializeComponent();
        }

        public void Update(ObservableCollection<Card> cards) => ItemsSource = cards;

        public void UpdatePosition()
        {
            Canvas.SetTop(this, Core.OverlayWindow.Height * 5 / 100);
            Canvas.SetRight(this, Core.OverlayWindow.Width * 20 / 100);
        }

        public void Show() => Visibility = Visibility.Visible;

        public void Hide() => Visibility = Visibility.Hidden;
    }
}