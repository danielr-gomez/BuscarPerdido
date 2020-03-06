using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscarPerdido
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            int[] A, B;

            Console.WriteLine("Algoritmo Numeros Perdidos...\n");
            Console.WriteLine("Ingrese el tamaño de la primera lista: \n");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("A continuacion complete los elementos de la lista 1 seguido de la tecla enter: ");
            A = LlenarLista(n);
            Console.WriteLine("Ingrese el tamaño de la segunda lista: \n");
            m = Convert.ToInt32(Console.ReadLine());
            while (n > m)
            {
                if (n > m)
                {
                    Console.WriteLine("Debe ingresar una tamaña superior a la primera lista: ");
                    m = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("A continuacion complete los elementos de la lista 2 seguido de la tecla enter: ");

            B = LlenarLista(m);
            List<int> resultado = new List<int>();
            resultado = BuscarPerdidos(A, B);
            Console.WriteLine("Los elementos perdidos son: ");
            foreach (var item in resultado)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        private static int[] LlenarLista(int tamano_lista)
        {
            int[] lista = new int[tamano_lista];
            for (int i = 0; i < tamano_lista; i++)
            {
                lista[i] = Convert.ToInt32(Console.ReadLine());
            }
            return lista;
        }

        private static List<int> BuscarPerdidos(int[] lista1, int[] lista2)
        {
            List<int> result = new List<int>();
            var frecuencia = new int[1000010];
            frecuencia[100] = 1;

            var pivote = lista2[0];
            for (var i = 1; i < lista2.Length; i++)
            {
                var diff = lista2[i] - pivote;
                frecuencia[100 + diff]++;
            }

            for (var i = 0; i < lista1.Length; i++)
            {
                var diff = lista1[i] - pivote;
                frecuencia[100 + diff]--;
            }

            for (var i = 0; i < frecuencia.Length; i++)
            {
                if (frecuencia[i] > 0)
                {
                    result.Add(pivote + (i - 100));
                }
                //Console.Write(string.Format("{0} ", pivot + (i - 100)));
            }

            return result;

        }
    }
}
