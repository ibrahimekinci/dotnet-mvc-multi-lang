using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ibrahimekinci.Lang;
using System.ComponentModel.DataAnnotations;

namespace ibrahimekinci_Web_Mvc_Multilingual.Models
{
    public class MyModel
    {
        [Display(ResourceType = typeof(ibrahimekinci.Lang.Language), Name = "FirstName")]
        [Required(ErrorMessageResourceName = "Warning_FieldRequired", ErrorMessageResourceType = typeof(ibrahimekinci.Lang.Language))]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(ibrahimekinci.Lang.Language), Name = "LastName")]
        [Required(ErrorMessageResourceName = "Warning_FieldRequired", ErrorMessageResourceType = typeof(ibrahimekinci.Lang.Language))]
        public string LastName { get; set; }
    }
}