﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSheep.Interface
{
    public partial class DofusPathForm : Form
    {
        /// <summary>
        /// Selection form of the dofus path.
        /// </summary>

        #region Fields
        int flag = 0;
        MainForm mainfrm;
        #endregion

        #region Constructors
        public DofusPathForm(MainForm main)
        {
            InitializeComponent();
            mainfrm = main;
        }
        #endregion

        #region Interface methods
        private void BtValider_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                FolderBrowserDialog_DofusPath.ShowDialog();
                TextBox1.Text = FolderBrowserDialog_DofusPath.SelectedPath;
                BtValider.Text = "Continuer";
                flag = 1;
            }
            else
            {
                if (Directory.Exists(TextBox1.Text + "\\app\\data\\i18n"))
                {
                    mainfrm.DofusPath = TextBox1.Text;
                    StreamWriter sr = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BlueSheep\bs.conf");
                    sr.WriteLine(TextBox1.Text);
                    sr.Close();
                    this.Close();
                    return;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Impossible de trouver le dossier : \"" + TextBox1.Text + @"\app\data\i18n\");
                    flag = 0;
                    BtValider.Text = "Parcourir";
                    TextBox1.Clear();
                }
            }
        }
        #endregion
    }
}
