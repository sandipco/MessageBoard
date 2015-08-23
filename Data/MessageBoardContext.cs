using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MessageBoard.Data
{
    public class MessageBoardContext:DbContext
    {
        public MessageBoardContext()
            : base("connMsgBoard")
        {

        }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }
}