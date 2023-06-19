using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository.TraderRepo;

namespace MVCProject.Controllers
{
    public class TraderController : Controller
    {
        ITraderRepository _traderRepository;
        public TraderController(ITraderRepository traderRepository)
        {
            _traderRepository = traderRepository;
        }

        public IActionResult Index(string word)
        {
            List<Trader> traders;
            if (string.IsNullOrEmpty(word))
            {
                traders = _traderRepository.GetAll();
            }
            else
            {
                traders = _traderRepository.GetAll().Where(
                                e => e.Name.ToLower().Contains(word.ToLower())).ToList();
            }
            return View(traders);

        }

        public IActionResult Details(int id)
        {
            Trader trader = _traderRepository.GetById(id);

            return View(trader);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Trader trader)
        {
            if (ModelState.IsValid)
            {
                _traderRepository.Add(trader);
                //_traderRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            return View(trader);
        }

        public IActionResult Edit(int id)
        {
            Trader trader = _traderRepository.GetById(id);
            return View(trader);
        }
        [HttpPost]
        public IActionResult Edit(Trader trader)
        {
            if (ModelState.IsValid)
            {
                _traderRepository.Edit(trader);
                //_traderRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            return View(trader);
        }

        public IActionResult Delete(int id)
        {
            _traderRepository.Delete(id);
            //_traderRepository.Save();
            return View();
        }
    }
}
