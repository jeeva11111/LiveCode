using LiveCode.Data;
using LiveCode.Models.DapperModels.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LiveCode.Controllers.Dapper
{
  //  [Route("notifaction")]
    public class NotifactionController : Controller
    {
        private readonly ICompanyRepository _repository;
        private readonly ApplicationDbContext _context;

        public NotifactionController(ICompanyRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ShowConnectedUser()
        {
            return View();
        }


    }
}
