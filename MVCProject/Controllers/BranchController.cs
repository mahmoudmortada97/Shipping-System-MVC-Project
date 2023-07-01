using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository.BranchRepo;
using MVCProject.Repository.TraderRepo;

namespace MVCProject.Controllers
{
    [Authorize(Roles = "Employee, Admin")]
    public class BranchController : Controller
    {
        IBranchRepository _branchRepository;
        ITraderRepository _traderRepository;

        public BranchController(IBranchRepository branchRepository, ITraderRepository traderRepository)
        {
            _branchRepository = branchRepository;
            _traderRepository = traderRepository;
        }

        public IActionResult Index(string word)
        {
            List<Branch> branches;
            if (string.IsNullOrEmpty(word))
            {
                branches = _branchRepository.GetAll();
            }
            else
            {
                branches = _branchRepository.GetAll().Where(
                                e => e.Name.ToLower().Contains(word.ToLower())).ToList();

            }
            return View(branches);

        }

        public IActionResult Details(int id)
        {
            var traders = _traderRepository.GetAllTradersByBranchId(id);
            ViewData["BranchName"] = _branchRepository.GetById(id).Name;

            return View(traders);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchRepository.Add(branch);
                _branchRepository.Save();
                return RedirectToAction("Index");
            }

            return View(branch);
        }

        public IActionResult Edit(int id)
        {
            Branch branch = _branchRepository.GetById(id);
            return View(branch);
        }
        [HttpPost]
        public IActionResult Edit(Branch branch)
        {

            if (ModelState.IsValid)
            {
                _branchRepository.Edit(branch);
                _branchRepository.Save();
                return RedirectToAction("Index");
            }
            return View(branch);

        }

        public IActionResult Delete(int id)
        {
            _branchRepository.Delete(id);
            _branchRepository.Save();
            return Content("sucsses");
        }
    }
}
