﻿using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_PROMO_WEB_21B
{
    public partial class webRegistroExitoso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}