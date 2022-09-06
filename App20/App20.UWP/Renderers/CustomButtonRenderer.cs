using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;
using Style = Windows.UI.Xaml.Style;
using Color = Xamarin.Forms.Color;
using Setter = Windows.UI.Xaml.Setter;
using Button = Windows.UI.Xaml.Controls.Button;
using App20.Renderers;
using App20.UWP.Renderers;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace App20.UWP.Renderers
{
    class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {

            base.OnElementChanged(e);
            if (Control == null)
                return;

            var uwpButton = Control;

            Style style = new Style(typeof(Button));
           
            style.Setters.Add(new Setter(Windows.UI.Xaml.Controls.Control.BackgroundProperty, Color.Transparent.ToBrush()));
            uwpButton.Style = style;
        }
    }
}
