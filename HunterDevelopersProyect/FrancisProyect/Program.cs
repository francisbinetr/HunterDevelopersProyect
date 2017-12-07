using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Final
{
    class Program
    {
        private static List<Integrante> listIntegrantes = new List<Integrante>(); 
        private static List<Proyecto> listProyecto = new List<Proyecto>();        

        private static bool ProgramaElegido(int codProgramaElegido)
        {
            try
            {
                if (listProyecto.Where(x => x.codProyecto == codProgramaElegido).Count() == 0)
                {
                    Console.WriteLine("ESTE PROGRAMA NO EXISTE. FAVOR ELEGIR A CUAL PROGRAMA DESEA IR.");
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("ERROR: {0}", ex.Message));
                return false;
            }
        }

        private static void Empezar()
        {
            int codPrograma = 0;
            Integrante francis = new Integrante { nombreIntegrante = "FRANCIS BINET", matricula = "10-MISM-1-070" };
            Integrante ezequiel = new Integrante { nombreIntegrante = "EZEQUIEL ROMERO", matricula = "14-EISN-1-061" };
            listIntegrantes.Add(francis);
            listIntegrantes.Add(ezequiel);

            Proyecto proyecto1 = new Proyecto { codProyecto = 1, nombreProyecto = "INDICE DE MASA CORPORAL" };
            Proyecto proyecto2 = new Proyecto { codProyecto = 2, nombreProyecto = "SUCESION FIBONACCI" };

            listProyecto.Add(proyecto1);
            listProyecto.Add(proyecto2);

            Console.WriteLine("==================================================");
            Console.WriteLine("===== PROGRAMACION ORIENTADA A OBJETOS (POO) =====");
            Console.WriteLine("================ PROYECTO FINAL ==================");
            Console.WriteLine("==================================================");
            Console.WriteLine("");
            Console.WriteLine("================== INTEGRANTES ===================");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var l in listIntegrantes)
                Console.WriteLine(String.Format("MATRICULA: {0} | NOMBRE: {1}", l.matricula, l.nombreIntegrante));

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("============= LISTADO DE PROGRAMAS ===============");
            Console.WriteLine("");
            foreach (var l in listProyecto)
                Console.WriteLine(String.Format("{0} - {1}", l.codProyecto, l.nombreProyecto));

            do
            {
                Console.WriteLine("");
                Console.WriteLine("A CUAL PROGRAMA DESEA IR?");

                codPrograma = int.Parse(Console.ReadLine());
            }
            while (!(ProgramaElegido(codPrograma)));

            switch (codPrograma)
            {
                case 1:
                    IMC_Project.Program.Main(new string[5]);
                    break;

                case 2:
                    Console.Clear();
                    SuccesionFibonacci.Program.Main(new string[5]);
                    break;
            }
        }

        static void Main(string[] args)
        {
            Empezar();
            Console.WriteLine("==================================================");
            Console.WriteLine("DESEA EMPEZAR DESDE 0? Y: SI");
            string a = Console.ReadLine();

            if (a == "Y")
            {
                Console.Clear();
                listIntegrantes = new List<Integrante>();
                listProyecto = new List<Proyecto>();
                Main(new string[5]);
            }

            Console.WriteLine("===== PRESIONE ENTER PARA SALIR.           ADIOS!!! =====");
            Console.ReadLine();
        }
    }
}
