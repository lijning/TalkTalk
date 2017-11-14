using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace TalkTalk.MessageInterface
{
    public class TalkWindow
    {
        public ObservableCollection<MessageBase> _messageList = new ObservableCollection<MessageBase>();        public string testStringBinding = "到底行不行";

        public TalkWindow()
        {
        }

        public ObservableCollection<MessageBase> MessageList
        {
            get
            {
                return _messageList;
            }
            set
            {
                _messageList = value;
            }
        }

        public void AddMessage(MessageBase msg)
        {
            _messageList.Add(msg);
        }
    }
}
