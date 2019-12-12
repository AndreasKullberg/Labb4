using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Labb4
{
    public class MainViewModel:SimpleViewModel
    {
        private Country selectedCountry;
        private List<Country> countries;
        private CountryRepository countryRepository = new CountryRepository();
        private int index;

        public ICommand NextButtonCommand { get; private set; }
        public ICommand PrevButtonCommand { get; private set; }

        public Country SelectedCountry
        {
            get => selectedCountry;
            set => SetPropertyValue(ref selectedCountry, value);
        }

        public MainViewModel()
        {
            countries = countryRepository.GetCountries();
            SelectedCountry = countries[0];
            NextButtonPressed();
            PrevButtonPressed();
        }

        private void NextButtonPressed()
        {
            NextButtonCommand = new Command(() =>
            {
                index++;
                if (index > countries.Count - 1)
                {
                    index = 0;
                }
                SelectedCountry = countries[index];
            });
        }

        private void PrevButtonPressed()
        {
            PrevButtonCommand = new Command(() =>
            {
                index--;
                if (index < 0)
                {
                    index = countries.Count - 1;
                }
                SelectedCountry = countries[index];
            });
        }

    }
}
