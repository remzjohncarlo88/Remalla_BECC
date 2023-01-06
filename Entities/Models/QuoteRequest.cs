﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class QuoteRequest
    {
        public string? From { get; set; }

        public string? To { get; set; }

        public ICollection<Listing> Listings { get; set; }
    }
}
