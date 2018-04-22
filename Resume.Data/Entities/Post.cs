﻿using Resume.Data.Entities.Base;
using System;
using System.Collections.Generic;

namespace Resume.Data.Entities
{
    public class Post : Entity
    {
        public Post(Guid id,
            Guid userId,
            string title,
            string subTitle,
            string mainImage,
            string content,
            DateTime publicationDate) : base(id)
        {
            Title = title;
            SubTitle = subTitle;
            MainImage = mainImage;
            Content = content;
            PublicationDate = publicationDate;
            UserId = userId;
            PostTags = new List<PostTag>();
        }

        public Post() : base(Guid.NewGuid()) { }

        public string Title { get; private set; }
        public string SubTitle { get; private set; }
        public string MainImage { get; private set; }
        public string Content { get; private set; }
        public DateTime PublicationDate { get; private set; }

        public ICollection<PostTag> PostTags { get; } = new List<PostTag>();

        public Guid UserId { get; private set; }
        public virtual User User { get; private set; }
    }
}
