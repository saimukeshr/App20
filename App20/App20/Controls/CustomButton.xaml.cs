using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App20.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomButton : ContentView
    {
        public event EventHandler Clicked;

        public static readonly BindableProperty ButtonText
                             = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomButton));

        public static readonly BindableProperty ButtonImage
                             = BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomButton));

        public string Text
        {
            get => (string)GetValue(ButtonText);
            set => SetValue(ButtonText, value);
        }

        public string Image
        {
            get => (string)GetValue(ButtonImage);
            set => SetValue(ButtonImage, value);
        }

        public static readonly BindableProperty BgColor
                           = BindableProperty.Create(nameof(FrameBackgroundColor), typeof(string), typeof(CustomButton), "#fff");

        public string FrameBackgroundColor
        {
            get => (string)GetValue(BgColor);
            set => SetValue(BgColor, value);
        }

        public static readonly BindableProperty TxtColor
                            = BindableProperty.Create(nameof(TextColor), typeof(string), typeof(CustomButton), "#000");

        public string TextColor
        {
            get => (string)GetValue(TxtColor);
            set => SetValue(TxtColor, value);
        }

        public static readonly BindableProperty FntSize
                           = BindableProperty.Create(nameof(FontSize), typeof(string), typeof(CustomButton), "#000");

        public string FontSize
        {
            get => (string)GetValue(FntSize);
            set => SetValue(FntSize, value);
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command),
            typeof(ICommand), typeof(CustomButton), null);

        
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandPropertyParam = BindableProperty.Create(nameof(CommandParam),
            typeof(object), typeof(CustomButton), null);

    
        public object CommandParam
        {
            get => (object)GetValue(CommandPropertyParam);
            set => SetValue(CommandPropertyParam, value);
        }

        public CustomButton()
        {
            InitializeComponent();

            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    Clicked?.Invoke(this, EventArgs.Empty);
                    if (Command != null)
                    {
                        if (Command.CanExecute(this))
                            Command.Execute(this);
                    }
                })

            });
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            btnIcon.Source = Image;
            btnText.Text = Text;
            buttonFrame.BackgroundColor = Color.FromHex(FrameBackgroundColor);
            btnText.TextColor = Color.FromHex(TextColor);

            stack.BackgroundColor = Color.FromHex(FrameBackgroundColor);
            btnText.BackgroundColor = Color.FromHex(FrameBackgroundColor);
            btnIcon.BackgroundColor = Color.FromHex(FrameBackgroundColor);
        }
    }
}