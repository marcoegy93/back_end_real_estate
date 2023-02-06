using Backend_Projet_BDD.IService;
using Backend_Projet_BDD.Modele;
using System.Data.SqlClient;

namespace Backend_Projet_BDD.Service
{
    public class PersonneService: IPersonneService
    {
        SqlConnection _con;
        public PersonneService()
        {
            String strConnexion = "Data Source =DESKTOP-103GNA6\\SQLEXPRESS;Initial Catalog= master; Integrated Security = true";
            _con = new SqlConnection(strConnexion);
            _con.Open();
        }

        public List<Personne> getAllPersonne()
        {
            String query = " select * from personne";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Personne> listLogement = new List<Personne>();
            while (reader.Read())
            {
                listLogement.Add(new Personne(
                    Convert.ToInt32(reader.GetValue(0)),
                    reader.GetValue(1).ToString(),
                    reader.GetValue(2).ToString()
                    ));
            }
            return listLogement;
        }

        public List<Personne> getPersoneByName(string name)
        {
            String query = "select * from personne where nom like '%"+name+"%'";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Personne> listLogement = new List<Personne>();
            while (reader.Read())
            {
                listLogement.Add(new Personne(
                    Convert.ToInt32(reader.GetValue(0)),
                    reader.GetValue(1).ToString(),
                    reader.GetValue(2).ToString()
                    ));
            }
            return listLogement;
        }

    }


}
