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
        public List<AppAddressInfo> AllAddressList = new List<AppAddressInfo>();

        private List<AppAddressInfo> _CurrentAllAddressList = new List<AppAddressInfo>();
        public Setting(List<AppAddressInfo> addressList)
        {
            foreach (var address in addressList)
            {
                AllAddressList.Add(address);
                _CurrentAllAddressList.Add(address);
            }
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            InitToolStripItemList();
        }

        private void InitToolStripItemList()
        {
            this.exeListBox.Items.Clear();
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

                if (AllAddressList.FirstOrDefault(x => x.DisplayName == result.DisplayName) != null)
                {
                    MessageBox.Show("该条目名称已存在，请修改！");
                    return;
                }
                else
                {
                    AllAddressList.Add(result);
                    AllAddressList = AllAddressList.OrderBy(x => int.Parse(x.Index)).ToList();
                    InitToolStripItemList();
                }
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
                var needUpdateItem = AllAddressList.FirstOrDefault(x => x.IDName == result.IDName && x.DisplayName == result.DisplayName);
                AllAddressList.Remove(needUpdateItem);
                AllAddressList.Add(result);
                AllAddressList = AllAddressList.OrderBy(x => int.Parse(x.Index)).ToList();
                InitToolStripItemList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.exeListBox.SelectedItem == null)
            {
                MessageBox.Show("请先选中");
                return;
            }
            else
            {
                AllAddressList.Remove(AllAddressList.FirstOrDefault(x => x.DisplayName == this.exeListBox.SelectedItem.ToString()));
                InitToolStripItemList();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
