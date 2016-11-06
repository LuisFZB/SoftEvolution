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
    private String PObservaciones;


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

    public String TelEmpresa
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

    public clsProveedores()
	{
	}
}
