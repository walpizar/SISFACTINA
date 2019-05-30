using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.FacturaElectronica.Excepciones
{
    public class GenerarXMLException: Exception
    {

        public GenerarXMLException() : base()
        {

        }
        public GenerarXMLException(Exception ex) :
           base(ex.Message)
        {

        }
    }
}
