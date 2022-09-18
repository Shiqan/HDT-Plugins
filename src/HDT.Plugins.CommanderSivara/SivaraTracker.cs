using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;
using System.Collections.ObjectModel;
using static HearthDb.CardIds;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;


namespace HDT.Plugins.CommanderSivara
{
    internal class SivaraTracker
    {
        private readonly SivaraWidget _widget = null;

        private readonly ObservableCollection<Card> _cards = new ObservableCollection<Card>();
        private bool _tracking;

        public SivaraTracker(SivaraWidget widget)
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
        internal void InMenu()
        {
            if (Config.Instance.HideInMenu)
            {
                _widget.Hide();
            }
        }

        /// <summary>
        /// Reset on when a new game starts
        /// </summary>
        internal void OnGameStart()
        {
            _widget.Hide();

            _cards.Clear();
            _widget.Update(_cards);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        internal void OnGet(Card card)
        {
            //if (card.Id == Collectible.Mage.CommanderSivara)
            if (card.Id == Collectible.Neutral.Multicaster)
            {
                _tracking = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        internal void OnPlay(Card card)
        {
            if (_tracking && card.Type == "Spell" && _cards.Count < 3)
            {
                _cards.Add(card.Clone() as Card);
                _widget.Update(_cards);
            }

            if (card.Id == Collectible.Mage.CommanderSivara)
            {
                _tracking = false;

                _cards.Clear();
                _widget.Update(_cards);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        internal void OnMouseOver(Card card)
        {
            //if (card.Id == Collectible.Mage.CommanderSivara)
            if (card.Id == Collectible.Neutral.Multicaster)
            {
                _widget.UpdatePosition();
                _widget.Show();
            }
            else
            {
                _widget.Hide();
            }
        }
    }
}