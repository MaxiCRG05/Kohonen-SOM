using System;
using System.Collections.Generic;

namespace SOM_Kohonen
{
    class Neurona
    {
		public string nombre;
		public double a, umbral, delta;
        public List<double> w = new List<double>();
		public List<Neurona> neuronasF1 = new List<Neurona>();
		public List<Neurona> neuronasF2 = new List<Neurona>();
		readonly Random rand = new Random();

		public Neurona(string nombre)
		{
			this.nombre = nombre;
			umbral = rand.NextDouble();
		}

		public void agregar_Neurona(Neurona neurona, string tipo)
		{
			if(tipo == "F1")
				neuronasF1.Add(neurona);
			else
				neuronasF2.Add(neurona);
		}
	}
}