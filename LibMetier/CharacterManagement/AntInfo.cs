using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.CharacterManagement
{
    public class AntInfo
    {
        public enum AntInfoType { Food, Enemy, DeadlyThreat, Material, DeadEnd }

        public AntInfoType Info { get; set; }
        public string Payload { get; set; }
        
        // Payload will often be a zone ID + une charactérisation 
        // (comme le montant de nouriture, le nombre des ennemis, LA PEREMPTION DE L'INFO)
        public AntInfo(AntInfoType Info, string Payload)
        {
            this.Info = Info;
            this.Payload = Payload;
        }
    }
}
