using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace BadCalc_VeryBad
{
    /// <summary>
    /// Clase que contiene toda la lógica del proyecto
    /// </summary>
    public static class LogicApp
    {
        // Variable global que maneja el historial y los archivos
        private static EntityDataTxt globals = new EntityDataTxt();
        public static void init()
        {
            // Bucle principal de la aplicación
            bool execute = true;
            while (execute)
            {
                // Inicialización del archivo AUTO_PROMPT.txt
                try
                {
                    EntityDataTxt.InitialFile();
                }
                // Se añade código a realizar al capturar la excepción
                catch (Exception ex)
                {
                    Console.WriteLine("Error to create AUTO_PROMPT.txt:\n" + ex.Message);
                }
                // Menú de opciones
                Console.WriteLine("BAD CALC - worst practices edition");
                Console.WriteLine("1) add  2) sub  3) mul  4) div  5) pow  6) mod  7) sqrt  8) llm  9) hist 0) exit");
                Console.Write("opt: ");
                var option = Console.ReadLine();
                string valueA = "0", valueB = "0";
                // De acuerdo a las opciones, se solicitan los valores necesarios, se cambia Switch para mejor claridad
                // Y eliminar los goto
                switch (option)
                {
                    case "0":
                        break;
                    case "7":
                        // Extrae raiz cuadrada, solo necesita un número
                        Console.Write("a: ");
                        valueA = Console.ReadLine();
                        break;
                    // Para las opciones 8 y 9 no se necesitan valores, ya que son operaciones con los archivos
                    case "8":
                    case "9":
                        break;
                    // Para el resto de opciones, siempre requiere dos valores
                    default:
                        Console.Write("a: ");
                        valueA = Console.ReadLine();

                        Console.Write("b: ");
                        valueB = Console.ReadLine();
                        break;
                }
                double res = 0;
                switch (option)
                {
                    // Opción de suma
                    case "1":
                        res = Operations.AddTwoNumbers(valueA, valueB);
                        SaveHistoryAndShow(valueA, valueB, option, res);
                        break;
                    // Opción de resta
                    case "2":
                        res = Operations.SubtractTwoNumbers(valueA, valueB);
                        SaveHistoryAndShow(valueA, valueB, option, res);
                        break;
                    // Opción de multiplicación
                    case "3":
                        res = Operations.MultiplyTwoNumbers(valueA, valueB);
                        SaveHistoryAndShow(valueA, valueB, option, res);
                        break;
                    // Opción de división
                    case "4":
                        res = Operations.DivideTwoNumbers(valueA, valueB);
                        SaveHistoryAndShow(valueA, valueB, option, res);
                        break;
                    // Opción de potencia
                    case "5":
                        res = Operations.Pow(valueA, valueB);
                        SaveHistoryAndShow(valueA, valueB, option, res);
                        break;
                    // Opción de módulo
                    case "6":
                        res = Operations.Module(valueA, valueB);
                        SaveHistoryAndShow(valueA,valueB, option, res);
                        break;
                    // Opción de raíz cuadrada
                    case "7":
                        res = Operations.TrySqrt(valueA);
                        SaveHistoryAndShow(valueA, "0",option, res);
                        break;
                    // Opción de poner un template y un usuario para el archivo history.txt
                    // Anteriormente esta opción no realizaba nada con los inputs
                    case "8":
                        Console.WriteLine("Enter user template (will be concatenated SAFELY):");
                        var tpl = Console.ReadLine();
                        Console.WriteLine("Enter user input:");
                        var uin = Console.ReadLine();
                        EntityDataTxt.AddNewLineHistory(uin + " - " + tpl);
                        break;
                    // Opción de mostrar el historial de operaciones realizadas en la sesión actual
                    case "9":
                        globals.ShowHistory();
                        Thread.Sleep(100);
                        break;
                    // Opción de salir de la aplicación, guardado de la última operación en leftover.tmp
                    case "0":
                        try
                        {
                            globals.SaveLastUse();
                        }
                        // Se añade código a realizar al capturar la excepción
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error to save leftover.txt:\n" + ex.Message);
                        }
                        execute = false;
                        break;
                    // Se añade opción por defecto para manejar opciones inválidas
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }   
            }
        }
        /// <summary>
        /// Imprime en consola el resultado de la operación y guarda la línea en el historial
        /// Esto funciona igual que el comportamiento inicial
        /// </summary>
        /// <param name="valueA">Valor 1</param>
        /// <param name="valueB">Valor 2</param>
        /// <param name="option">Operación realizada</param>
        /// <param name="res">Respuesta obtenida</param>
        private static void SaveHistoryAndShow(string valueA, string valueB, string option, double res)
        {
            Console.WriteLine("= " + res.ToString(CultureInfo.InvariantCulture));
            globals.SaveHistoryLine(valueA, valueB, Operations.operationToString(option), res);
        }
    }
}
