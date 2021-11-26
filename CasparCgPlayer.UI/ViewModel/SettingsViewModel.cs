using CasparCgPlayer.UI.Handlers;
using CasparCgPlayer.UI.Startup;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CasparCgPlayer.UI.ViewModel
{
    public class LanguageItem
    {
        public string Key { get; set; }
        public string Name { get; set; }
    }

    public class SettingsViewModel : ViewModelBase
    {
        private readonly LanguageHandler _languageHandler;
        private LanguageItem selectedLanguageItem;

        public ObservableCollection<LanguageItem> LanguageItems { get; private set; }
        public LanguageItem SelectedLanguageItem
        {
            get { return selectedLanguageItem; }
            set
            {
                selectedLanguageItem = value;

                _languageHandler.Language = _languageHandler.Languages.Single(l => l.Name == value.Key);

                OnPropertyChanged();
            }
        }

        public SettingsViewModel(LanguageHandler languageHandler)
            : base(languageHandler)
        {
            _languageHandler = languageHandler;

            LanguageItems = new ObservableCollection<LanguageItem>(
                _languageHandler.Languages.Select(l => CreateLanguageItem(l))
            );

            SelectedLanguageItem = LanguageItems.Where(l => l.Key == _languageHandler.Language.Name).SingleOrDefault();
        }

        public void OnSettingsClosing()
        {
            if (HasPropertyChanged)
            {
                var title = (string)_languageHandler.CurrentLanguageResourceDictionary["##HAS_UNSAVED_CHANGES"];
                var message = (string)_languageHandler.CurrentLanguageResourceDictionary["##SAVE_CHANGES_YES_NO"];

                var dialogResult = MessageBox.Show(message, title, MessageBoxButton.YesNo);
                if(dialogResult == MessageBoxResult.No)
                {
                    // revert changes

                }
            }
        }

        private LanguageItem CreateLanguageItem(CultureInfo cultureInfo)
        {
            return new LanguageItem()
            {
                Key = cultureInfo.Name,
                Name = cultureInfo.DisplayName
            };
        }
    }
}
