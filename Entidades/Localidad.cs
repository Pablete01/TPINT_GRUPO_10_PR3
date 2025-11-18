using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localidad
    {
        private int _ID_localidad;
        private string _nombreLocalidad;        
        private int _ID_provincia;

        public Localidad()
        {

        }

        public Localidad(int id_localidad, string nombreLocalidad, int id_provincia)
        {
            _ID_localidad = id_localidad;
            _nombreLocalidad = nombreLocalidad;            
            _ID_provincia = id_provincia;
        }       
        public int ID_localidad
        {
            get { return _ID_localidad; }
            set { _ID_localidad = value; }
        }
        public string NombreLocalidad
        {
            get { return _nombreLocalidad; }
            set { _nombreLocalidad = value; }
        }
        public int ID_provincia
        {
            get { return _ID_provincia; }
            set { _ID_provincia = value; }
        }


    }


}
