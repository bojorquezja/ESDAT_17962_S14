using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kruskal {
    internal class Arista {
        public int NodoOrig { get; set; }
        public int NodoDest { get; set; }
        public int Peso { get; set; }
        public bool EsArbolExpMin { get; set; }

        public Arista(int nodoOrig, int nodoDest, int peso) {
            NodoOrig = nodoOrig;
            NodoDest = nodoDest;
            Peso = peso;
            EsArbolExpMin = false;
        }

        public override string? ToString() {
            return $"{NodoOrig}-{NodoDest}:{Peso} ({EsArbolExpMin})";
        }
    }
}
