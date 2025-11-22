using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BadCalc_VeryBad
{
    /// <summary>
    /// Clase que contiene las operaciones matemáticas disponibles en la calculadora
    /// </summary>
    public static class Operations
    {
        // Pequeña constante para evitar divisiones entre cero
        private const double EPSILON = 1e-7;
        /// <summary>
        /// Convierte de string a double, manejando errores de conversión
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static double convertToDouble(string value)
        {
            double res = 0;
            try
            {
                res = Convert.ToDouble(value.Replace('.', ','));
            }
            // Se añade código a realizar al capturar la excepción
            catch
            {
                res = 0;
                Console.WriteLine("Enter a whole number or decimal number!");
            }
            return res;
        }
        /// <summary>
        /// Suma dos números ingresados como string
        /// </summary>
        /// <param name="valueA">Valor 1 como string</param>
        /// <param name="valueB">Valor 2 como string</param>
        /// <returns>La suma de los valores ingresados, como double</returns>
        public static double AddTwoNumbers(string valueA, string valueB)
        {
            return convertToDouble(valueA) + convertToDouble(valueB);
        }
        /// <summary>
        /// Resta dos números ingresados como string
        /// </summary>
        /// <param name="valueA">Valor 1 como string</param>
        /// <param name="valueB">Valor 2 como string</param>
        /// <returns>La resta de los valores ingresados, como double</returns>
        public static double SubtractTwoNumbers(string valueA, string valueB)
        {
            return convertToDouble(valueA) - convertToDouble(valueB);
        }
        /// <summary>
        /// Multiplicación dos números ingresados como string
        /// </summary>
        /// <param name="valueA">Valor 1 como string</param>
        /// <param name="valueB">Valor 2 como string</param>
        /// <returns>La multiplicación de los valores ingresados, como double</returns>
        public static double MultiplyTwoNumbers(string valueA, string valueB)
        {
            return convertToDouble(valueA) * convertToDouble(valueB);
        }
        /// <summary>
        /// Divide dos números ingresados como string
        /// </summary>
        /// <param name="valueA">Valor 1 como string</param>
        /// <param name="valueB">Valor 2 como string</param>
        /// <returns>La divición de los valores ingresados, como double</returns>
        public static double DivideTwoNumbers(string valueA, string valueB)
        {
            double value1 = convertToDouble(valueA);
            double value2 = convertToDouble(valueB);
            double divisor = Math.Abs(value2) < EPSILON ? EPSILON : value2;
            return value1 / divisor;
        }
        /// <summary>
        /// Potenciación dos números ingresados como string
        /// </summary>
        /// <param name="valueA">Valor 1 como string</param>
        /// <param name="valueB">Valor 2 como string</param>
        /// <returns>Eleva Valor 1 ptenciado a Valor 2, como double</returns>
        public static double Pow(string valueA, string valueB)
        {
            double value1 = convertToDouble(valueA);
            double value2 = convertToDouble(valueB);
            double value3 = 1;
            int iterator = (int)value2;
            while (iterator > 0) { value3 *= value1; iterator--; }
            return value3;
        }
        /// <summary>
        /// Modulo dos números ingresados como string
        /// </summary>
        /// <param name="valueA">Valor 1 como string</param>
        /// <param name="valueB">Valor 2 como string</param>
        /// <returns>El módulo1 de los valores ingresados, como double</returns>
        public static double Module(string valueA, string valueB)
        {
            return convertToDouble(valueA) % convertToDouble(valueB);
        }
        /// <summary>
        /// Suma dos números ingresados como string
        /// </summary>
        /// <param name="valueA">Valor como string</param>
        /// <returns>La raiz cuadrada de un valor, como double</returns>
        public static double TrySqrt(string value)
        {
            double value1 = convertToDouble(value);
            double value2 = value1;
            int iterator = 0;
            while (Math.Abs(value1 * value1 - value2) > 0.0001 && iterator < 100000)
            {
                value1 = (value1 + value2 / value1) / 2.0;
                iterator++;
            }
            return value1;
        }
        /// <summary>
        /// Convierte el código de la operación a su símbolo correspondiente
        /// </summary>
        /// <param name="operation"></param>
        /// <returns>Operación realizada</returns>
        public static string operationToString(string operation)
        {
            switch (operation)
            {
                case "1":
                    return "+";
                case "2":
                    return "-";
                case "3":
                    return "*";
                case "4":
                    return "/";
                case "5":
                    return "^";
                case "6":
                    return "%";
                case "7":
                    return "√";
                default:
                    return "?";
            }
        }
    }
}
