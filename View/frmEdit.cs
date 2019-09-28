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
    public partial class frmEdit : Form
    {
        #region [- ctor -]
        public frmEdit(Int32 id,string title, string nationalCod,string givenName, string familyName,string country,
            DateTime dateOfBirth, string email, string mobileNumber, string username,
            string password,string address)
        {
            InitializeComponent();
            Ref_PersonViewModel = new ViewModel.PersonViewModel();

            txtId.Text = System.Convert.ToString(id);
            cmbTitle.SelectedItem = title;
            txtNationalCode.Text = nationalCod;
            txtName.Text = givenName;
            txtSurname.Text = familyName;
            txtCountry.Text = country;
            dtpBirth.Value = dateOfBirth;
            txtEmailAddress.Text = email;
            txtMobilNumber.Text = mobileNumber;
            txtUsername.Text = username;
            txtPassword.Text = password;
            txtAddress.Text = address;
        }
        #endregion

        #region [- Props -]
        public ViewModel.PersonViewModel Ref_PersonViewModel { get; set; }

        #endregion

        #region [- btnExit_Click -]
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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

            if (txtName.Text == "" || txtSurname.Text == "" || txtNationalCode.Text == ""
                || txtMobilNumber.Text == "" || cmbTitle.SelectedIndex == -1)
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

                Ref_PersonViewModel.Edit(txtId.Text, cmbTitle.SelectedItem.ToString(), txtNationalCode.Text,
                    txtName.Text, txtSurname.Text, txtCountry.Text, Convert.ToDateTime(dtpBirth.Value.ToShortDateString()),
                    txtEmailAddress.Text, txtMobilNumber.Text, txtUsername.Text,
                    txtPassword.Text, txtAddress.Text);
                MessageBox.Show("Edit is done.");
                this.Close();


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
        
    }
}