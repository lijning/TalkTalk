using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TalkTalk.Model
{
    public static class Record
    {
        public static List<string> replies, queries;
        public static void InitializeRecords()
        {
            if(replies==null)
                replies = new List<string>();
            if(queries==null)
                queries = new List<string>();
        }
        public static void ClearRecords()
        {
            try
            {
                replies.Clear();
                queries.Clear();
            }
            catch (NullReferenceException)
            {
                
                return;
            }
        }
    }
}
