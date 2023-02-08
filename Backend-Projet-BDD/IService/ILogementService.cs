using Backend_Projet_BDD.Modele;

namespace Backend_Projet_BDD.IService
{
    public interface ILogementService
    {
        public List<Logement> getAllLogement();
        public List<Logement> getLogementByCriteria(Criteria criteria);
        public List<Logement> getLogementByWord(string word);
    }
}
