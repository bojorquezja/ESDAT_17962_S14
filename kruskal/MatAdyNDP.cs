using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace kruskal {
    internal class MatAdyNDP {
        private int[,] matady;
        public int Nodos { get; }
        public MatAdyNDP(int nodos) {
            Nodos = nodos;
            matady = new int[nodos, nodos];
        }
        public void Mostrar() {
            for (int f = 0; f < matady.GetLength(0); f++) {
                for (int c = 0; c < matady.GetLength(1); c++) {
                    Console.Write(matady[f, c] + ", ");
                }
                Console.WriteLine();
            }
        }

        public void AgregaArista(int origen, int destino, int peso) {
            matady[origen, destino] = peso;
            matady[destino, origen] = peso;
        }

        
        public void Kruskal() {
            //grupos de 1
            int[] grupos = new int[Nodos];
            for (int x = 0; x < Nodos; x++) {
                grupos[x] = x;
            }
            //definir aristas
            Arista[] aristas = new Arista[0];
            for (int f = 0; f < matady.GetLength(0); f++) {
                for (int c = f; c < matady.GetLength(1); c++) {
                    if (matady[f, c] > 0) {
                        Array.Resize(ref aristas, aristas.Length+1);
                        aristas[aristas.Length-1] = new Arista(f,c, matady[f, c]);
                    }
                }
            }
            //ordenar aristas
            for (int x = 0; x < aristas.Length; x++) {
                for (int pos = 0; pos < aristas.Length - 1; pos++) {
                    if (aristas[pos].Peso > aristas[pos + 1].Peso) {
                        Arista temporal = aristas[pos];
                        aristas[pos] = aristas[pos + 1];
                        aristas[pos + 1] = temporal;
                    }
                }
            }

            //aplicar kruskal AEM
            for (int x = 0; x < aristas.Length; x++) {
                int grupOrig = grupos[aristas[x].NodoOrig];
                int grupDest = grupos[aristas[x].NodoDest];
                if (grupOrig != grupDest) {
                    for(int g = 0; g < grupos.Length; g++) {
                        if (grupos[g] == grupDest) {
                            grupos[g] = grupOrig;
                        }
                    }
                    aristas[x].EsArbolExpMin = true;
                }
            }

            //Mostrar aristas del Arbol de expansion minima
            foreach (Arista w in aristas) {
                Console.WriteLine(w);
            }
            
        }




        public void DFS(int origen) {
            bool[] visitados = new bool[Nodos];
            DFSUtil(origen, visitados);
        }
        private void DFSUtil(int origen, bool[] visitados) {
            visitados[origen] = true;
            Console.Write(origen + ",");
            for (int c = 0; c < matady.GetLength(1); c++) {
                if (matady[origen, c] > 0) {
                    if (!visitados[c]) {
                        DFSUtil(c, visitados);
                    }
                }
            }
        }

        //muestra nodos hasta que el peso acumulado alcance al valor de 
        //maxpeso
        public void DFSPesoMax(int origen, int maxpeso) {
            bool[] visitados = new bool[Nodos];
            int acum = 0;
            DFSDFSPesoMaxUtil(origen, visitados, maxpeso, ref acum);
        }
        private void DFSDFSPesoMaxUtil(int origen, bool[] visitados, int maxpeso,
            ref int acum) {
            visitados[origen] = true;

            Console.Write(origen + ",");
            for (int c = 0; c < matady.GetLength(1); c++) {
                if (matady[origen, c] > 0) {
                    if (!visitados[c]) {
                        acum = acum + matady[origen, c];
                        if (maxpeso >= acum) {
                            DFSDFSPesoMaxUtil(c, visitados, maxpeso, ref acum);
                        }
                    }
                }
            }

        }
        
    }
}
