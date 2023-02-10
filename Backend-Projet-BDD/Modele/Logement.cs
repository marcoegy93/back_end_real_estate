namespace Backend_Projet_BDD.Modele
{
    public class Logement
    {

        public int id_Logement { get; set; }
        public string adresse { get; set; }
        public string type { get; set; }
        public int nbPiece { get; set; }
        public int surface { get; set; }
        public int prix { get; set; }
        public string etat { get; set; }
        public string objetGestion { get; set; }
        public DateTime dateDispo { get; set; }
        public string ville { get; set; }
        public string nomProprio { get; set; }
        public int nbGarages { get; set; }
        public float commission { get; set; }
        public String lastVisite { get; set; }

        public Logement(int id, string adresse, string type, int nbPiece, int surface, string etat, string objetGestion, int prix, DateTime dateDispo, string ville, string nomProprio, int nbGarages, float commission, String lastVisite)
        {
            this.id_Logement = id;
            this.adresse = adresse;
            this.type = type;
            this.nbPiece = nbPiece;
            this.surface = surface;
            this.etat = etat;
            this.objetGestion = objetGestion;
            this.dateDispo = dateDispo;
            this.ville = ville;
            this.prix = prix;
            this.nomProprio = nomProprio;
            this.nbGarages = nbGarages;
            this.commission = commission;
            this.lastVisite = lastVisite;
        }
    }
}