Public Class EditarProduto
    Dim Id As Integer
    Dim Fornecedor_Id As Integer
    Dim produtoC As New ProdutoController()
    Dim fornecedor As New FornecedorController()

    Public Sub New(ByVal idProduto As Integer, ByVal idFornecedor As Integer)
        InitializeComponent()

        Id = idProduto
        Fornecedor_Id = idFornecedor
    End Sub

    Public Sub CarregarFornecedores()
        Try
            Dim fornecedores = fornecedor.Buscar()

            ListBox1.DataSource = fornecedores
            ListBox1.DisplayMember = "nome"
            ListBox1.ValueMember = "id"
            ListBox1.SelectedIndex = Fornecedor_Id - 1
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro ao encontrar o fornecedor, tente novamente mais tarde...", "Erro")
            Close()
        End Try
    End Sub

    Private Sub EditarProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregarFornecedores()

        Try
            Dim fornecedorForm As New CadastrarProduto()
            Dim produto = produtoC.BuscarPorId(Id)

            TextBox1.Text = produto.nome
            TextBox2.Text = produto.marca
            NumericUpDown1.Value = produto.quantidade
            NumericUpDown2.Value = produto.estoque_minimo
            TextBox5.Text = produto.preco
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro ao carregar o produto, tente novamente mais tarde...", "Erro")
            Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim produto = produtoC.BuscarPorId(Id)

            Dim produtoEditado As Produto = produto
            produtoEditado.nome = TextBox1.Text
            produtoEditado.marca = TextBox2.Text
            produtoEditado.quantidade = NumericUpDown1.Value
            produtoEditado.estoque_minimo = NumericUpDown2.Value
            produtoEditado.preco = TextBox5.Text
            produtoEditado.fornecedor_id = ListBox1.GetItemText(ListBox1.SelectedValue)

            Dim status As String = "Valor inválido."

            Dim produtoqtd As Integer = produtoEditado.quantidade
            Dim estoquemin As Integer = produtoEditado.estoque_minimo

            If produtoqtd > estoquemin Then
                status = "Estoque confortável"
            ElseIf produtoqtd < estoquemin AndAlso produtoqtd > 0 Then
                status = "Estoque perigoso"
            ElseIf produtoqtd = 0 Then
                status = "Sem estoque"
            End If

            produtoEditado.status = status
            produtoC.Atualizar(produtoEditado)

            MessageBox.Show("Produto editado com sucesso!", "Sucesso")
            Close()
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro ao editar o produto, tente novamente mais tarde...", "Erro")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim confirmaExclusao As DialogResult = MessageBox.Show("Deseja excluir o id " & Id & "?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmaExclusao = DialogResult.Yes Then
            Try
                produtoC.Deletar(Id)
                MessageBox.Show("Produto excluido com sucesso!", "Sucesso")
                Close()
            Catch
                MessageBox.Show("Ocorreu um erro ao excluir o produto, tente novamente mais tarde...", "Erro")
            End Try
        End If
    End Sub
End Class