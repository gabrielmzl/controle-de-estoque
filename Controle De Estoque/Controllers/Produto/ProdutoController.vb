Imports System.Threading

Public Class ProdutoController
    Public Sub Adicionar(produto As Produto)
        Using contexto As New EstoqueContext()
            contexto.Produtos.Add(produto)
            contexto.SaveChanges()
        End Using
    End Sub

    Public Function Buscar() As List(Of Produto)
        Using contexto As New EstoqueContext()
            Return contexto.Produtos.ToList()
        End Using
    End Function

    Public Function BuscarPorId(id As Integer) As Produto
        Using contexto As New EstoqueContext()
            Return contexto.Produtos.Find(id)
        End Using
    End Function

    Public Sub Atualizar(produto As Produto)
        Using contexto As New EstoqueContext()
            Dim produtoEditado = contexto.Produtos.Find(produto.id)

            If produtoEditado IsNot Nothing Then
                contexto.Entry(produtoEditado).CurrentValues.SetValues(produto)
                contexto.SaveChanges()
            End If
        End Using
    End Sub

    Public Sub Deletar(id As Integer)
        Using contexto As New EstoqueContext()
            Dim produto = contexto.Produtos.Find(id)

            If produto IsNot Nothing Then
                contexto.Produtos.Remove(produto)
                contexto.SaveChanges()
            End If
        End Using
    End Sub

    Public Sub Entrada(id As Integer, novaQuantidade As Integer)
        Using contexto As New EstoqueContext()
            Dim produto = contexto.Produtos.Find(id)
            Dim produtoQuantidade = produto.quantidade + novaQuantidade
            produto.quantidade = produto.quantidade + novaQuantidade

            If produtoQuantidade > produto.estoque_minimo Then
                produto.status = "Estoque confortável"
            ElseIf produtoQuantidade < produto.estoque_minimo AndAlso produtoQuantidade > 0 Then
                produto.status = "Estoque perigoso"
            ElseIf produtoQuantidade = 0 Then
                produto.status = "Sem estoque"
            End If

            contexto.SaveChanges()
        End Using
    End Sub

    Public Sub Saida(id As Integer, novaQuantidade As Integer)
        Using contexto As New EstoqueContext()
            Dim produto = contexto.Produtos.Find(id)
            Dim produtoQuantidade = produto.quantidade - novaQuantidade
            produto.quantidade = produto.quantidade - novaQuantidade

            If produtoQuantidade < 0 Then
                MessageBox.Show("Não é possivel dar saida e deixar o valor < 0.", "Erro")
                Return
            Else
                If produtoQuantidade > produto.estoque_minimo Then
                    produto.status = "Estoque confortável"
                ElseIf produtoQuantidade < produto.estoque_minimo AndAlso produtoQuantidade > 0 Then
                    produto.status = "Estoque perigoso"
                ElseIf produtoQuantidade = 0 Then
                    produto.status = "Sem estoque"
                End If

                contexto.SaveChanges()
            End If

        End Using
    End Sub
End Class
