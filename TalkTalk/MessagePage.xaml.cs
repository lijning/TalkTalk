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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TalkTalk
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        MessageInterface.TalkWindow talkWindow;
        Model.Connector connector = new Model.Connector();
        
        public MainPage()
        {
            talkWindow = new MessageInterface.TalkWindow();
            this.DataContext = talkWindow;
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(SendBox.Text) || string.IsNullOrWhiteSpace(SendBox.Text)))
            {
                MessageInterface.Message messageSent = new MessageInterface.Message(SendBox.Text, true, DateTime.Now);
                talkWindow.AddMessage(messageSent);
                MessageInterface.Message messageReceived = new MessageInterface.Message();

                messageReceived.Content = await connector.QueryAndStore(messageSent.Content);
                //messageReceived.Content = Model.Record.replies.Last();
                messageReceived.IsSelf = false;
                messageReceived.SentTime = DateTime.Now;
                talkWindow.AddMessage(messageReceived);
                MessageListView.SelectedIndex = MessageListView.Items.Count - 1;
                MessageListView.ScrollIntoView(MessageListView.SelectedItem);
            }
            SendBox.Text = string.Empty;
        }
    }
}
