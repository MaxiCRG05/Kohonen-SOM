using Perceptron_Multicapa_Colores;
using System;
using System.Collections.Generic;

namespace SOM_Kohonen
{
    class Kohonen
	{

		public List<Capa> capas = new List<Capa>();

		public double alfa = VariablesGlobales.TasaAprendizaje;

		public Neurona neuronaGanadora;

		public Kohonen(List<int> n)
		{
			for (int i = 0; i < n.Count; i++)
			{
				if (i == 0)
					capas.Add(new Capa(n[i], 0, Capa.TipoCapa.F1));
				else if (i == n.Count - 1)
					capas.Add(new Capa(n[i], n[0], Capa.TipoCapa.F2));
			}

			for (int c = 0; c < capas.Count; c++)
				conectar_Neuronas(c, capas[c].tipo);

			for (int i = 0; i < capas.Count; i++)
				capas[i].iniciar_Pesos();
		}

		public void conectar_Neuronas(int c, Capa.TipoCapa tipo)
		{
			if (tipo == Capa.TipoCapa.F1)
				for (int i = 0; i < capas[c].neuronas.Count; i++)
					for (int j = 0; j < capas[c + 1].neuronas.Count; j++)
						capas[c].neuronas[i].agregar_Neurona(capas[c + 1].neuronas[j], "F2");
			else
			{
				for (int i = 0; i < capas[c].neuronas.Count; i++)
					for (int j = 0; j < capas[c - 1].neuronas.Count; j++)
						capas[c].neuronas[i].agregar_Neurona(capas[c - 1].neuronas[j], "F1");
			}
		}

		public void propagar_F1(double[] entradaRGB)
		{
			for (int i = 0; i < capas[0].neuronas.Count && i < entradaRGB.Length; i++)
			{
				capas[0].neuronas[i].a = entradaRGB[i];
			}
		}

		public void propagar_F2()
		{
			for (int j = 0; j < capas[1].neuronas.Count; j++)
			{
				double suma = 0;

				for (int i = 0; i < capas[0].neuronas.Count; i++)
				{
					double entrada = capas[0].neuronas[i].a;
					double peso = capas[1].neuronas[j].w[i];
					suma += Math.Pow(entrada - peso, 2);
				}
				capas[1].neuronas[j].a = Math.Sqrt(suma);
			}
		}

		public void encontrarCelulaGanadora()
		{
			propagar_F2();

			double menorDistancia = double.MaxValue;
			neuronaGanadora = null;

			for (int i = 0; i < capas[1].neuronas.Count; i++)
			{
				if (capas[1].neuronas[i].a < menorDistancia)
				{
					menorDistancia = capas[1].neuronas[i].a;
					neuronaGanadora = capas[1].neuronas[i];
				}
			}
		}

		public void actualizarPesos(double[] entradaRGB)
		{
			if (neuronaGanadora == null) return;

			for (int i = 0; i < neuronaGanadora.w.Count; i++)
			{
				neuronaGanadora.w[i] += alfa * (entradaRGB[i] - neuronaGanadora.w[i]);
			}
		}

		public void propagar(double[] entradaRGB)
		{
			propagar_F1(entradaRGB);
			encontrarCelulaGanadora();
			actualizarPesos(entradaRGB);
		}

		public void entrenar(int epocas)
		{
			List<double[]> patronesRGB = new List<double[]>();
			for (int i = 0; i < VariablesGlobales.PatronesRGB.Count; i += 3)
			{
				if (i + 2 < VariablesGlobales.PatronesRGB.Count)
				{
					patronesRGB.Add(new double[] {
						VariablesGlobales.PatronesRGB[i],
						VariablesGlobales.PatronesRGB[i+1],
						VariablesGlobales.PatronesRGB[i+2]
					});
				}
			}

			for (int e = 0; e < epocas; e++)
			{
				foreach (var patron in patronesRGB)
				{
					propagar(patron);
				}

				// Opcional: reducir tasa de aprendizaje
				alfa *= 0.99;
			}
		}
	}
}