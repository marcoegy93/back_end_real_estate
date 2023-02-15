using Backend_Projet_BDD.IService;
using Backend_Projet_BDD.Modele;
using MySql.Data.MySqlClient;

namespace Backend_Projet_BDD.Service
{
    public class PersonneService: IPersonneService
    {
        MySqlConnection _con;
        public PersonneService()
        {
            String host = "localhost";
            String database = "bdd_project";
            String port = "3306";
            String username = "root";
            String password = "";
            String strConnexion = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;
            _con = new MySqlConnection(strConnexion);
            _con.Open();
        }

        public List<Personne> getAllPersonne()
        {
            String query = " select * from Personne";
            MySqlCommand cmd = new MySqlCommand(query, _con);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Personne> listPersonne = new List<Personne>();
            while (reader.Read())
            {
                listPersonne.Add(new Personne(
                    Convert.ToInt32(reader.GetValue(0)),
                    reader.GetValue(1).ToString(),
                    reader.GetValue(2).ToString()
                    ));
            }
            return listPersonne;
        }

        public List<Personne> getPersoneByName(string name)
        {
            String query = "select * from Personne where nom like '%"+name+"%'";
            MySqlCommand cmd = new MySqlCommand(query, _con);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Personne> listPersonne= new List<Personne>();
            while (reader.Read())
            {
                listPersonne.Add(new Personne(
                    Convert.ToInt32(reader.GetValue(0)),
                    reader.GetValue(1).ToString(),
                    reader.GetValue(2).ToString()
                    ));
            }
            return listPersonne;
        }

    }


}
