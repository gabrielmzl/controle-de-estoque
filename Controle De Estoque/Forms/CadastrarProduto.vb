Public Class CadastrarProduto
    Dim fornecedor As New FornecedorController()
    Dim produto As New ProdutoController()

    Public Sub CarregarFornecedores()
        Dim fornecedores = fornecedor.Buscar()

        ListBox1.DataSource = fornecedores
        ListBox1.DisplayMember = "nome"
        ListBox1.ValueMember = "id"
    End Sub

    Private Sub CadastrarProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarFornecedores()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nomeProduto = TextBox1.Text
        Dim marcaProduto = TextBox2.Text
        Dim quantidadeProduto = NumericUpDown1.Value
        Dim estoqueMinimo = NumericUpDown2.Value
        Dim precoProduto = TextBox5.Text
        Dim fornecedorId = ListBox1.GetItemText(ListBox1.SelectedValue)
        Dim status As String = "Valor inválido."

        If quantidadeProduto > estoqueMinimo Then
            status = "Estoque confortável"
        ElseIf quantidadeProduto <= estoqueMinimo AndAlso quantidadeProduto > 0 Then
            status = "Estoque perigoso"
        ElseIf quantidadeProduto = 0 Then
            status = "Sem estoque"
        End If

        Try
            Dim novoProduto As New Produto() With {
                .nome = nomeProduto,
                .marca = marcaProduto,
                .quantidade = quantidadeProduto,
                .estoque_minimo = estoqueMinimo,
                .preco = precoProduto,
                .fornecedor_id = fornecedorId,
                .status = status
            }

            produto.Adicionar(novoProduto)

            MessageBox.Show("Produto adicionado com sucesso!", "Sucesso")
            Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao adicionar produto, tente novamente mais tarde...", "Erro")
        End Try
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub
End Class