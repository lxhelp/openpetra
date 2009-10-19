/* auto generated with nant generateWinforms from MainForm.yaml
 *
 * DO NOT edit manually, DO NOT edit with the designer
 * use a user control if you need to modify the screen content
 *
 */
/*************************************************************************
 *
 * DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 *
 * @Authors:
 *       auto generated
 *
 * Copyright 2004-2009 by OM International
 *
 * This file is part of OpenPetra.org.
 *
 * OpenPetra.org is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * OpenPetra.org is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
 *
 ************************************************************************/
using System;
using System.Windows.Forms;
using Mono.Unix;
using Ict.Common.Controls;
using Ict.Petra.Client.CommonControls;

namespace Ict.Petra.Client.MFinance.Gui.BankImport
{
    partial class TFrmMainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFrmMainForm));

            this.pnlContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInfoStatement = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.txtDateStatement = new System.Windows.Forms.TextBox();
            this.lblDateStatement = new System.Windows.Forms.Label();
            this.txtValueAltogether = new System.Windows.Forms.TextBox();
            this.lblValueAltogether = new System.Windows.Forms.Label();
            this.txtNumberAltogether = new System.Windows.Forms.TextBox();
            this.lblNumberAltogether = new System.Windows.Forms.Label();
            this.txtValueMatchedGifts = new System.Windows.Forms.TextBox();
            this.lblValueMatchedGifts = new System.Windows.Forms.Label();
            this.txtNumberMatched = new System.Windows.Forms.TextBox();
            this.lblNumberMatched = new System.Windows.Forms.Label();
            this.txtValueUnmatchedGifts = new System.Windows.Forms.TextBox();
            this.lblValueUnmatchedGifts = new System.Windows.Forms.Label();
            this.txtNumberUnmatched = new System.Windows.Forms.TextBox();
            this.lblNumberUnmatched = new System.Windows.Forms.Label();
            this.txtValueOther = new System.Windows.Forms.TextBox();
            this.lblValueOther = new System.Windows.Forms.Label();
            this.txtNumberOther = new System.Windows.Forms.TextBox();
            this.lblNumberOther = new System.Windows.Forms.Label();
            this.rgrFilter = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtAllTransactions = new System.Windows.Forms.RadioButton();
            this.rbtMatchedGifts = new System.Windows.Forms.RadioButton();
            this.rbtUnmatchedGifts = new System.Windows.Forms.RadioButton();
            this.rbtOther = new System.Windows.Forms.RadioButton();
            this.grdResult = new Ict.Common.Controls.TSgrdDataGridPaged();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.tbbImportStatement = new System.Windows.Forms.ToolStripButton();
            this.tbbExportGiftBatch = new System.Windows.Forms.ToolStripButton();
            this.tbbExportUnmatchedDonors = new System.Windows.Forms.ToolStripButton();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mniFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelpPetraHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator0 = new System.Windows.Forms.ToolStripSeparator();
            this.mniHelpBugReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniHelpAboutPetra = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelpDevelopmentTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.stbMain = new Ict.Common.Controls.TExtStatusBarHelp();

            this.pnlContent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlInfoStatement.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.rgrFilter.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tbrMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.stbMain.SuspendLayout();

            //
            // pnlContent
            //
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.AutoSize = true;
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.AutoSize = true;
            this.pnlContent.Controls.Add(this.tableLayoutPanel1);
            //
            // pnlInfoStatement
            //
            this.pnlInfoStatement.Location = new System.Drawing.Point(2,2);
            this.pnlInfoStatement.Name = "pnlInfoStatement";
            this.pnlInfoStatement.AutoSize = true;
            //
            // tableLayoutPanel2
            //
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.AutoSize = true;
            this.pnlInfoStatement.Controls.Add(this.tableLayoutPanel2);
            //
            // txtBankName
            //
            this.txtBankName.Location = new System.Drawing.Point(2,2);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(150, 28);
            this.txtBankName.ReadOnly = true;
            //
            // lblBankName
            //
            this.lblBankName.Location = new System.Drawing.Point(2,2);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.AutoSize = true;
            this.lblBankName.Text = "Bank Name:";
            this.lblBankName.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // txtDateStatement
            //
            this.txtDateStatement.Location = new System.Drawing.Point(2,2);
            this.txtDateStatement.Name = "txtDateStatement";
            this.txtDateStatement.Size = new System.Drawing.Size(150, 28);
            this.txtDateStatement.ReadOnly = true;
            //
            // lblDateStatement
            //
            this.lblDateStatement.Location = new System.Drawing.Point(2,2);
            this.lblDateStatement.Name = "lblDateStatement";
            this.lblDateStatement.AutoSize = true;
            this.lblDateStatement.Text = "Date Statement:";
            this.lblDateStatement.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // txtValueAltogether
            //
            this.txtValueAltogether.Location = new System.Drawing.Point(2,2);
            this.txtValueAltogether.Name = "txtValueAltogether";
            this.txtValueAltogether.Size = new System.Drawing.Size(150, 28);
            this.txtValueAltogether.ReadOnly = true;
            //
            // lblValueAltogether
            //
            this.lblValueAltogether.Location = new System.Drawing.Point(2,2);
            this.lblValueAltogether.Name = "lblValueAltogether";
            this.lblValueAltogether.AutoSize = true;
            this.lblValueAltogether.Text = "Value Altogether:";
            this.lblValueAltogether.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // txtNumberAltogether
            //
            this.txtNumberAltogether.Location = new System.Drawing.Point(2,2);
            this.txtNumberAltogether.Name = "txtNumberAltogether";
            this.txtNumberAltogether.Size = new System.Drawing.Size(150, 28);
            this.txtNumberAltogether.ReadOnly = true;
            //
            // lblNumberAltogether
            //
            this.lblNumberAltogether.Location = new System.Drawing.Point(2,2);
            this.lblNumberAltogether.Name = "lblNumberAltogether";
            this.lblNumberAltogether.AutoSize = true;
            this.lblNumberAltogether.Text = "Number Altogether:";
            this.lblNumberAltogether.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // txtValueMatchedGifts
            //
            this.txtValueMatchedGifts.Location = new System.Drawing.Point(2,2);
            this.txtValueMatchedGifts.Name = "txtValueMatchedGifts";
            this.txtValueMatchedGifts.Size = new System.Drawing.Size(150, 28);
            this.txtValueMatchedGifts.ReadOnly = true;
            //
            // lblValueMatchedGifts
            //
            this.lblValueMatchedGifts.Location = new System.Drawing.Point(2,2);
            this.lblValueMatchedGifts.Name = "lblValueMatchedGifts";
            this.lblValueMatchedGifts.AutoSize = true;
            this.lblValueMatchedGifts.Text = "Value Matched Gifts:";
            this.lblValueMatchedGifts.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // txtNumberMatched
            //
            this.txtNumberMatched.Location = new System.Drawing.Point(2,2);
            this.txtNumberMatched.Name = "txtNumberMatched";
            this.txtNumberMatched.Size = new System.Drawing.Size(150, 28);
            this.txtNumberMatched.ReadOnly = true;
            //
            // lblNumberMatched
            //
            this.lblNumberMatched.Location = new System.Drawing.Point(2,2);
            this.lblNumberMatched.Name = "lblNumberMatched";
            this.lblNumberMatched.AutoSize = true;
            this.lblNumberMatched.Text = "Number Matched:";
            this.lblNumberMatched.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // txtValueUnmatchedGifts
            //
            this.txtValueUnmatchedGifts.Location = new System.Drawing.Point(2,2);
            this.txtValueUnmatchedGifts.Name = "txtValueUnmatchedGifts";
            this.txtValueUnmatchedGifts.Size = new System.Drawing.Size(150, 28);
            this.txtValueUnmatchedGifts.ReadOnly = true;
            //
            // lblValueUnmatchedGifts
            //
            this.lblValueUnmatchedGifts.Location = new System.Drawing.Point(2,2);
            this.lblValueUnmatchedGifts.Name = "lblValueUnmatchedGifts";
            this.lblValueUnmatchedGifts.AutoSize = true;
            this.lblValueUnmatchedGifts.Text = "Value Unmatched Gifts:";
            this.lblValueUnmatchedGifts.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // txtNumberUnmatched
            //
            this.txtNumberUnmatched.Location = new System.Drawing.Point(2,2);
            this.txtNumberUnmatched.Name = "txtNumberUnmatched";
            this.txtNumberUnmatched.Size = new System.Drawing.Size(150, 28);
            this.txtNumberUnmatched.ReadOnly = true;
            //
            // lblNumberUnmatched
            //
            this.lblNumberUnmatched.Location = new System.Drawing.Point(2,2);
            this.lblNumberUnmatched.Name = "lblNumberUnmatched";
            this.lblNumberUnmatched.AutoSize = true;
            this.lblNumberUnmatched.Text = "Number Unmatched:";
            this.lblNumberUnmatched.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // txtValueOther
            //
            this.txtValueOther.Location = new System.Drawing.Point(2,2);
            this.txtValueOther.Name = "txtValueOther";
            this.txtValueOther.Size = new System.Drawing.Size(150, 28);
            this.txtValueOther.ReadOnly = true;
            //
            // lblValueOther
            //
            this.lblValueOther.Location = new System.Drawing.Point(2,2);
            this.lblValueOther.Name = "lblValueOther";
            this.lblValueOther.AutoSize = true;
            this.lblValueOther.Text = "Value Other:";
            this.lblValueOther.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // txtNumberOther
            //
            this.txtNumberOther.Location = new System.Drawing.Point(2,2);
            this.txtNumberOther.Name = "txtNumberOther";
            this.txtNumberOther.Size = new System.Drawing.Size(150, 28);
            this.txtNumberOther.ReadOnly = true;
            //
            // lblNumberOther
            //
            this.lblNumberOther.Location = new System.Drawing.Point(2,2);
            this.lblNumberOther.Name = "lblNumberOther";
            this.lblNumberOther.AutoSize = true;
            this.lblNumberOther.Text = "Number Other:";
            this.lblNumberOther.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblBankName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblValueAltogether, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblValueMatchedGifts, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblValueUnmatchedGifts, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblValueOther, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtBankName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtValueAltogether, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtValueMatchedGifts, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtValueUnmatchedGifts, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtValueOther, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblDateStatement, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblNumberAltogether, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblNumberMatched, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblNumberUnmatched, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblNumberOther, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtDateStatement, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNumberAltogether, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtNumberMatched, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtNumberUnmatched, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtNumberOther, 3, 4);
            //
            // rgrFilter
            //
            this.rgrFilter.Location = new System.Drawing.Point(2,2);
            this.rgrFilter.Name = "rgrFilter";
            this.rgrFilter.AutoSize = true;
            //
            // tableLayoutPanel3
            //
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.AutoSize = true;
            this.rgrFilter.Controls.Add(this.tableLayoutPanel3);
            //
            // rbtAllTransactions
            //
            this.rbtAllTransactions.Location = new System.Drawing.Point(2,2);
            this.rbtAllTransactions.Name = "rbtAllTransactions";
            this.rbtAllTransactions.AutoSize = true;
            this.rbtAllTransactions.CheckedChanged += new System.EventHandler(this.FilterChanged);
            this.rbtAllTransactions.Text = "AllTransactions";
            this.rbtAllTransactions.Checked = true;
            //
            // rbtMatchedGifts
            //
            this.rbtMatchedGifts.Location = new System.Drawing.Point(2,2);
            this.rbtMatchedGifts.Name = "rbtMatchedGifts";
            this.rbtMatchedGifts.AutoSize = true;
            this.rbtMatchedGifts.CheckedChanged += new System.EventHandler(this.FilterChanged);
            this.rbtMatchedGifts.Text = "MatchedGifts";
            //
            // rbtUnmatchedGifts
            //
            this.rbtUnmatchedGifts.Location = new System.Drawing.Point(2,2);
            this.rbtUnmatchedGifts.Name = "rbtUnmatchedGifts";
            this.rbtUnmatchedGifts.AutoSize = true;
            this.rbtUnmatchedGifts.CheckedChanged += new System.EventHandler(this.FilterChanged);
            this.rbtUnmatchedGifts.Text = "UnmatchedGifts";
            //
            // rbtOther
            //
            this.rbtOther.Location = new System.Drawing.Point(2,2);
            this.rbtOther.Name = "rbtOther";
            this.rbtOther.AutoSize = true;
            this.rbtOther.CheckedChanged += new System.EventHandler(this.FilterChanged);
            this.rbtOther.Text = "Other";
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Controls.Add(this.rbtAllTransactions, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rbtMatchedGifts, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.rbtUnmatchedGifts, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.rbtOther, 3, 0);
            this.rgrFilter.Text = "Filter";
            //
            // grdResult
            //
            this.grdResult.Name = "grdResult";
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Controls.Add(this.pnlInfoStatement, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rgrFilter, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdResult, 0, 2);
            //
            // tbbImportStatement
            //
            this.tbbImportStatement.Name = "tbbImportStatement";
            this.tbbImportStatement.AutoSize = true;
            this.tbbImportStatement.Click += new System.EventHandler(this.ImportStatement);
            this.tbbImportStatement.Text = "&Import Statement";
            //
            // tbbExportGiftBatch
            //
            this.tbbExportGiftBatch.Name = "tbbExportGiftBatch";
            this.tbbExportGiftBatch.AutoSize = true;
            this.tbbExportGiftBatch.Text = "Export Gift Batch";
            //
            // tbbExportUnmatchedDonors
            //
            this.tbbExportUnmatchedDonors.Name = "tbbExportUnmatchedDonors";
            this.tbbExportUnmatchedDonors.AutoSize = true;
            this.tbbExportUnmatchedDonors.Text = "Export Unmatched Donors";
            //
            // tbrMain
            //
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbrMain.AutoSize = true;
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           tbbImportStatement,
                        tbbExportGiftBatch,
                        tbbExportUnmatchedDonors});
            //
            // mniClose
            //
            this.mniClose.Name = "mniClose";
            this.mniClose.AutoSize = true;
            this.mniClose.Click += new System.EventHandler(this.actClose);
            this.mniClose.Image = ((System.Drawing.Bitmap)resources.GetObject("mniClose.Glyph"));
            this.mniClose.ToolTipText = "Closes this window";
            this.mniClose.Text = "&Close";
            //
            // mniFile
            //
            this.mniFile.Name = "mniFile";
            this.mniFile.AutoSize = true;
            this.mniFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           mniClose});
            this.mniFile.Text = "&File";
            //
            // mniHelpPetraHelp
            //
            this.mniHelpPetraHelp.Name = "mniHelpPetraHelp";
            this.mniHelpPetraHelp.AutoSize = true;
            this.mniHelpPetraHelp.Text = "&Petra Help";
            //
            // mniSeparator0
            //
            this.mniSeparator0.Name = "mniSeparator0";
            this.mniSeparator0.AutoSize = true;
            this.mniSeparator0.Text = "-";
            //
            // mniHelpBugReport
            //
            this.mniHelpBugReport.Name = "mniHelpBugReport";
            this.mniHelpBugReport.AutoSize = true;
            this.mniHelpBugReport.Text = "Bug &Report";
            //
            // mniSeparator1
            //
            this.mniSeparator1.Name = "mniSeparator1";
            this.mniSeparator1.AutoSize = true;
            this.mniSeparator1.Text = "-";
            //
            // mniHelpAboutPetra
            //
            this.mniHelpAboutPetra.Name = "mniHelpAboutPetra";
            this.mniHelpAboutPetra.AutoSize = true;
            this.mniHelpAboutPetra.Text = "&About Petra";
            //
            // mniHelpDevelopmentTeam
            //
            this.mniHelpDevelopmentTeam.Name = "mniHelpDevelopmentTeam";
            this.mniHelpDevelopmentTeam.AutoSize = true;
            this.mniHelpDevelopmentTeam.Text = "&The Development Team...";
            //
            // mniHelp
            //
            this.mniHelp.Name = "mniHelp";
            this.mniHelp.AutoSize = true;
            this.mniHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           mniHelpPetraHelp,
                        mniSeparator0,
                        mniHelpBugReport,
                        mniSeparator1,
                        mniHelpAboutPetra,
                        mniHelpDevelopmentTeam});
            this.mniHelp.Text = "&Help";
            //
            // mnuMain
            //
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.mnuMain.AutoSize = true;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           mniFile,
                        mniHelp});
            //
            // stbMain
            //
            this.stbMain.Name = "stbMain";
            this.stbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stbMain.AutoSize = true;

            //
            // TFrmMainForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 623);
            // this.rpsForm.SetRestoreLocation(this, false);  for the moment false, to avoid problems with size
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tbrMain);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = mnuMain;
            this.Controls.Add(this.stbMain);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.Name = "TFrmMainForm";
            this.Text = "Bank import";

	        this.Activated += new System.EventHandler(this.TFrmPetra_Activated);
	        this.Load += new System.EventHandler(this.TFrmPetra_Load);
	        this.Closing += new System.ComponentModel.CancelEventHandler(this.TFrmPetra_Closing);
	        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
	        this.Closed += new System.EventHandler(this.TFrmPetra_Closed);
	
            this.stbMain.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.tbrMain.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.rgrFilter.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnlInfoStatement.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlInfoStatement;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.TextBox txtDateStatement;
        private System.Windows.Forms.Label lblDateStatement;
        private System.Windows.Forms.TextBox txtValueAltogether;
        private System.Windows.Forms.Label lblValueAltogether;
        private System.Windows.Forms.TextBox txtNumberAltogether;
        private System.Windows.Forms.Label lblNumberAltogether;
        private System.Windows.Forms.TextBox txtValueMatchedGifts;
        private System.Windows.Forms.Label lblValueMatchedGifts;
        private System.Windows.Forms.TextBox txtNumberMatched;
        private System.Windows.Forms.Label lblNumberMatched;
        private System.Windows.Forms.TextBox txtValueUnmatchedGifts;
        private System.Windows.Forms.Label lblValueUnmatchedGifts;
        private System.Windows.Forms.TextBox txtNumberUnmatched;
        private System.Windows.Forms.Label lblNumberUnmatched;
        private System.Windows.Forms.TextBox txtValueOther;
        private System.Windows.Forms.Label lblValueOther;
        private System.Windows.Forms.TextBox txtNumberOther;
        private System.Windows.Forms.Label lblNumberOther;
        private System.Windows.Forms.GroupBox rgrFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton rbtAllTransactions;
        private System.Windows.Forms.RadioButton rbtMatchedGifts;
        private System.Windows.Forms.RadioButton rbtUnmatchedGifts;
        private System.Windows.Forms.RadioButton rbtOther;
        private Ict.Common.Controls.TSgrdDataGridPaged grdResult;
        private System.Windows.Forms.ToolStrip tbrMain;
        private System.Windows.Forms.ToolStripButton tbbImportStatement;
        private System.Windows.Forms.ToolStripButton tbbExportGiftBatch;
        private System.Windows.Forms.ToolStripButton tbbExportUnmatchedDonors;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mniFile;
        private System.Windows.Forms.ToolStripMenuItem mniClose;
        private System.Windows.Forms.ToolStripMenuItem mniHelp;
        private System.Windows.Forms.ToolStripMenuItem mniHelpPetraHelp;
        private System.Windows.Forms.ToolStripSeparator mniSeparator0;
        private System.Windows.Forms.ToolStripMenuItem mniHelpBugReport;
        private System.Windows.Forms.ToolStripSeparator mniSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mniHelpAboutPetra;
        private System.Windows.Forms.ToolStripMenuItem mniHelpDevelopmentTeam;
        private Ict.Common.Controls.TExtStatusBarHelp stbMain;
    }
}
