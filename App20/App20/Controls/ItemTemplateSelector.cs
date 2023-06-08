using App20.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App20.Controls
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EntryTemplate { get; set; }

        public DataTemplate DateTemplate { get; set; }

        public DataTemplate PickerTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
        

            if (!string.IsNullOrEmpty(((Items)item).Name))
            {
                return EntryTemplate;
            }

            else if (((Items)item).Details != null)
            {
                return PickerTemplate;
            }

            else if (((Items)item).DateofBirth != null)
            {
                return DateTemplate;
            }
           
                            
            return null;
        }
    }
}
