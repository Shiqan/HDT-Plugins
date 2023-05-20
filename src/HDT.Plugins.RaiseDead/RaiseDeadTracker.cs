using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;
using System.Collections.ObjectModel;
using System.Linq;
using static HearthDb.CardIds;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;

namespace HDT.Plugins.RaiseDead
{
    internal class RaiseDeadTracker
    {
        private readonly RaiseDeadWidget _widget = null;
        private readonly ObservableCollection<Card> _cards = new ObservableCollection<Card>();

        public RaiseDeadTracker(RaiseDeadWidget widget)
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

            _cards.Clear();
            _widget.Update(_cards);
        }

        /// <summary>
        /// Update when a minion dies
        /// </summary>
        internal void OnPlayerPlayToGraveyard(Card card)
        {
            if (card.Type == "Minion")
            {
                var exists = _cards.FirstOrDefault(c => c.Name == card.Name);
                if (exists != null)
                {
                    exists.Count++;
                }
                else
                {
                    _cards.Add(card.Clone() as Card);
                }

                _widget.Update(_cards);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        internal void OnMouseOver(Card card)
        {
            if (card.Id == Collectible.Priest.RaiseDead)
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