using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsProveedores
{

    private int PCodigo;
    private String PNomEmpresa;
    private String PTelEmpresa;
    private String PEmailEmpresa;
    private String PNomContacto;
    private String PApContacto;
    private String PObservaciones;
    //private bool _accion;

    public int Codigo
    {
        get
        {
            return PCodigo;
        }
        set
        {
            PCodigo = value;
        }
    }

    public String NombreEmpresa
    {
        get
        {
            return PNomEmpresa;
        }
        set
        {
            PNomEmpresa = value;
        }
    }

    public String TelefonoEmpresa
    {
        get
        {
            return PTelEmpresa;
        }
        set
        {
            PTelEmpresa = value;
        }
    }

    public String EmailEmpresa
    {
        get
        {
            return PEmailEmpresa;
        }
        set
        {
            PEmailEmpresa = value;
        }
    }

    public String NombreContacto
    {
        get
        {
            return PNomContacto;
        }
        set
        {
            PNomContacto = value;
        }
    }

    public String ApellidoContacto
    {
        get
        {
            return PApContacto;
        }
        set
        {
            PApContacto = value;
        }
    }

    public String Observaciones
    {
        get
        {
            return PObservaciones;
        }
        set
        {
            PObservaciones = value;
        }
    }

    /*public bool accion
    {
        get
        {
            return _accion;
        }
        set
        {
            _accion = value;
        }
    }*/

    public clsProveedores()
	{
	}
}
