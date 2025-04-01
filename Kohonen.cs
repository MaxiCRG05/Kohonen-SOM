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

			for(int c = 0; c < capas.Count; c++)
				conectarNeuronas(c, capas[c].tipo);

			for (int i = 0; i < capas.Count; i++)
				capas[i].iniciarPesos();
		}

		public void conectarNeuronas(int c, Capa.TipoCapa tipo)
		{
			if(tipo == Capa.TipoCapa.Entrada)
			{
				for(int i = 0; i < capas[c].neuronas.Count; i++)
					for(int j = 0; j < capas[c + 1].neuronas.Count; j++)
						capas[c].neuronas[i].agregarNeurona(capas[c + 1].neuronas[j], "Salida");
			}
			else
			{
				for (int i = 0; i < capas[c].neuronas.Count; i++)
					for (int j = 0; j < capas[c - 1].neuronas.Count; j++)
						capas[c].neuronas[i].agregarNeurona(capas[c - 1].neuronas[j], "Entrada");
			}
		}
	}
}
