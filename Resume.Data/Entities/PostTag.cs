﻿using System;

namespace Resume.Data.Entities
{
    public class PostTag
    {
        public Guid PostId { get; set; }
        public Guid TagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
