namespace Backend_Projet_BDD.Modele
{
    public class Personne
    {

        public int id_personne { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }

        public Personne(int id, string nom, string adresse)
        {
            this.id_personne = id;
            this.nom = nom;
            this.adresse = adresse;
        }

    }
}
