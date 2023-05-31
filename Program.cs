using System;
using System.Net.Cache;

namespace Listas_Genericas
{
    class ListaGenerica
    {
        class Nodo
        {
            public int info;
            public Nodo sig;
        }
        private Nodo raiz, fondo;

        public ListaGenerica()
        {
            raiz = null;            
        }
        void Insertar(int pos, int x)
        {
            if(pos<= Cantidad()+1)//Cantidad de numeros que tengo en mi lista 
            {
                Nodo nuevo= new Nodo();
                nuevo.info = x; //Nuevo info es lo que reciba en X

                if(pos==1)//Cuando es el primer elemento o sea estoy llenado la lista
                {
                    nuevo.sig = raiz;
                    raiz =  nuevo;
                }
                else
                    if(pos == Cantidad()+1) 
                {
                    Nodo reco = raiz;
                    while(reco.sig != null)//hasta llegar al final 
                    {
                        reco = reco.sig;
                    }
                    reco.sig = nuevo;//a nueva información 
                    nuevo.sig = null;
                }
                else
                {
                    Nodo reco = raiz;
                    for(int f = 1; f<=pos - 2; f++)//Menos 2 porque ya le sumamos una antes
                    {
                        reco = reco.sig;

                    }
                    Nodo siguiente = reco.sig;
                    reco.sig = nuevo;
                    nuevo.sig = siguiente;
                }

            }
        }
        public bool Existe(int x)
        {
            Nodo reco = raiz;
            while(reco!= null)
            {
                if(reco.info == x) 
                    return true;
                reco = reco.sig;
                
            }
            return false;
        }
        public int Cantidad()
        {
            int cant = 0;
            Nodo reco = raiz;
                while(reco != null )
            {
                reco = reco.sig;
                cant++;
            }
            return cant;
        }
        public void Imprimir()
        {
            Nodo reco = raiz;
            while(reco != null)//recorremos la lista hasta el final 
            {
                Console.Write(reco.info+"-");
                reco = reco.sig;
            }
            Console.WriteLine();
        }
        public int Extraer(int pos)
        {
            if (pos <= Cantidad())//preguntar si la posicion es valida
            {
                int informacion;//para guardar el valor que vamos a extraer

                if (pos == 1)//saber si es la raiz
                {
                    informacion = raiz.info;//guardamos temporalmente la raiz
                    raiz = raiz.sig; //la raiz es la siguiente
                }
                else
                {
                    Nodo reco;
                    reco = raiz;
                    for (int f = 1; f <= pos - 2; f++)
                    {
                        reco = reco.sig;
                    }
                    Nodo prox = reco.sig;
                    reco.sig = prox.sig;
                    informacion = prox.info;
                }
                return informacion;
            }
            else
                return int.MaxValue;
        }
        public void Intercambiar(int pos1, int pos2)
        {
            if(pos1 <=Cantidad() && pos1 <= Cantidad()) 
            {
                Nodo reco1 = raiz;
                for(int f = 1; f<pos1; f++)
                {
                    reco1= reco1.sig;//variable temporal
                }
                Nodo reco2 = raiz;
                for(int f=1; f<pos2; f++)
                {
                    reco2= reco2.sig;
                }
                int aux = reco1.info;
                reco1.info = reco2.info;
                reco2.info = aux;//intercambio de numeros
            }
        }
        static void Main(string[]args )
        {
            ListaGenerica objeto = new ListaGenerica();
            objeto.Insertar(1, 10);
            objeto.Insertar(2, 20);
            objeto.Insertar(3, 30);
            objeto.Insertar(2, 12);
            objeto.Imprimir();
            Console.WriteLine("Aplicando método Extraer");
            objeto.Extraer(2);
            objeto.Imprimir();
            Console.WriteLine("Aplicando método intercambiar");
            objeto.Intercambiar(1,3);
            objeto.Imprimir();
            Console.WriteLine("Aplicando el método existe");
            if (objeto.Existe(11))
                Console.WriteLine("El numero 11 se encuentra en la lista");
            else Console.WriteLine("No se encuentra el numero");
            Console.ReadKey();
        }
    }
   
}
