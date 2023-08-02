Imports System.ComponentModel.DataAnnotations.Schema
Imports System.ComponentModel.DataAnnotations

<Table("public.fornecedores")>
Public Class Fornecedor
    Public Property id As Integer
    Public Property nome As String
    Public Property endereco As String
    Public Property telefone As String
    Public Property cnpj As String
End Class
