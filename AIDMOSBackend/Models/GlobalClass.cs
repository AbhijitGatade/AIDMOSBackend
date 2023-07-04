using Microsoft.AspNetCore.Routing.Constraints;
using System.Data;
using System.Data.SqlClient;

namespace AIDMOSBackend.Models
{
    public class GlobalClass
    {
        string constr = "";
        public GlobalClass(IConfiguration configuration)
        {
            this.constr = configuration.GetConnectionString("DbConStr");
        }

        public DataTable GetDataTable(string query)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dtable = new DataTable();
            da.Fill(dtable);
            return dtable;
        }
    }
}
