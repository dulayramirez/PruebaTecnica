﻿using System.Web;
using System.Web.Mvc;

namespace Aplicacion_Prueba_Tecnica
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
