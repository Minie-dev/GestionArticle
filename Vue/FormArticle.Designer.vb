<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormArticle
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        Label1 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        TextCode = New TextBox()
        TextDesignation = New TextBox()
        TextPrix = New TextBox()
        ButtonEnregistrer = New Button()
        LinkLabel1 = New LinkLabel()
        Label2 = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Lime
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(1, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(334, 38)
        Panel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18.0F)
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(110, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(97, 32)
        Label1.TabIndex = 0
        Label1.Text = "Le BEST"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12.0F)
        Label3.Location = New Point(12, 119)
        Label3.Name = "Label3"
        Label3.Size = New Size(46, 21)
        Label3.TabIndex = 2
        Label3.Text = "Code"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12.0F)
        Label4.Location = New Point(12, 167)
        Label4.Name = "Label4"
        Label4.Size = New Size(93, 21)
        Label4.TabIndex = 3
        Label4.Text = "Designation"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12.0F)
        Label5.Location = New Point(12, 217)
        Label5.Name = "Label5"
        Label5.Size = New Size(36, 21)
        Label5.TabIndex = 4
        Label5.Text = "Prix"
        ' 
        ' TextCode
        ' 
        TextCode.Location = New Point(130, 117)
        TextCode.Name = "TextCode"
        TextCode.Size = New Size(194, 23)
        TextCode.TabIndex = 5
        ' 
        ' TextDesignation
        ' 
        TextDesignation.Location = New Point(130, 165)
        TextDesignation.Name = "TextDesignation"
        TextDesignation.Size = New Size(194, 23)
        TextDesignation.TabIndex = 6
        ' 
        ' TextPrix
        ' 
        TextPrix.Location = New Point(130, 215)
        TextPrix.Name = "TextPrix"
        TextPrix.Size = New Size(194, 23)
        TextPrix.TabIndex = 7
        ' 
        ' ButtonEnregistrer
        ' 
        ButtonEnregistrer.BackColor = Color.Red
        ButtonEnregistrer.Font = New Font("Segoe UI", 18.0F)
        ButtonEnregistrer.ForeColor = SystemColors.Control
        ButtonEnregistrer.Location = New Point(73, 273)
        ButtonEnregistrer.Name = "ButtonEnregistrer"
        ButtonEnregistrer.Size = New Size(142, 40)
        ButtonEnregistrer.TabIndex = 8
        ButtonEnregistrer.Text = "Enregistrer"
        ButtonEnregistrer.UseVisualStyleBackColor = False
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Location = New Point(275, 298)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(49, 15)
        LinkLabel1.TabIndex = 10
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Annuler"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12.0F)
        Label2.Location = New Point(50, 67)
        Label2.Name = "Label2"
        Label2.Size = New Size(244, 21)
        Label2.TabIndex = 11
        Label2.Text = "Entrez les informations de l'article"
        ' 
        ' FormArticle
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(336, 325)
        Controls.Add(Label2)
        Controls.Add(LinkLabel1)
        Controls.Add(ButtonEnregistrer)
        Controls.Add(TextPrix)
        Controls.Add(TextDesignation)
        Controls.Add(TextCode)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Panel1)
        Name = "FormArticle"
        Text = "FormModifer"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextCode As TextBox
    Friend WithEvents TextDesignation As TextBox
    Friend WithEvents TextPrix As TextBox
    Friend WithEvents ButtonEnregistrer As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label2 As Label

End Class
