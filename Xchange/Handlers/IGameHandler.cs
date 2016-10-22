namespace Xchange.Handlers
{
    using System.Web.Mvc;

    public interface IGameHandler
    {
        ActionResult GetBoardGameById(int? id);
    }
}