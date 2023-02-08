﻿namespace Backend_Projet_BDD.Modele
{
    public class Logement
    {

        public int id_Logement { get; set; }
        public string adresse { get; set; }
        public string type { get; set; }
        public int nbPiece { get; set; }
        public int surface { get; set; }
        public float prix { get; set; }
        public string etat { get; set; }
        public string objetGestion { get; set; }
        public string dateDispo { get; set; }
        public string ville { get; set; }
        public string nomProprio { get; set; }

        public Logement(int id, string adresse, string type, int nbPiece, int surface, string etat, string objetGestion, float prix, string dateDispo, string ville, string nomProprio)
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
        }
    }
}