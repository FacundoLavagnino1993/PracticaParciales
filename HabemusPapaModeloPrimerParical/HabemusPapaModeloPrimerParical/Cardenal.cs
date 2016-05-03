using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabemusPapaModeloPrimerParical
{
    class Cardenal
    {
        private int _cantidadDeVotosRecibidos;
        private ENacionalidades _nacionalidad;
        private string _nombre;
        private string _nombrePapal;

        private Cardenal()
        {
            this._cantidadDeVotosRecibidos = 0;
        }

        public Cardenal(string nombre, string nombrePapal):this()
        {
            this._nombre = nombre;
            this._nombrePapal = nombrePapal;
        }

        public Cardenal(string nombre, string nombrePapal, ENacionalidades nacionalidad):this(nombre,nombrePapal)
        {
            this._nacionalidad = nacionalidad;

        }

        public int getCantidadDeVotosRecibidos()
        {
            return this._cantidadDeVotosRecibidos;
        }

        private string Mostrar()
        {
            string respuesta;
            respuesta = string.Concat(ObtenerNombreYNombrePapal() + " \nNacionalidad : " + this._nacionalidad + " \nCantidad de votos recibidos : " + this._cantidadDeVotosRecibidos);
            return respuesta;
        }

        public static string Mostrar(Cardenal c)
        {
            return c.Mostrar();
        }

        public string ObtenerNombreYNombrePapal()
        {
            string alias;
            alias = string.Concat("\nEl cardenal " + this._nombre + " se llamara " + this._nombrePapal);
            return alias;
        }

        public static bool operator !=(Cardenal c1, Cardenal c2)
        {
          return !(c1 == c2);
        }

        public static Cardenal operator ++(Cardenal c)
        {
            c._cantidadDeVotosRecibidos++;
            return c;
        }

        public static bool operator ==(Cardenal c1, Cardenal c2)
        {
            bool rta = false;
            if(c1._nombre == c2._nombre && c1._nombrePapal == c2._nombrePapal && c1._nacionalidad == c2._nacionalidad)
            { 
                rta = true;
            }
            return rta;
        }


    }

    enum ENacionalidades
    {
        Italiano, Polaco, Español, Argentino, Nigeriano
    }
}
