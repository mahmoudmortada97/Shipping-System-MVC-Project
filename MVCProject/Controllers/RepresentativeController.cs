using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository.EmployeeRepo;
using MVCProject.Repository.RepresentiveRepo;
using MVCProject.ViewModel;

namespace MVCProject.Controllers
{
    public class RepresentativeController : Controller
    {
        IRepresentativeRepository _representativeRepostiory;
        public RepresentativeController(IRepresentativeRepository representativeRepository)
        {
            _representativeRepostiory = representativeRepository;
        }
        public IActionResult Index(string word)
        {
            List<Representative> reps;
            if (string.IsNullOrEmpty(word))
            {
                reps = _representativeRepostiory.GetAll();
            }
            else
            {
                reps = _representativeRepostiory.GetAll().Where(
                                e => e.Name.ToLower().Contains(word.ToLower())).ToList();
            }
            return View(reps);
        }
        public IActionResult Details(int id)
        {
            var rep = _representativeRepostiory.GetById(id);
            return View(rep);
        }
        public IActionResult Create()
        {
            var repViewModel = new RepresentativeGovBranchPercentageViewModel
            {
                //Governorates = from context
                //Branchs = from context
                //DiscountTypes = from context
            };
            return View();
        }
        [HttpPost]
        public IActionResult Create(RepresentativeGovBranchPercentageViewModel repViewModel)
        {
            if (!ModelState.IsValid)
            {
                //repViewModel.overnorates = from context
                //repViewModel.Branchs = from context
                //repViewModel.DiscountTypes = from context
                return View(repViewModel);
            }
            var rep = new Representative
            {
                Name = repViewModel.Name,
                Address = repViewModel.Address,
                Email = repViewModel.Email,
                Password = repViewModel.Password,
                Phone = repViewModel.Phone,
                CompanyPercentageOfOrder = repViewModel.CompanyPercentageOfOrder,
                GovernorateId = repViewModel.GovernorateId,
                BranchId = repViewModel.BranchId,
                DiscountTypeId = repViewModel.DiscountTypeId,
            };
            _representativeRepostiory.Add(rep);
            _representativeRepostiory.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var rep = _representativeRepostiory.GetById(id);
            var repViewModel = new RepresentativeGovBranchPercentageViewModel
            {
                Name = rep.Name,
                Address = rep.Address,
                Email = rep.Email,
                Password = rep.Password,
                Phone = rep.Phone,
                BranchId = rep.BranchId,
                DiscountTypeId = rep.DiscountTypeId,
                GovernorateId = rep.GovernorateId,
                IsDeleted = rep.IsDeleted,
                CompanyPercentageOfOrder = rep.CompanyPercentageOfOrder,

                //Governorates = from context
                //Branchs = from context
                //DiscountTypes = from context
            };
            return View(repViewModel);
        }
        //[HttpPost]
        //public IActionResult Create(RepresentativeGovBranchPercentageViewModel repViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        //repViewModel.overnorates = from context
        //        //repViewModel.Branchs = from context
        //        //repViewModel.DiscountTypes = from context
        //        return View(repViewModel);
        //    }
        //    var rep = new Representative
        //    {
        //        Name = repViewModel.Name,
        //        Address = repViewModel.Address,
        //        Email = repViewModel.Email,
        //        Password = repViewModel.Password,
        //        Phone = repViewModel.Phone,
        //        CompanyPercentageOfOrder = repViewModel.CompanyPercentageOfOrder,
        //        GovernorateId = repViewModel.GovernorateId,
        //        BranchId = repViewModel.BranchId,
        //        DiscountTypeId = repViewModel.DiscountTypeId,
        //    };
        //    _representativeRepostiory.Add(rep);
        //    _representativeRepostiory.Save();
        //    return RedirectToAction(nameof(Index));
        //}
    } 
}
