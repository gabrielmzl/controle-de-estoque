Public Class Form1

    Dim Id As Integer
    Dim Fornecedor_Id As Integer
    Dim fornecedor As New FornecedorController()
    Dim produto As New ProdutoController()

    Public Sub CarregarProdutos()
        Try
            Dim produtos = produto.Buscar()

            dataGridViewProdutos.DataSource = produtos
            dataGridViewProdutos.Columns(0).HeaderText = "ID"
            dataGridViewProdutos.Columns(1).HeaderText = "Nome"
            dataGridViewProdutos.Columns(2).HeaderText = "Marca"
            dataGridViewProdutos.Columns(3).HeaderText = "Quantidade"
            dataGridViewProdutos.Columns(4).HeaderText = "Estoque Minimo"
            dataGridViewProdutos.Columns(5).HeaderText = "Status"
            dataGridViewProdutos.Columns(6).HeaderText = "Preço"
            dataGridViewProdutos.Columns(7).HeaderText = "Fornecedor ID"
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar produtos, tente novamente mais tarde...", "Erro")
            Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cadastrarProduto As New CadastrarProduto()

        cadastrarProduto.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cadastrarFornecedor As New CadastrarFornecedor()

        cadastrarFornecedor.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarProdutos()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CarregarProdutos()
    End Sub

    Public Sub PegarId(sender As Object, e As EventArgs) Handles dataGridViewProdutos.SelectionChanged
        If dataGridViewProdutos.SelectedRows.Count > 0 Then
            Id = CInt(dataGridViewProdutos.SelectedRows(0).Cells("id").Value)
            Fornecedor_Id = CInt(dataGridViewProdutos.SelectedRows(0).Cells("fornecedor_id").Value)
        End If
    End Sub

    Private Sub TabelaDuploClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dataGridViewProdutos.DoubleClick
        Dim editarProduto As New EditarProduto(Id, Fornecedor_Id)
        editarProduto.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim entrada As New Entrada(Id)
        entrada.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim saida As New Saida(Id)
        saida.Show()
    End Sub
End Class
