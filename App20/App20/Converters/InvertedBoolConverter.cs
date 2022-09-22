using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.Converters;

namespace App20.Converters
{
    public class InvertedBoolConverter : BaseConverter<bool, bool>
    {
        public override bool ConvertBackTo(bool value)
        => ConvertFrom(value);
        

        public override bool ConvertFrom(bool value)
        => !value;
    }
}
