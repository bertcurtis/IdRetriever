using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistIdProvider
{
    public class SetData
    {
        private string Sql(bool? hasLoyalty = null, string rankId = "1 and 10")
        {
            string query = string.Format("SQL QUERY HERE" , rankId);
            if(hasLoyalty.HasValue)
            {
                query += string.Format("SQL QUERY HERE", hasLoyalty.Value ? "1" : "0");
            }
            query += " SQL QUERY HERE";
            return query;
        }

        private string SqlCountries = "SQL QUERY HERE";
        private string sqlConn = "CONNECTION STRING HERE";
        public void SetCountries(ComboBox combo, DataLayer data)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(SqlCountries, sqlConn);

            DataSet countries = new DataSet();
            adapter.Fill(countries, "TABLE NAME HERE");
            //combo.DataSource = countries;

            for (int i = 0; i < countries.Tables[0].Rows.Count; i++)
            {
                combo.Items.Add(countries.Tables[0].Rows[i][0]);
            }
            for (int i = 0; i < combo.Items.Count -1; i++)
            {
                data.CountryName.Add(combo.Items[i].ToString());
            }
        }
        public void SetID(string country, DataLayer data, bool? checkBoxForNoLoyalty = null, string maxRankId = "1 and 10")
        {
            SqlConnection conn = new SqlConnection(sqlConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql(checkBoxForNoLoyalty, maxRankId), conn);
     
            cmd.Parameters.AddWithValue("@VARIABLE NAME HERE", country);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet distIds = new DataSet();
            adapter.Fill(distIds, "TABLE NAME HERE");

            if (data.DistIds.Count > 0)
            {
                data.DistIds.Clear();
            }
            for (int i = 0; i < distIds.Tables[0].Rows.Count; i++)
            {
                data.DistIds.Add(distIds.Tables[0].Rows[i][0].ToString());
            }
        }
    }
}
