using CadastroClienteAcademiaCsharp.Services;
using System;
using System.Windows.Forms;

namespace CadastroClienteAcademiaCsharp
{
    public partial class FormularioCliente : Form
    {
        private ClienteService _clienteService;
        public string cidadeId;
        private FormListarCliente _listagemCliente;
        private string _clienteId;

        public FormularioCliente(FormListarCliente listagemCliente, string clienteId = null)
        {
            InitializeComponent();
            _clienteService = new ClienteService();
            _listagemCliente = listagemCliente;
            _clienteId = clienteId;
            if (!string.IsNullOrWhiteSpace(_clienteId))
            {
                LoadCliente();
            }
        }

        private void LoadCliente()
        {
            var cliente = _clienteService.GetClienteById(_clienteId);
            txtCodigo.Text = cliente.Codigo.ToString();
            txtNome.Text = cliente.Nome.ToString();
            txtCidade.Text = cliente.Cidade.Nome.ToString();
            cidadeId = cliente.CidadeId.ToString();
            txtTelefone.Text = cliente.Telefone.ToString();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLocalizarCidade_Click(object sender, EventArgs e)
        {
            var formCidade = new FormCidade(this);
            formCidade.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {
                if (_clienteService.SaveCliente(_clienteId, txtNome.Text, cidadeId, txtTelefone.Text) > 0)
                {
                    _listagemCliente.txtBusca.Text = txtNome.Text;
                    _listagemCliente.btnBusca_Click(sender, e);
                    Close();
                }
            }
        }

        private bool VerificaCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo nome é obrigatório!");
                txtNome.Focus();
                return false;
            }

            return true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtCidade.Text = "";
            txtTelefone.Text = "";
            cidadeId = null;
            txtNome.Focus();
        }
    }
}