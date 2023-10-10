using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManager.Application
{
    internal class Comment
    {
        public User User { get; }
        public string Text { get; }
        public DateTime Created { get; }
        public Comment(User user, string text)
        {
            User = user;
            Text = text;
            Created = DateTime.UtcNow;
        }
    }
}
