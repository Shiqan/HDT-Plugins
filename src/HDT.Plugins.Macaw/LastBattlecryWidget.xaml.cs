using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace HDT.Plugins.Macaw
{
	public partial class LastBattlecryWidget
	{
		public LastBattlecryWidget()
		{
			InitializeComponent();
		}

		public void Update(Card card)
		{
			this.ItemsSource = new List<Card> { card };
			UpdatePosition();
		}

		public void UpdatePosition()
		{
			Canvas.SetTop(this, Core.OverlayWindow.Height * 5 / 100);
			Canvas.SetRight(this, Core.OverlayWindow.Width * 20 / 100);
		}

		public void Show()
		{
			this.Visibility = Visibility.Visible;
		}

		public void Hide()
		{
			this.Visibility = Visibility.Hidden;
		}
	}
}