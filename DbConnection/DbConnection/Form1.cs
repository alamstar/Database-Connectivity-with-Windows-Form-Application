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
        int R_ID;
        public Form1()
        {
            InitializeComponent();
            ClearView();
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
                ClearView();
            }
            catch(Exception)
            {

            }
        }

        public void ClearView()
        {
            DataGridView1.DataSource = obj.DataView();
            txtName.Text = null;
            txtLName.Text = null;
            txtFName.Text = null;
            txtFLName.Text = null;
            rbtnMale.Checked = false;
            rbtnFemale.Checked = false;
            dateTimePicker1.Text = null;
            txtEmail.Text = null;
            txtPhone.Text = null;
            txtAddress.Text = null;
            CmbCity.SelectedValue = null;
            CmbProvince.SelectedValue = null;
            CmbCountry.SelectedValue = null;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                R_ID = Convert.ToInt32(DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLName.Text = DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtFName.Text = DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtFLName.Text = DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                if (DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "Male" || DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "MALE")
                {
                    rbtnMale.Checked = true;
                    rbtnFemale.Checked = false;
                }
                else
                {
                    rbtnMale.Checked = false;
                    rbtnFemale.Checked = true;
                }

                dateTimePicker1.Text = DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtEmail.Text = DataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtPhone.Text = DataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtAddress.Text = DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

                CmbCountry.Text = DataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                obj.DDLProvince(CmbProvince, Convert.ToInt32(CmbCountry.SelectedValue.ToString()));
                        
                CmbProvince.Text = DataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                obj.DDLCity(CmbCity, Convert.ToInt32(CmbProvince.SelectedValue.ToString()));

                CmbCity.Text = DataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
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
                else if (rbtnFemale.Checked)
                {
                    SEX = "Female";
                }
                string DATE_OF_BIRTH = dateTimePicker1.Text;
                string EMAIL = txtEmail.Text;
                string MOBILE = txtPhone.Text;
                string MAILING_ADDRESS = txtAddress.Text;
                int CITY_ID = Convert.ToInt32(CmbCity.SelectedValue);
                int PROVINCE_ID = Convert.ToInt32(CmbProvince.SelectedValue);
                int COUNTRY_ID = Convert.ToInt32(CmbCountry.SelectedValue);
                MessageBox.Show(obj.Update(R_ID, FIRST_NAME, LAST_NAME, FATHER_FIRST_NAME, FATHER_LAST_NAME, SEX, DATE_OF_BIRTH, EMAIL, MOBILE, MAILING_ADDRESS, CITY_ID, PROVINCE_ID, COUNTRY_ID));
                ClearView();
            }
            catch(Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                obj.Delete(R_ID);
                MessageBox.Show("Record Deleted Successfully.");
                ClearView();
            }
            catch (Exception)
            {

            }
        }
    }
}
