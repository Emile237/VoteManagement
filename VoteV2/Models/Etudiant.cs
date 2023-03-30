using System;
using System.Collections.Generic;

namespace VoteV2.Models
{
    public partial class Etudiant
    {
        public Etudiant()
        {
            Votes = new HashSet<Vote>();
        }

        public int IdEtudiant { get; set; }
        public string Code { get; set; } = null!;

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
