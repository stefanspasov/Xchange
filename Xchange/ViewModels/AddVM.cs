using System.Web;
using Data.Models;

namespace Xchange.ViewModels
{
    public class AddVM
    {
        public BoardGame BoardGame { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}