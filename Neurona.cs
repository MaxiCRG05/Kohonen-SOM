using System;
using System.Collections.Generic;

namespace Kohonen
{
    class Neurona
    {
		public string nombre;
        public int a;
        public List<double> w = new List<double>();
		public List<Neurona> neuronasEntrada = new List<Neurona>();

		public Neurona(string nombre)
		{
			this.nombre = nombre;
		}

		public void agregarNeurona(Neurona neurona)
		{
			neuronasEntrada.Add(neurona);
		}
	}
}
