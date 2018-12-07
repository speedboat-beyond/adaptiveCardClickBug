using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AdaptiveCards;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppTestAdpativeCardBug
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            AdaptiveCard card = new AdaptiveCard();
            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = "Hello",
                Size = AdaptiveTextSize.ExtraLarge
            });

            card.Body.Add(new AdaptiveImage()
            {
                Url = new Uri("http://adaptivecards.io/content/cats/1.png")
            });

            var datePicker = new AdaptiveDateInput()
            {
                Id = "123",
                Placeholder = "123",
                Value = "2017-09-20"
            };
            card.Body.Add(datePicker);

            // serialize the card to JSON
            string json = card.ToJson();

            var renderer = new AdaptiveCards.Rendering.Uwp.AdaptiveCardRenderer();

            var cardNew = AdaptiveCards.Rendering.Uwp.AdaptiveCard.FromJsonString(json);

            var renderedAdaptiveCard = renderer.RenderAdaptiveCard(cardNew.AdaptiveCard);
            if (renderedAdaptiveCard.FrameworkElement != null)
            {
                myGrid.Children.Add(renderedAdaptiveCard.FrameworkElement);
            }
        }
    }
}
