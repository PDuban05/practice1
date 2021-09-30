using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORMPrac1
{
    public partial class Form1 : Form
    {

        public List<Model.ALUMNO> oAlumno;
        public List<Model.APODERADO> oApoderado;
        public List<Model.CURSOS> oCurso;
        public List<Model.INSCRITO> OInscrito;
        int indice = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Alumno");
            comboBox1.Items.Add("Apoderado");
            comboBox1.Items.Add("Curso");
            comboBox1.Items.Add("Inscrito");



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Model.DBPrac1Entities db = new Model.DBPrac1Entities())
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        oAlumno = db.ALUMNO.ToList();
                        break;
                    case 1: oApoderado = db.APODERADO.ToList();
                        break;
                    case 2:
                        oCurso = db.CURSOS.ToList();
                        break;
                    case 3:
                        OInscrito = db.INSCRITO.ToList();
                        break;

                }
            }
            indice = 0;
            Llenar();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            indice--;
            Llenar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            indice++;
            Llenar();
        }
    public void Llenar()
        {
            if (indice < 0)
                indice = 0;

            string cadena = "";

            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    if (indice >= oAlumno.Count)
                        indice = oAlumno.Count - 1;
                    cadena = oAlumno[indice].Id.ToString() + " . " + oAlumno[indice].nombre + " , de" + oAlumno[indice].ciudad + ", " + oAlumno[indice].edad + "años";

                    break;
                case 1:
                    if (indice >= oApoderado.Count)
                        indice = oApoderado.Count - 1;
                    using (Model.DBPrac1Entities db = new Model.DBPrac1Entities())
                    {
                        oAlumno = db.ALUMNO.ToList();
                        cadena = oApoderado[indice].Id.ToString() + " ." + oApoderado[indice].nombre + " , es el | la apoderado | a de  " + oAlumno.Find(a => a.Id == (int)oApoderado[indice].Id_Alumno).nombre;
                    }
                    break;
                case 2:
                    if (indice >= oCurso.Count)
                        indice = oCurso.Count - 1;
                    cadena = oCurso[indice].COD.ToString() + " . " + oCurso[indice].nombre + " -- Fecha de inicio:  " + oCurso[indice].fecha_inicio + " -- Duracion: " + oCurso[indice].duracion + " -- valor: " + oCurso[indice].valor;
                   
                    break;

                case 3:
                    if (indice >= OInscrito.Count)
                        indice = OInscrito.Count -1;

                    using (Model.DBPrac1Entities db = new Model.DBPrac1Entities())
                    {
                        oAlumno = db.ALUMNO.ToList();
                        oCurso = db.CURSOS.ToList();
                      
                        cadena = OInscrito[indice].Id.ToString() + " ." + oAlumno.Find(a => a.Id == (int)OInscrito[indice].Id_Alumno).nombre + "  estudia " + oCurso.Find(a => a.COD == (int)OInscrito[indice].COD_CURSO).nombre;
                    }


                    break;

                   
            }

            textBox1.Text = cadena;

        }




    }
}
