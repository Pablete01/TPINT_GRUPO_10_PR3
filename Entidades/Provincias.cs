using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincias
    {
        private int _IDProvincia;
        private string _nombreProvincia;

        public Provincias()
        {

        }

        public Provincias(int idProvincia, string nombreProvincia)
        {
            _IDProvincia = idProvincia;
            _nombreProvincia = nombreProvincia;
        }

        public int IDProvincia
        {
            get { return _IDProvincia; }
            set { _IDProvincia = value; }
        }
        public string NombreProvincia
        {
            get { return _nombreProvincia; }
            set { _nombreProvincia = value; }
        }
    }
}
