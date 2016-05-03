using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcialBoligrafo
{
    class Boligrafo
    {
        private int _cantidadTinta;
        private string _color;
        private string _marca;

        static Boligrafo()
        { }
        public Boligrafo(string Color, string Marca)
        {
            this._color = Color;
            this._marca = Marca;
            this._cantidadTinta = 0;
        }

   
        

        public Boligrafo(string Color, string Marca, int CantidadTinta):this(Color, Marca)
        {
            this._cantidadTinta = CantidadTinta;
        }


        
        public void Escribir(int CantidadNecesaria)
        {
            if(this._cantidadTinta < CantidadNecesaria)
            {
                Console.WriteLine("Cantidad de tinta insuficiente para: ");
                this.Mostrar();
            }
        }

        private void Mostrar()
        {
            Console.WriteLine("\nMarca de boligrafo: " + this._marca + "\nColor de boligrafo" + this._color + "\nCantidad de tinta: " + this._cantidadTinta);
        }
        
        public static void MostrarBoligrafos(List<Boligrafo> ListaBoligrafos)
        {
            
            foreach (Boligrafo item in ListaBoligrafos)
            {
                item.Mostrar();
                
            }
        }


         
        public static bool operator !=(Boligrafo UnPen, Boligrafo OtroPen)
        {
            bool rta = false;
            if(!(UnPen==OtroPen))
            {
                rta = true;
            }
            return rta;
        }

        public static List<Boligrafo> operator -(List<Boligrafo> Lista, Boligrafo UnPen)
        {
            foreach (Boligrafo item in Lista)
            {
                if(item == UnPen)
                {
                    Lista.Remove(item);
                }
            }

            return new List<Boligrafo>();
        }

        public static List<Boligrafo> operator +(List<Boligrafo> Lista, Boligrafo UnPen)
        {   
            Lista.Add(UnPen);

            return new List<Boligrafo>();

        }
        public static bool operator ==(Boligrafo UnPen, Boligrafo OtroPen)
        {
            bool rta = false;
            if(UnPen._marca == OtroPen._marca && UnPen._color == OtroPen._color)
            {
                rta = true;
            }
            return rta;
        }

        public bool RecargarTinta()
        {
            bool rta = false;
            if(this._cantidadTinta < 50)
            {
                this._cantidadTinta = 100;
                rta = true;
            }

            return rta;
        }

        public bool RecargarTinta(int cantidad)
        {
            bool rta = false;
            if(this._cantidadTinta > 50)
            {
                this._cantidadTinta += cantidad;
                rta = true;
            }

            return rta;

        }

        
            



    }
}
