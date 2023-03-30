using System;
using System.Collections.Generic;

namespace VoteV2.Models
{
    public partial class Candidature
    {
        public Candidature()
        {
            Votes = new HashSet<Vote>();
        }

        public int Idcandidature { get; set; }
        public int Idcandidat { get; set; }
        public int IdPoste { get; set; }

        public virtual Poste? poste { get; set; }
        public virtual Candidat? candidat { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
