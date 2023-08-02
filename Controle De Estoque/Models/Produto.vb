Imports System.ComponentModel.DataAnnotations.Schema

<Table("public.produtos")>
Public Class Produto
    Public Property id As Integer
    Public Property nome As String
    Public Property marca As String
    Public Property quantidade As String
    Public Property estoque_minimo As String
    Public Property status As String
    Public Property preco As Decimal
    Public Property fornecedor_id As String
End Class
