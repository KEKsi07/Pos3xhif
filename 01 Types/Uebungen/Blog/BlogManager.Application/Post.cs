using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManager.Application
{
    internal abstract class Post
    {
        private List<Comment> comments = new List<Comment>();
        private int ratingSum = 0;
        private int ratingCount = 0;
        private HashSet<string> excludedEmails = new HashSet<string>();
        public User User { get; }
        public string Title { get; }
        public abstract string Html { get; }
        public decimal? AverageRating
        {
            get
            {
                return ratingCount == 0 ? null : (decimal) ratingSum / ratingCount;
            }
        }
        public int RatingCount
        {
            get
            {
                return ratingCount;
            }
        }
        public IReadOnlyList<Comment> Comments => comments.AsReadOnly();
        public Post(User user, string title)
        {
            User = user;
            Title = title;
        }
        public void AddComment(User user, string text)
        {
            comments.Add(new Comment(user, text));
        }
        public bool TryRate(User user, int rating)
        {
            if(user.Email is not null)
            {
                if(excludedEmails.Contains(user.Email) || rating < 1 || rating > 5)
                {
                    return false;
                } else
                {
                    ratingSum += rating;
                    ratingCount++;
                    excludedEmails.Add(user.Email);
                    return true;
                }
            }
            return false;
        }

    }
}
