using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkTalk.MessageInterface
{
    public abstract class MessageBase
    {
        public string Name { get; set; }

        public DateTime SentTime { get; set; }
    }

    public class Message : MessageBase
    {
        public Message() { }
        public Message(string con, bool isS, DateTime time)
        {
            Content = con;
            IsSelf = isS;
            SentTime = time;
        }

        public string Content { get; set; }

        public bool IsSelf { get; set; }
    }
}
