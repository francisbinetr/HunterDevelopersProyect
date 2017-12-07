using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC_Project
{
    public class Program
    {
        public static List<IMC_INFORMACION> listDiagnosticos;
        public static void Main(string[] args)
        {
            listDiagnosticos = new List<IMC_INFORMACION>();
            Run();
        }

        public static void Opciones()
        {
            IMC_INFORMACION imc = new IMC_INFORMACION();
            Console.WriteLine(" Cual es tu nombre?");
            Console.Write(" Nombre:");
            imc.nombrePersona = Console.ReadLine();
            Console.WriteLine();

            //Console.WriteLine(" {0}, Que edad tienes?",imc.nombrePersona.TrimStart());
            //Console.Write(" Edad:");
            //imc.edad = int.Parse(Console.ReadLine());
            //Console.WriteLine();

            //Console.WriteLine(" {0} años, muy bien {1}, cuanto mides?", imc.edad, imc.nombrePersona);
            Console.WriteLine(" {0}, Cuanto mides?", imc.nombrePersona.TrimStart());
            Console.Write(" Estatura(Pie):");
            imc.estaturaMetro = double.Parse(Console.ReadLine()) / 3.2808;

            Console.WriteLine();
            Console.WriteLine(" muy bien, cuanto pesas?");
            Console.Write(" Peso(lib):");
            imc.pesoKg = double.Parse(Console.ReadLine()) / 2.2046;

            Diagnostico(imc);
        }

        // HACER EL DIAGNOSTICO
        public static void Diagnostico(IMC_INFORMACION imc)
        {
            imc.codigo = Guid.NewGuid().ToString();

            imc.indiceMasa = imc.pesoKg / (imc.estaturaMetro * imc.estaturaMetro);
            Console.Clear();
            diagnosticar(imc);
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("1: Realizar otro diagnostico         2: Ver todos los diagnosticos       3: salir");
            string n = Console.ReadLine();
            if (n == "1")
            {
                listDiagnosticos.Add(imc);
                Run();
            }
            else if (n == "2")
            {
                listDiagnosticos.Add(imc);
                verTodosLosDiagnosticos();
                Console.ReadKey();
            }
            else if (n == "3")
            {
                Console.WriteLine("Hasta Luego....!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Opción no valida..");
                Console.ReadKey();
                Diagnostico(imc);
            }
        }

        // VER TODOS LOS DIAGNOSTICOS
        public static void verTodosLosDiagnosticos()
        {
            Console.Clear();
            if (listDiagnosticos.Count > 0)
            {
                List<IMC_INFORMACION> orden = new List<IMC_INFORMACION>();
                double temp = 0;
                string codigoDiagnostico = "";

                // ORDENAR DE MAYOR A MENOR
                for (int i = 0; i < listDiagnosticos.Count; i++)
                {
                    IMC_INFORMACION imc = listDiagnosticos[i];

                    // VERIFICAR SINO ESTA DIAGNOSTICO NO SE ENCUENTRA EN LA LISTA DE ORDEN
                    if (orden.Exists(or => or.codigo == imc.codigo))
                    {
                        // SI ES EL ULTIMO BUCLE DE LA LISTA, AGREGAR EL DIAGNOSTICO MAYOR ENCONTRADO
                        if(i==(listDiagnosticos.Count-1))
                        {
                            var cp1 = listDiagnosticos.Find(diag => diag.codigo == codigoDiagnostico);

                            if (cp1 == null)
                            {
                                Console.WriteLine("Error:diag:{0} i:{1} temp:{2}", codigoDiagnostico, i, temp);
                                continue;
                            }

                            IMC_INFORMACION I = new IMC_INFORMACION()
                            {
                                codigo = cp1.codigo,
                                nombrePersona = cp1.nombrePersona,
                                pesoKg = cp1.pesoKg,
                                estaturaMetro = cp1.estaturaMetro,
                                indiceMasa = cp1.indiceMasa,
                                diagnostico = cp1.diagnostico,
                            };
                            orden.Add(I);
                            // SI LA LISTA DE ORDEN ES MENOR A LA DE DIAGNOSTICO, REINICIAR EL BUCLE
                            if(orden.Count < listDiagnosticos.Count)
                            {
                                temp = 0;
                                codigoDiagnostico = "";
                                i = -1;
                            }
                        }
                        continue;
                    }
                    // DETERMINAR CUAL ES EL VALOR MAYOR EN LA LISTA
                    if (imc.indiceMasa > temp)
                    {
                        temp = imc.indiceMasa;
                        codigoDiagnostico = imc.codigo;
                    }

                    // REINICIAR BUCLE Y GUARDAR EL VALOR MAYOR
                    if (i == (listDiagnosticos.Count - 1) && orden.Count < listDiagnosticos.Count)
                    {
                        
                        var cop = listDiagnosticos.Find(diag => diag.codigo == codigoDiagnostico);
                        IMC_INFORMACION I = new IMC_INFORMACION()
                        {
                            codigo = cop.codigo,
                            nombrePersona = cop.nombrePersona,
                            pesoKg = cop.pesoKg,
                            estaturaMetro = cop.estaturaMetro,
                            indiceMasa = cop.indiceMasa,
                            diagnostico = cop.diagnostico,
                        };
                        orden.Add(I);

                        temp = 0;
                        codigoDiagnostico = "";
                        i = -1;
                    }
                }

                // MOSTRAR LA LISTA
                for (int i = 0; i < orden.Count; i++)
                {
                    diagnosticar(orden[i]);
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine("1: Realizar otro diagnostico      2: salir");
                string n = Console.ReadLine();
                if (n == "1")
                {
                    Run();
                }
                else if (n == "2")
                {
                    Console.WriteLine("Hasta Luego....!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Opción no valida..");
                    Console.ReadKey();
                    verTodosLosDiagnosticos();
                }
            }
        }


        // MOSTRAR EL DIAGNOSTICO
        public static void diagnosticar(IMC_INFORMACION imc)
        {
            if (imc.indiceMasa < 18)
            {
                imc.diagnostico = "Peso bajo, posible signo de desnutricion";
            }
            else if (imc.indiceMasa >= 18 && imc.indiceMasa <= 24.9)
            {
                imc.diagnostico = "Peso normal";
            }
            else if (imc.indiceMasa >= 25 && imc.indiceMasa <= 26.9)
            {
                imc.diagnostico = "Sobrepeso";
            }
            else if (imc.indiceMasa >= 27 && imc.indiceMasa <= 29.9)
            {
                imc.diagnostico = "Obesidad grado 1, Riesgo relativo alto para desarrollar enfermedades cardiovasculares";
            }
            else if (imc.indiceMasa >= 30 && imc.indiceMasa <= 39.9)
            {
                imc.diagnostico = "Obesidad grado 2, Riesgo relativo muy alto para desarrollar enfermedades cardiovasculares";
            }
            else
            {
                imc.diagnostico = "Obesidad grado 3 Extrema o Mórbida, Riesgo relativo extremedamente alto para desarrollar enfermedades cardiovasculares";
            }

            Console.WriteLine("------------------------------------ DIAGNOSTICO IMC -----------------------------------------");
            Console.WriteLine();
            Console.WriteLine(string.Format("Señor/ra:    {0}", imc.nombrePersona));
            Console.WriteLine(string.Format("Estatura:    {0} pie ", Math.Round((imc.estaturaMetro * 3.2808), 2)));
            Console.WriteLine(string.Format("Peso:        {0} Lb ", Math.Round((imc.pesoKg * 2.2046), 2)));
            Console.WriteLine(string.Format("IMC:         {0}", Math.Round(imc.indiceMasa,2)));
            string diag = string.Format("Diagnostico: {0} ", imc.diagnostico);
            if (diag.Length > 94)
                diag = diag.Insert(93, "\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(diag);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("--------------------- MEDIDOR INDICE DE MASA CORPORAR --------------------------");
            Opciones();
            Console.ReadKey();
        }

        public class IMC_INFORMACION
        {
            public string codigo;
            public double pesoKg;
            public string nombrePersona;
            public string diagnostico;
            public double indiceMasa;
            public double estaturaMetro;
        }
    }
}
