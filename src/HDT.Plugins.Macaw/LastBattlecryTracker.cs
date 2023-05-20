using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;
using System.Linq;
using static HearthDb.CardIds;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;

namespace HDT.Plugins.Macaw
{
    internal class LastBattlecryTracker
    {
        private readonly LastBattlecryWidget _widget = null;

        public LastBattlecryTracker(LastBattlecryWidget widget)
        {
            _widget = widget;

            if (Config.Instance.HideInMenu && CoreAPI.Game.IsInMenu)
            {
                _widget.Hide();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void OnInMenu() => _widget.Hide();


        /// <summary>
        /// Reset on when a new game starts
        /// </summary>
        internal void OnGameStart()
        {
            _widget.Hide();
            _widget.Update(null);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        internal void OnPlayerPlay(Card card)
        {
            if (card.Mechanics.Contains("Battlecry") && card.Id != Collectible.Shaman.BrilliantMacaw)
            {
                _widget.Update(card);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        internal void OnMouseOver(Card card)
        {
            if (card.Id == Collectible.Shaman.BrilliantMacaw)
            {
                _widget.Show();
            }
            else
            {
                _widget.Hide();
            }
        }
    }
}