using System;
using System.Collections.Generic;

namespace SOM_Kohonen
{
    class Neurona
    {
		public string nombre;
		public double a;
        public List<double> w = new List<double>();
		public List<Neurona> neuronasEntrada = new List<Neurona>();
		public List<Neurona> neuronasCompeticion = new List<Neurona>();

		public Neurona(string nombre)
		{
			this.nombre = nombre;
		}

		public void agregarNeurona(Neurona neurona, string tipo)
		{
			if(tipo == "Entrada")
				neuronasEntrada.Add(neurona);
			else
				neuronasCompeticion.Add(neurona);
		}
	}
}