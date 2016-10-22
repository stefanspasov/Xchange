namespace Xchange.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CustomersModel
    {
        public string SelectedOption { get; set; }
        public IEnumerable<SelectListItem> SelectOptions { get; set; }
    }
}