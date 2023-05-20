using HearthDb.Enums;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static HearthDb.CardIds;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;

namespace HDT.Plugins.Rommath
{
    internal class GrandMagisterRommathTracker
    {
        private readonly GrandMagisterRommathWidget _widget = null;
        private readonly List<string> _cardsGenerated = new List<string>();
        private readonly ObservableCollection<Card> _cardsPlayed = new ObservableCollection<Card>();

        public GrandMagisterRommathTracker(GrandMagisterRommathWidget widget)
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

            _cardsGenerated.Clear();
            _cardsPlayed.Clear();
            _widget.Update(_cardsPlayed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        internal void OnPlayerGet(Card card)
        {
            if (card.Type == "Spell")
            {
                _cardsGenerated.Add(card.Id);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        internal void OnPlayerPlay(Card card)
        {
            if (card.Type == "Spell" && _cardsGenerated.Contains(card.Id))
            {
                _cardsGenerated.Remove(card.Id);

                var exists = _cardsPlayed.FirstOrDefault(c => c.Id == card.Id);
                if (exists != null)
                {
                    exists.Count++;
                }
                else
                {
                    _cardsPlayed.Add(card.Clone() as Card);
                }

                _widget.Update(_cardsPlayed);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        internal void OnMouseOver(Card card)
        {
            if (card.Id == Collectible.Mage.GrandMagisterRommath)
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