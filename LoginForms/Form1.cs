using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LoginForms
{
    public partial class Form1 : Form
    {
         
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-CF87QM2O\\SQLEXPRESS;Initial Catalog=sample;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        SqlCommand cmd;
        SqlDataReader rdr;

        public Form1()
        {
            InitializeComponent();
        }

         
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

         
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 
                cmd = new SqlCommand("SELECT * FROM User_Pass WHERE Username = @Username AND Password = @Password", conn);

                 
                cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", textBox2.Text.Trim());

                
                conn.Open();

                 
                rdr = cmd.ExecuteReader();

                 
                if (rdr.HasRows)
                {
                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Login Failed! Please check your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                 
                rdr.Close();
            }
            catch (Exception ex)
            {
                 
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
