Public Class FormArticle  ' ← Un seul formulaire pour Ajout ET Modification

    Private ReadOnly _controller As ArticleController
    Private _article As Article
    Private ReadOnly _estModeAjout As Boolean

    ' Constructeur unique
    Public Sub New(controller As ArticleController, Optional article As Article = Nothing)
        InitializeComponent()
        _controller = controller

        If article Is Nothing Then
            ' Mode AJOUT
            _estModeAjout = True
            _article = New Article()
            Me.Text = "Ajouter un article"
            ButtonEnregistrer.Text = "Ajouter"
            _article.Date_Creation = If(_estModeAjout, Date.Now, _article.Date_Creation)
            ClearFields()                    ' Vide les champs
        Else
            ' Mode MODIFICATION
            _estModeAjout = False
            _article = article
            Me.Text = "Modifier l'article"
            ButtonEnregistrer.Text = "Modifier"
            ChargerDonnees(_article)         ' Remplit les champs
        End If

        ' Optionnel : désactiver certains champs en mode modif si besoin
        ' If Not _estModeAjout Then TextCode.ReadOnly = True
    End Sub

    Private Sub ClearFields()
        TextCode.Clear()
        TextDesignation.Clear()
        TextPrix.Clear()
        ' DateTimePicker1.Value = Date.Now   ' ou Nothing selon ta logique
    End Sub

    Private Sub ChargerDonnees(article As Article)
        If article Is Nothing Then Return
        TextCode.Text = article.Code
        TextDesignation.Text = article.Designation
        TextPrix.Text = article.Prix.ToString("N2")
        ' DateTimePicker1.Value = article.Date_Creation
    End Sub

    Private Sub ButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles ButtonEnregistrer.Click
        ' Récupération des valeurs saisies
        _article.Code = TextCode.Text.Trim()
        _article.Designation = TextDesignation.Text.Trim()

        Dim prix As Decimal
        Dim succes As Boolean = False

        If Not Decimal.TryParse(TextPrix.Text.Trim(), prix) Then
            MessageBox.Show("Le prix doit être un nombre valide.", "Erreur saisie")
            TextPrix.Focus()
            Return
        End If
        _article.Prix = prix

        ' Date de création pour un nouvel article
        If _article.ID = 0 Then
            _article.Date_Creation = Date.Now   ' ← ou Today si sans heure
        End If

        Try
            If Not _controller.ValiderArticle(_article) Then
                Return   ' Validation métier a déjà affiché un message
            End If

            _controller.EnregistrerArticle(_article)

            succes = True

        Catch ex As Exception
            ' Capture TOUTES les erreurs (y compris violation unique, NULL interdit, etc.)
            MessageBox.Show("Erreur lors de l'enregistrement :" & vbCrLf & vbCrLf & ex.Message,
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' IMPORTANT : on NE ferme PAS le formulaire
            ' → l'utilisateur peut corriger directement (ex: changer le code)
            ' Focus sur le champ problématique si possible
            If ex.Message.Contains("Code") OrElse ex.Message.Contains("unique") Then
                TextCode.Focus()
                TextCode.SelectAll()
            End If

            ' Optionnel : logger l'erreur complète quelque part
            ' Debug.WriteLine(ex.ToString())
        End Try

        If succes Then
            MessageBox.Show("Enregistrement réussi !")
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub BtnAnnuler_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class