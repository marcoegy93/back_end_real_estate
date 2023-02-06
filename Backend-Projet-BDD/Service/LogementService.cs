using Backend_Projet_BDD.IService;
using Backend_Projet_BDD.Modele;
using System.Data.SqlClient;

namespace Backend_Projet_BDD.Service
{
    public class LogementService: ILogementService
    {
        SqlConnection _con;
        public LogementService()
        {
            String strConnexion = "Data Source =DESKTOP-103GNA6\\SQLEXPRESS;Initial Catalog= master; Integrated Security = true";
            _con = new SqlConnection(strConnexion);
            _con.Open();
        }

        public List<Logement> getAllLogement()
        {
              String query = "Select l.*, p.nom as 'nomProprio' from Logement l inner join Personne p on p.id_Personne= l.id_Proprietaire";
              SqlCommand cmd = new SqlCommand(query,_con);
              SqlDataReader reader = cmd.ExecuteReader();
              List<Logement> listLogement = new List<Logement>();
              while (reader.Read())
              {
                listLogement.Add(new Logement(
                        Convert.ToInt32(reader.GetValue(0)) ,
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        Convert.ToInt32(reader.GetValue(3)),
                        Convert.ToSingle(reader.GetValue(4)),
                        reader.GetValue(5).ToString(),
                        reader.GetValue(6).ToString(),
                        Convert.ToInt32(reader.GetValue(7)),
                        reader.GetValue(8).ToString(),
                        reader.GetValue(9).ToString(),
                        reader.GetValue(11).ToString()

                    ));
              }
            return listLogement;
        }
    }
}
