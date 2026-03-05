Imports System.Windows.Forms
Imports GestionArticle.LUNA
Imports Microsoft.Data.SqlClient   ' Assure-toi que le namespace est correct

Public Class ArticleController
    Private ReadOnly _dao As New ArticleDAO()   ' ReadOnly car on ne le change pas
    Private ReadOnly _form1 As Form1   ' Renommé pour clarté
    Private ReadOnly _formArticle As FormArticle ' Renommé
    Private _articleCourant As Article    ' Pour l'édition

    Public Sub New(formPrincipale As Form1)
        _form1 = formPrincipale
        _formArticle = New FormArticle(Me)
    End Sub

    ''' <summary>
    ''' Ouvre la connexion globale (une seule fois au démarrage de l'app)
    ''' </summary>
    Public Sub InitialiserConnexionBD()
        Try
            LunaContext.OpenDbConnection()   ' Méthode Shared → pas besoin d'instance
            ' MessageBox.Show("Connexion ouverte avec succès") ' Pour test
        Catch ex As Exception
            MessageBox.Show("Erreur ouverture BD : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub FermerConnexionBD()
        LunaContext.CloseDbConnection()
    End Sub

    Public Sub ChargerListeArticles()
        Try
            Dim liste As IEnumerable(Of Article) = _dao.GetAll("Designation") ' Tri par désignation par ex.
            _form1.MettreAJourGrid(liste)   ' À implémenter dans Form1 (ex: DataGridView.DataSource = liste)
        Catch ex As Exception
            MessageBox.Show("Erreur chargement liste : " & ex.Message)
        End Try
    End Sub

    Public Sub ChargerArticlePourEdition(id As Integer)
        Dim article As Article = _dao.Read(id)

        If article IsNot Nothing AndAlso article.ID > 0 Then
            Using frm As New FormArticle(Me, article)   ' ← On passe l'article → mode modif
                frm.ShowDialog()
                If frm.DialogResult = DialogResult.OK Then
                    ChargerListeArticles()
                End If
            End Using
        Else
            MessageBox.Show("Article introuvable")
        End If
    End Sub

    Public Sub NavigationAjout()
        Using frm As New FormArticle(Me)   ' ← Rien passé → mode ajout
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.OK Then
                ChargerListeArticles()
            End If
        End Using
    End Sub

    Public Sub NavigationModifier()
        _formArticle.ShowDialog()
    End Sub

    ''' <summary>
    ''' Valide et enregistre un nouvel article ou une modif depuis le form
    ''' </summary>
    Public Sub EnregistrerArticle(article As Article)
        Try
            Dim idSauve As Integer = _dao.Save(article)

            If idSauve > 0 Then
                'MessageBox.Show("Article enregistré avec succès (ID: " & idSauve & ")", "Succès")
                ChargerListeArticles()
            End If

        Catch sqlEx As SqlException When sqlEx.Number = 2627 OrElse sqlEx.Number = 2601
            ' 2627 = violation PRIMARY KEY / UNIQUE constraint
            ' 2601 = violation UNIQUE INDEX
            MessageBox.Show("Ce code existe déjà dans la base. Veuillez en choisir un autre.", "Code dupliqué", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Validation métier (utilise l'objet Article au lieu des TextBox directement)
    ''' </summary>
    Friend Function ValiderArticle(article As Article) As Boolean
        If String.IsNullOrWhiteSpace(article.Code) Then
            MessageBox.Show("Le code est obligatoire !")
            Return False
        End If
        If String.IsNullOrWhiteSpace(article.Designation) Then
            MessageBox.Show("La désignation est obligatoire !")
            Return False
        End If
        If article.Prix < 1 Then
            MessageBox.Show("Le prix doit être positif.")
            Return False
        End If
        Return True
    End Function

    ' Exemple : méthode callback depuis FormAjouter ou FormModifier
    Public Sub ArticleAjouteOuModifie(article As Article)
        EnregistrerArticle(article)
    End Sub

    Public Sub SupprimerArticle(id As Integer)
        Try
            _dao.Delete(id)          ' Luna a déjà une méthode Delete(id)
            ' Optionnel : si tu veux une logique soft-delete, modifie le DAO
        Catch ex As Exception
            Throw New Exception("Échec suppression article ID " & id, ex)
        End Try
    End Sub

    ''' <summary>
    ''' Recherche des articles par mot-clé (code OU désignation)
    ''' </summary>
    Public Sub RechercherArticles(filtre As String)
        Try
            If String.IsNullOrWhiteSpace(filtre) Then
                ChargerListeArticles()   ' Affiche tout si filtre vide
                Return
            End If

            ' Méthode 1 : filtre côté client (simple, fonctionne bien pour < 10 000 articles)
            Dim tous = _dao.GetAll("Designation")
            Dim resultats = tous.Where(Function(a) a.Code?.Contains(filtre, StringComparison.OrdinalIgnoreCase) = True OrElse
                                           a.Designation?.Contains(filtre, StringComparison.OrdinalIgnoreCase) = True
            ).ToList()

            _form1.MettreAJourGrid(resultats)

            ' Méthode 2 : filtre côté serveur avec Luna (plus performant pour grosse base)
            ' Dim params = New LUNA.LunaSearchParameter() {
            '     New LUNA.LunaSearchParameter("Code", "LIKE", "%" & filtre & "%", "OR"),
            '     New LUNA.LunaSearchParameter("Designation", "LIKE", "%" & filtre & "%")
            ' }
            ' Dim resultatsLuna = _dao.Find("Designation ASC", params)
            ' _form1.MettreAJourGrid(resultatsLuna)

        Catch ex As Exception
            MessageBox.Show("Erreur pendant la recherche : " & ex.Message, "Erreur")
        End Try
    End Sub
End Class