Imports System.Data.Entity

Public Class EstoqueContext
    Inherits DbContext

    Public Property Produtos As DbSet(Of Produto)
    Public Property Fornecedores As DbSet(Of Fornecedor)

    Public Sub New()
        MyBase.New("name=DefaultConnection")
    End Sub
End Class
