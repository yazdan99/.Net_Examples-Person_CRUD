using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class frmAdd : Form
    {
        #region [- ctor -]
        public frmAdd()
        {
            InitializeComponent();
            Ref_PersonViewModel = new ViewModel.PersonViewModel();

        } 
        #endregion

        #region [- Props -]
        public ViewModel.PersonViewModel Ref_PersonViewModel { get; set; }
        #endregion

        #region [- btnSave_Click -]
        private void btnSave_Click(object sender, EventArgs e)
        {

            #region [- Trim -]
            txtNationalCode.Text = txtNationalCode.Text.Trim();
            txtName.Text = txtName.Text.Trim();
            txtSurname.Text = txtSurname.Text.Trim();
            txtCountry.Text = txtCountry.Text.Trim();
            txtEmailAddress.Text = txtEmailAddress.Text.Trim();
            txtMobilNumber.Text = txtMobilNumber.Text.Trim();
            txtUsername.Text = txtUsername.Text.Trim();
            txtPassword.Text = txtPassword.Text.Trim();
            txtAddress.Text = txtAddress.Text.Trim();
            #endregion

            if (txtName.Text == "" || txtSurname.Text == "" || txtNationalCode.Text==""
                || txtMobilNumber.Text == ""|| cmbTitle.SelectedIndex == -1)
            {                
                if (cmbTitle.SelectedIndex == -1)
                {
                    MessageBox.Show("Title Must Be Choose");
                    cmbTitle.Focus();
                }
                else if (txtNationalCode.Text == "")
                {
                    MessageBox.Show("National Code Can Not Be Empty");
                    txtNationalCode.Focus();
                }
                else if (txtName.Text == "")
                {
                    MessageBox.Show("Given Name Can Not Be Empty");
                    txtName.Focus();
                }
                else if (txtSurname.Text == "")
                {
                    MessageBox.Show("Family Name Can Not Be Empty");
                    txtSurname.Focus();
                }
                else if (txtMobilNumber.Text == "")
                {
                    MessageBox.Show("Mobile Number Can Not Be Empty");
                    txtMobilNumber.Focus();
                }                
            }        
            else
            {

                Ref_PersonViewModel.Save(cmbTitle.SelectedItem.ToString(), txtNationalCode.Text,
                    txtName.Text, txtSurname.Text, txtCountry.Text, Convert.ToDateTime(dtpBirth.Value.ToShortDateString()),
                    txtEmailAddress.Text, txtMobilNumber.Text, txtUsername.Text,
                    txtPassword.Text, txtAddress.Text);
                MessageBox.Show("Save is done.");
                this.Close();
                

            }
        } 
        #endregion

        #region [- btnExit_Click -]
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region [- txtNationalCode_TextChanged -]
        private void txtNationalCode_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtNationalCode.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtNationalCode.Text = txtNationalCode.Text.Remove(txtNationalCode.Text.Length - 1);
            }
        }
        #endregion

        #region [- txtMobilNumber_TextChanged -]
        private void txtMobilNumber_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtMobilNumber.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtMobilNumber.Text = txtMobilNumber.Text.Remove(txtMobilNumber.Text.Length - 1);
            }
        }
        #endregion
       
        #region [- btnShowPassword_Click(object sender, EventArgs e) -]
        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (btnShowPassword.Text == "Show")
            {
                txtPassword.PasswordChar = '\0';
                btnShowPassword.Text = "Hide";
                txtPassword.Focus();
            }
            else
            {
                txtPassword.PasswordChar = '*';
                btnShowPassword.Text = "Show";
                txtPassword.Focus();
            }
        }
        #endregion

        #region [- Empty Birth Date -]

        #region [- frmAdd_Load(object sender, EventArgs e) -]
        private void frmAdd_Load(object sender, EventArgs e)
        {
            dtpBirth.CustomFormat = " ";
            dtpBirth.Format = DateTimePickerFormat.Custom;

        }
        #endregion

        #region [- dtpBirth_ValueChanged(object sender, EventArgs e) -]
        private void dtpBirth_ValueChanged(object sender, EventArgs e)
        {
            dtpBirth.CustomFormat = "dd/MM/yyyy";
        }
        #endregion 

        #endregion
    }
}
