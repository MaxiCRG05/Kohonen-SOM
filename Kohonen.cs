using System.Collections.Generic;

namespace Kohonen
{
    class Kohonen
    {

		public List<Capa> capas = new List<Capa>();

		public Kohonen(List<int> n)
		{
			for(int i = 0; i < n.Count ; i++)
				if (i == 0)
					capas.Add(new Capa(n[i], 0, Capa.TipoCapa.Entrada));
				else if (i == n.Count - 1)
					capas.Add(new Capa(n[i], n[0], Capa.TipoCapa.Salida));

			conectarEntradas();

			for (int i = 0; i < capas.Count; i++)
				capas[i].iniciarPesos();
		}

		public void conectarEntradas()
		{
			for(int i = 0; i < capas[0].neuronas.Count; i++)
			{
				for(int j = 0; j < capas[1].neuronas.Count; j++)
					capas[1].neuronas[j].agregarNeurona(capas[0].neuronas[i]);
			}
		}
	}
}
