using CadastroClienteAcademiaCsharp.Domain;
using CadastroClienteAcademiaCsharp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CadastroClienteAcademiaCsharp
{
    public partial class FormCidade : Form
    {
        private FormularioCliente _formularioCliente;
        private CidadeService _cidadeService;

        public FormCidade(FormularioCliente formularioCliente)
        {
            InitializeComponent();
            _formularioCliente = formularioCliente;
            _cidadeService = new CidadeService();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetDataSource(IEnumerable<Cidade> dados)
        {
            dgvCidade.DataSource = dados;
            dgvCidade.Columns[0].Visible = false;
        }

        private void FormCidade_Load(object sender, EventArgs e)
        {
            SetDataSource(_cidadeService.GetCidades());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SetDataSource(_cidadeService.GetCidadesByNome(txtNomeCidade.Text));
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNomeCidade.Text = "";
            txtNomeCidade.Focus();
        }

        private void txtNomeCidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnBuscar_Click(sender, e);

                e.SuppressKeyPress = true;
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvCidade.SelectedCells.Count > 0)
            {
                _formularioCliente.cidadeId = dgvCidade.CurrentRow.Cells["Id"].Value.ToString();
                _formularioCliente.txtCidade.Text = dgvCidade.CurrentRow.Cells["Nome"].Value.ToString();
                Close();
            }
        }

        private void dgvCidade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelecionar_Click(sender, e);
        }
    }
}
