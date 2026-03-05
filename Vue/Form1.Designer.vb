<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        Label1 = New Label()
        Label2 = New Label()
        DataGridView1 = New DataGridView()
        ButtonAjout = New Button()
        ButtonModifier = New Button()
        TextRecherche = New TextBox()
        ButtonRechercher = New Button()
        ButtonSupprimer = New Button()
        Panel1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Lime
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(0, -1)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(681, 43)
        Panel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 20F)
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(281, 6)
        Label1.Name = "Label1"
        Label1.Size = New Size(108, 37)
        Label1.TabIndex = 0
        Label1.Text = "Le BEST"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 16F)
        Label2.Location = New Point(247, 93)
        Label2.Name = "Label2"
        Label2.Size = New Size(169, 30)
        Label2.TabIndex = 1
        Label2.Text = "Liste des articles"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(4, 126)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(677, 249)
        DataGridView1.TabIndex = 2
        ' 
        ' ButtonAjout
        ' 
        ButtonAjout.BackColor = Color.Lime
        ButtonAjout.Font = New Font("Segoe UI", 18F)
        ButtonAjout.ForeColor = SystemColors.Control
        ButtonAjout.Location = New Point(38, 395)
        ButtonAjout.Name = "ButtonAjout"
        ButtonAjout.Size = New Size(116, 43)
        ButtonAjout.TabIndex = 3
        ButtonAjout.Text = "Ajouter"
        ButtonAjout.UseVisualStyleBackColor = False
        ' 
        ' ButtonModifier
        ' 
        ButtonModifier.BackColor = Color.Lime
        ButtonModifier.Font = New Font("Segoe UI", 18F)
        ButtonModifier.ForeColor = SystemColors.Control
        ButtonModifier.Location = New Point(265, 395)
        ButtonModifier.Name = "ButtonModifier"
        ButtonModifier.Size = New Size(124, 43)
        ButtonModifier.TabIndex = 4
        ButtonModifier.Text = "Modifier"
        ButtonModifier.UseVisualStyleBackColor = False
        ' 
        ' TextRecherche
        ' 
        TextRecherche.Location = New Point(149, 54)
        TextRecherche.Name = "TextRecherche"
        TextRecherche.Size = New Size(211, 23)
        TextRecherche.TabIndex = 5
        ' 
        ' ButtonRechercher
        ' 
        ButtonRechercher.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(0))
        ButtonRechercher.Font = New Font("Segoe UI", 9F)
        ButtonRechercher.ForeColor = SystemColors.Control
        ButtonRechercher.Location = New Point(393, 54)
        ButtonRechercher.Name = "ButtonRechercher"
        ButtonRechercher.Size = New Size(104, 23)
        ButtonRechercher.TabIndex = 6
        ButtonRechercher.Text = "Rechercher"
        ButtonRechercher.UseVisualStyleBackColor = False
        ' 
        ' ButtonSupprimer
        ' 
        ButtonSupprimer.BackColor = Color.Red
        ButtonSupprimer.Font = New Font("Segoe UI", 18F)
        ButtonSupprimer.ForeColor = SystemColors.Control
        ButtonSupprimer.Location = New Point(494, 395)
        ButtonSupprimer.Name = "ButtonSupprimer"
        ButtonSupprimer.Size = New Size(135, 43)
        ButtonSupprimer.TabIndex = 7
        ButtonSupprimer.Text = "Supprimer"
        ButtonSupprimer.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(681, 450)
        Controls.Add(ButtonSupprimer)
        Controls.Add(ButtonRechercher)
        Controls.Add(TextRecherche)
        Controls.Add(ButtonModifier)
        Controls.Add(ButtonAjout)
        Controls.Add(DataGridView1)
        Controls.Add(Label2)
        Controls.Add(Panel1)
        Name = "Form1"
        Text = "Form1"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ButtonAjout As Button
    Friend WithEvents ButtonModifier As Button
    Friend WithEvents TextRecherche As TextBox
    Friend WithEvents ButtonRechercher As Button
    Friend WithEvents ButtonSupprimer As Button

End Class
