Namespace Views
	Partial Class AboutBoxForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.tableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
			Me.labelProductName = New System.Windows.Forms.Label()
			Me.labelVersion = New System.Windows.Forms.Label()
			Me.labelCopyright = New System.Windows.Forms.Label()
			Me.labelCompanyName = New System.Windows.Forms.Label()
			Me.textBoxDescription = New System.Windows.Forms.TextBox()
			Me.okButton = New System.Windows.Forms.Button()
			Me.tableLayoutPanel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' tableLayoutPanel
			' 
			Me.tableLayoutPanel.ColumnCount = 1
			Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F))
			Me.tableLayoutPanel.Controls.Add(Me.labelProductName, 0, 1)
			Me.tableLayoutPanel.Controls.Add(Me.labelVersion, 0, 2)
			Me.tableLayoutPanel.Controls.Add(Me.labelCopyright, 0, 3)
			Me.tableLayoutPanel.Controls.Add(Me.labelCompanyName, 0, 4)
			Me.tableLayoutPanel.Controls.Add(Me.textBoxDescription, 0, 5)
			Me.tableLayoutPanel.Controls.Add(Me.okButton, 0, 6)
			Me.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.tableLayoutPanel.Location = New System.Drawing.Point(9, 9)
			Me.tableLayoutPanel.Name = "tableLayoutPanel"
			Me.tableLayoutPanel.RowCount = 7
			Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F))
			Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
			Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
			Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
			Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
			Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F))
			Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F))
			Me.tableLayoutPanel.Size = New System.Drawing.Size(737, 453)
			Me.tableLayoutPanel.TabIndex = 0
			' 
			' labelProductName
			' 
			Me.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill
			Me.labelProductName.Location = New System.Drawing.Point(6, 135)
			Me.labelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
			Me.labelProductName.MaximumSize = New System.Drawing.Size(0, 17)
			Me.labelProductName.Name = "labelProductName"
			Me.labelProductName.Size = New System.Drawing.Size(728, 17)
			Me.labelProductName.TabIndex = 19
			Me.labelProductName.Text = "Product Name"
			Me.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' labelVersion
			' 
			Me.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill
			Me.labelVersion.Location = New System.Drawing.Point(6, 180)
			Me.labelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
			Me.labelVersion.MaximumSize = New System.Drawing.Size(0, 17)
			Me.labelVersion.Name = "labelVersion"
			Me.labelVersion.Size = New System.Drawing.Size(728, 17)
			Me.labelVersion.TabIndex = 0
			Me.labelVersion.Text = "Version"
			Me.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' labelCopyright
			' 
			Me.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
			Me.labelCopyright.Location = New System.Drawing.Point(6, 225)
			Me.labelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
			Me.labelCopyright.MaximumSize = New System.Drawing.Size(0, 17)
			Me.labelCopyright.Name = "labelCopyright"
			Me.labelCopyright.Size = New System.Drawing.Size(728, 17)
			Me.labelCopyright.TabIndex = 21
			Me.labelCopyright.Text = "Copyright"
			Me.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' labelCompanyName
			' 
			Me.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
			Me.labelCompanyName.Location = New System.Drawing.Point(6, 270)
			Me.labelCompanyName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
			Me.labelCompanyName.MaximumSize = New System.Drawing.Size(0, 17)
			Me.labelCompanyName.Name = "labelCompanyName"
			Me.labelCompanyName.Size = New System.Drawing.Size(728, 17)
			Me.labelCompanyName.TabIndex = 22
			Me.labelCompanyName.Text = "Company Name"
			Me.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' textBoxDescription
			' 
			Me.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
			Me.textBoxDescription.Location = New System.Drawing.Point(6, 318)
			Me.textBoxDescription.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
			Me.textBoxDescription.Multiline = True
			Me.textBoxDescription.Name = "textBoxDescription"
			Me.textBoxDescription.[ReadOnly] = True
			Me.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.textBoxDescription.Size = New System.Drawing.Size(728, 84)
			Me.textBoxDescription.TabIndex = 23
			Me.textBoxDescription.TabStop = False
			Me.textBoxDescription.Text = "Description"
			' 
			' okButton
			' 
			Me.okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.okButton.Location = New System.Drawing.Point(659, 427)
			Me.okButton.Name = "okButton"
			Me.okButton.Size = New System.Drawing.Size(75, 23)
			Me.okButton.TabIndex = 24
			Me.okButton.Text = "&OK"
			' 
			' AboutBoxForm
			' 
			Me.AcceptButton = Me.okButton
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(755, 471)
			Me.Controls.Add(Me.tableLayoutPanel)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "AboutBoxForm"
			Me.Padding = New System.Windows.Forms.Padding(9)
			Me.ShowIcon = False
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "About..."
			Me.tableLayoutPanel.ResumeLayout(False)
			Me.tableLayoutPanel.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private tableLayoutPanel As System.Windows.Forms.TableLayoutPanel
		Private labelProductName As System.Windows.Forms.Label
		Private labelVersion As System.Windows.Forms.Label
		Private labelCopyright As System.Windows.Forms.Label
		Private labelCompanyName As System.Windows.Forms.Label
		Private textBoxDescription As System.Windows.Forms.TextBox
		Private okButton As System.Windows.Forms.Button
	End Class
End Namespace
