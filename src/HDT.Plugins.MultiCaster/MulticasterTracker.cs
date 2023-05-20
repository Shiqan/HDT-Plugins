using HearthDb.Enums;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;
using System.Collections.Generic;
using static HearthDb.CardIds;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;

namespace HDT.Plugins.Multicaster
{
    internal class MulticasterTracker
    {
        private readonly MulticasterWidget _widget = null;
        private readonly ISet<SpellSchool> _spellSchoolsPlayed = new HashSet<SpellSchool>();

        public MulticasterTracker(MulticasterWidget widget)
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

            _spellSchoolsPlayed.Clear();
            _widget.SpellSchoolsPlayed = "";
        }

        internal void OnPlayerPlay(Card card)
        {
            if (card.Type == "Spell" && card.SpellSchool != SpellSchool.NONE)
            {
                _spellSchoolsPlayed.Add(card.SpellSchool);
                _widget.SpellSchoolsPlayed = _spellSchoolsPlayed.Count.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        internal void OnMouseOver(Card card)
        {
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