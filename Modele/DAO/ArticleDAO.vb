#Region "Author"
'Class created with Luna 3.4.6.11
'Author: Diego Lunadei
'Date: 03/03/2026
#End Region

Imports System.Xml.Serialization
Imports Microsoft.Data.SqlClient

Partial Public Class Article
    Inherits LUNA.LunaBaseClassEntity
    '******IMPORTANT: Don't write your code here. Write your code in the Class object that use this Partial Class.
    '******So you can replace DAOClass and EntityClass without lost your code

    Public Sub New()

    End Sub

#Region "Database Field Map"

    'Instancier les attributs de la classe Article

    Protected _ID As Integer = 0

    <XmlElementAttribute("ID")>
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            If _ID <> value Then
                IsChanged = True
                _ID = value
            End If
        End Set
    End Property

    Protected _Code As String = ""

    <XmlElementAttribute("Code")>
    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal value As String)
            If _Code <> value Then
                IsChanged = True
                _Code = value
            End If
        End Set
    End Property

    Protected _Designation As String = ""

    <XmlElementAttribute("Designation")>
    Public Property Designation() As String
        Get
            Return _Designation
        End Get
        Set(ByVal value As String)
            If _Designation <> value Then
                IsChanged = True
                _Designation = value
            End If
        End Set
    End Property

    Protected _Prix As Decimal = 0

    <XmlElementAttribute("Prix")>
    Public Property Prix() As Decimal
        Get
            Return _Prix
        End Get
        Set(ByVal value As Decimal)
            If _Prix <> value Then
                IsChanged = True
                _Prix = value
            End If
        End Set
    End Property

    Protected _Date_Creation As DateTime = Nothing

    <XmlElementAttribute("Date_Creation")>
    Public Property Date_Creation() As DateTime
        Get
            Return _Date_Creation
        End Get
        Set(ByVal value As DateTime)
            If _Date_Creation <> value Then
                IsChanged = True
                _Date_Creation = value
            End If
        End Set
    End Property
#End Region

