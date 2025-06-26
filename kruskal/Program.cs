using kruskal;

//int nodos = Convert.ToInt32(Console.ReadLine());
MatAdyNDP mat = new MatAdyNDP(9);
//string[] resp = { "0", "0", "0" };

mat.AgregaArista(0, 1, 4);
mat.AgregaArista(0, 7, 9);
mat.AgregaArista(1, 7, 11);
mat.AgregaArista(1, 2, 9);
mat.AgregaArista(7, 8, 7);
mat.AgregaArista(7, 6, 1);
mat.AgregaArista(2, 8, 2);
mat.AgregaArista(6, 8, 6);
mat.AgregaArista(5, 6, 2);
mat.AgregaArista(2, 3, 7);
mat.AgregaArista(2, 5, 4);
mat.AgregaArista(3, 5, 15);
mat.AgregaArista(3, 4, 10);
mat.AgregaArista(4, 5, 11);

mat.Kruskal();//lista de aristas