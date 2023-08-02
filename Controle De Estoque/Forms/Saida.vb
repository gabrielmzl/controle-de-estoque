Public Class Saida

    Dim Id As Integer
    Dim produtoC As New ProdutoController()

    Public Sub New(ByVal idProduto As Integer)
        InitializeComponent()

        Id = idProduto
    End Sub

    Private Sub Saida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim produto = produtoC.BuscarPorId(Id)

            TextBox1.Text = produto.nome
        Catch ex As Exception
            MessageBox.Show("Erro ao procurar produto, tente novamente mais tarde...", "Erro")
            Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            produtoC.Saida(Id, NumericUpDown1.Value)
            MessageBox.Show("Saida adicionada com sucesso!", "Sucesso")
            Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao cadastrar saida, tente novamente mais tarde...", "Erro")
        End Try
    End Sub
End Class