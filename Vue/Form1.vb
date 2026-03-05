Public Class Form1

    Private _controller As ArticleController

    Public Sub New()
        InitializeComponent()
        _controller = New ArticleController(Me)
    End Sub

    Public Sub AfficherArticles(articles As List(Of Article))
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = articles
        If DataGridView1.Columns.Contains("ID") Then
            DataGridView1.Columns("ID").ReadOnly = True
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _controller = New ArticleController(Me)
        _controller.InitialiserConnexionBD()
        _controller.ChargerListeArticles()
    End Sub

    Public Sub MettreAJourGrid(listeArticles As IEnumerable(Of Article))

        ' Supposons que tu as un DataGridView nommé DataGridViewArticles sur Form1
        DataGridView1.DataSource = listeArticles.ToList()   ' .ToList() pour que ça marche bien avec DataGridView

        ' Optionnel : personnalise l'affichage des colonnes
        If DataGridView1.Columns.Count > 0 Then
            DataGridView1.Columns("ID").Visible = True
            DataGridView1.Columns("Code").HeaderText = "Code article"
            DataGridView1.Columns("Designation").HeaderText = "Désignation"
            DataGridView1.Columns("Prix").HeaderText = "Prix (fcfa)"
            DataGridView1.Columns("Date_Creation").HeaderText = "Date création"
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

        ' À la fin de la méthode
        If DataGridView1.Columns("IsChanged") IsNot Nothing Then
            DataGridView1.Columns("IsChanged").Visible = False
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _controller.FermerConnexionBD()
    End Sub

    Private Sub BtnAjout_Click(sender As Object, e As EventArgs) Handles ButtonAjout.Click
        _controller.NavigationAjout()
    End Sub

    Private Sub BtnModifier_Click(sender As Object, e As EventArgs) Handles ButtonModifier.Click

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Veuillez sélectionner un article à modifier.", "Attention")
            Return
        End If

        Dim idSelectionne As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("ID").Value)
        _controller.ChargerArticlePourEdition(idSelectionne)

    End Sub

    Private Sub ButtonRechercher_Click(sender As Object, e As EventArgs) Handles ButtonRechercher.Click
        _controller.RechercherArticles(TextRecherche.Text.Trim())
    End Sub

    ' Bonus : recherche en temps réel (très apprécié des utilisateurs)
    Private Sub TxtRecherche_TextChanged(sender As Object, e As EventArgs) Handles TextRecherche.TextChanged
        _controller.RechercherArticles(TextRecherche.Text.Trim())
    End Sub

    ' Bouton Supprimer (nomme-le BtnSupprimer par exemple)
    Private Sub ButtonSupprimer_Click(sender As Object, e As EventArgs) Handles ButtonSupprimer.Click

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Veuillez sélectionner un article à supprimer.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim id As Integer
        Try
            id = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("ID").Value)
        Catch
            MessageBox.Show("ID invalide dans la ligne sélectionnée.", "Erreur")
            Return
        End Try

        Dim cellValue = DataGridView1.SelectedRows(0).Cells("Designation").Value

        Dim articleDesignation As String
        If cellValue IsNot Nothing Then
            articleDesignation = cellValue.ToString()
        Else
            articleDesignation = "cet article"
        End If
        Dim reponse As DialogResult = MessageBox.Show(
        $"Voulez-vous vraiment supprimer l'article : {articleDesignation} (ID: {id}) ?",
        "Confirmation de suppression",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button2)   ' Non par défaut pour éviter les suppressions accidentelles

        If reponse = DialogResult.Yes Then
            Try
                _controller.SupprimerArticle(id)   ' À créer dans le controller
                MessageBox.Show("Article supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _controller.ChargerListeArticles()  ' Rafraîchir la grille
            Catch ex As Exception
                MessageBox.Show("Erreur lors de la suppression : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
