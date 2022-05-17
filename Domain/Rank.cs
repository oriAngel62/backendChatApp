using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Rank
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int RankNum { get; set; }

        public string UserName { get; set; }


        public string Details { get; set; }

        public DateTime Created { get; set; }
    }
}
