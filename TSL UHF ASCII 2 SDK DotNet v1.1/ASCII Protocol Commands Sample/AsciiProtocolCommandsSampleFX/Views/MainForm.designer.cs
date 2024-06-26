﻿namespace TechnologySolutions.AsciiProtocolSample.Views
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
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem readerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ListBox responsesListBox;
        private System.Windows.Forms.ListBox messagesListBox;
        private System.Windows.Forms.ToolTip helperToolTip;
        private System.Windows.Forms.ToolStripMenuItem refreshPortsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel messageToolStripStatusLabel;
        private System.Windows.Forms.SplitContainer responseSplitContainer;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label messagesLabel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showProtocolResponsesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearAllResponsesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearProtocolResponsesToolStripMenuItem;
        private System.Windows.Forms.Button clearMessagesButton;
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
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.messageToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.helperToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.barcodeTabPage = new System.Windows.Forms.TabPage();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.inventoryTabPage = new System.Windows.Forms.TabPage();
            this.readWriteTabPage = new System.Windows.Forms.TabPage();
            this.switchTabPage = new System.Windows.Forms.TabPage();
            this.commonTabPage = new System.Windows.Forms.TabPage();
            this.fileTabPage = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.verticalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.configureReaderTabPage = new System.Windows.Forms.TabPage();
            this.commissionTransponderTabPage = new System.Windows.Forms.TabPage();
            this.responseSplitContainer = new System.Windows.Forms.SplitContainer();
            this.responsesListBox = new System.Windows.Forms.ListBox();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.clearMessagesButton = new System.Windows.Forms.Button();
            this.messagesLabel = new System.Windows.Forms.Label();
            this.messagesListBox = new System.Windows.Forms.ListBox();
            this.transpondersTabPage = new System.Windows.Forms.TabPage();
            this.barcodeUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.BarcodeUserControl();
            this.commandsUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.CommandsUserControl();
            this.inventoryUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.InventoryUserControl();
            this.readWriteUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.ReadWriteUserControl();
            this.switchUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.SwitchUserControl();
            this.switchActionUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.SwitchActionUserControl();
            this.commonParametersUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.AntennaParametersUserControl();
            this.autorunFileUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.AutorunFileUserControl();
            this.logFileUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.LogFileUserControl();
            this.configureReaderUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.ConfigureReaderUserControl();
            this.commissionTransponderUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.CommissionTransponderUserControl();
            this.identifiedItemsUserControl1 = new TechnologySolutions.AsciiProtocolSample.Views.IdentifiedItemsUserControl();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.barcodeTabPage.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.inventoryTabPage.SuspendLayout();
            this.readWriteTabPage.SuspendLayout();
            this.switchTabPage.SuspendLayout();
            this.commonTabPage.SuspendLayout();
            this.fileTabPage.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.verticalSplitContainer.Panel1.SuspendLayout();
            this.verticalSplitContainer.Panel2.SuspendLayout();
            this.verticalSplitContainer.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.configureReaderTabPage.SuspendLayout();
            this.commissionTransponderTabPage.SuspendLayout();
            this.responseSplitContainer.Panel1.SuspendLayout();
            this.responseSplitContainer.Panel2.SuspendLayout();
            this.responseSplitContainer.SuspendLayout();
            this.resultPanel.SuspendLayout();
            this.transpondersTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.readerToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1115, 24);
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
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.disconnectToolStripMenuItem.Text = "&Disconnect";
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
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 574);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1115, 22);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // messageToolStripStatusLabel
            // 
            this.messageToolStripStatusLabel.Name = "messageToolStripStatusLabel";
            this.messageToolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.messageToolStripStatusLabel.Text = "No reader connected";
            // 
            // barcodeTabPage
            // 
            this.barcodeTabPage.Controls.Add(this.barcodeUserControl1);
            this.barcodeTabPage.Location = new System.Drawing.Point(42, 4);
            this.barcodeTabPage.Name = "barcodeTabPage";
            this.barcodeTabPage.Size = new System.Drawing.Size(737, 542);
            this.barcodeTabPage.TabIndex = 4;
            this.barcodeTabPage.Text = "Barcode";
            this.helperToolTip.SetToolTip(this.barcodeTabPage, "Barcode functions");
            this.barcodeTabPage.UseVisualStyleBackColor = true;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.commandsUserControl1);
            this.generalTabPage.Location = new System.Drawing.Point(42, 4);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Size = new System.Drawing.Size(737, 542);
            this.generalTabPage.TabIndex = 3;
            this.generalTabPage.Text = "General";
            this.helperToolTip.SetToolTip(this.generalTabPage, "General commands");
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // inventoryTabPage
            // 
            this.inventoryTabPage.Controls.Add(this.inventoryUserControl1);
            this.inventoryTabPage.Location = new System.Drawing.Point(42, 4);
            this.inventoryTabPage.Name = "inventoryTabPage";
            this.inventoryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.inventoryTabPage.Size = new System.Drawing.Size(737, 542);
            this.inventoryTabPage.TabIndex = 0;
            this.inventoryTabPage.Text = "Inventory";
            this.helperToolTip.SetToolTip(this.inventoryTabPage, "Inventory commands");
            this.inventoryTabPage.UseVisualStyleBackColor = true;
            // 
            // readWriteTabPage
            // 
            this.readWriteTabPage.Controls.Add(this.readWriteUserControl1);
            this.readWriteTabPage.Location = new System.Drawing.Point(42, 4);
            this.readWriteTabPage.Name = "readWriteTabPage";
            this.readWriteTabPage.Size = new System.Drawing.Size(737, 542);
            this.readWriteTabPage.TabIndex = 2;
            this.readWriteTabPage.Text = "Read Write";
            this.helperToolTip.SetToolTip(this.readWriteTabPage, "Transponder read write commands");
            this.readWriteTabPage.UseVisualStyleBackColor = true;
            // 
            // switchTabPage
            // 
            this.switchTabPage.Controls.Add(this.switchUserControl1);
            this.switchTabPage.Controls.Add(this.switchActionUserControl1);
            this.switchTabPage.Location = new System.Drawing.Point(42, 4);
            this.switchTabPage.Name = "switchTabPage";
            this.switchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.switchTabPage.Size = new System.Drawing.Size(737, 542);
            this.switchTabPage.TabIndex = 1;
            this.switchTabPage.Text = "Switch";
            this.helperToolTip.SetToolTip(this.switchTabPage, "Switch configuration commands");
            this.switchTabPage.UseVisualStyleBackColor = true;
            // 
            // commonTabPage
            // 
            this.commonTabPage.Controls.Add(this.commonParametersUserControl1);
            this.commonTabPage.Location = new System.Drawing.Point(42, 4);
            this.commonTabPage.Name = "commonTabPage";
            this.commonTabPage.Size = new System.Drawing.Size(737, 542);
            this.commonTabPage.TabIndex = 5;
            this.commonTabPage.Text = "Common";
            this.helperToolTip.SetToolTip(this.commonTabPage, "Set properties common to many commands");
            this.commonTabPage.UseVisualStyleBackColor = true;
            // 
            // fileTabPage
            // 
            this.fileTabPage.Controls.Add(this.flowLayoutPanel1);
            this.fileTabPage.Location = new System.Drawing.Point(42, 4);
            this.fileTabPage.Name = "fileTabPage";
            this.fileTabPage.Size = new System.Drawing.Size(737, 542);
            this.fileTabPage.TabIndex = 6;
            this.fileTabPage.Text = "Files";
            this.helperToolTip.SetToolTip(this.fileTabPage, "Log and Autorun files");
            this.fileTabPage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.autorunFileUserControl1);
            this.flowLayoutPanel1.Controls.Add(this.logFileUserControl1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(756, 542);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // verticalSplitContainer
            // 
            this.verticalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verticalSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.verticalSplitContainer.Name = "verticalSplitContainer";
            // 
            // verticalSplitContainer.Panel1
            // 
            this.verticalSplitContainer.Panel1.Controls.Add(this.tabControl1);
            // 
            // verticalSplitContainer.Panel2
            // 
            this.verticalSplitContainer.Panel2.Controls.Add(this.responseSplitContainer);
            this.verticalSplitContainer.Size = new System.Drawing.Size(1115, 550);
            this.verticalSplitContainer.SplitterDistance = 783;
            this.verticalSplitContainer.TabIndex = 18;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.barcodeTabPage);
            this.tabControl1.Controls.Add(this.generalTabPage);
            this.tabControl1.Controls.Add(this.inventoryTabPage);
            this.tabControl1.Controls.Add(this.readWriteTabPage);
            this.tabControl1.Controls.Add(this.switchTabPage);
            this.tabControl1.Controls.Add(this.commonTabPage);
            this.tabControl1.Controls.Add(this.fileTabPage);
            this.tabControl1.Controls.Add(this.configureReaderTabPage);
            this.tabControl1.Controls.Add(this.commissionTransponderTabPage);
            this.tabControl1.Controls.Add(this.transpondersTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 550);
            this.tabControl1.TabIndex = 16;
            // 
            // configureReaderTabPage
            // 
            this.configureReaderTabPage.Controls.Add(this.configureReaderUserControl1);
            this.configureReaderTabPage.Location = new System.Drawing.Point(42, 4);
            this.configureReaderTabPage.Name = "configureReaderTabPage";
            this.configureReaderTabPage.Size = new System.Drawing.Size(737, 542);
            this.configureReaderTabPage.TabIndex = 7;
            this.configureReaderTabPage.Text = "Configure Reader";
            this.configureReaderTabPage.UseVisualStyleBackColor = true;
            // 
            // commissionTransponderTabPage
            // 
            this.commissionTransponderTabPage.Controls.Add(this.commissionTransponderUserControl1);
            this.commissionTransponderTabPage.Location = new System.Drawing.Point(42, 4);
            this.commissionTransponderTabPage.Name = "commissionTransponderTabPage";
            this.commissionTransponderTabPage.Size = new System.Drawing.Size(737, 542);
            this.commissionTransponderTabPage.TabIndex = 8;
            this.commissionTransponderTabPage.Text = "Commission Transponder";
            this.commissionTransponderTabPage.UseVisualStyleBackColor = true;
            // 
            // responseSplitContainer
            // 
            this.responseSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.responseSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.responseSplitContainer.Name = "responseSplitContainer";
            this.responseSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // responseSplitContainer.Panel1
            // 
            this.responseSplitContainer.Panel1.Controls.Add(this.responsesListBox);
            this.responseSplitContainer.Panel1MinSize = 120;
            // 
            // responseSplitContainer.Panel2
            // 
            this.responseSplitContainer.Panel2.Controls.Add(this.resultPanel);
            this.responseSplitContainer.Size = new System.Drawing.Size(328, 550);
            this.responseSplitContainer.SplitterDistance = 164;
            this.responseSplitContainer.TabIndex = 10;
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
            this.responsesListBox.Size = new System.Drawing.Size(328, 164);
            this.responsesListBox.TabIndex = 0;
            // 
            // resultPanel
            // 
            this.resultPanel.BackColor = System.Drawing.Color.LightGray;
            this.resultPanel.Controls.Add(this.textBox1);
            this.resultPanel.Controls.Add(this.clearMessagesButton);
            this.resultPanel.Controls.Add(this.messagesLabel);
            this.resultPanel.Controls.Add(this.messagesListBox);
            this.resultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPanel.Location = new System.Drawing.Point(0, 0);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(328, 382);
            this.resultPanel.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(622, 20);
            this.textBox1.TabIndex = 16;
            // 
            // clearMessagesButton
            // 
            this.clearMessagesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearMessagesButton.Location = new System.Drawing.Point(266, 4);
            this.clearMessagesButton.Name = "clearMessagesButton";
            this.clearMessagesButton.Size = new System.Drawing.Size(51, 23);
            this.clearMessagesButton.TabIndex = 15;
            this.clearMessagesButton.Text = "Clear";
            this.clearMessagesButton.UseVisualStyleBackColor = true;
            // 
            // messagesLabel
            // 
            this.messagesLabel.AutoSize = true;
            this.messagesLabel.BackColor = System.Drawing.Color.LightGray;
            this.messagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagesLabel.ForeColor = System.Drawing.Color.Black;
            this.messagesLabel.Location = new System.Drawing.Point(4, 7);
            this.messagesLabel.Name = "messagesLabel";
            this.messagesLabel.Size = new System.Drawing.Size(82, 20);
            this.messagesLabel.TabIndex = 14;
            this.messagesLabel.Text = "Messages";
            // 
            // messagesListBox
            // 
            this.messagesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.messagesListBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagesListBox.FormattingEnabled = true;
            this.messagesListBox.IntegralHeight = false;
            this.messagesListBox.ItemHeight = 16;
            this.messagesListBox.Location = new System.Drawing.Point(8, 56);
            this.messagesListBox.Name = "messagesListBox";
            this.messagesListBox.Size = new System.Drawing.Size(309, 317);
            this.messagesListBox.TabIndex = 1;
            this.messagesListBox.SelectedIndexChanged += new System.EventHandler(this.MessagesListBox_SelectedIndexChanged);
            // 
            // transpondersTabPage
            // 
            this.transpondersTabPage.Controls.Add(this.identifiedItemsUserControl1);
            this.transpondersTabPage.Location = new System.Drawing.Point(42, 4);
            this.transpondersTabPage.Name = "transpondersTabPage";
            this.transpondersTabPage.Size = new System.Drawing.Size(737, 542);
            this.transpondersTabPage.TabIndex = 9;
            this.transpondersTabPage.Text = "Transponders";
            this.transpondersTabPage.UseVisualStyleBackColor = true;
            // 
            // barcodeUserControl1
            // 
            this.barcodeUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barcodeUserControl1.Location = new System.Drawing.Point(0, 0);
            this.barcodeUserControl1.Name = "barcodeUserControl1";
            this.barcodeUserControl1.Size = new System.Drawing.Size(737, 542);
            this.barcodeUserControl1.TabIndex = 0;
            // 
            // commandsUserControl1
            // 
            this.commandsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsUserControl1.Location = new System.Drawing.Point(0, 0);
            this.commandsUserControl1.Name = "commandsUserControl1";
            this.commandsUserControl1.Size = new System.Drawing.Size(756, 542);
            this.commandsUserControl1.TabIndex = 22;
            // 
            // inventoryUserControl1
            // 
            this.inventoryUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryUserControl1.Location = new System.Drawing.Point(3, 3);
            this.inventoryUserControl1.Name = "inventoryUserControl1";
            this.inventoryUserControl1.Size = new System.Drawing.Size(750, 536);
            this.inventoryUserControl1.TabIndex = 2;
            // 
            // readWriteUserControl1
            // 
            this.readWriteUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readWriteUserControl1.Location = new System.Drawing.Point(0, 0);
            this.readWriteUserControl1.Name = "readWriteUserControl1";
            this.readWriteUserControl1.Size = new System.Drawing.Size(756, 542);
            this.readWriteUserControl1.TabIndex = 0;
            // 
            // switchUserControl1
            // 
            this.switchUserControl1.Location = new System.Drawing.Point(6, 210);
            this.switchUserControl1.Name = "switchUserControl1";
            this.switchUserControl1.Size = new System.Drawing.Size(227, 140);
            this.switchUserControl1.TabIndex = 20;
            // 
            // switchActionUserControl1
            // 
            this.switchActionUserControl1.Location = new System.Drawing.Point(6, 6);
            this.switchActionUserControl1.Name = "switchActionUserControl1";
            this.switchActionUserControl1.Size = new System.Drawing.Size(453, 198);
            this.switchActionUserControl1.TabIndex = 21;
            // 
            // commonParametersUserControl1
            // 
            this.commonParametersUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonParametersUserControl1.Location = new System.Drawing.Point(0, 0);
            this.commonParametersUserControl1.Name = "commonParametersUserControl1";
            this.commonParametersUserControl1.Size = new System.Drawing.Size(756, 542);
            this.commonParametersUserControl1.TabIndex = 0;
            // 
            // autorunFileUserControl1
            // 
            this.autorunFileUserControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.autorunFileUserControl1.Location = new System.Drawing.Point(3, 3);
            this.autorunFileUserControl1.Name = "autorunFileUserControl1";
            this.autorunFileUserControl1.Size = new System.Drawing.Size(437, 136);
            this.autorunFileUserControl1.TabIndex = 0;
            // 
            // logFileUserControl1
            // 
            this.logFileUserControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logFileUserControl1.Location = new System.Drawing.Point(3, 145);
            this.logFileUserControl1.Name = "logFileUserControl1";
            this.logFileUserControl1.Size = new System.Drawing.Size(437, 174);
            this.logFileUserControl1.TabIndex = 1;
            // 
            // configureReaderUserControl1
            // 
            this.configureReaderUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configureReaderUserControl1.Location = new System.Drawing.Point(0, 0);
            this.configureReaderUserControl1.Name = "configureReaderUserControl1";
            this.configureReaderUserControl1.Size = new System.Drawing.Size(756, 542);
            this.configureReaderUserControl1.TabIndex = 0;
            // 
            // commissionTransponderUserControl1
            // 
            this.commissionTransponderUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commissionTransponderUserControl1.Location = new System.Drawing.Point(0, 0);
            this.commissionTransponderUserControl1.Name = "commissionTransponderUserControl1";
            this.commissionTransponderUserControl1.Size = new System.Drawing.Size(737, 542);
            this.commissionTransponderUserControl1.TabIndex = 0;
            // 
            // identifiedItemsUserControl1
            // 
            this.identifiedItemsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.identifiedItemsUserControl1.Location = new System.Drawing.Point(0, 0);
            this.identifiedItemsUserControl1.Name = "identifiedItemsUserControl1";
            this.identifiedItemsUserControl1.Size = new System.Drawing.Size(737, 542);
            this.identifiedItemsUserControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 596);
            this.Controls.Add(this.verticalSplitContainer);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "ASCII Commands Sample";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.barcodeTabPage.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.inventoryTabPage.ResumeLayout(false);
            this.readWriteTabPage.ResumeLayout(false);
            this.switchTabPage.ResumeLayout(false);
            this.commonTabPage.ResumeLayout(false);
            this.fileTabPage.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.verticalSplitContainer.Panel1.ResumeLayout(false);
            this.verticalSplitContainer.Panel2.ResumeLayout(false);
            this.verticalSplitContainer.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.configureReaderTabPage.ResumeLayout(false);
            this.commissionTransponderTabPage.ResumeLayout(false);
            this.responseSplitContainer.Panel1.ResumeLayout(false);
            this.responseSplitContainer.Panel2.ResumeLayout(false);
            this.responseSplitContainer.ResumeLayout(false);
            this.resultPanel.ResumeLayout(false);
            this.resultPanel.PerformLayout();
            this.transpondersTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion        

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage inventoryTabPage;
        private System.Windows.Forms.TabPage switchTabPage;
        private System.Windows.Forms.TabPage readWriteTabPage;
        private System.Windows.Forms.SplitContainer verticalSplitContainer;
        private System.Windows.Forms.TabPage generalTabPage;
        private ReadWriteUserControl readWriteUserControl1;
        private System.Windows.Forms.TabPage barcodeTabPage;
        private BarcodeUserControl barcodeUserControl1;
        private InventoryUserControl inventoryUserControl1;
        private SwitchUserControl switchUserControl1;
        private SwitchActionUserControl switchActionUserControl1;
        private CommandsUserControl commandsUserControl1;
        private System.Windows.Forms.TabPage commonTabPage;
        private AntennaParametersUserControl commonParametersUserControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage fileTabPage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private AutorunFileUserControl autorunFileUserControl1;
        private LogFileUserControl logFileUserControl1;
        private System.Windows.Forms.TabPage configureReaderTabPage;
        private ConfigureReaderUserControl configureReaderUserControl1;
        private System.Windows.Forms.TabPage commissionTransponderTabPage;
        private CommissionTransponderUserControl commissionTransponderUserControl1;
        private System.Windows.Forms.TabPage transpondersTabPage;
        private IdentifiedItemsUserControl identifiedItemsUserControl1;
    }
}

