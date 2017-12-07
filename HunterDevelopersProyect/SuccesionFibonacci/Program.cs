using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuccesionFibonacci
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string valor;
                string respuesta;

                Console.WriteLine("\t-===================================== Sucesión Fibonacci ==================================-");
                Console.WriteLine("\t-===========================================================================================-");
                Console.WriteLine("\n");

                do
                {

                    Console.WriteLine("\t\t\t\t\tIntroduzca el tamaño de la sucesión");
                    valor = Console.ReadLine();

                    if (validarEntrada(valor))
                        SucesionFibonacci(int.Parse(valor));
                    respuesta = "";

                    Console.WriteLine("\n\t\t\t\t\t Desea Realizar otra operación S/N");
                    respuesta = Console.ReadLine();

                }
                while (respuesta.Equals("S") || respuesta.Equals("s"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SucesionFibonacci(int length)
        {
            try
            {
                int[] sumatoria = new int[length + 1];

                for (int i = 0; i < length; i++)
                {
                    if (i == 0)
                    {
                        Console.Write("\t\t\t\t\t\t");
                        sumatoria[i] = 1;
                    }
                    else if (i == 1)
                        sumatoria[i] = 1;
                    else
                        sumatoria[i] = sumatoria[i - 2] + sumatoria[i - 1];

                    Console.Write(sumatoria[i] + " ");

                    if (i == length - 1)
                        Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool validarEntrada(string entrada)
        {
            bool result = true;
            try
            {
                if (string.IsNullOrEmpty(entrada))
                {

                    result = false;
                    Console.WriteLine("\t\t\t\t\tFavor ingresar un valor");
                }
                if (!IsNumeric(entrada))
                {
                    result = false;
                    Console.WriteLine("\t\t\t\t\tFavor ingresar un número válido");
                }
                if (IsNumeric(entrada))
                {
                    if (int.Parse(entrada) <= 1)
                    {
                        result = false;
                        Console.WriteLine("\t\t\t\t\tDebe Agragar un tamaño mayor que 1");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static bool IsNumeric(string texto)
        {
            bool Valido = false;
            try
            {
                Regex valores_numericos = new Regex(@"^[0-9]");
                Match m = valores_numericos.Match(texto);
                if (m.Success)
                    Valido = true;
                else
                    Valido = false;
            }
            catch { }
            return Valido;
        }
    }
}
