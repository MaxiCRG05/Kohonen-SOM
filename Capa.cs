using System;
using System.Collections.Generic;

namespace SOM_Kohonen
{
    class Capa
	{
		public TipoCapa tipo;

		public List<Neurona> neuronas = new List<Neurona>();

		public int numNeuronasEntrada, numNeuronas;

		Random rand = new Random();

		public enum TipoCapa
		{
			Entrada,
			Competicion
		}

		public Capa(int numNeuronas, int numNeuronasEntrada, TipoCapa tipo)
		{
			this.tipo = tipo;
			this.numNeuronas = numNeuronas;
			this.numNeuronasEntrada = numNeuronasEntrada;

			crearNeuronas();
		}

		public void crearNeuronas()
		{
			for (int i = 0; i < numNeuronas; i++)
				neuronas.Add(new Neurona($"Neurona_{tipo}_{i + 1}"));
		}

		public void iniciarPesos()
		{
			if (tipo == TipoCapa.Entrada)
				iniciarPesosEntrada();
			else
				iniciarPesosCompeticion();
		}

		public void iniciarPesosEntrada()
		{
			for(int i = 0; i < neuronas.Count; i++)
				for(int j = 0; j < neuronas[i].neuronasCompeticion.Count; j++)
					neuronas[i].w.Add(rand.NextDouble());
		}

		public void iniciarPesosCompeticion()
		{
			for (int i = 0; i < neuronas.Count; i++)
				for (int j = 0; j < numNeuronasEntrada; j++)
					neuronas[i].w.Add(rand.NextDouble());
		}
	}
}