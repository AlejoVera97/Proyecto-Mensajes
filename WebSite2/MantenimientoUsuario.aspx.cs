using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;

public partial class MantenimientoUsuario : System.Web.UI.Page
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
        TxtNomUsu.Text = "";
        TxtCedula.Text = "";
        TxtNomComp.Text = "";
    }

    private void DesactivoBotones()
    {
        BtnAlta.Enabled = false;
        BtnModificar.Enabled = false;
        BtnBaja.Enabled = false;

        BtnBuscarUsu.Enabled = true;
    }

    protected void BtnBuscarUsu_Click(object sender, EventArgs e)
    {
        string nombreUsuario = "";
        try
        {
            Usuario unUsuario = LogicaUsuario.Buscar(nombreUsuario);
            if (unUsuario != null)
            {
                TxtCedula.Text = Convert.ToString(unUsuario.Cedula);
                TxtNomComp.Text = unUsuario.NombreCompleto;

                Session["Usuario"] = unUsuario;

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
        string nombreUsuario = TxtNomUsu.Text;
        int cedula = Convert.ToInt32(TxtCedula.Text);
        string nombreCompleto = TxtNomComp.Text;

        Usuario unUsuario = new Usuario(nombreUsuario, cedula, nombreCompleto);

        try
        {
            LogicaUsuario.AltaUsuario(unUsuario);

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
            int cedula = Convert.ToInt32(TxtCedula.Text);
            string nombreCompleto = TxtNomComp.Text;

            Usuario unUsuario = (Usuario)Session["Usuario"];
            unUsuario.Cedula = cedula;
            unUsuario.NombreCompleto = nombreCompleto;

            LogicaUsuario.ModificarUsuario(unUsuario);
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
            Usuario unUsuario = (Usuario)Session["Usuario"];
            LogicaUsuario.BajaUsuario(unUsuario);
            LblError.Text = "Baja del usuario exitosa";
           
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
