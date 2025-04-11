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

			DateTime inicio = DateTime.Now;
			red_neuronal.entrenar(VariablesGlobales.PatronesRGB);
			DateTime fin = DateTime.Now;

			lblInfo.Text = $"Inicializado en {(fin - inicio).TotalSeconds:F2} segundos";
			ActualizarVisualizacion();
		}

		public void ActualizarVisualizacion()
		{
			if (red_neuronal.capas[1].alto == 0) return;

			int ancho = mapaNeuronas.Width;
			int alto = mapaNeuronas.Height;
			Bitmap bitmap = new Bitmap(ancho, alto);

			int neuronasX = red_neuronal.capas[1].ancho;
			int neuronasY = red_neuronal.capas[1].alto;

			int celdaAncho = ancho / neuronasX;
			int celdaAlto = alto / neuronasY;

			for (int y = 0; y < neuronasY; y++)
			{
				for (int x = 0; x < neuronasX; x++)
				{
					for (int i = 0; i < celdaAncho; i++)
					{
						for (int j = 0; j < celdaAlto; j++)
						{
							int px = x * celdaAncho + i;
							int py = y * celdaAlto + j;
							if (px < ancho && py < alto)
								bitmap.SetPixel(px, py, color);
						}
					}
				}
			}

			mapaNeuronas.Image = bitmap;
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
				ResaltarNeuronaGanadora();
			}
		}

		private void ResaltarNeuronaGanadora()
		{
			if (mapaNeuronas.Image == null || red_neuronal.neuronaGanadora == null) return;

			Bitmap bitmap = (Bitmap)mapaNeuronas.Image;
			int neuronasX = red_neuronal.capas[1].ancho;
			int neuronasY = red_neuronal.capas[1].alto;
			int celdaAncho = bitmap.Width / neuronasX;
			int celdaAlto = bitmap.Height / neuronasY;

			int x = red_neuronal.neuronaGanadora.X;
			int y = red_neuronal.neuronaGanadora.Y;

			using (Graphics g = Graphics.FromImage(bitmap))
			{
				Pen pen = new Pen(Color.Black, 3);
				g.DrawRectangle(pen,
					x * celdaAncho,
					y * celdaAlto,
					celdaAncho,
					celdaAlto);
			}

			mapaNeuronas.Invalidate();
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
	}
}
