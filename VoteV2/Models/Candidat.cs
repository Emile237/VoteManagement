using System;
using System.Collections.Generic;

namespace VoteV2.Models
{
    public partial class Candidat
    {
        public Candidat()
        {
            Candidatures = new HashSet<Candidature>();
        }

        public int IdCandidat { get; set; }
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Candidature>? Candidatures { get; set; }
    }
}
