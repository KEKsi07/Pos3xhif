using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManager.Application
{
    internal class ImagePost : Post
    {
        public override string Html { get;}
        public ImagePost(User user, string title, string url) : base(user, title)
        {
            Html = $"<img src=\"{url}\" />";
        }
    }
}
