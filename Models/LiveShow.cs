using System;

namespace LiveMusicFinder.Models
{
    public class LiveShow
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Venue { get; set; }
        public DateTime ShowDate { get; set; }
        public string EnteredBy { get; set; }
    }
}