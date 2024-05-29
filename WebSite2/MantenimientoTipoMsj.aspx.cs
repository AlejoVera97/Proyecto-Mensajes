using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;


public partial class MantenimientoTipoMsj : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            this.LimpioFormulario();
            this.DesactivoBotones();
        }
    }

    private void LimpioFormulario()
    {
        TxtCodTipo.Text = "";
        TxtNomTipo.Text = "";
    }

    private void DesactivoBotones()
    {
        BtnAlta.Enabled = false;
        BtnModificar.Enabled = false;
        BtnBaja.Enabled = false;

        BtnBuscar.Enabled = true;
    }


    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        string codTipo = "";
        try
        {
            TipoMsj unTipo = LogicaTipoMsj.Buscar(codTipo);
            if (unTipo != null)
            {
                TxtNomTipo.Text = unTipo.NombCod;

                Session["UnTipo"] = unTipo;

                BtnBaja.Enabled = true;
                BtnModificar.Enabled = true;
            }
            else
            {
                BtnAlta.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        string codTipo = TxtCodTipo.Text;
        string nombreTipo = TxtNomTipo.Text;

        TipoMsj unTipo = new TipoMsj(codTipo, nombreTipo);

        try
        {
            LogicaTipoMsj.AltaTipoMsj(unTipo);

            LblError.Text = "Alta con éxito.";
            this.LimpioFormulario();
            this.DesactivoBotones();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }


    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            string codTipo = TxtCodTipo.Text;

            TipoMsj unTipo = (TipoMsj)Session["UnTipo"];
            unTipo.NombCod = codTipo;

            LogicaTipoMsj.ModificarTipoMsj(unTipo);
            LblError.Text = "Modificación exitosa";

            this.LimpioFormulario();
            this.DesactivoBotones();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }


    protected void BtnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            TipoMsj unTipo = (TipoMsj)Session["UnTipo"];
            LogicaTipoMsj.BajaTipoMsj(unTipo);
            LblError.Text = "Baja exitosa";

            this.LimpioFormulario();
            this.DesactivoBotones();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }


    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
        this.DesactivoBotones();
    }
}
