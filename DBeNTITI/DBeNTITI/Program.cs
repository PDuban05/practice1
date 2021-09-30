using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBeNTITI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Model.DBPrac1Entities db = new Model.DBPrac1Entities())
            {
                using (var dbContextTransaccion = db.Database.BeginTransaction())
                {
                    try
                    {

                        var TrAlumno = new Model.ALUMNO();
                        TrAlumno.nombre = "Marcos";
                        TrAlumno.ciudad = "Berlin";
                        TrAlumno.edad = "17";

                        db.ALUMNO.Add(TrAlumno);
                        db.SaveChanges();
                        
                     dbContextTransaccion.Commit();




                    }
                    catch
                    {
                        dbContextTransaccion.Rollback();
                    }

                }


            }

            Console.ReadLine();
        }
    }
}
