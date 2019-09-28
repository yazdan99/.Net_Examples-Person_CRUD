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
    public partial class Form1 : Form
    {
        #region [- ctor -]
        public Form1()
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
            frmAdd frmadd_ref = new frmAdd();
            frmadd_ref.ShowDialog();

        }
        #endregion

        #region [- btnRefresh_Click -]
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvPerson.DataSource = Ref_PersonViewModel.FillGrid(txtNationalCode.Text);
            dgvPerson.Columns[0].Visible = false;
            if (dgvPerson.RowCount == 0)
                MessageBox.Show("The Person List is Empty.");
        }
        #endregion               

        #region [- btnDelete_Click -]
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int z = 1;
            if (dgvPerson.RowCount == 0)
                MessageBox.Show("The Person List is Empty.");
            else
            {
                if (dgvPerson.SelectedRows.Count ==0)
                    MessageBox.Show("Please Selcet a Row.");
                else
                {
                    z = (int)dgvPerson.CurrentRow.Cells[0].Value;
                    Ref_PersonViewModel.Delete(z);
                    dgvPerson.DataSource = Ref_PersonViewModel.FillGrid(txtNationalCode.Text);
                    MessageBox.Show("Delete is done.");
                }
            }
        }
        #endregion

        #region [- btnEdit_Click -]
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPerson.RowCount == 0 )
                MessageBox.Show("The Person List is Empty.");
            else
            { 
                if (dgvPerson.SelectedRows.Count == 0)
                     MessageBox.Show("Please Selcet a Row.");
                else
                    {
                    frmEdit frmedit_ref = new frmEdit((Int32)dgvPerson.CurrentRow.Cells[0].Value,
                    (string)dgvPerson.CurrentRow.Cells[1].Value, (string)dgvPerson.CurrentRow.Cells[2].Value,
                    (string)dgvPerson.CurrentRow.Cells[3].Value, (string)dgvPerson.CurrentRow.Cells[4].Value,
                    (string)dgvPerson.CurrentRow.Cells[5].Value, (DateTime)dgvPerson.CurrentRow.Cells[6].Value,
                    (string)dgvPerson.CurrentRow.Cells[7].Value, (string)dgvPerson.CurrentRow.Cells[8].Value,
                    (string)dgvPerson.CurrentRow.Cells[9].Value, (string)dgvPerson.CurrentRow.Cells[10].Value,
                    (string)dgvPerson.CurrentRow.Cells[11].Value);
                    frmedit_ref.ShowDialog();
                    }
            }
        }
        #endregion

        #region [- btnExit_Click -]
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region [- Hide Password Column in Data Grid View -]

        #region [- dgvPerson_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) -]
        void dgvPerson_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPerson.Columns[e.ColumnIndex].Index == 10)
            {
                if (e.Value != null)
                {
                    e.Value = "********";
                    e.FormattingApplied = true;
                }
            }
        }
        #endregion

        #region [- dgvPerson_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) -]
        void dgvPerson_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox t = e.Control as TextBox;
            if (t != null)
            {
                t.Text = (string)dgvPerson.SelectedCells[10].Value;
            }
        }
        #endregion

        #region [- private void Form1_Load(object sender, EventArgs e) -]
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvPerson.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvPerson_CellFormatting);
            dgvPerson.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvPerson_EditingControlShowing);

        }
        #endregion

        #endregion
        
    }
}
