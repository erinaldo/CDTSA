using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Util;

namespace CG
{
    public partial class frmShowHideColumns : DevExpress.XtraEditors.XtraForm
    {
        List<clsColumnGrid> lstLista = new List<clsColumnGrid>();
        public frmShowHideColumns(List<clsColumnGrid> lstLista)
        {
            InitializeComponent();
            this.lstLista = lstLista;
            this.Load += FrmShowHideColumns_Load;
            this.chkList.ItemCheck += ChkList_ItemCheck;
        }

        private void ChkList_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                lstLista.FirstOrDefault(a => a.Name == this.chkList.Items[e.Index].Tag.ToString()).Visible = (e.State == CheckState.Checked) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void FrmShowHideColumns_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (clsColumnGrid col in lstLista)
                {
                    DevExpress.XtraEditors.Controls.CheckedListBoxItem item = new DevExpress.XtraEditors.Controls.CheckedListBoxItem();
                    item.Value = col.Caption;
                    item.Tag = col.Name;
                    item.CheckState = (col.Visible) ? CheckState.Checked : CheckState.Unchecked;
                    this.chkList.Items.Add(item);

                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<clsColumnGrid> GetLista()
        {
            return lstLista;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}