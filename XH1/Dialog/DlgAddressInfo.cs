using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XH1.Entity;

namespace XH1.Dialog
{
    public partial class DlgAddressInfo : Form
    {
        public AppAddressInfo _AddressInfo = null;
        private bool _IsEdit;
        private bool isChecked;
        public DlgAddressInfo(AppAddressInfo addressInfo)
        {
            if (addressInfo == null)
                _IsEdit = false;
            else
            {
                _AddressInfo = addressInfo;
                _IsEdit = true;
            }
            InitializeComponent();
        }

        private void AddressInfo_Load(object sender, EventArgs e)
        {
            radVisible.Checked = false;
            if (_IsEdit)
            {
                this.Text = "编辑";
                txtDisplayName.Text = _AddressInfo.DisplayName;
                txtAddress.Text = _AddressInfo.Value;
                radVisible.Checked = _AddressInfo.Visible == "1" ? true : false;
            }
            else
                this.Text = "新增";

            isChecked = radVisible.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_AddressInfo == null)
            {
                _AddressInfo = new AppAddressInfo();
                _AddressInfo.IDName = Guid.NewGuid().ToString() + "Address";
                _AddressInfo.Index = "0";
            }
            _AddressInfo.DisplayName = txtDisplayName.Text;
            _AddressInfo.Value = txtAddress.Text;
            _AddressInfo.Visible = radVisible.Checked ? "1" : "0";

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void radVisible_Click(object sender, EventArgs e)
        {
            if (isChecked)
                radVisible.Checked = isChecked = false;
            else
                radVisible.Checked = isChecked = true;
        }
    }
}
