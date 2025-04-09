using System;
using System.Collections.Generic;

namespace SOM_Kohonen
{
    class Capa
	{
		public TipoCapa tipo;

		public List<Neurona> neuronas = new List<Neurona>();

		public int numneuronasF1, numNeuronas;

		Random rand = new Random();

		public enum TipoCapa
		{
			F1,
			F2
		}

		public Capa(int numNeuronas, int numneuronasF1, TipoCapa tipo)
		{
			this.tipo = tipo;
			this.numNeuronas = numNeuronas;
			this.numneuronasF1 = numneuronasF1;

			crear_Neuronas();
		}

		public void crear_Neuronas()
		{
			for (int i = 0; i < numNeuronas; i++)
				neuronas.Add(new Neurona($"Neurona_{tipo}_{i + 1}"));
		}

		public void iniciar_Pesos()
		{
			if (tipo == TipoCapa.F1)
				iniciar_Pesos_F1();
			else
				iniciar_Pesos_F2();
		}

		public void iniciar_Pesos_F1()
		{
			for(int i = 0; i < neuronas.Count; i++)
				for(int j = 0; j < neuronas[i].neuronasF2.Count; j++)
					neuronas[i].w.Add(rand.NextDouble());
		}

		public void iniciar_Pesos_F2()
		{
			for (int i = 0; i < neuronas.Count; i++)
				for (int j = 0; j < numneuronasF1; j++)
					neuronas[i].w.Add(rand.NextDouble());
		}
	}
}