using Xamarin.Forms;
using System;

namespace SampleMenus
{
    public partial class SampleMenusPage : ContentPage
    {
        public SampleMenusPage()
        {
            InitializeComponent();

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
