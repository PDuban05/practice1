using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORMPrac2
{
    public partial class Form1 : Form
    {


        public List<Model.AGENTS> oAgentes;
        public List<Model.CUSTOMER> oCustomers;
        public List<Model.ORDERS> oOrders;
        public int indice = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Model.DB2EntityContainer db =new Model.DB2EntityContainer())
            {
                var oAgents = db.AGENTS.ToList();
                if(oAgents.Count > 0)
                {
                    MessageBox.Show("La base de datos ya contiene informacion", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {


                    //todo
                    //se debe llenar

                    using (var dbTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            List<Model.AGENTS> agentes = new List<Model.AGENTS>();
                            List<Model.CUSTOMER> customers = new List<Model.CUSTOMER>();
                            List<Model.ORDERS> orders = new List<Model.ORDERS>();

                            agentes.Add(new Model.AGENTS { AGENT_CODE = 001, AGENT_NAME = "Ramasundar", WORKING_AREA = "Bangalore", COMMISSION = 0, COUNTRY = "", PHONE_NO = "077-25814763" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 002, AGENT_NAME = "Alex", WORKING_AREA = "Londo", COMMISSION = 0.13m, COUNTRY = "", PHONE_NO = "077-43323" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 003, AGENT_NAME = "Alford", WORKING_AREA = "New York", COMMISSION = 0.12m, COUNTRY = "", PHONE_NO = "077-3441314" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 004, AGENT_NAME = "Satakumar", WORKING_AREA = "chennai", COMMISSION = 0.23m, COUNTRY = "", PHONE_NO = "077-84444675" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 005, AGENT_NAME = "lucida", WORKING_AREA = "San Jose", COMMISSION = 0.27m, COUNTRY = "", PHONE_NO = "077-5411684" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 006, AGENT_NAME = "Anderson", WORKING_AREA = "Brisban", COMMISSION = 0.232m, COUNTRY = "", PHONE_NO = "077-544646354" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 007, AGENT_NAME = "Ivan", WORKING_AREA = "Toronto", COMMISSION = 0.56m, COUNTRY = "", PHONE_NO = "077-644546" });

                            customers.Add(new Model.CUSTOMER { CUST_CODE=  0001 ,CUST_NAME="Holmes",CUST_CITY="Londo",WORKING_AREA="Tokio",CUST_COUNTRY="USD",GRADE=2,OPENING_AMT=6000 , RECEIVE_AMT= 7000,PAYMENT_AMT=6000 ,OUTSTANDING_AMT=8000 ,PHONE_NO="05-4149941",AGENT_CODE= 001});
                            customers.Add(new Model.CUSTOMER { CUST_CODE = 0002, CUST_NAME = "Michael", CUST_CITY = "new York", WORKING_AREA = "venezuela", CUST_COUNTRY = "UK", GRADE = 3, OPENING_AMT = 400, RECEIVE_AMT =5000 , PAYMENT_AMT =60641694 , OUTSTANDING_AMT =40000 , PHONE_NO = "05-4199494", AGENT_CODE =002 });
                            customers.Add(new Model.CUSTOMER { CUST_CODE = 0003, CUST_NAME = "Albert", CUST_CITY = "New York", WORKING_AREA = "London", CUST_COUNTRY = "JP", GRADE = 4, OPENING_AMT = 20000, RECEIVE_AMT =62222 , PAYMENT_AMT = 6500000, OUTSTANDING_AMT = 60000, PHONE_NO = "06-5426941", AGENT_CODE = 003});
                            customers.Add(new Model.CUSTOMER { CUST_CODE = 0004, CUST_NAME = "Stuard", CUST_CITY = "London", WORKING_AREA = "Canada", CUST_COUNTRY = "NGL", GRADE = 5, OPENING_AMT =52000 , RECEIVE_AMT =6000 , PAYMENT_AMT = 50000, OUTSTANDING_AMT = 44222, PHONE_NO = "0-555", AGENT_CODE = 004});
                            customers.Add(new Model.CUSTOMER { CUST_CODE = 0005, CUST_NAME = "Bolt", CUST_CITY = "Singapur", WORKING_AREA = "Toronto", CUST_COUNTRY = "COL", GRADE = 6, OPENING_AMT = 620000, RECEIVE_AMT =4000 , PAYMENT_AMT = 60000, OUTSTANDING_AMT =852858 , PHONE_NO = "075-20757", AGENT_CODE =005 });
                            customers.Add(new Model.CUSTOMER { CUST_CODE = 0006, CUST_NAME = "fleming", CUST_CITY = "Tokio", WORKING_AREA = "Estambul", CUST_COUNTRY = "URG", GRADE =7 , OPENING_AMT = 5450000, RECEIVE_AMT = 9000, PAYMENT_AMT = 70000, OUTSTANDING_AMT = 58585, PHONE_NO = "5757572", AGENT_CODE = 006});
                            customers.Add(new Model.CUSTOMER { CUST_CODE = 0007, CUST_NAME = "Jacks", CUST_CITY = "London", WORKING_AREA = "San francisco", CUST_COUNTRY = "PJ", GRADE =8 , OPENING_AMT = 520000, RECEIVE_AMT = 7000, PAYMENT_AMT = 9000, OUTSTANDING_AMT = 78585, PHONE_NO = "5757275", AGENT_CODE = 007});
                            customers.Add(new Model.CUSTOMER { CUST_CODE = 0008, CUST_NAME = "Yearannaidu", CUST_CITY = "Bogota", WORKING_AREA = "Tokio", CUST_COUNTRY = "UK", GRADE =0 , OPENING_AMT = 45000, RECEIVE_AMT =6000 , PAYMENT_AMT =1000 , OUTSTANDING_AMT = 585858, PHONE_NO = "6996986986", AGENT_CODE = 001});
                            customers.Add(new Model.CUSTOMER { CUST_CODE = 0009, CUST_NAME = "Yearannaidu", CUST_CITY = "Bogota", WORKING_AREA = "Tokio", CUST_COUNTRY = "UK", GRADE = 0, OPENING_AMT = 45000, RECEIVE_AMT = 6000, PAYMENT_AMT = 1000, OUTSTANDING_AMT = 585858, PHONE_NO = "6996986986", AGENT_CODE = 002 });
                            customers.Add(new Model.CUSTOMER { CUST_CODE = 00010, CUST_NAME = "Yearannaidu", CUST_CITY = "Bogota", WORKING_AREA = "Tokio", CUST_COUNTRY = "UK", GRADE = 0, OPENING_AMT = 45000, RECEIVE_AMT = 6000, PAYMENT_AMT = 1000, OUTSTANDING_AMT = 585858, PHONE_NO = "6996986986", AGENT_CODE = 003 });
                            



                            orders.Add(new Model.ORDERS { ORD_NUM=100,ORD_AMOUNT=15085550,ADVANCE_AMOUNT="6000",ORD_DATE= new DateTime(2008,08,01), CUST_CODE=00010,AGENT_CODE=001,ORD_DESCRIPTION="sod" });
                            orders.Add(new Model.ORDERS { ORD_NUM = 100, ORD_AMOUNT = 150226222, ADVANCE_AMOUNT = "7000", ORD_DATE = new DateTime(2009, 08, 018), CUST_CODE = 0001, AGENT_CODE = 001, ORD_DESCRIPTION = "sod" });
                            orders.Add(new Model.ORDERS { ORD_NUM = 200, ORD_AMOUNT = 1502626262, ADVANCE_AMOUNT = "68000", ORD_DATE = new DateTime(2007, 06, 08), CUST_CODE = 0002, AGENT_CODE = 002, ORD_DESCRIPTION = "sod" });
                            orders.Add(new Model.ORDERS { ORD_NUM = 300, ORD_AMOUNT = 55029592, ADVANCE_AMOUNT = "9000", ORD_DATE = new DateTime(2004, 05, 07), CUST_CODE = 0003, AGENT_CODE = 003, ORD_DESCRIPTION = "sod" });
                            orders.Add(new Model.ORDERS { ORD_NUM = 400, ORD_AMOUNT = 9508952959, ADVANCE_AMOUNT = "1000", ORD_DATE = new DateTime(2003, 03, 06), CUST_CODE = 0004, AGENT_CODE = 004, ORD_DESCRIPTION = "sod" });
                            orders.Add(new Model.ORDERS { ORD_NUM = 500, ORD_AMOUNT = 3508599529, ADVANCE_AMOUNT = "6000", ORD_DATE = new DateTime(2002, 04, 05), CUST_CODE = 0005, AGENT_CODE = 005, ORD_DESCRIPTION = "sod" });
                            orders.Add(new Model.ORDERS { ORD_NUM = 600, ORD_AMOUNT = 15049959, ADVANCE_AMOUNT = "6000", ORD_DATE = new DateTime(2001, 07, 04), CUST_CODE = 0006, AGENT_CODE = 006, ORD_DESCRIPTION = "sod" });
                            orders.Add(new Model.ORDERS { ORD_NUM = 700, ORD_AMOUNT = 984426294, ADVANCE_AMOUNT = "6000", ORD_DATE = new DateTime(2009, 09, 03), CUST_CODE = 0007, AGENT_CODE = 007, ORD_DESCRIPTION = "sod" });
                            orders.Add(new Model.ORDERS { ORD_NUM = 800, ORD_AMOUNT = 219494, ADVANCE_AMOUNT = "6000", ORD_DATE = new DateTime(2000, 08, 01), CUST_CODE = 0008, AGENT_CODE = 001, ORD_DESCRIPTION = "sod" });
                            orders.Add(new Model.ORDERS { ORD_NUM = 900, ORD_AMOUNT = 4995585, ADVANCE_AMOUNT = "6000", ORD_DATE = new DateTime(2008, 01, 02), CUST_CODE = 0009, AGENT_CODE = 002, ORD_DESCRIPTION = "sod" });


                            db.AGENTS.AddRange(agentes);
                            db.CUSTOMERS.AddRange(customers);
                            db.ORDERS.AddRange(orders);
                            db.SaveChanges();
                            dbTransaction.Commit();

                            MessageBox.Show("La base de datos ha sido poblada con exito", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch
                        {
                            dbTransaction.Rollback();
                            MessageBox.Show("Ocurrio un error y la base de datos no pudo ser poblada.\n\nLa aplicación se cerrará. ", "error encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                            return;
                        }




                    }   
                
                }
                button1.Enabled = false;
                oAgentes = db.AGENTS.ToList();
                oCustomers = db.CUSTOMERS.ToList();
                oOrders = db.ORDERS.ToList();
                indice = 0;
                Llenar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Siguiente registro
            indice++;
            Llenar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //registro anterior
            indice--;
            Llenar();
        }


        public void Llenar()
        {
            if (indice < 0)
                indice = 0;
            if (indice >= oAgentes.Count)
                indice = oAgentes.Count - 1;
            string cadena = "";
            string cadena2 = "";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            cadena = oAgentes[indice].AGENT_CODE.ToString() + "  -  " + oAgentes[indice].AGENT_NAME + ", en " + oAgentes[indice].WORKING_AREA;
            textBox1.Text = cadena;

            List<Model.CUSTOMER> iCustomer = new List<Model.CUSTOMER>();
            iCustomer = oCustomers.Where(a => a.AGENT_CODE == (int)oAgentes[indice].AGENT_CODE).ToList();
            if (iCustomer !=null)
            {
                cadena = "";
                cadena2 = "";

                for(int i = 0; i <iCustomer.Count;i++)
                {
                    cadena = cadena + iCustomer[i].CUST_CODE.ToString() + " - " + iCustomer[i].CUST_NAME + ",";

                    List<Model.ORDERS> jOrder = new List<Model.ORDERS>();

                    jOrder = oOrders.Where(a => a.AGENT_CODE == (int)oAgentes[indice].AGENT_CODE && a.CUST_CODE == (int)iCustomer[i].CUST_CODE).ToList(); 
                    if (jOrder !=null)
                    {
                        for(int j=0; j < jOrder.Count;j++)
                        {
                            cadena2 = cadena2 + jOrder[j].ORD_NUM.ToString() + ",";
                        }
                    }



                }
                textBox2.Text = cadena;
                textBox3.Text = cadena2;
            }




            


        }

    }
}
