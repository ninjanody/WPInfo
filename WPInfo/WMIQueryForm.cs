﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ventajou.WPInfo
{
    public partial class WMIQueryForm : Form
    {
        public WMIQueryForm()
        {
            InitializeComponent();
            foreach (WMIQuery W in Program.Settings.WMIQueries)
            {
                listQueries.Items.Add(W.Name);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true; txtName.ReadOnly = false;
            txtNamespace.Enabled = true; txtNamespace.ReadOnly = false;
            txtQuery.Enabled = true; txtQuery.ReadOnly = false;
            txtName.Focus();
            txtName.Text = "";
            txtNamespace.Text = "";
            txtQuery.Text = "";
            btnSave.Enabled = true;
        }

        private void listQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Enabled = false; txtName.ReadOnly = true;
            txtNamespace.Enabled = false; txtNamespace.ReadOnly = true;
            txtQuery.Enabled = false; txtQuery.ReadOnly = true;
            if (listQueries.SelectedItem != null)
            {
                WMIQuery W = Program.Settings.WMIQueries.Find(WMIQuery => WMIQuery.Name == (string)listQueries.SelectedItem);
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                txtName.Text = W.Name;
                txtNamespace.Text = W.Namespace;
                txtQuery.Text = W.Query;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                txtName.Text = "";
                txtNamespace.Text = "";
                txtQuery.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WMIQuery oldW = Program.Settings.WMIQueries.Find(WMIQuery => WMIQuery.Name == (string)listQueries.SelectedItem);
            WMIQuery W = new WMIQuery();
            W.Name = txtName.Text;
            W.Namespace = txtNamespace.Text;
            W.Query = txtQuery.Text;
            Program.Settings.WMIQueries.Remove(oldW);
            Program.Settings.WMIQueries.Add(W);
            if (oldW.Name != W.Name)
            {
                listQueries.Items.RemoveAt(listQueries.SelectedIndex);
                listQueries.Items.Add(txtName.Text);
            }
            listQueries.SelectedIndex = listQueries.Items.IndexOf(txtName.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            WMIQuery W = Program.Settings.WMIQueries.Find(WMIQuery => WMIQuery.Name == (string)listQueries.SelectedItem);
            Program.Settings.WMIQueries.Remove(W);
            listQueries.Items.RemoveAt(listQueries.SelectedIndex);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
