using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabemusPapaModeloPrimerParical
{
    class Conclave
    {
        private int _cantMaxCardenales;
        private List<Cardenal> _cardenales;
        private bool _habemusPapa;
        private string _lugarEleccion;
        private Cardenal _papa;
        public static int cantidadVotaciones;
        public static DateTime fechaVotacion;

        

        static Conclave()
        { 
            cantidadVotaciones = 0;
            fechaVotacion = DateTime.Now;
        }

        public Conclave()
        { 
            this._cantMaxCardenales = 1;
            this._lugarEleccion = "Capilla Sixtina";
            this._cardenales = new List<Cardenal>();

        }

        private  Conclave(int cantidadCardenales):this()
        {
            this._cantMaxCardenales = cantidadCardenales;                        
        }

        public Conclave(int cantidadCardenales, string lugarEleccion):this()
        {
            
            
        }

        private static void ContarVotos(Conclave conclave)
        {
            int indice = 0;
            foreach (Cardenal item in conclave._cardenales)
            {
                
                if(item.getCantidadDeVotosRecibidos() >= conclave._cardenales[indice].getCantidadDeVotosRecibidos())
                {
                    indice = conclave._cardenales.IndexOf(item);
                }

            }

            conclave._habemusPapa = true;
            conclave._papa = conclave._cardenales[indice];
        }

        public static explicit operator bool(Conclave con)
        {
            bool hayPapa = false;
            if (con._habemusPapa == true)
            {
                hayPapa = true;
            }

            return hayPapa;
        }

        private bool HayLugar()
        {
            bool respuesta = false;
            if (this._cantMaxCardenales > this._cardenales.Count)
            {
                respuesta = true;
            }
             return respuesta;

        }

        public static implicit operator Conclave(int cantidadCardenales)
        {

                  return new Conclave(cantidadCardenales);

        }

        public string Mostrar()
        {
            string respuesta = "";

            if (this._habemusPapa == true)
            {
                respuesta = string.Concat("\nLugar de votacion : " + this._lugarEleccion + "\nFecha de Votacion: " + fechaVotacion + "\nCantidad de votos: " + cantidadVotaciones + "\nHABEMUS PAPA!!!\n" + this._papa.ObtenerNombreYNombrePapal());
            }
            else
            {

                respuesta = string.Concat("\nLugar de votacion : " + this._lugarEleccion + "\nFecha de Votacion: " + fechaVotacion + "\nCantidad de votos: " + cantidadVotaciones + "\nNO HABEMUS PAPA!!!\n" + MostrarCardenales());
                                
            }

            return respuesta;
            
        }

        private string MostrarCardenales()
        {
            string respuesta = "";

            foreach(Cardenal item in _cardenales)
            {
                respuesta+=Cardenal.Mostrar(item);
                
            }

            return respuesta;
            
        }

        public static bool operator !=(Conclave con,Cardenal c)
        {
            return !(con == c);
        }

        public static Conclave operator +(Conclave con, Cardenal c)
        {
               if(con.HayLugar() == true)
               {
                   if (!con._cardenales.Where(cc => cc == c).Any())
                   {
                       con._cardenales.Add(c);
                   }

                 //  if (con.HayLugar() && !con._cardenales.Where(cc => cc == c).Any()) con._cardenales.Add(c);

           /*        foreach (Cardenal item in con._cardenales)
                   {
                       
                       if(item != c)
                       {
                           con._cardenales.Add(c);
                       }
                       
                   }*/
               }
               return con;
        }

        public static bool operator ==(Conclave con, Cardenal c)
        {
            bool rta = false;

            foreach (Cardenal item in con._cardenales)
            {
                if(c == item)
                {
                    rta = true;
                }
            }

            return rta;
        }

        public static void VotarPapa(Conclave conclave)
        {
            Random random = new Random();

            int indicePapal = random.Next(0, conclave._cardenales.Count - 1);

            conclave._cardenales[indicePapal]++;
            ContarVotos(conclave);
        }



    }
}
