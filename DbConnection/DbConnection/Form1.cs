using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbConnection
{
    public partial class Form1 : Form
    {
        DDL obj = new DDL();
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            obj.DDLCountry(cmbCountry);
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int COUNTRY_ID = Convert.ToInt32(cmbCountry.SelectedValue);
                obj.DDLProvince(cmbProvince, COUNTRY_ID);
            }
            catch (Exception)
            {

            }
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int PROVINCE_ID = Convert.ToInt32(cmbProvince.SelectedValue);
                obj.DDLCity(cmbCity, PROVINCE_ID);
            }
            catch (Exception)
            {

            }
        }
    }
}
