﻿namespace AsciiProtocolInventory.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.Button scanRfidButton;
        private System.Windows.Forms.ToolStripMenuItem readerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ListBox responsesListBox;
        private System.Windows.Forms.Button scanBarcodeButton;
        private System.Windows.Forms.ListBox transponderListBox;
        private System.Windows.Forms.ToolTip helperToolTip;
        private System.Windows.Forms.ToolStripMenuItem refreshPortsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel messageToolStripStatusLabel;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox barcodeListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer resultsSplitContainer;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showProtocolResponsesToolStripMenuItem;
        private System.Windows.Forms.Button scanRfidAsyncButton;
        private System.Windows.Forms.Button scanBarcodeAsyncButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearAllResponsesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearProtocolResponsesToolStripMenuItem;
        private System.Windows.Forms.ComboBox querySessionComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox queryTargetComboBox;
        private System.Windows.Forms.Button clearTransponderResponsesButton;
        private System.Windows.Forms.Button clearBarcodeResponsesButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshPortsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllResponsesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearProtocolResponsesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showProtocolResponsesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.messageToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.scanRfidButton = new System.Windows.Forms.Button();
            this.scanBarcodeButton = new System.Windows.Forms.Button();
            this.transponderListBox = new System.Windows.Forms.ListBox();
            this.responsesListBox = new System.Windows.Forms.ListBox();
            this.helperToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.scanRfidAsyncButton = new System.Windows.Forms.Button();
            this.scanBarcodeAsyncButton = new System.Windows.Forms.Button();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.resultsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.queryTargetComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.querySessionComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.clearTransponderResponsesButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearBarcodeResponsesButton = new System.Windows.Forms.Button();
            this.barcodeListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.abortBarcodeButton = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.resultsSplitContainer.Panel1.SuspendLayout();
            this.resultsSplitContainer.Panel2.SuspendLayout();
            this.resultsSplitContainer.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.readerToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(839, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // readerToolStripMenuItem
            // 
            this.readerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshPortsToolStripMenuItem,
            this.portToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.readerToolStripMenuItem.Name = "readerToolStripMenuItem";
            this.readerToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.readerToolStripMenuItem.Text = "&Reader";
            // 
            // refreshPortsToolStripMenuItem
            // 
            this.refreshPortsToolStripMenuItem.Name = "refreshPortsToolStripMenuItem";
            this.refreshPortsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.refreshPortsToolStripMenuItem.Text = "&Refresh Ports";
            this.refreshPortsToolStripMenuItem.Click += new System.EventHandler(this.RefreshPortsToolStripMenuItem_Click);
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.portToolStripMenuItem.Text = "&Port";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.connectToolStripMenuItem.Text = "&Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.disconnectToolStripMenuItem.Text = "&Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.DisconnectToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllResponsesToolStripMenuItem,
            this.toolStripSeparator2,
            this.clearProtocolResponsesToolStripMenuItem,
            this.toolStripSeparator1,
            this.showProtocolResponsesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // clearAllResponsesToolStripMenuItem
            // 
            this.clearAllResponsesToolStripMenuItem.Name = "clearAllResponsesToolStripMenuItem";
            this.clearAllResponsesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.clearAllResponsesToolStripMenuItem.Text = "Clear All Responses";
            this.clearAllResponsesToolStripMenuItem.Click += new System.EventHandler(this.ClearAllResponsesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(206, 6);
            // 
            // clearProtocolResponsesToolStripMenuItem
            // 
            this.clearProtocolResponsesToolStripMenuItem.Name = "clearProtocolResponsesToolStripMenuItem";
            this.clearProtocolResponsesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.clearProtocolResponsesToolStripMenuItem.Text = "Clear Protocol Responses";
            this.clearProtocolResponsesToolStripMenuItem.Click += new System.EventHandler(this.ClearProtocolResponsesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // showProtocolResponsesToolStripMenuItem
            // 
            this.showProtocolResponsesToolStripMenuItem.Name = "showProtocolResponsesToolStripMenuItem";
            this.showProtocolResponsesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.showProtocolResponsesToolStripMenuItem.Text = "Show Protocol Responses";
            this.showProtocolResponsesToolStripMenuItem.Click += new System.EventHandler(this.ShowProtocolResponsesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 528);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(839, 22);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // messageToolStripStatusLabel
            // 
            this.messageToolStripStatusLabel.Name = "messageToolStripStatusLabel";
            this.messageToolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.messageToolStripStatusLabel.Text = "No reader connected";
            // 
            // scanRfidButton
            // 
            this.scanRfidButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scanRfidButton.Location = new System.Drawing.Point(12, 303);
            this.scanRfidButton.Name = "scanRfidButton";
            this.scanRfidButton.Size = new System.Drawing.Size(75, 51);
            this.scanRfidButton.TabIndex = 5;
            this.scanRfidButton.Text = "Scan";
            this.helperToolTip.SetToolTip(this.scanRfidButton, "Scan for RFID Transponders using a synchronous command");
            this.scanRfidButton.UseVisualStyleBackColor = true;
            this.scanRfidButton.Click += new System.EventHandler(this.ScanRfidCommandButton_Click);
            // 
            // scanBarcodeButton
            // 
            this.scanBarcodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scanBarcodeButton.Location = new System.Drawing.Point(21, 303);
            this.scanBarcodeButton.Name = "scanBarcodeButton";
            this.scanBarcodeButton.Size = new System.Drawing.Size(75, 51);
            this.scanBarcodeButton.TabIndex = 8;
            this.scanBarcodeButton.Text = "Scan";
            this.helperToolTip.SetToolTip(this.scanBarcodeButton, "Scan for barcodes using a synchronous command");
            this.scanBarcodeButton.UseVisualStyleBackColor = true;
            this.scanBarcodeButton.Click += new System.EventHandler(this.ScanBarcodeCommandButton_Click);
            // 
            // transponderListBox
            // 
            this.transponderListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.transponderListBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transponderListBox.FormattingEnabled = true;
            this.transponderListBox.IntegralHeight = false;
            this.transponderListBox.ItemHeight = 16;
            this.transponderListBox.Location = new System.Drawing.Point(8, 30);
            this.transponderListBox.Name = "transponderListBox";
            this.transponderListBox.Size = new System.Drawing.Size(394, 267);
            this.transponderListBox.TabIndex = 1;
            // 
            // responsesListBox
            // 
            this.responsesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.responsesListBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.responsesListBox.FormattingEnabled = true;
            this.responsesListBox.IntegralHeight = false;
            this.responsesListBox.ItemHeight = 14;
            this.responsesListBox.Location = new System.Drawing.Point(0, 0);
            this.responsesListBox.Name = "responsesListBox";
            this.responsesListBox.Size = new System.Drawing.Size(839, 136);
            this.responsesListBox.TabIndex = 0;
            // 
            // scanRfidAsyncButton
            // 
            this.scanRfidAsyncButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scanRfidAsyncButton.Location = new System.Drawing.Point(93, 303);
            this.scanRfidAsyncButton.Name = "scanRfidAsyncButton";
            this.scanRfidAsyncButton.Size = new System.Drawing.Size(75, 51);
            this.scanRfidAsyncButton.TabIndex = 16;
            this.scanRfidAsyncButton.Text = "Scan (Async)";
            this.helperToolTip.SetToolTip(this.scanRfidAsyncButton, "Scan for RFID Transponders using an asynchronous command");
            this.scanRfidAsyncButton.UseVisualStyleBackColor = true;
            this.scanRfidAsyncButton.Click += new System.EventHandler(this.scanRfidAsyncButton_Click);
            // 
            // scanBarcodeAsyncButton
            // 
            this.scanBarcodeAsyncButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scanBarcodeAsyncButton.Location = new System.Drawing.Point(102, 303);
            this.scanBarcodeAsyncButton.Name = "scanBarcodeAsyncButton";
            this.scanBarcodeAsyncButton.Size = new System.Drawing.Size(75, 51);
            this.scanBarcodeAsyncButton.TabIndex = 15;
            this.scanBarcodeAsyncButton.Text = "Scan (Async)";
            this.helperToolTip.SetToolTip(this.scanBarcodeAsyncButton, "Scan for barcodes using an asynchronous command");
            this.scanBarcodeAsyncButton.UseVisualStyleBackColor = true;
            this.scanBarcodeAsyncButton.Click += new System.EventHandler(this.ScanBarcodeAsyncButton_Click);
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.responsesListBox);
            this.mainSplitContainer.Panel1MinSize = 120;
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.resultsSplitContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(839, 504);
            this.mainSplitContainer.SplitterDistance = 136;
            this.mainSplitContainer.TabIndex = 10;
            // 
            // resultsSplitContainer
            // 
            this.resultsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.resultsSplitContainer.Name = "resultsSplitContainer";
            // 
            // resultsSplitContainer.Panel1
            // 
            this.resultsSplitContainer.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.resultsSplitContainer.Panel1.Controls.Add(this.panel3);
            this.resultsSplitContainer.Panel1.Controls.Add(this.scanRfidAsyncButton);
            this.resultsSplitContainer.Panel1.Controls.Add(this.scanRfidButton);
            this.resultsSplitContainer.Panel1.Controls.Add(this.panel2);
            // 
            // resultsSplitContainer.Panel2
            // 
            this.resultsSplitContainer.Panel2.BackColor = System.Drawing.Color.LightGray;
            this.resultsSplitContainer.Panel2.Controls.Add(this.abortBarcodeButton);
            this.resultsSplitContainer.Panel2.Controls.Add(this.scanBarcodeAsyncButton);
            this.resultsSplitContainer.Panel2.Controls.Add(this.scanBarcodeButton);
            this.resultsSplitContainer.Panel2.Controls.Add(this.panel1);
            this.resultsSplitContainer.Size = new System.Drawing.Size(839, 364);
            this.resultsSplitContainer.SplitterDistance = 413;
            this.resultsSplitContainer.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.queryTargetComboBox);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.querySessionComboBox);
            this.panel3.Location = new System.Drawing.Point(174, 306);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(193, 55);
            this.panel3.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 21);
            this.label4.TabIndex = 20;
            this.label4.Text = "Query Target:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // queryTargetComboBox
            // 
            this.queryTargetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.queryTargetComboBox.FormattingEnabled = true;
            this.queryTargetComboBox.Location = new System.Drawing.Point(95, 27);
            this.queryTargetComboBox.Name = "queryTargetComboBox";
            this.queryTargetComboBox.Size = new System.Drawing.Size(49, 21);
            this.queryTargetComboBox.TabIndex = 19;
            this.queryTargetComboBox.SelectedIndexChanged += new System.EventHandler(this.QueryTargetComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Query Session:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // querySessionComboBox
            // 
            this.querySessionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.querySessionComboBox.FormattingEnabled = true;
            this.querySessionComboBox.Location = new System.Drawing.Point(95, 0);
            this.querySessionComboBox.Name = "querySessionComboBox";
            this.querySessionComboBox.Size = new System.Drawing.Size(93, 21);
            this.querySessionComboBox.TabIndex = 17;
            this.querySessionComboBox.SelectedIndexChanged += new System.EventHandler(this.QuerySessionComboBox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.clearTransponderResponsesButton);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.transponderListBox);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 306);
            this.panel2.TabIndex = 15;
            // 
            // clearTransponderResponsesButton
            // 
            this.clearTransponderResponsesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearTransponderResponsesButton.Location = new System.Drawing.Point(351, 4);
            this.clearTransponderResponsesButton.Name = "clearTransponderResponsesButton";
            this.clearTransponderResponsesButton.Size = new System.Drawing.Size(51, 23);
            this.clearTransponderResponsesButton.TabIndex = 15;
            this.clearTransponderResponsesButton.Text = "Clear";
            this.clearTransponderResponsesButton.UseVisualStyleBackColor = true;
            this.clearTransponderResponsesButton.Click += new System.EventHandler(this.ClearTransponderResponsesButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Transponders Received";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.clearBarcodeResponsesButton);
            this.panel1.Controls.Add(this.barcodeListBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 306);
            this.panel1.TabIndex = 14;
            // 
            // clearBarcodeResponsesButton
            // 
            this.clearBarcodeResponsesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBarcodeResponsesButton.Location = new System.Drawing.Point(357, 4);
            this.clearBarcodeResponsesButton.Name = "clearBarcodeResponsesButton";
            this.clearBarcodeResponsesButton.Size = new System.Drawing.Size(51, 23);
            this.clearBarcodeResponsesButton.TabIndex = 16;
            this.clearBarcodeResponsesButton.Text = "Clear";
            this.clearBarcodeResponsesButton.UseVisualStyleBackColor = true;
            this.clearBarcodeResponsesButton.Click += new System.EventHandler(this.ClearBarcodeResponsesButton_Click);
            // 
            // barcodeListBox
            // 
            this.barcodeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barcodeListBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodeListBox.FormattingEnabled = true;
            this.barcodeListBox.IntegralHeight = false;
            this.barcodeListBox.ItemHeight = 16;
            this.barcodeListBox.Location = new System.Drawing.Point(9, 30);
            this.barcodeListBox.Name = "barcodeListBox";
            this.barcodeListBox.Size = new System.Drawing.Size(399, 267);
            this.barcodeListBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Barcodes Received";
            // 
            // abortBarcodeButton
            // 
            this.abortBarcodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.abortBarcodeButton.Location = new System.Drawing.Point(183, 303);
            this.abortBarcodeButton.Name = "abortBarcodeButton";
            this.abortBarcodeButton.Size = new System.Drawing.Size(75, 51);
            this.abortBarcodeButton.TabIndex = 16;
            this.abortBarcodeButton.Text = "Abort";
            this.helperToolTip.SetToolTip(this.abortBarcodeButton, "Scan for barcodes using an asynchronous command");
            this.abortBarcodeButton.UseVisualStyleBackColor = true;
            this.abortBarcodeButton.Click += new System.EventHandler(this.AbortBarcodeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 550);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "ASCII Protocol Inventory";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.ResumeLayout(false);
            this.resultsSplitContainer.Panel1.ResumeLayout(false);
            this.resultsSplitContainer.Panel2.ResumeLayout(false);
            this.resultsSplitContainer.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion        

        private System.Windows.Forms.Button abortBarcodeButton;
    }
}

