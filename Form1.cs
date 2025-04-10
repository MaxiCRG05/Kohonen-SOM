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

namespace SOM_Kohonen
{
    public partial class Form1: Form
	{
		static VariablesGlobales datos = new VariablesGlobales();
		Kohonen red_neuronal = new Kohonen(datos.n);
		Color color = new Color();

		public Form1()
        {
			DateTime inicio = DateTime.Now;

			red_neuronal.propagar(VariablesGlobales.PatronesRGB);	

			DateTime fin = DateTime.Now;

			var tiempoDeEjecucion = fin - inicio;

			Console.WriteLine("Tiempo de ejecución: " + tiempoDeEjecucion.TotalSeconds + " segundos.");

			InitializeComponent();
        }

		private void btnEntrenar_MouseClick(object sender, MouseEventArgs e)
		{
            red_neuronal.entrenar(VariablesGlobales.PatronesRGB);
			MessageBox.Show("Entrenamiento completado.");
			btnEntrenar.Enabled = false;
		}

		private void btnProbar_MouseClick(object sender, MouseEventArgs e)
		{
			List<double[]> seleccion = new List<double[]>
		    {
			   new double[] { color.R, color.G, color.B }
			};

			red_neuronal.propagar(seleccion);
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
	}
}
