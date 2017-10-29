using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TalkTalk.Model
{
    public class Record
    {
        List<string> replies, queries;
        public Record()
        {
            replies = new List<string>();
            queries = new List<string>();
        }
        public void AddQuery(string query)
        {
            queries.Add(query);
        }
        public void AddReply(string reply)
        {
            replies.Add(reply);
        }
    }
}
