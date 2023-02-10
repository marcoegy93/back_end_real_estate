using Backend_Projet_BDD.IService;
using Backend_Projet_BDD.Modele;
using Microsoft.Extensions.Hosting;
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
              String query = "Select l.*, p.nom as 'nomProprio', count(g.id_Garage) as nbGarages,isnull((select top 1 (c.commissionBase + CAST(c.pourcentage as FLOAT)/100 * l.prix) as commission from Commission c where c.id_Logement = l.id_Logement order by c.date_Commission desc),0) as 'commission', max(v.date_Visite) as lastVisite from Logement l inner join Personne p on p.id_Personne= l.id_Proprietaire inner join Garage g on l.id_Logement = g.id_Logement LEFT join Commission c on c.id_Logement = l.id_Logement LEFT join Visite v on v.id_Logement = l.id_Logement group by l.id_Logement,l.adresse,l.type,l.nbPiece,l.surface,l.etat,l.objetGestion,l.prix,l.dateDispo,l.ville,l.id_Proprietaire, p.nom;";
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
                        Convert.ToInt32(reader.GetValue(7)),
                        Convert.ToDateTime(reader.GetValue(8)),
                        reader.GetValue(9).ToString(),
                        reader.GetValue(11).ToString(),
                        Convert.ToInt32(reader.GetValue(12)),
                        Convert.ToSingle(reader.GetValue(13)),
                        reader.GetValue(14).ToString()

                    ));
                string s = reader.GetValue(10).ToString();
              }
            return listLogement;
        }

        public List<Logement> getLogementByWord(string word)
        {
            String query = "Select l.*, p.nom as 'nomProprio', count(g.id_Garage) as nbGarages,isnull((select top 1 (c.commissionBase + CAST(c.pourcentage as FLOAT)/100 * l.prix) as commission from Commission c where c.id_Logement = l.id_Logement order by c.date_Commission desc),0) as 'commission', max(v.date_Visite) as lastVisite from Logement l inner join Personne p on p.id_Personne= l.id_Proprietaire inner join Garage g on l.id_Logement = g.id_Logement LEFT join Commission c on c.id_Logement = l.id_Logement LEFT join Visite v on v.id_Logement = l.id_Logement where l.dateDispo like '%" + word + "%' or l.adresse like '%" + word + "%' or l.type like '%" + word + "%' or l.nbPiece like '%" + word + "%' or l.surface like '%" + word + "%' or l.etat like '%" + word + "%' or l.objetGestion like '%" + word + "%' or l.prix like '%" + word + "%' or l.ville like '%" + word + "%' or p.nom like '%" + word + "%' group by l.id_Logement,l.adresse,l.type,l.nbPiece,l.surface,l.etat,l.objetGestion,l.prix,l.dateDispo,l.ville,l.id_Proprietaire, p.nom;";
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
                    Convert.ToInt32(reader.GetValue(7)),
                    Convert.ToDateTime(reader.GetValue(8)),
                    reader.GetValue(9).ToString(),
                    reader.GetValue(11).ToString(),
                    Convert.ToInt32(reader.GetValue(12)),
                    Convert.ToSingle(reader.GetValue(13)),
                    reader.GetValue(14).ToString()
                    ));
            }
            return listLogement;
        }

        public List<Logement> getLogementByCriteria(Criteria criteria)
        {
            String whereType = criteria.type!="" ? ("l.type = '"+ criteria.type + "' and ") : "";
            String wherenbPieces = criteria.nbPiece != null ? ("l.nbPiece = " + criteria.nbPiece + " and ") : "";
            String whereSurface = criteria.surface != null ? ("l.surface = " + criteria.surface + " and ") : "";
            String whereEtat = criteria.etat != "" ? ("l.etat = '" + criteria.etat + "' and ") : "";
            String whereObjet = criteria.objetGestion != "" ? ("l.objetGestion = '" + criteria.objetGestion + "' and ") : "";
            String whereVille = criteria.ville != "" ? ("l.ville = '" + criteria.ville + "' and ") : "";
            String wherePrixMin = criteria.prixMinimum != null ? ("l.prix >= " + criteria.prixMinimum + " and ") : "";
            String wherePrixMax = criteria.prixMaximum != null ? ("l.prix <= " + criteria.prixMaximum + " and ") : "";
            String havingNbGarages = criteria.nbGarages != null ? (" having(count(g.id_garage)) = " + criteria.nbGarages) : "";
            String where = "where " + whereType + wherenbPieces + whereSurface + whereEtat + whereObjet + whereVille + wherePrixMin + wherePrixMax;
            String whereTotal = where.Length == 6 ? " and " : where;
            String groupBy = " group by l.id_Logement,l.adresse,l.type,l.nbPiece,l.surface,l.etat,l.objetGestion,l.prix,l.dateDispo,l.ville,l.id_Proprietaire, p.nom ";
            String querytmp = "Select l.*, p.nom as 'nomProprio', count(g.id_Garage) as nbGarages,isnull((select top 1 (c.commissionBase + CAST(c.pourcentage as FLOAT)/100 * l.prix) as commission from Commission c where c.id_Logement = l.id_Logement order by c.date_Commission desc),0) as 'commission', max(v.date_Visite) as lastVisite from Logement l inner join Personne p on p.id_Personne= l.id_Proprietaire inner join Garage g on l.id_Logement = g.id_Logement LEFT join Commission c on c.id_Logement = l.id_Logement LEFT join Visite v on v.id_Logement = l.id_Logement " + whereTotal;
            String query = querytmp.Substring(0, querytmp.Length - 5) + groupBy + havingNbGarages;
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
                    Convert.ToInt32(reader.GetValue(7)),
                    Convert.ToDateTime(reader.GetValue(8)),
                    reader.GetValue(9).ToString(),
                    reader.GetValue(11).ToString(),
                    Convert.ToInt32(reader.GetValue(12)),
                    Convert.ToSingle(reader.GetValue(13)),
                    reader.GetValue(14).ToString()
                    ));
            }
            return listLogement;
        }
    }
}
