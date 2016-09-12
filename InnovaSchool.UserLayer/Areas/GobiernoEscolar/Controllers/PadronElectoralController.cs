using InnovaSchool.BL;
using InnovaSchool.Entity.Result;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnovaSchool.UserLayer.Areas.GobiernoEscolar.Controllers
{
    public class PadronElectoralController : BaseController
    {
        //
        // GET: /GobiernoEscolar/PadronElectoral/
        public ActionResult Index()
        {
            //Extrael el padron generado
            BAlumnoEmpadronado oBAlumnoEmpadronado = new BAlumnoEmpadronado();
            var model = oBAlumnoEmpadronado.ListarAlumnosEmpadronados_BL();
            Session["AlumnosEmpadronados"] = model;
            return View(model);
        }

        public ActionResult GenerarPadron()
        {
            BAlumnoEmpadronado oBAlumnoEmpadronado = new BAlumnoEmpadronado();
            string mensaje = oBAlumnoEmpadronado.GenerarPadronElectoral_BL();
            TempData["Mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Notificar()
        {
            List<SP_GE_ListarAlumnosPadronElectoral_Result> model = (List<SP_GE_ListarAlumnosPadronElectoral_Result>)Session["AlumnosEmpadronados"];

            BAlumnoEmpadronado oBAlumnoEmpadronado = new BAlumnoEmpadronado();
            int procesados = oBAlumnoEmpadronado.GenerarCredenciales_BL(model);

            return Json(procesados);
        }

        public ActionResult Reporte(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Areas/GobiernoEscolar/Informes"), "PadronElectoral.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                TempData["Mensaje"] = "No existe el archivo del reporte: " + path;
                return RedirectToAction("Index");
            }

            List<SP_GE_ListarAlumnosPadronElectoral_Result> model = (List<SP_GE_ListarAlumnosPadronElectoral_Result>)Session["AlumnosEmpadronados"];
            ReportDataSource rd = new ReportDataSource("DataSet1", model);
            lr.DataSources.Add(rd);

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Titulo", "PADRON ELECTORAL " + DateTime.Now.Year.ToString()));
            lr.SetParameters(reportParameters);
            
            lr.DataSources.Add(rd);
            string reportType = id;//PDF | Excel | Word | Image
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + reportType + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, mimeType);
        }
	}
}