using Xchange.ViewModels;

namespace Xchange.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Data.Models;
    using Data.Repositories;

    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            return this.View(GamesRepo.Games);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);   
            }

            var game = GamesRepo.GetGameById((int)id);

            if (game == null)
            {
                return this.HttpNotFound();
            }

            return this.View(game);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var game = GamesRepo.GetGameById((int)id);

            if (game == null)
            {
                return this.HttpNotFound();
            }

            return this.View(game);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Name, Description, CustomerId")] BoardGame game)
        {
            if (this.ModelState.IsValid)
            {
                GamesRepo.SaveGame(game);
                return this.RedirectToAction("Index");
            }

            return this.View(game);
        }

        public ActionResult Add()
        {
            return this.View();
        }


        [HttpPost]
        public ActionResult Add(AddVM game)
        {
            if (this.ModelState.IsValid)
            {
                var filePath = "~/Pics/" + game.File.FileName;
                game.File.SaveAs(Server.MapPath(filePath));
                game.BoardGame.ImagePath = game.File.FileName;
                GamesRepo.AddGame(game.BoardGame);
            }

            return this.View(game);
        }

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var game = GamesRepo.GetGameById((int)id);

        //    if (game == null)
        //    {
        //        return this.HttpNotFound();
        //    }
        //}
    }
}