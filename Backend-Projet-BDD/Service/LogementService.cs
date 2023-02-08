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
            //String strConnexion = "Data Source =DESKTOP-103GNA6\\SQLEXPRESS;Initial Catalog= master; Integrated Security = true"; Abdel DATABASE
            String strConnexion = "Data Source =DESKTOP-H4NG18I\\SQLEXPRESS;Initial Catalog= Immobilier; Integrated Security = true";
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
                        Convert.ToInt32(reader.GetValue(4)),
                        reader.GetValue(5).ToString(),
                        reader.GetValue(6).ToString(),
                        Convert.ToSingle(reader.GetValue(7)),
                        Convert.ToDateTime(reader.GetValue(8)).ToString("dd/MM/yyyy"),
                        reader.GetValue(9).ToString(),
                        reader.GetValue(11).ToString()

                    ));
                string s = reader.GetValue(10).ToString();
              }
            return listLogement;
        }

        public List<Logement> getLogementByWord(string word)
        {
            String query = "select l.*, p.nom as 'nomProprio' from Logement l inner join Personne p on p.id_Personne= l.id_Proprietaire where l.dateDispo like '%" + word + "%' or l.adresse like '%" + word + "%' or l.type like '%" + word + "%' or l.nbPiece like '%" + word + "%' or l.surface like '%" + word + "%' or l.etat like '%" + word + "%' or l.objetGestion like '%" + word + "%' or l.prix like '%" + word + "%' or l.ville like '%" + word + "%' or p.nom like '%" + word + "%'";
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Logement> listLogement = new List<Logement>();
            while (reader.Read())
            {
                listLogement.Add(new Logement(
                    Convert.ToInt32(reader.GetValue(0)),
                    reader.GetValue(1).ToString(),
                    reader.GetValue(2).ToString(),
                    Convert.ToInt32(reader.GetValue(3)),
                    Convert.ToInt32(reader.GetValue(4)),
                    reader.GetValue(5).ToString(),
                    reader.GetValue(6).ToString(),
                    Convert.ToSingle(reader.GetValue(7)),
                    Convert.ToDateTime(reader.GetValue(8)).ToString("dd/MM/yyyy"),
                    reader.GetValue(9).ToString(),
                    reader.GetValue(11).ToString()
                    ));
            }
            return listLogement;
        }

        public List<Logement> getLogementByCriteria(Criteria criteria)
        {
            String whereType = criteria.type!="" ? ("l.type = '"+ criteria.type + "' and ") : "";
            String wherenbPieces = criteria.nbPiece != null ? ("l.nbPiece = '" + criteria.nbPiece + "' and ") : "";
            String whereSurface = criteria.surface != null ? ("l.surface = '" + criteria.surface + "' and ") : "";
            String whereEtat = criteria.etat != "" ? ("l.etat = '" + criteria.etat + "' and ") : "";
            String whereObjet = criteria.objetGestion != "" ? ("l.objetGestion = '" + criteria.objetGestion + "' and ") : "";
            String whereVille = criteria.ville != "" ? ("l.ville = '" + criteria.ville + "' and ") : "";
            String wherePrixMin = criteria.prixMinimum != null ? ("l.prix >= '" + criteria.prixMinimum + "' and ") : "";
            String wherePrixMax = criteria.prixMaximum != null ? ("l.prix <= '" + criteria.prixMaximum + "' and ") : "";
            String whereDate = "";
            if (criteria.dateDispo != "")
            {
                DateTime date = Convert.ToDateTime(criteria.dateDispo);
                String dateFormat = date.Year.ToString() + date.Month.ToString("D2") + date.Day.ToString("D2");
                whereDate = criteria.dateDispo != "" ? ("l.dateDispo >= '" + dateFormat + "' and ") : "";
            }
            String querytmp = "select l.*, p.nom as 'nomProprio' from Logement l inner join Personne p on p.id_Personne=l.id_Proprietaire where " + whereType + wherenbPieces + whereSurface + whereEtat + whereObjet + whereVille + wherePrixMin + wherePrixMax + whereDate;
            String query = querytmp.Substring(0, querytmp.Length - 5);
            SqlCommand cmd = new SqlCommand(query, _con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Logement> listLogement = new List<Logement>();
            while (reader.Read())
            {
                listLogement.Add(new Logement(
                    Convert.ToInt32(reader.GetValue(0)),
                    reader.GetValue(1).ToString(),
                    reader.GetValue(2).ToString(),
                    Convert.ToInt32(reader.GetValue(3)),
                    Convert.ToInt32(reader.GetValue(4)),
                    reader.GetValue(5).ToString(),
                    reader.GetValue(6).ToString(),
                    Convert.ToSingle(reader.GetValue(7)),
                    Convert.ToDateTime(reader.GetValue(8)).ToString("dd/MM/yyyy"),
                    reader.GetValue(9).ToString(),
                    reader.GetValue(11).ToString()
                    ));
            }
            return listLogement;
        }
    }
}
