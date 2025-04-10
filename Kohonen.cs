using Perceptron_Multicapa_Colores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOM_Kohonen
{
    class Kohonen
	{

		public List<Capa> capas = new List<Capa>();

		public double alfa = VariablesGlobales.TasaAprendizaje, factor = VariablesGlobales.Factor;

		public int min = VariablesGlobales.Min, max = VariablesGlobales.Max, epocas = VariablesGlobales.Epocas;

		public Neurona neuronaGanadora;

		public Kohonen(List<int> n)
		{
			capas.Add(new Capa(n[0], 0, n[0], Capa.TipoCapa.F1));

			if (n.Count == 2)
			{
				capas.Add(new Capa(n[1], 0, n[0], Capa.TipoCapa.F2));
			}
			else if (n.Count == 3)
			{
				capas.Add(new Capa(n[1], n[2], n[0], Capa.TipoCapa.F2));
			}
			else
			{
				throw new ArgumentException("Formato no soportado. Use 2 parámetros para 1D [entrada, neuronas] o 3 para 2D [entrada, ancho, alto]");
			}

			for (int c = 0; c < capas.Count; c++)
				conectarNeuronas(c, capas[c].tipo);

			for (int i = 0; i < capas.Count; i++)
				capas[i].iniciarPesos();
		}

		public void conectarNeuronas(int c, Capa.TipoCapa tipo)
		{
			if (tipo == Capa.TipoCapa.F1)
				conexionF1(c);
			else
				conexionF2(c);
		}

		private void conexionF1(int c)
		{
			for (int i = 0; i < capas[c].neuronas.Count; i++)
				for (int j = 0; j < capas[c + 1].neuronas.Count; j++)
					capas[c].neuronas[i].agregarNeurona(capas[c + 1].neuronas[j], "F2");
		}

		private void conexionF2(int c)
		{
			for (int i = 0; i < capas[c].neuronas.Count; i++)
			{
				bool agregar = false;
				for (int j = 0; j < capas[c - 1].neuronas.Count; j++)
				{
					capas[c].neuronas[i].agregarNeurona(capas[c - 1].neuronas[j], "F1");

					if (!agregar)
					{
						if (i > 0 && i < capas[c].neuronas.Count - 1)
						{
							capas[c].neuronas[i].agregarNeurona(capas[c].neuronas[i - 1], "Vecina");
							capas[c].neuronas[i].agregarNeurona(capas[c].neuronas[i + 1], "Vecina");
							agregar = true;
						}
						else if (i == 0)
						{
							capas[c].neuronas[i].agregarNeurona(capas[c].neuronas[i + 1], "Vecina");
							agregar = true;
						}
						else
						{
							capas[c].neuronas[i].agregarNeurona(capas[c].neuronas[i - 1], "Vecina");
							agregar = true;
						}
					}
				}
			}
		}

		public void propagarF1(List<double[]> entradaRGB)
		{
			double[] patron = entradaRGB[0];

			for (int j = 0; j < patron.Length && j < capas[0].neuronas.Count; j++)
				capas[0].neuronas[j].a = patron[j];
		}

		public void propagarF2()
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
			propagarF2();

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

		public List<double[]> normalizarDatos(List<double[]> entradas)
		{
			List<double[]> resultado = new List<double[]>();
			for (int i = 0; i < entradas.Count; i++)
			{
				resultado.Add(new double[entradas[i].Length]);
				for(int j = 0; j < entradas[i].Length; j++)
				{
					resultado[i][j] = (entradas[i][j] - min) / (max - min);
				}
			}
			return resultado;
		}

		public void actualizarPesos(List<double[]> entradaRGB)
		{
			if (neuronaGanadora == null) return;

			double[] patron = entradaRGB[0];
			for (int j = 0; j < neuronaGanadora.w.Count && j < patron.Length; j++)
			{
				neuronaGanadora.w[j] += alfa * (patron[j] - neuronaGanadora.w[j]);
			}
		}

		public void propagar(List<double[]> entradaRGB)
		{
			entradaRGB = normalizarDatos(entradaRGB);
			propagarF1(entradaRGB);
			encontrarCelulaGanadora();
			actualizarPesos(entradaRGB);
		}

		public void entrenar(List<double[]> entradaRGB)
		{
			for (int epoca = 0; epoca < epocas; epoca++)
			{
				foreach (var patron in entradaRGB)
				{
					List<double[]> patronList = new List<double[]> { patron };
					propagar(patronList);

					alfa = alfa * factor;
				}
			}
		}
	}
}