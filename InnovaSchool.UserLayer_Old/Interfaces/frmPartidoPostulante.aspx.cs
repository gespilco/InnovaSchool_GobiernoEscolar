using InnovaSchool.BL;
using InnovaSchool.Entity;
using InnovaSchool.UserLayer.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InnovaSchool.UserLayer.Interfaces
{
    public partial class frmPartidoPostulante1 : System.Web.UI.Page
    {
        BPersona BPersona = new BPersona();
        BAgenda BAgenda = new BAgenda();
        Resources.Resources objResources = new Resources.Resources();
        BParametro BParametro = new BParametro();
        BAmbiente BAmbiente = new BAmbiente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              IniciarValidacion();

              //  CargarTipoActividad();
               // CargarResponsable();
                //CargarAlcance();
                //CargarAnioEscolar();
              //CargarPartidos();      //partidos
            }
        }

        private void CargarAlcance()
        {
            ddlAlcance.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroAlcance));
            ddlAlcance.DataValueField = "ValTextual";
            ddlAlcance.DataTextField = "Descripcion";
            ddlAlcance.DataBind();
            ddlAlcance.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));
        }

        private void CargarPartidos() {//partidos
            ddlResponsable.DataSource = "";

        }

        private void CargarTipoActividad()
        {
            ddlActividad.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroTipoActividad));
            ddlActividad.DataValueField = "ValTextual";
            ddlActividad.DataTextField = "Descripcion";
            ddlActividad.DataBind();
            ddlActividad.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));
            ddlTipoActividad.Enabled = false;
        }

        protected void ddlActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strTipoActividad = ddlActividad.SelectedValue;
            if (strTipoActividad.Equals(Constant.ParametroTipoCalendarioAcademico))
            {
                CargarTipoActividadAcademica();
                ddlTipoActividad.Enabled = true;
            }
            else if (strTipoActividad.Equals(Constant.ParametroTipoCalendarioExtracurricular))
            {
                CargarTipoActividadExtracurricular();
                ddlTipoActividad.Enabled = true;
            }
            else
            { 
                ddlTipoActividad.Enabled = false;
                ddlTipoActividad.Items.Clear();
                ddlTipoActividad.DataBind();
            }
        }

        private void CargarTipoActividadAcademica()
        {
            ddlTipoActividad.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroTipoActividadAcademica));
            ddlTipoActividad.DataValueField = "ValNumerico";
            ddlTipoActividad.DataTextField = "Descripcion";
            //ddlTipoActividad.DataTextField = "Estado";
            ddlTipoActividad.DataBind();
            ddlTipoActividad.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));               
        }

        private void CargarTipoActividadExtracurricular()
        {
            ddlTipoActividad.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroTipoActividadExtracurricular));
            ddlTipoActividad.DataValueField = "ValNumerico";
            ddlTipoActividad.DataTextField = "Descripcion";
            ddlTipoActividad.DataBind();
            ddlTipoActividad.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));            
        }

        private void IniciarValidacion()
        {
            var FecIniAnio = "01/01/" + DateTime.Today.Year.ToString();
            var FecFinAnio = "31/12/" + DateTime.Today.Year.ToString();
            var FecActual = DateTime.Today.ToShortDateString();
            
            rvFechaInicio.MinimumValue = FecIniAnio.ToString();
            rvFechaInicio.MaximumValue = FecFinAnio.ToString();
            cvFechaInicio.ValueToCompare = FecActual.ToString();

            rvFechaFin.MinimumValue = FecIniAnio.ToString();
            rvFechaFin.MaximumValue = FecFinAnio.ToString();
            cvFechaFin.ValueToCompare = FecActual.ToString();
        }

        protected void gvDetalleSolicitudActividad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlUbicacion = (e.Row.FindControl("ddlUbicacion") as DropDownList);
                ddlUbicacion.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroUbicacion));
                ddlUbicacion.DataValueField = "ValTextual";
                ddlUbicacion.DataTextField = "Descripcion";
                ddlUbicacion.DataBind();
                ddlUbicacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));          
            }
        }

        protected void ddlUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlUbicacion = (DropDownList)sender;
            string strUbicacion = ddlUbicacion.SelectedValue;

            GridViewRow gvrUbicacion = ((GridViewRow)ddlUbicacion.Parent.Parent);
            DropDownList ddlAmbiente = (DropDownList)gvrUbicacion.FindControl("ddlAmbiente");
            TextBox txtDireccion = (TextBox)gvrUbicacion.FindControl("txtDireccion");           

            if(strUbicacion.Equals(Constant.ParametroUbicacionInterna))
            {
                ddlAmbiente.DataSource = BAmbiente.ListarAmbientes();
                ddlAmbiente.DataValueField = "IDAmbiente";
                ddlAmbiente.DataTextField = "Nombre";
                ddlAmbiente.DataBind();
                ddlAmbiente.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));          
                ddlAmbiente.Visible = true;
                txtDireccion.Visible = false;                
            }
            else if (strUbicacion.Equals(Constant.ParametroUbicacionExterna))
            {
                ddlAmbiente.Visible = false;                
                txtDireccion.Visible = true;
                txtDireccion.Text = string.Empty;
            }
            else
            {
                ddlAmbiente.Visible = false;
                txtDireccion.Visible = false;
            }
        }

        protected void gvDetalleSolicitudActividad_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvConsultaSolicitudes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvConsultaSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        protected void btnIngresarHoras_Click(object sender, EventArgs e)
        {            
            DataTable dtFechas = new DataTable();
            dtFechas.Columns.Add("Fecha", typeof(DateTime));
            DateTime dtFechaFin = Convert.ToDateTime(txtFechaFin.Text);
            DateTime dtFechaInicio = Convert.ToDateTime(txtFechaInicio.Text);

            for (DateTime dt = dtFechaInicio; dt <= dtFechaFin; dt = dt.AddDays(1))
            {
                DataRow drFecha = dtFechas.NewRow();
                drFecha["Fecha"] = dt;
                dtFechas.Rows.Add(drFecha);
            }

            gvDetalleSolicitudActividad.DataSource = dtFechas;
            gvDetalleSolicitudActividad.DataBind();            
        }        
                
        protected void ddlTipoActividad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAlcance_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtActividades = new DataTable();
            dtActividades.Columns.Add("Nombre", typeof(DateTime));
            dtActividades.Columns.Add("Actividad", typeof(DateTime));
            dtActividades.Columns.Add("TipoActividad", typeof(DateTime));
            dtActividades.Columns.Add("Descripcion", typeof(DateTime));
            dtActividades.Columns.Add("Responsable", typeof(DateTime));
            dtActividades.Columns.Add("Alcance", typeof(DateTime));
            dtActividades.Columns.Add("FechaInicio", typeof(DateTime));
            dtActividades.Columns.Add("FechaFin", typeof(DateTime));
            DateTime dtFechaFin = Convert.ToDateTime(txtFechaFin.Text);
            DateTime dtFechaInicio = Convert.ToDateTime(txtFechaInicio.Text);

            for (DateTime dt = dtFechaInicio; dt <= dtFechaFin; dt = dt.AddDays(1))
            {
                DataRow drFecha = dtActividades.NewRow();
                drFecha["Nombre"] = dt;
                drFecha["Actividad"] = dt;
                drFecha["TipoActividad"] = dt;
                drFecha["Descripcion"] = dt;
                drFecha["Responsable"] = dt;
                drFecha["Alcance"] = dt;
                drFecha["FechaInicio"] = dt;
                drFecha["FechaFin"] = dt;
                dtActividades.Rows.Add(drFecha);
            }

            gvConsultaSolicitudes.DataSource = dtActividades;
            gvConsultaSolicitudes.DataBind();  
        }

        private void CargarResponsable()
        {
            List<EPersona> ListEPersona;
            ListEPersona = BPersona.ListarPersona();
            ddlResponsable.DataSource = ListEPersona;
            ddlResponsable.DataTextField = "Nombre";
            ddlResponsable.DataValueField = "IdPersona";
            ddlResponsable.DataBind();
            ddlResponsable.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));
        }

        private void CargarAnioEscolar()
        {
            List<EAgenda> ListEagenda;
            ListEagenda = BAgenda.AniosAgenda();
            ddlAnio.DataSource = ListEagenda;
            ddlAnio.DataTextField = "IdAgenda";
            ddlAnio.DataValueField = "IdAgenda";
            ddlAnio.DataBind();
            ddlAnio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Años", "0"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            ddlTipoActividad.Items.Clear();
            ddlTipoActividad.DataBind();
            ddlTipoActividad.Enabled = false;
        }

        private void Limpiar()
        {
            objResources.LimpiarControles(this.Controls);            
        }
    }
}