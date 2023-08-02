Public Class CadastrarFornecedor
    Dim fornecedor As New FornecedorController()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nomeFornecedor = TextBox1.Text
        Dim enderecoFornecedor = TextBox2.Text
        Dim telefoneFornecedor = MaskedTextBox1.Text
        Dim cnpjFornecedor = MaskedTextBox2.Text

        Try
            Dim novoFornecedor As New Fornecedor() With {
                .nome = nomeFornecedor,
                .endereco = enderecoFornecedor,
                .telefone = telefoneFornecedor,
                .cnpj = cnpjFornecedor
            }

            fornecedor.Adicionar(novoFornecedor)

            MessageBox.Show("Fornecedor adicionado com sucesso!", "Sucesso")
            Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao adicionar fornecedor, tente novamente mais tarde...", "Erro")
        End Try
    End Sub
End Class