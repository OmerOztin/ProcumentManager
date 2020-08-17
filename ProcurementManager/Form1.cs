using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Code written by Ömer Öztin mail:omeroztin@gmail.com
namespace ProcurementManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Products pro = new Products();//We call Products class
            pro.identity = int.Parse(textBox2.Text);
            pro.productName = textBox3.Text;
            pro.location = textBox4.Text;
            pro.supplierID = int.Parse(textBox5.Text);

            ContextClass objContext = new ContextClass();
            objContext.Productss.Add(pro);//We add our variables into our Database
            objContext.SaveChanges();
            this.suppliersTableAdapter.Fill(this.productDBDataSet.Suppliers);//We update our datagridview
            this.productsTableAdapter.Fill(this.productDBDataSet.Products);


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void productsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.suppliersTableAdapter.Fill(this.productDBDataSet.Suppliers);
            this.productsTableAdapter.Fill(this.productDBDataSet.Products);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            sup.supplierName = textBox1.Text;

            ContextClass2 objContext2 = new ContextClass2();
            objContext2.Supplierss.Add(sup);
            objContext2.SaveChanges();
            this.suppliersTableAdapter.Fill(this.productDBDataSet.Suppliers);
            this.productsTableAdapter.Fill(this.productDBDataSet.Products);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ContextClass conn = new ContextClass();
            conn.Database.Delete();

            ContextClass2 connn = new ContextClass2();
            connn.Database.Delete();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == dataGridView1.Columns["Update"].Index && e.RowIndex >= 0)
            {
                int id= Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                Products pro = new Products();
                pro.productID = id;
                pro.identity = int.Parse(textBox2.Text);
                pro.productName = textBox3.Text;
                pro.location = textBox4.Text;
                pro.supplierID = int.Parse(textBox5.Text);

                ContextClass objContext = new ContextClass();
                objContext.Productss.Attach(pro);
                objContext.Entry(pro).State = System.Data.Entity.EntityState.Modified;//We use entiystate.modified for update our data on database
                objContext.SaveChanges();
                this.suppliersTableAdapter.Fill(this.productDBDataSet.Suppliers);
                this.productsTableAdapter.Fill(this.productDBDataSet.Products);

            }
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                ContextClass objContext = new ContextClass();
                int id = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                Products pro = new Products();
                pro.productID = id;

                objContext.Entry(pro).State = System.Data.Entity.EntityState.Deleted;//We use entiystate.deleted for delete our data on database
                objContext.SaveChanges();
                this.suppliersTableAdapter.Fill(this.productDBDataSet.Suppliers);
                this.productsTableAdapter.Fill(this.productDBDataSet.Products);
            }
            if (e.ColumnIndex == dataGridView1.Columns["Supplier"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridView1[4, e.RowIndex].Value);

                var ctx = new ContextClass2();
                var name = ctx.Supplierss.Find(id);
                MessageBox.Show(name.supplierName);               
            }
        }
    }
}
