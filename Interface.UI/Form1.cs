using CommonLibrary.Business;
using CommonLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.UI
{
    public partial class Form1 : Form
    {


        private  List<MassaDadosModel> a_ListReturnFullDados;
        private List<AgrupamentoModel> a_Conta_AgrupamentoModel;
        private List<AgrupamentoModel> a_Ativo_AgrupamentoModel;
        private List<AgrupamentoModel> a_TipoOperacao_AgrupamentoModel;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //comboBoxAgrup.DataSource = Enum.GetValues(typeof(AgrupamentoEnum));
        }

        private void carregaGridFull(List<MassaDadosModel> p_massaDadosModels)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("datetime", typeof(string));
                dt.Columns.Add("tipoOperacao", typeof(string));
                dt.Columns.Add("ativo", typeof(string));
                dt.Columns.Add("quantidade", typeof(int));
                dt.Columns.Add("preco", typeof(double));
                dt.Columns.Add("conta", typeof(int));
                DataRow dr = dt.NewRow();

                foreach (var item in p_massaDadosModels)
                {
                    dr = dt.NewRow();
                    dr["id"] = item.id;
                    dr["datetime"] = item.datetime;
                    dr["tipoOperacao"] = item.tipoOperacao;
                    dr["ativo"] = item.ativo;
                    dr["quantidade"] = item.quantidade;
                    dr["preco"] = item.preco;
                    dr["conta"] = item.conta;
                    
                    dt.Rows.Add(dr);

                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
        }

        private void carregaAgrupamento(int p_agrupamentoEnum)
        {
            try
            {
                List<AgrupamentoModel> _genericLIst =new List<AgrupamentoModel>();

                RequestBusiness _request = new RequestBusiness();
                var json = _request.RunRequest("https://localhost:44313/Agrupamento/" + p_agrupamentoEnum.ToString());
                
                switch (p_agrupamentoEnum)
                {
                    case 1: // Conta
                        a_Conta_AgrupamentoModel = JsonConvert.DeserializeObject<List<AgrupamentoModel>>(json);
                        _genericLIst = a_Conta_AgrupamentoModel;
                        break;
                    case 2: // Ativo
                        a_Ativo_AgrupamentoModel = JsonConvert.DeserializeObject<List<AgrupamentoModel>>(json);
                        _genericLIst = a_Ativo_AgrupamentoModel;
                        break;
                    case 3: // TipoOperacao
                        a_TipoOperacao_AgrupamentoModel = JsonConvert.DeserializeObject<List<AgrupamentoModel>>(json);
                        _genericLIst = a_TipoOperacao_AgrupamentoModel;
                        break;
                    default:
                        MessageBox.Show("Erro " + "Tipo de agrupamento inválido");
                        break;
                }
                
                if ( _genericLIst.Count == 0 )
                { return; }

                DataTable dt = new DataTable();
                dt.Columns.Add("descricao", typeof(string));
                dt.Columns.Add("quantidade", typeof(int));
                dt.Columns.Add("precomedio", typeof(double));
                
                DataRow dr = dt.NewRow();

                foreach (var item in _genericLIst)
                {
                    dr = dt.NewRow();
                    dr["descricao"] = item.descricao;
                    dr["quantidade"] = item.quantidade;
                    dr["precomedio"] = item.precomedio;
                    dt.Rows.Add(dr);
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _agrup = comboBoxAgrup.SelectedIndex;

            if (_agrup == 0) 
            { 
                if (a_ListReturnFullDados == null )
                { 
                    RequestBusiness _request = new RequestBusiness();
                    var json = _request.RunRequest("https://localhost:44313/GetFullDados");
                    a_ListReturnFullDados = JsonConvert.DeserializeObject<List<MassaDadosModel>>(json);

                }
                else
                {
                    this.carregaGridFull(a_ListReturnFullDados);
                }
            }
            else 
            {
                this.carregaAgrupamento(_agrup);
            }
        }
    }
}
