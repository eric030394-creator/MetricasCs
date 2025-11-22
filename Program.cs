using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading;

using BadCalc_VeryBad;
namespace BadCalcVeryBad
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Se elimina todo el código de la función Main y se llama a la función init de LogicApp
            // Es mala práctias tener toda la lógica en el Main, por lo que se delega a otra clase
            LogicApp.init();
        }   
    }
}
