using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSConnectSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void queryToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if(cn.State==ConnectionState.Closed)
                        cn.Open();
                    MessageBox.Show("Connection Successful","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }

            catch (Exception ex){
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using (DataTable dt = new DataTable("Result"))
                    {
                        using (SqlCommand cmd = new SqlCommand(txtQuery.Text, cn))
                        {
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                            sqlDataAdapter.Fill(dt);
                            dataGridView.DataSource = dt;
                        }
                    }
                    }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
