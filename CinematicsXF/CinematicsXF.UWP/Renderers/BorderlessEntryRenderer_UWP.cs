using CinematicsXF.Controls;
using CinematicsXF.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer_UWP))]
namespace CinematicsXF.UWP
{
    public class BorderlessEntryRenderer_UWP : EntryRenderer
    {
        public BorderlessEntryRenderer_UWP()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.BorderThickness = new Windows.UI.Xaml.Thickness(0, 0, 0, 1);
            }
        }
    }
}
