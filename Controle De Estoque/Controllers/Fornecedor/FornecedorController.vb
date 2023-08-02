Public Class FornecedorController
    Public Sub Adicionar(fornecedor As Fornecedor)
        Using contexto As New EstoqueContext()
            contexto.Fornecedores.Add(fornecedor)
            contexto.SaveChanges()
        End Using
    End Sub

    Public Function Buscar() As List(Of Fornecedor)
        Using contexto As New EstoqueContext()
            Return contexto.Fornecedores.ToList()
        End Using
    End Function
End Class
