﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSchool.Entity.Result
{
    public partial class SP_GE_ListarInstrumentosPlanGobierno_Result
    {
        public int idInstrumento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Objetivo { get; set; }
    }
}
