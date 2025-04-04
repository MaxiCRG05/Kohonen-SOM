using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOM_Kohonen
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
			List<int> n = new List<int> { 5, 5 };
			DateTime inicio = DateTime.Now;

			Kohonen red_neuronal = new Kohonen(n);

			DateTime fin = DateTime.Now;
			var tiempoDeEjecucion = fin - inicio;

			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

			Console.WriteLine("Tiempo de ejecución: " + tiempoDeEjecucion.TotalSeconds + " segundos.");
		}
	}
}
