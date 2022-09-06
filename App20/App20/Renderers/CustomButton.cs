using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App20.Renderers
{
    public class CustomButton : Button
    {
        public CustomButton()
        {
            const int animationTime = 50;
            Clicked += async (sender, e) =>
            {
                try
                {
                    var btn = (CustomButton)sender;
                    await btn.ScaleTo(1.2, animationTime);
                    await btn.ScaleTo(1, animationTime);
                    
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            };
        }
    }
}
