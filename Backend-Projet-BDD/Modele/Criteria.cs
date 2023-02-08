

namespace Backend_Projet_BDD.Modele
{
    public class Criteria
    {
        public string type { get; set; }
        public int? nbPiece { get; set; }
        public int? surface { get; set; }
        public string etat { get; set; }
        public string objetGestion { get; set; }
        public string ville { get; set; }
        public float? prixMinimum { get; set; }
        public float? prixMaximum { get; set; }
        public string dateDispo { get; set; }


        public Criteria(string type, int? nbPiece, int? surface, string etat, string objetGestion, string ville, float? prixMinimum, float? prixMaximum, string dateDispo)
        {
            this.type = type;
            this.nbPiece = nbPiece;
            this.surface = surface;
            this.etat = etat;
            this.objetGestion = objetGestion;
            this.dateDispo = dateDispo;
            this.ville = ville;
            this.prixMinimum = prixMinimum;
            this.prixMaximum = prixMaximum;
        }








    }
}

