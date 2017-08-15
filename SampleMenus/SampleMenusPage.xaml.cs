using Xamarin.Forms;

namespace SampleMenus
{
    public partial class SampleMenusPage : ContentPage
    {
        public SampleMenusPage()
        {
            InitializeComponent();

            slider.Value = 0;
            UpdateSliderLabel();
        }

        public void OnSliderChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == slider)
            {
                UpdateSliderLabel();
            }
        }

        private void UpdateSliderLabel()
        {
            sliderLabel.Text = $"Slider: {(int)slider.Value}";
        }
    }

}
