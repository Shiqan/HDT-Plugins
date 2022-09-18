using Hearthstone_Deck_Tracker.Annotations;
using Hearthstone_Deck_Tracker.API;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace HDT.Plugins.Multicaster
{
    public partial class MulticasterWidget : INotifyPropertyChanged
    {
        private string _spellSchoolsPlayed;

        public event PropertyChangedEventHandler PropertyChanged;

        public MulticasterWidget()
        {
            InitializeComponent();
        }

        public string SpellSchoolsPlayed
        {
            get { return _spellSchoolsPlayed; }
            set
            {
                if (value == _spellSchoolsPlayed)
                    return;
                _spellSchoolsPlayed = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdatePosition()
        {
            Canvas.SetBottom(this, Core.OverlayWindow.Height * 5 / 100);
            Canvas.SetRight(this, Core.OverlayWindow.Width * 20 / 100);
        }

        public void Show() => this.Visibility = Visibility.Visible;

        public void Hide() => this.Visibility = Visibility.Hidden;
    }
}