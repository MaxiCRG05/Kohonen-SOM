using System.Collections.Generic;

namespace SOM_Kohonen
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
					capas.Add(new Capa(n[i], n[0], Capa.TipoCapa.Competicion));

			for(int c = 0; c < capas.Count; c++)
				conectarNeuronas(c, capas[c].tipo);

			for (int i = 0; i < capas.Count; i++)
				capas[i].iniciarPesos();
					}

		public void propagar()
		{
			for (int i = 0; i < capas.Count; i++)
				for (int j = 0; j < capas[i].neuronas.Count; j++)
					capas[i].neuronas[j].a = 0;
		}

		public void entrenar()
		{

		}

		public void conectarNeuronas(int c, Capa.TipoCapa tipo)
		{
			if(tipo == Capa.TipoCapa.Entrada)
				for(int i = 0; i < capas[c].neuronas.Count; i++)
					for(int j = 0; j < capas[c + 1].neuronas.Count; j++)
						capas[c].neuronas[i].agregarNeurona(capas[c + 1].neuronas[j], "Competicion");
			else
				for (int i = 0; i < capas[c].neuronas.Count; i++)
					for (int j = 0; j < capas[c - 1].neuronas.Count; j++)
						capas[c].neuronas[i].agregarNeurona(capas[c - 1].neuronas[j], "Entrada");
		}
	}
}