using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC01
{
    public class Bai1Controller : Controller
    {
        [Route("")]
        [Route("home/index")]
        public string Index()
        {
            DateTime date =DateTime.Now;
            return date.ToString();
        }
        [Route("Welcome/{name?}")]
         public string Welcome(string name)
        {
            return HtmlEncoder.Default.Encode($"Xin chao`: {name}");
        }
    }
}