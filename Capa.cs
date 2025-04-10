using System;
using System.Collections.Generic;

namespace SOM_Kohonen
{
    class Capa
	{
		public TipoCapa tipo;
		public List<Neurona> neuronas = new List<Neurona>();
		public int numneuronasF1, numNeuronas;
		public int alto, ancho;
		Random rand = new Random();

		public enum TipoCapa
		{
			F1,
			F2
		}

		public Capa(int ancho, int alto, int numneuronasF1, TipoCapa tipo)
		{
			this.tipo = tipo;
			this.ancho = ancho;
			this.alto = alto;
			this.numNeuronas = (alto != 0) ? ancho * alto : ancho;
			this.numneuronasF1 = numneuronasF1;

			crearNeuronas();
		}

		public void crearNeuronas()
		{
			if (tipo == TipoCapa.F1)
			{
				for(int i = 0; i < numNeuronas; i++)
					neuronas.Add(new Neurona($"Neurona_{tipo}_{i}", i + 1, 0, 0));
			}
			else
			{
				for (int y = 0; y < alto; y++)
					for (int x = 0; x < ancho; x++)
						neuronas.Add(new Neurona($"Neurona_{tipo}_{x}_{y}", (y * ancho) + x + 1, x, y));
			}
		}

		public Neurona ObtenerNeurona(int x, int y)
		{
			if (x < 0 || x >= ancho || y < 0 || y >= alto)
				return null;

			return neuronas[y * ancho + x];
		}

		public void iniciarPesos()
		{
			if (tipo == TipoCapa.F1)
				iniciarPesosF1();
			else
				iniciarPesosF2();
		}

		public void iniciarPesosF1()
		{
			for(int i = 0; i < neuronas.Count; i++)
				for(int j = 0; j < neuronas[i].neuronasF2.Count; j++)
					neuronas[i].w.Add(rand.NextDouble());
		}

		public void iniciarPesosF2()
		{
			for (int i = 0; i < neuronas.Count; i++)
				for (int j = 0; j < numneuronasF1; j++)
					neuronas[i].w.Add(rand.NextDouble());
		}
	}
}