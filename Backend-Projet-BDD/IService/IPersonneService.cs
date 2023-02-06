using Backend_Projet_BDD.Modele;

namespace Backend_Projet_BDD.IService
{
    public interface IPersonneService
    {
        public List<Personne> getAllPersonne();
        public List<Personne> getPersoneByName(string name);

    }
}
