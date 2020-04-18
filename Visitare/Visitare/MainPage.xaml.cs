﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Visitare
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Position> positions = new ObservableCollection<Position>();
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnLogOut(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
        private async void OnProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        private void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            CustomPin pin = new CustomPin
            {
                Type = PinType.SavedPin,
                Position = new Position(e.Position.Latitude, e.Position.Longitude),
                Label = nazwaEntry.Text,
                Address = opisEntry.Text,
                Name = "Xamarin",
                Url = "http://xamarin.com/about/",
                Question = zagadkaEntry.Text,
                Answer = odpowiedzEntry.Text
            };
            pin.MarkerClicked += async (s, args) =>
            {
                args.HideInfoWindow = true;
                string pinName = ((CustomPin)s).Label;
                string pytanie = ((CustomPin)s).Question;
                await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
                string result = await DisplayPromptAsync("Zagadka", $"{pytanie}", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);

            };
            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin);
        }
        private void OnClearClicked(object sender, EventArgs e)
        {
            customMap.Pins.Clear();
            customMap.MapElements.Clear();
            positions.Clear();
        }

        private async void OnRoutesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RoutesPage());
        }

        private void OnNewRoutesClicked(object sender, EventArgs e)
        {

        }
    }
}