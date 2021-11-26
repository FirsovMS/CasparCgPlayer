using CasparCgPlayer.UI.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace CasparCgPlayer.UI.Handlers
{
    public class LanguageHandler
    {
        private readonly IReadOnlyList<CultureInfo> _cultureInfos;

        public event EventHandler LanguageChanged;

        public IReadOnlyList<CultureInfo> Languages { get => _cultureInfos; }

        public LanguageHandler()
        {
            _cultureInfos = new List<CultureInfo>()
            {
                new CultureInfo("en-US"),
                new CultureInfo("ru-RU")
            };

            Language = Settings.Default.DefaultLanguage;
        }

        public CultureInfo Language
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (value.Name == Thread.CurrentThread.CurrentUICulture.Name)
                {
                    return;
                }

                ChangeLanguageResources(value);

                Thread.CurrentThread.CurrentUICulture = value;

                LanguageChanged(Application.Current, new EventArgs());
            }
        }

        private ResourceDictionary _currentLanguageResourceDictionary;
        public ResourceDictionary CurrentLanguageResourceDictionary
        {
            get
            {
                if (_currentLanguageResourceDictionary == null)
                {
                    _currentLanguageResourceDictionary = Application.Current.Resources.MergedDictionaries
                                        .Where(d => d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang."))
                                        .SingleOrDefault();
                }

                return _currentLanguageResourceDictionary;
            }
        }

        private void ChangeLanguageResources(CultureInfo value)
        {
            var newResDict = new ResourceDictionary();
            switch (value.Name)
            {
                case "ru-RU":
                    newResDict.Source = new Uri($"Resources/lang.{value.Name}.xaml", UriKind.Relative);
                    break;
                // by the default uses en-US
                default:
                    newResDict.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
                    break;
            }

            var languageResDict = CurrentLanguageResourceDictionary;

            if (languageResDict != null)
            {
                int index = Application.Current.Resources.MergedDictionaries.IndexOf(languageResDict);
                Application.Current.Resources.MergedDictionaries.Remove(languageResDict);
                Application.Current.Resources.MergedDictionaries.Insert(index, newResDict);

                _currentLanguageResourceDictionary = newResDict;
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(newResDict);
            }
        }
    }
}
