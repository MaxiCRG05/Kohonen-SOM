﻿using Perceptron_Multicapa_Colores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOM_Kohonen
{
    public class Program
    {
        /// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
        public static void Main()
        {
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
		}
	}
}