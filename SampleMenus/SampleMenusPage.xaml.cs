using Xamarin.Forms;

namespace SampleMenus
{
    public partial class SampleMenusPage : ContentPage
    {
        public SampleMenusPage()
        {
            InitializeComponent();

            slider.Value = 0;
            switchView.IsToggled = true;
            renderLabels();
        }

        public void OnSliderChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == slider)
            {
                renderLabels();
            }
        }

        private void renderLabels()
        {
            sliderLabel.Text = $"Slider: {(int)slider.Value}";
        }

        public void OnSwitchChanged(object sender, ToggledEventArgs args)
        {
            if (sender == switchView)
            {
                switchLabel.Text = $"Switch: {args.Value}";
            }
        }

    }

}
