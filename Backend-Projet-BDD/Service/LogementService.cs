using Backend_Projet_BDD.IService;
using System.Data.SqlClient;

namespace Backend_Projet_BDD.Service
{
    public class LogementService: ILogementService
    {
        SqlConnection _con;
        public LogementService()
        {
          //  String strConnexion = "Data Source =DESKTOP-103GNA6\\SQLEXPRESS;Initial Catalog= ProjetBDD; Integrated Security = true";
          //  _con = new SqlConnection(strConnexion);
          //  _con.Open();
        }

        public string getAllLogement()
        {
            /*  String query = "Select * from Logement";
              SqlCommand cmd = new SqlCommand(query,_con);
              SqlDataReader reader = cmd.ExecuteReader();
              while (reader.Read())
              {
                  System.Diagnostics.Debug.WriteLine( reader.GetValue(1));
              }
              System.Diagnostics.Debug.WriteLine("///////////////");
              return reader.GetValue(0).ToString();*/
            return "r";
        }
    }
}
