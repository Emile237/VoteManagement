using System;
using System.Collections.Generic;

namespace VoteV2.Models
{
    public partial class Poste
    {
        public Poste()
        {
            Candidatures = new HashSet<Candidature>();
        }

        public int Idposte { get; set; }
        public string? Appelation { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Candidature>? Candidatures { get; set; }
    }
}
