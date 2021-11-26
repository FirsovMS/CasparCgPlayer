using CasparCgPlayer.UI.Handlers;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CasparCgPlayer.UI.ViewModel
{
    public abstract class ViewModelBase
    {
        private readonly LanguageHandler _languageHandler;
        public bool HasPropertyChanged { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase(LanguageHandler languageHandler)
        {
            _languageHandler = languageHandler;

            _languageHandler.LanguageChanged += LanguageChanged;
        }

        protected void LanguageChanged(object sender, EventArgs e)
        {
            
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            HasPropertyChanged = true;
        }
    }
}
