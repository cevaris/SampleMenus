using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleMenus
{
    class EmailViewModel
    {
        public EmailViewModel(string from, string to, string header, string body)
        {
            this.From = from;
            this.To = to;
            this.Header = header;
            this.Body = body;
        }
        public string From { get; set; }
        public string To { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string DisplayLabel { get { return $"{this.From} - {this.Header}"; } }        
    }

    public partial class SampleMenusPage : ContentPage
    {

        private ObservableCollection<EmailViewModel> Emails = new ObservableCollection<EmailViewModel>
        {
            new EmailViewModel("alice@example.com", "to@my.com", "hello moto", "this is a test"),
            new EmailViewModel("bob@example.com", "toOther@google.com", "great news!!", "this is great news")
        };

        public SampleMenusPage()
        {
            InitializeComponent();

            itemListView.ItemsSource = Emails;

            switchView.IsToggled = true;
            render();
        }

        public void OnSliderChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == slider)
            {
                render();
            }
        }

        public void OnSwitchChanged(object sender, ToggledEventArgs args)
        {
            if (sender == switchView)
            {
                switchLabel.Text = $"Switch: {args.Value}";
            }
        }

        public void OnSpinnerBtnClick(object sender, EventArgs args)
        {
            if (sender == spinnerBtn)
            {
                spinner.IsRunning = !spinner.IsRunning;
                render();
            }
        }


        public void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            if (sender == entry)
            {
                entryLabel.Text = $"Entry: {args.NewTextValue}";
            }
        }

        private void render()
        {
            sliderLabel.Text = $"Slider: {((int)slider.Value)}";


            if (spinner.IsRunning)
            {
                spinnerBtn.Text = "Stop Spinner";
            }
            else
            {
                spinnerBtn.Text = "Start Spinner";
            }
        }

    }

}
