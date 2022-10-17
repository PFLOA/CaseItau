using System;
using System.Collections.Generic;

namespace A4S.CaseItau.Domain.Entidades
{
    public class Tweets
    {
        public List<Tweet> data { get; set; }
    }

    public class Tweet
    {
        public int? id { get; set; }
        public int? author_id { get; set; }
        public string text { get; set; }
        public string lang { get; set; }
        public DateTime? created_at { get; set; }
    }
}
