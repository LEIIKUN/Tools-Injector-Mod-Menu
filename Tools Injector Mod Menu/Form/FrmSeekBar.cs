﻿using System;
using System.Windows.Forms;
using Tools_Injector_Mod_Menu.Patch_Manager;

namespace Tools_Injector_Mod_Menu
{
    public partial class FrmSeekBar : Form
    {
        public FrmSeekBar()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!MyMessage.MsgOkCancel("Do you want to save?\n\n" +
                                       "Click \"OK\" to confirm.\n\n" +
                                       "Click \"Cancel\" to cancel.")) return;
            Values.SeekBar = $"{numMin.Value}_{numMax.Value}";
            if (chkField.Checked)
            {
                if (Utility.IsEmpty(txtOffset)) return;
                Values.Field = chkField.Checked;
                Values.Type = (Enums.Type) comboType.SelectedIndex;
                Values.Offset = txtOffset.Text;
            }
            Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!MyMessage.MsgOkCancel("Do you want to close?\n\n" +
                                       "Click \"OK\" to confirm.\n\n" +
                                       "Click \"Cancel\" to cancel.")) return;
            Dispose();
        }

        private void NumValueChanged(object sender, EventArgs e)
        {
            if (numMax.Value <= numMin.Value)
            {
                numMax.Value = numMin.Value + 1;
            }
        }
        
        private void chkField_CheckedChanged(object sender, EventArgs e)
        {
            if (chkField.Checked)
            {
                txtOffset.Enabled = true;
                comboType.Enabled = true;
            }
            else
            {
                txtOffset.Enabled = false;
                comboType.Enabled = false;
            }
        }
    }
}