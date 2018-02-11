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
            obj.DDLCountry(CmbCountry);
        }

        private void CmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int COUNTRY_ID = Convert.ToInt32(CmbCountry.SelectedValue);
                obj.DDLProvince(CmbProvince, COUNTRY_ID);
            }
            catch (Exception)
            {

            }
        }

        private void CmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int PROVINCE_ID = Convert.ToInt32(CmbProvince.SelectedValue);
                obj.DDLCity(CmbCity, PROVINCE_ID);
            }
            catch (Exception)
            {

            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string FIRST_NAME = txtName.Text;
                string LAST_NAME = txtLName.Text;
                string FATHER_FIRST_NAME = txtFName.Text;
                string FATHER_LAST_NAME = txtFLName.Text;
                string SEX = "Female";
                if (rbtnMale.Checked)
                {
                    SEX = "Male";
                }
                string DATE_OF_BIRTH = dateTimePicker1.Text;
                string EMAIL = txtEmail.Text;
                string MOBILE = txtPhone.Text;
                string MAILING_ADDRESS = txtAddress.Text;
                int CITY_ID = Convert.ToInt32(CmbCity.SelectedValue);
                int PROVINCE_ID = Convert.ToInt32(CmbProvince.SelectedValue);
                int COUNTRY_ID = Convert.ToInt32(CmbCountry.SelectedValue);

                MessageBox.Show(obj.Insert(FIRST_NAME, LAST_NAME, FATHER_FIRST_NAME, FATHER_LAST_NAME, SEX, DATE_OF_BIRTH, EMAIL, MOBILE, MAILING_ADDRESS, CITY_ID, PROVINCE_ID, COUNTRY_ID));

            }
            catch(Exception)
            {

            }
        }
    }
}
