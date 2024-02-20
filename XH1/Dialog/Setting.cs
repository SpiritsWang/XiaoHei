using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XH1.Entity;
using XH1.Util;

namespace XH1.Dialog
{
    public partial class Setting : Form
    {
        private List<AppAddressInfo> AllAddressList;
        public Setting(List<AppAddressInfo> addressList)
        {
            AllAddressList = addressList;
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            InitToolStripItemList();
        }

        private void InitToolStripItemList()
        {
            foreach (var addressInfo in AllAddressList)
            {
                this.exeListBox.Items.Add(addressInfo.DisplayName);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.exeListBox.SelectedItem == null)
            {
                MessageBox.Show("请先选中");
                return;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.exeListBox.SelectedItem == null)
            {
                MessageBox.Show("请先选中");
                return;
            }
            else
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DlgAddressInfo dlgAddressInfo = new DlgAddressInfo(null);
            if (dlgAddressInfo.ShowDialog() == DialogResult.OK)
            {
                var result = dlgAddressInfo._AddressInfo;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.exeListBox.SelectedItem == null)
            {
                MessageBox.Show("请先选中");
                return;
            }
            AppAddressInfo selectedAddressInfo = AllAddressList.FirstOrDefault(x => x.DisplayName == this.exeListBox.SelectedItem.ToString());

            DlgAddressInfo dlgAddressInfo = new DlgAddressInfo(selectedAddressInfo);

            if (dlgAddressInfo.ShowDialog() == DialogResult.OK)
            {
                var result = dlgAddressInfo._AddressInfo;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.exeListBox.SelectedItem == null)
            {
                MessageBox.Show("请先选中");
                return;
            }
        }
    }
}
