using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DbConnection
{
    class DDL
    {
        //SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        Connect conn;

       public DDL()
        {
            try
            {
                conn = new Connect();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public void DDLCountry(ComboBox ddlcountry)
        {
            try
            {
                adp = new SqlDataAdapter("SELECT * FROM COUNTRY", conn.OpenConn());
                dt = new DataTable();
                adp.Fill(dt);
                ddlcountry.DataSource = dt;
                ddlcountry.DisplayMember = "COUNTRY_NAME";
                ddlcountry.ValueMember = "COUNTRY_ID";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DDLProvince(ComboBox ddlprovince, int COUNTRY_ID)
        {
            try
            {
                adp = new SqlDataAdapter("SELECT * FROM PROVINCE WHERE C_ID = " + COUNTRY_ID + "", conn.OpenConn());
                dt = new DataTable();
                adp.Fill(dt);
                ddlprovince.DataSource = dt;
                ddlprovince.DisplayMember = "PROVINCE_NAME";
                ddlprovince.ValueMember = "PROVINCE_ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DDLCity(ComboBox ddlcity, int PROVINCE_ID)
        {
            try
            {
                adp = new SqlDataAdapter("SELECT * FROM CITY WHERE PRO_ID = " + PROVINCE_ID + "", conn.OpenConn());
                dt = new DataTable();
                adp.Fill(dt);
                ddlcity.DataSource = dt;
                ddlcity.DisplayMember = "CITY_NAME";
                ddlcity.ValueMember = "CITY_ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
