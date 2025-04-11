using Perceptron_Multicapa_Colores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace SOM_Kohonen
{
	class Kohonen
	{
		public List<Capa> capas = new List<Capa>();

		public double alfa = VariablesGlobales.TasaAprendizaje, factor = VariablesGlobales.Factor, radioVecindad = 1;

		public int min = VariablesGlobales.Min, max = VariablesGlobales.Max, epocas = VariablesGlobales.Epocas, epocasAlcanzadas = 0;

		private double radioInicial, alfaInicial;

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

			radioInicial = Math.Max(capas[1].ancho, capas[1].alto) / 2.0;
			alfaInicial = alfa;
		}

		public Dictionary<string, double> ObtenerMetricas(List<double[]> conjuntoEntrenamiento)
		{
			return new Dictionary<string, double>
			{
				{"ErrorCuantizacion", CalcularErrorCuantizacion(conjuntoEntrenamiento)},
				{"ErrorTopografico", CalcularErrorTopografico(conjuntoEntrenamiento)},
				{"RadioVecindad", radioVecindad},
				{"TasaAprendizaje", alfa}
			};
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
				var neuronaActual = capas[c].neuronas[i];

				for (int j = 0; j < capas[c - 1].neuronas.Count; j++)
				{
					neuronaActual.agregarNeurona(capas[c - 1].neuronas[j], "F1");
				}

				int x = neuronaActual.X;
				int y = neuronaActual.Y;

				agregarVecinaSiExiste(capas[c], x, y - 1, neuronaActual);
				agregarVecinaSiExiste(capas[c], x, y + 1, neuronaActual);
				agregarVecinaSiExiste(capas[c], x - 1, y, neuronaActual);
				agregarVecinaSiExiste(capas[c], x + 1, y, neuronaActual);
			}
		}

		private void agregarVecinaSiExiste(Capa capa, int x, int y, Neurona neuronaActual)
		{
			var vecina = capa.ObtenerNeurona(x, y);
			if (vecina != null)
			{
				neuronaActual.agregarNeurona(vecina, "Vecina");
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
				for (int j = 0; j < entradas[i].Length; j++)
				{
					resultado[i][j] = (entradas[i][j] - min) / (max - min);
				}
			}
			return resultado;
		}

		public void actualizarPesos(List<double[]> entradaRGB, double radioVecindad, double tasaAprendizaje)
		{
			if (neuronaGanadora == null) return;

			double[] patron = entradaRGB[0];

			foreach (var neurona in capas[1].neuronas)
			{
				double distancia = calcularDistancia2D(neuronaGanadora, neurona);
				double influencia = CalcularInfluenciaVecindario(distancia, radioVecindad);

				for (int j = 0; j < neurona.w.Count && j < patron.Length; j++)
				{
					neurona.w[j] += tasaAprendizaje * influencia * (patron[j] - neurona.w[j]);
				}
			}
		}

		public void VisualizarMapa()
		{
			if (capas[1].alto == 0) return;

			Console.WriteLine("Mapa Auto-Organizado:");
			for (int y = 0; y < capas[1].alto; y++)
			{
				for (int x = 0; x < capas[1].ancho; x++)
				{
					var neurona = capas[1].ObtenerNeurona(x, y);
					Console.Write($"[{neurona.w[0].ToString("e3"):F2},\t{neurona.w[1].ToString("e2"):F2},\t{neurona.w[2].ToString("e2"):F2}]\t");
				}
				Console.WriteLine();
			}
		}

		private double CalcularInfluenciaVecindario(double distancia, double radio)
		{
			return distancia <= radio ? Math.Exp(-(distancia * distancia) / (2 * radio * radio)) : 0;
		}

		private double calcularDistancia2D(Neurona a, Neurona b)
		{
			int dx = a.X - b.X;
			int dy = a.Y - b.Y;
			return Math.Sqrt(dx * dx + dy * dy);
		}

		public void propagar(List<double[]> entradaRGB)
		{
			entradaRGB = normalizarDatos(entradaRGB);
			propagarF1(entradaRGB);
			encontrarCelulaGanadora();
			actualizarPesos(entradaRGB, radioVecindad, alfa);
		}

		private double CalcularRadioVecindad(int epoca)
		{
			double radioFinal = 0.5;
			return radioInicial * Math.Pow(radioFinal / radioInicial, epoca / (double)epocas);
		}

		private double CalcularTasaAprendizaje(int epoca)
		{
			double alfaFinal = 0.01;
			return alfaInicial * Math.Pow(alfaFinal / alfaInicial, epoca / (double)epocas);
		}

		public double CalcularErrorCuantizacion(List<double[]> conjuntoEntrenamiento)
		{
			double errorTotal = 0;

			foreach (var patron in conjuntoEntrenamiento)
			{
				propagar(new List<double[]> { patron });
				errorTotal += neuronaGanadora.a;
			}

			return errorTotal / conjuntoEntrenamiento.Count;
		}

		public double CalcularErrorTopografico(List<double[]> conjuntoEntrenamiento)
		{
			int errores = 0;

			foreach (var patron in conjuntoEntrenamiento)
			{
				propagar(new List<double[]> { patron });
				var segundaMejor = EncontrarSegundaMejorNeurona();

				if (calcularDistancia2D(neuronaGanadora, segundaMejor) > 1.0)
					errores++;
			}

			return (double)errores / conjuntoEntrenamiento.Count;
		}

		private Neurona EncontrarSegundaMejorNeurona()
		{
			double mejorDistancia = double.MaxValue;
			double segundaMejorDistancia = double.MaxValue;
			Neurona segundaMejor = null;

			foreach (var neurona in capas[1].neuronas)
			{
				if (neurona != neuronaGanadora && neurona.a < segundaMejorDistancia)
				{
					segundaMejorDistancia = neurona.a;
					segundaMejor = neurona;
				}
			}

			return segundaMejor;
		}

		public void entrenar(List<double[]> entradaRGB)
		{
			for (int epoca = 0; epoca < epocas; epoca++)
			{
				double radioActual = CalcularRadioVecindad(epoca);
				double tasaAprendizajeActual = CalcularTasaAprendizaje(epoca);

				foreach (var patron in entradaRGB)
				{
					List<double[]> patronList = new List<double[]> { patron };
					propagar(patronList);
					actualizarPesos(patronList, radioActual, tasaAprendizajeActual);
				}

				epocasAlcanzadas++;
			}
		}
	}
}