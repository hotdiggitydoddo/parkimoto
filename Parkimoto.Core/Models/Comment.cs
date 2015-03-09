﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkimoto.Core
{
    public class Comment : Entity
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual Post Post { get; set; }
        public virtual Comment ParentComment { get; set; }
    }
}
