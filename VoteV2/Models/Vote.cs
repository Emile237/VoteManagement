using System;
using System.Collections.Generic;

namespace VoteV2.Models
{
    public partial class Vote
    {
        public int Idvote { get; set; }
        public int? IdCandidature { get; set; }
        public int? IdEtudiant { get; set; }

        public virtual Candidature? IdCandidatureNavigation { get; set; }
        public virtual Etudiant? IdEtudiantNavigation { get; set; }
    }
}
