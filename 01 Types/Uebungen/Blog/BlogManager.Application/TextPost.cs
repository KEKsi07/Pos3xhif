using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManager.Application
{
    internal class TextPost : Post
    {
        public override string Html { get; }
        public TextPost(User user, string title, string content) : base(user, title)
        {
            Html = $"<h1>{title}</h1><p>{content}</p>";
        }

    }
}
