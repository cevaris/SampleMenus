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

    class ColorViewModel
    {
        public ColorViewModel(string name, Color value)
        {
            this.Name = name;
            this.Value = value;
        }

        public Color Value { get; set; }
        public string Name { get; set; }
    }

    public partial class SampleMenusPage : ContentPage
    {

        private ObservableCollection<EmailViewModel> Emails = new ObservableCollection<EmailViewModel>
        {
            new EmailViewModel("alice@example.com", "to@my.com", "hello moto", "this is a test"),
            new EmailViewModel("bob@example.com", "toOther@google.com", "great news!!", "this is great news")
        };

        private ObservableCollection<ColorViewModel> Colors = new ObservableCollection<ColorViewModel>
        {
            new ColorViewModel("Red", Color.Red),
            new ColorViewModel("Blue", Color.Blue),
            new ColorViewModel("Yellow", Color.Yellow)
        };


        public SampleMenusPage()
        {
            InitializeComponent();

            itemListView.ItemsSource = Emails;

            foreach (ColorViewModel c in Colors)
            {
                picker.Items.Add(c.Name);
            }


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

        public void OnButtonClick(object sender, EventArgs args)
        {
            if (sender == spinnerBtn)
            {
                spinner.IsRunning = !spinner.IsRunning;
                render();
            }
            else if (sender == progresssBarBtn)
            {
                progressBar.Progress = 0;
                launchProgressBar();
            }
        }


        public void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            if (sender == entry)
            {
                entryLabel.Text = $"Entry: {args.NewTextValue}";
            }
        }

        public void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == picker)
            {
                if (0 <= picker.SelectedIndex && picker.SelectedIndex <= Colors.Count)
                {
                    ColorViewModel color = Colors[picker.SelectedIndex];
                    pickerLbl.TextColor = color.Value;
                }

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

        async void launchProgressBar()
        {
            await progressBar.ProgressTo(1, 5000, Easing.SinIn);
            progresssBarBtn.Text = "Restart";
        }

    }

}
