using System;
using System.Collections.Generic;

namespace SOM_Kohonen
{
    class Neurona
    {
		public int id;
		public string nombre;
		public double a, umbral, delta;
        public List<double> w = new List<double>();
		public List<Neurona> neuronasF1 = new List<Neurona>();
		public List<Neurona> neuronasF2 = new List<Neurona>();
		public List<Neurona> vecinas = new List<Neurona>();
		public int X;
		public int Y;
		readonly Random rand = new Random();

		public Neurona(string nombre, int id, int x = 0, int y = 0)
		{
			this.nombre = nombre;
			this.id = id;
			X = x;
			Y = y;
			umbral = rand.NextDouble();
		}

		public void agregarNeurona(Neurona neurona, string tipo)
		{
			if(tipo == "F1")
				neuronasF1.Add(neurona);
			else if (tipo == "F2")
				neuronasF2.Add(neurona);
			else
				vecinas.Add(neurona);
		}
	}
}