#Region "Method"
    ''' <summary>
    '''This method read an Article from DB.
    ''' </summary>
    ''' <returns>
    '''Return 0 if all ok, 1 if error
    ''' </returns>

    'Lire les articles dans la BD

    'Public Overridable Function ReadOne(Id As Integer) As Integer
    'Return 0 if all ok
    'Dim Ris As Integer = 1
    'Try
    'Using Mgr As New ArticleDAO
    'Dim articleLu As Article = Mgr.Read(Id)
    '
    'If articleLu IsNot Nothing AndAlso articleLu.ID <> 0 Then
    ' On copie les valeurs lues dans l'instance courante
    'Me.ID = articleLu.ID
    'Me.Code = articleLu.Code
    'Me.Designation = articleLu.Designation
    'Me.Prix = articleLu.Prix
    'Me.Date_Creation = articleLu.Date_Creation
    '
    ' Optionnel : on marque comme non modifié car on vient de le charger
    'Me.IsChanged = False
    '
    '               Ris = 0
    'End If
    'End Using
    'Catch ex As Exception
    '       ManageError(ex)
    '      Ris = 1
    'End Try
    'Return Ris
    'End Function

    ''' <summary>
    '''This method save an Article on DB.
    ''' </summary>
    ''' <returns>
    '''Return Id insert in DB if all ok, 0 if error
    ''' </returns>
    ''' 

    'Enregistrer les donnees dans la BD

    'Public Overridable Function SaveOne() As Integer
    'Return the id Inserted
    'Dim Ris As Integer = 0
    'Try
    'Using Mgr As New ArticleDAO
    'Dim articleLu As Article = Mgr.Read(ID)
    '
    'If articleLu IsNot Nothing AndAlso articleLu.ID <> 0 Then
    ' On copie les valeurs lues dans l'instance courante
    '               _ID = articleLu.ID
    '              _Code = articleLu.Code
    '             _Designation = articleLu.Designation
    '            _Prix = articleLu.Prix
    '           _Date_Creation = articleLu.Date_Creation
    '
    ' ' Optionnel : on marque comme non modifié car on vient de le charger
    'IsChanged = False
    'Else
    ' Article non trouvé → on peut décider quoi faire
    '               Ris = 1  ' ou lever une exception personnalisée
    'End If
    'End Using
    'Catch ex As Exception
    '       ManageError(ex)
    'End Try
    'Return Ris
    'End Function

    Private Function InternalIsValid() As Boolean
        Dim Ris As Boolean = True
        If _Code.Length = 0 Then Ris = False
        If _Code.Length > 20 Then Ris = False
        If _Designation.Length = 0 Then Ris = False
        If _Designation.Length > 150 Then Ris = False
        Return Ris
    End Function

#End Region

#Region "Embedded Class"

#End Region

End Class

''' <summary>
'''This class manage persistency on db of Article object
''' </summary>
''' <remarks>
'''
''' </remarks>
Partial Public Class ArticleDAO
    Inherits LUNA.LunaBaseClassDAO(Of Article)

    ''' <summary>
    '''New() create an istance of this class. Use default DB Connection
    ''' </summary>
    ''' <returns>
    '''
    ''' </returns>
    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    '''New() create an istance of this class and specify a DB connection
    ''' </summary>
    ''' <returns>
    '''
    ''' </returns>
    Public Sub New(ByVal Connection As Microsoft.Data.SqlClient.SqlConnection)
        MyBase.New()
    End Sub

    ''' <summary>
    '''New() create an instance of this class and specify a DB connectionstring
    ''' </summary>
    ''' <returns>
    '''
    ''' </returns>
    Public Sub New(ByVal ConnectionString As String)
        MyBase.New(ConnectionString)
    End Sub

    ''' <summary>
    '''Read from DB table Article
    ''' </summary>
    ''' <returns>
    '''Return an Article object
    ''' </returns>
    ''' 

    Public Overrides Function Read(Id As Integer) As Article
        Dim cls As New Article With {.ID = 0}  ' Valeur par défaut = non trouvé

        Try
            Using myCommand As New SqlCommand("SELECT ID, Code, Designation, Prix, Date_Creation FROM Article WHERE ID = @ID", _cn)
                myCommand.Parameters.AddWithValue("@ID", Id)

                If DbTransaction IsNot Nothing Then
                    myCommand.Transaction = DbTransaction
                End If

                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    If myReader.Read() Then
                        cls.ID = If(myReader.IsDBNull(myReader.GetOrdinal("ID")), 0, myReader.GetInt32("ID"))
                        cls.Code = If(myReader.IsDBNull("Code"), "", myReader.GetString("Code"))
                        cls.Designation = If(myReader.IsDBNull("Designation"), "", myReader.GetString("Designation"))
                        cls.Prix = If(myReader.IsDBNull("Prix"), 0D, myReader.GetDecimal("Prix"))
                        cls.Date_Creation = If(myReader.IsDBNull("Date_Creation"), Date.MinValue, myReader.GetDateTime("Date_Creation"))
                    End If
                End Using
            End Using
        Catch ex As Exception
            ManageError(ex)
            ' On retourne quand même un objet vide plutôt que Nothing
        End Try

        Return cls
    End Function

    ''' <summary>
    '''Save on DB table Article
    ''' </summary>
    ''' <returns>
    '''Return ID insert in DB
    ''' </returns>
    Public Overrides Function Save(ByRef cls As Article) As Integer

        Dim Ris As Integer = 0 'in Ris return Insert Id

        If cls.IsValid Then
            If cls.IsChanged Then
                Dim DbCommand As SqlCommand = New SqlCommand()
                Try
                    Dim sql As String
                    DbCommand.Connection = _cn
                    If Not DbTransaction Is Nothing Then DbCommand.Transaction = DbTransaction
                    If cls.ID = 0 Then
                        sql = "INSERT INTO Article ("
                        sql &= "Code,"
                        sql &= "Designation,"
                        sql &= "Prix,"
                        sql &= "Date_Creation"
                        sql &= ") VALUES ("
                        sql &= "@Code,"
                        sql &= "@Designation,"
                        sql &= "@Prix,"
                        sql &= "@Date_Creation"
                        sql &= ")"
                    Else
                        sql = "UPDATE Article SET "
                        sql &= "Code = @Code,"
                        sql &= "Designation = @Designation,"
                        sql &= "Prix = @Prix,"
                        sql &= "Date_Creation = @Date_Creation"
                        sql &= " WHERE ID= " & cls.ID
                    End If
                    DbCommand.Parameters.Add(New Microsoft.Data.SqlClient.SqlParameter("@Code", cls.Code))
                    DbCommand.Parameters.Add(New Microsoft.Data.SqlClient.SqlParameter("@Designation", cls.Designation))
                    DbCommand.Parameters.Add(New Microsoft.Data.SqlClient.SqlParameter("@Prix", cls.Prix))
                    If cls.Date_Creation <> Date.MinValue Then
                        Dim DataPar As New Microsoft.Data.SqlClient.SqlParameter("@Date_Creation", SqlDbType.DateTime)
                        DataPar.Value = cls.Date_Creation
                        DbCommand.Parameters.Add(DataPar)
                    Else
                        DbCommand.Parameters.Add(New Microsoft.Data.SqlClient.SqlParameter("@Date_Creation", DBNull.Value))
                    End If
                    DbCommand.CommandType = CommandType.Text
                    DbCommand.CommandText = sql
                    DbCommand.ExecuteNonQuery()

                    If cls.ID = 0 Then
                        Dim IdInserito As Integer = 0
                        sql = "select @@identity"
                        DbCommand.CommandText = sql
                        IdInserito = DbCommand.ExecuteScalar()
                        cls.ID = IdInserito
                        Ris = IdInserito
                    Else
                        Ris = cls.ID
                    End If

                    DbCommand.Dispose()

                Catch ex As Exception
                    ManageError(ex)
                End Try
            Else
                Ris = cls.ID
            End If

        Else
            Err.Raise(602, "Object data is not valid")
        End If
        Return Ris
    End Function

    Private Sub DestroyPermanently(Id As Integer)
        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE Article SET DELETED=True "
            Dim Sql As String = "DELETE FROM Article"
            Sql &= " Where ID = " & Id

            UpdateCommand.CommandText = Sql
            If Not DbTransaction Is Nothing Then UpdateCommand.Transaction = DbTransaction
            UpdateCommand.ExecuteNonQuery()
            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    ''' <summary>
    '''Delete from DB table Article. Accept id of object to delete.
    ''' </summary>
    ''' <returns>
    '''
    ''' </returns>
    Public Overrides Sub Delete(Id As Integer)

        DestroyPermanently(Id)

    End Sub

    ''' <summary>
    '''Delete from DB table Article. Accept object to delete and optional a List to remove the object from.
    ''' </summary>
    ''' <returns>
    '''
    ''' </returns>
    Public Overrides Sub Delete(ByRef obj As Article, Optional ByRef ListaObj As List(Of Article) = Nothing)

        DestroyPermanently(obj.ID)
        If Not ListaObj Is Nothing Then ListaObj.Remove(obj)

    End Sub

    Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Article)
        Return FindReal(0, OrderBy, Parameter)
    End Function

    Public Overloads Function Find(ByVal Top As Integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Article)
        Return FindReal(Top, OrderBy, Parameter)
    End Function

    Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Article)
        Return FindReal(0, "", Parameter)
    End Function

    Private Function FindReal(ByVal Top As Integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Article)
        Dim Ls As New List(Of Article)
        Try

            Dim sql As String = "
				sql = SELECT " & IIf(Top, Top, "") & "Id" &
                    "Code," &
                    "Designation," &
                    "Prix," &
                    "Date_Creation"
            sql &= " from Article"
            For Each Par As LUNA.LunaSearchParameter In Parameter
                If Not Par Is Nothing Then
                    If sql.IndexOf("WHERE") = -1 Then sql &= " WHERE " Else sql &= " " & Par.LogicOperatorStr & " "
                    sql &= Par.FieldName & " " & Par.SqlOperator & " " & Ap(Par.Value)
                End If
            Next

            If OrderBy.Length Then sql &= " ORDER BY " & OrderBy

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

    Public Overrides Function GetAll(Optional OrderByField As String = "", Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Article)
        Dim Ls As New List(Of Article)
        Try

            Dim sql As String = " SELECT ID,Code,Designation,Prix,Date_Creation from Article"

            If Not String.IsNullOrWhiteSpace(OrderByField) Then
                sql &= " ORDER BY " & OrderByField
            End If

            Ls = GetData(sql, AddEmptyItem).ToList()

        Catch ex As Exception
            ManageError(ex)
            Ls = New List(Of Article)
        End Try
        Return Ls
    End Function

    Private Function GetData(sql As String, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Article)
        Dim Ls As New List(Of Article)
        Try
            Dim myCommand As SqlCommand = _cn.CreateCommand()
            myCommand.CommandText = sql
            If Not DbTransaction Is Nothing Then myCommand.Transaction = DbTransaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            If AddEmptyItem Then Ls.Add(New Article() With {.ID = 0, .Code = "", .Designation = "", .Prix = 0, .Date_Creation = Nothing})
            While myReader.Read
                Dim classe As New Article
                If Not myReader("ID") Is DBNull.Value Then classe.ID = myReader("ID")
                If Not myReader("Code") Is DBNull.Value Then classe.Code = myReader("Code")
                If Not myReader("Designation") Is DBNull.Value Then classe.Designation = myReader("Designation")
                If Not myReader("Prix") Is DBNull.Value Then classe.Prix = myReader("Prix")
                If Not myReader("Date_Creation") Is DBNull.Value Then classe.Date_Creation = myReader("Date_Creation")
                Ls.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function
End Class


