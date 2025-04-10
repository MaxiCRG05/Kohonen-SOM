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
			Carpeta = @"\Archivos\SOM\",
			Ruta = Path.Combine(Escritorio + Carpeta),
			FormatoArchivos = ".txt",
			Configuracion = "configuracion" + FormatoArchivos;

		public static double TasaAprendizaje, Factor;

		private Archivos  Datos = new Archivos(Ruta);

		public List<int> n = new List<int>();

		/// <summary>
		/// Epocas: Iteraciones que se harán para el aprendizaje.
		/// Min: Valor mínimo dentro del contexto de los datos.
		/// Max: Valor máximo dentro del contexto de los datos.
		/// </summary>
		public static int Epocas, NumPatrones, Min, Max;

		/// <summary>
		/// Arreglo bidimensional el cual obtendrá los datos de entrada
		/// </summary>
		public static List<double[]> PatronesRGB = new List<double[]>();

		/// <summary>
		/// Constructor para iniciar y comprobar si existe la carpeta "Archivos". Si no la encuentra la crea.
		/// </summary>
		public VariablesGlobales()
		{
			cargarDatos();

			try
			{
				if (!Directory.Exists(Ruta))
				{
					MessageBox.Show("Se ha creado el directorio.", "Archivos");
					Directory.CreateDirectory(Ruta);
				}
				else
				{
					Console.WriteLine("Ya existe el directorio.");
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

			List<string> lineas = Datos.LeerArchivo(Configuracion);

			for (int i = 0; i < lineas.Count; i++)
			{
				if (i < 3)
					n.Add(Convert.ToInt32(lineas[i]));
				else if (i == 3)
					TasaAprendizaje = Convert.ToDouble(lineas[i]);
				else if (i == 4)
					NumPatrones = Convert.ToInt32(lineas[i]);
				else if (i == 5)
					Epocas = Convert.ToInt32(lineas[i]);
				else if (i == 6)
					Min = Convert.ToInt32(lineas[i]);
				else if (i == 7)
					Max = Convert.ToInt32(lineas[i]);
				else if (i == 8)
					Factor = Convert.ToDouble(lineas[i]);
				else
					PatronesRGB.Add(lineas[i].Split('\t').Select(x => Convert.ToDouble(x)).ToArray());
			}
		}
	}
}
