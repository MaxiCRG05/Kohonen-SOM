using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron_Multicapa_Colores
{
	/// <summary>
	/// Clase para manejar las variables globales las cuales se usarán a lo largo del sistema.
	/// </summary>
	public class VariablesGlobales
	{
		/// <summary>
		/// Escritorio: Ruta de cada entorno al escritorio.
		/// Carpeta: Nombre de la carpeta de archivos para guardar los archivos.
		/// Ruta: Combina la ruta del escritorio con la carpeta donde se guardarán los archivos.
		/// FormatoArchivos: Es el formato en el que se almacenaran los archivos.
		/// Configuracion: Nombre del archivo para guardar la configuración.
		/// Datos: Nombre del archivo en el que se almacenarán los datos.
		/// </summary>
		public static readonly string Escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
			Carpeta = @"\Archivos\SOM",
			Ruta = Path.Combine(Escritorio + Carpeta),
			FormatoArchivos = ".txt",
			Configuracion = "configuracion" + FormatoArchivos;

		public static double TasaAprendizaje = 0;

		private Archivos  Datos = new Archivos(Ruta);

		public static List<double> n = new List<double>();

		/// <summary>
		/// Epocas: Iteraciones que se harán para el aprendizaje.
		/// Min: Valor mínimo dentro del contexto de los datos.
		/// Max: Valor máximo dentro del contexto de los datos.
		/// </summary>
		public static int Epocas = 100000, Min = 0, Max = 255, NumPatrones;

		/// <summary>
		/// Arreglo bidimensional el cual obtendrá los datos de entrada
		/// </summary>
		public static List<double[]> PatronesRGB = new List<double[]>();

		/// <summary>
		/// Constructor para iniciar y comprobar si existe la carpeta "Archivos". Si no la encuentra la crea.
		/// </summary>
		public VariablesGlobales()
		{
			try
			{
				if (!Directory.Exists(Ruta))
				{
					MessageBox.Show("Se ha creado el directorio.", "Archivos");
					Directory.CreateDirectory(Ruta);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error al crear el directorio: {e.Message}");
			}
		}

		public void cargarDatos()
		{
			Datos.BuscarArchivo(Configuracion);

			n.Add(int.Parse(Datos.LeerLinea(Configuracion)));
			n.Add(int.Parse(Datos.LeerLinea(Configuracion)));
			TasaAprendizaje = double.Parse(Datos.LeerLinea(Configuracion));
			NumPatrones = int.Parse(Datos.LeerLinea(Configuracion));

			for (int i = 0; i < NumPatrones; i++)
			{
				string linea = Datos.LeerLinea(Configuracion);
				string[] valores = linea.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
				
				if (valores.Length == 3)
				{
					double[] rgb = new double[3] {
					double.Parse(valores[0]),
					double.Parse(valores[1]),
					double.Parse(valores[2])
				};
					PatronesRGB.Add(rgb);
				}
			}
		}
	}
}
