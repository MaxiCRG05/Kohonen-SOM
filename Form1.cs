using Perceptron_Multicapa_Colores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SOM_Kohonen
{
	public partial class Form1 : Form
	{
		static VariablesGlobales datos = new VariablesGlobales();
		Kohonen red_neuronal = new Kohonen(datos.n);
		Color color = new Color();

		public Form1()
		{
			InitializeComponent();

			VisualizarUMatrix();
			ActualizarVisualizacion();
		}

		public void ActualizarVisualizacion()
		{
			if (red_neuronal.capas[1].alto == 0) return;

			chSOM.Series.Clear();
			chSOM.ChartAreas.Clear();

			ChartArea chartArea = new ChartArea();
			chartArea.AxisX.Minimum = 0;
			chartArea.AxisX.Maximum = red_neuronal.capas[1].ancho;
			chartArea.AxisY.Minimum = 0;
			chartArea.AxisY.Maximum = red_neuronal.capas[1].alto;
			chartArea.AxisX.Interval = 1;
			chartArea.AxisY.Interval = 1;
			chSOM.ChartAreas.Add(chartArea);

			Series neuronSeries = new Series("Neuronas");
			neuronSeries.ChartType = SeriesChartType.Point;
			neuronSeries.MarkerSize = 15;
			neuronSeries.MarkerStyle = MarkerStyle.Circle;
			neuronSeries.Color = Color.Black;

			for (int y = 0; y < red_neuronal.capas[1].alto; y++)
			{
				for (int x = 0; x < red_neuronal.capas[1].ancho; x++)
				{
					var neurona = red_neuronal.capas[1].neuronas[x];
					Color neuronColor = Color.FromArgb(
						(int)(neurona.w[0] / 255),
						(int)(neurona.w[1] / 255),
						(int)(neurona.w[2] / 255));

					DataPoint point = new DataPoint(x, y);
					point.Color = neuronColor;
					point.Label = $"{x},{y}";
					neuronSeries.Points.Add(point);
				}
			}

			chSOM.Series.Add(neuronSeries);
		}

		public void VisualizarUMatrix()
		{
			chartPesos.Series.Clear();
			chartPesos.ChartAreas.Clear();
			ChartArea area = new ChartArea("UMatrix");
			chartPesos.ChartAreas.Add(area);

			Series series = new Series("Distancias")
			{
				ChartType = SeriesChartType.Point,
				MarkerSize = 15
			};

			for (int y = 0; y < red_neuronal.capas[1].alto; y++)
			{
				for (int x = 0; x < red_neuronal.capas[1].ancho; x++)
				{
					double distancia = red_neuronal.CalcularDistanciaPromedio(x, y);

					DataPoint point = new DataPoint(x, y);
					point.Color = GetColorForDistance(distancia);
					point.Label = $"{distancia:F2}";
					series.Points.Add(point);
				}
			}

			chartPesos.Series.Add(series);
		}

		private Color GetColorForDistance(double distancia)
		{
			int valor = (int)(Math.Min(distancia * 255, 255));
			return Color.FromArgb(valor, valor, valor);
		}

		private void ProbarColor()
		{
			List<double[]> seleccion = new List<double[]>
			{
				new double[] { color.R, color.G, color.B }
			};

			red_neuronal.propagar(seleccion);

			if (red_neuronal.neuronaGanadora != null)
			{
				string info = $"Color probado: R={color.R}, G={color.G}, B={color.B}\n";
				info += $"Neurona ganadora en posición: ({red_neuronal.neuronaGanadora.X}, {red_neuronal.neuronaGanadora.Y})\n";
				info += $"Pesos: [{(red_neuronal.neuronaGanadora.w[0] * 255):F0}, {(red_neuronal.neuronaGanadora.w[1] * 255):F0}, {(red_neuronal.neuronaGanadora.w[2] * 255):F0}]";

				lblInfo.Text = info;

				ActualizarVisualizacion();
				VisualizarUMatrix();
				ResaltarNeuronaGanadora();
			}
		}

		private void ResaltarNeuronaGanadora()
		{
			if (red_neuronal.neuronaGanadora == null) return;

			Series winnerSeries = new Series("Ganadora");
			winnerSeries.ChartType = SeriesChartType.Point;
			winnerSeries.MarkerSize = 20;
			winnerSeries.MarkerStyle = MarkerStyle.Circle;
			winnerSeries.MarkerBorderColor = Color.Black;
			winnerSeries.MarkerBorderWidth = 3;
			winnerSeries.Color = Color.Transparent; 

			DataPoint winnerPoint = new DataPoint(
				red_neuronal.neuronaGanadora.X,
				red_neuronal.neuronaGanadora.Y);
			winnerPoint.Label = $"GANADORA";
			winnerSeries.Points.Add(winnerPoint);

			chSOM.Series.Add(winnerSeries);
		}

		private void btnProbar_MouseClick(object sender, MouseEventArgs e)
		{
			List<double[]> seleccion = new List<double[]>
			{
			   new double[] { color.R, color.G, color.B }
			};
			ProbarColor();
		}

		private void imagen_MouseClick(object sender, MouseEventArgs e)
		{
			if (imagen.Image != null)
			{
				Bitmap bitmap = (Bitmap)imagen.Image;
				int x = e.X * bitmap.Width / imagen.ClientSize.Width;
				int y = e.Y * bitmap.Height / imagen.ClientSize.Height;
				color = bitmap.GetPixel(x, y);
				Console.WriteLine($"Color seleccionado: R={color.R}, G={color.G}, B={color.B}");
			}
			else
			{
				MessageBox.Show("No hay imagen cargada en el PictureBox.");
			}
		}

		private void imagen_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			List<double[]> seleccion = new List<double[]>
			{
			   new double[] { color.R, color.G, color.B }
			};
			ProbarColor();
		}

		private void btnTrain_MouseClick(object sender, MouseEventArgs e)
		{
			DateTime inicio = DateTime.Now;
			red_neuronal.entrenar(VariablesGlobales.PatronesRGB);
			DateTime fin = DateTime.Now;
			Console.WriteLine($"Entrenamiento completado en {(fin - inicio).TotalSeconds:F2} segundos");
			ActualizarVisualizacion();
			VisualizarUMatrix();
		}
	}
}
