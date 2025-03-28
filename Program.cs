using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kohonen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> n = new List<int> { 5, 10 };
			Kohonen red_neuronal = new Kohonen(n);

            Thread.Sleep(100000);
		}
    }
}
