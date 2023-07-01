using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository.BranchRepo;
using MVCProject.Repository.DiscountTypeRepo;
using MVCProject.Repository.GovernorateRepo;
using MVCProject.Repository.RepresentiveRepo;
using MVCProject.ViewModel;

namespace MVCProject.Controllers
{
    [Authorize(Roles = "Employee, Admin")]
    public class RepresentativeController : Controller
    {
        IRepresentativeRepository _representativeRepostiory;
        IGovernRepository _governRepository;
        IDiscountTypeRepository _discountTypeRepository;
        IBranchRepository _branchRepository;

        public RepresentativeController(IRepresentativeRepository representativeRepository, IGovernRepository governRepository, IDiscountTypeRepository discountTypeRepository, IBranchRepository branchRepository)
        {
            _representativeRepostiory = representativeRepository;
            _governRepository = governRepository;
            _branchRepository = branchRepository;
            _discountTypeRepository = discountTypeRepository;
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
            rep.Governorate = _governRepository.GetById(rep.GovernorateId);
            rep.Branch = _branchRepository.GetById(rep.BranchId);
            rep.DiscountType = _discountTypeRepository.GetById(rep.DiscountTypeId);

            return View(rep);
        }
        public IActionResult Create()
        {
            var repViewModel = new RepresentativeGovBranchPercentageViewModel
            {
                Governorates = _governRepository.GetAll(),
                Branchs = _branchRepository.GetAll(),
                DiscountTypes = _discountTypeRepository.GetAll()
            };
            return View(repViewModel);
        }
        [HttpPost]
        public IActionResult Create(RepresentativeGovBranchPercentageViewModel repViewModel)
        {
            if (!ModelState.IsValid)
            {
                repViewModel.Governorates = _governRepository.GetAll();
                repViewModel.Branchs = _branchRepository.GetAll();
                repViewModel.DiscountTypes = _discountTypeRepository.GetAll();
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
                IsDeleted = repViewModel.IsDeleted,
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
                Governorates = _governRepository.GetAll(),
                Branchs = _branchRepository.GetAll(),
                DiscountTypes = _discountTypeRepository.GetAll()
            };
            return View(repViewModel);
        }
        [HttpPost]
        public IActionResult Edit(RepresentativeGovBranchPercentageViewModel repViewModel)
        {
            if (!ModelState.IsValid)
            {
                repViewModel.Governorates = _governRepository.GetAll();
                repViewModel.Branchs = _branchRepository.GetAll();
                repViewModel.DiscountTypes = _discountTypeRepository.GetAll();
                return View(repViewModel);
            }
            var rep = new Representative
            {
                Id = repViewModel.Id,
                Name = repViewModel.Name,
                Address = repViewModel.Address,
                Email = repViewModel.Email,
                Password = repViewModel.Password,
                Phone = repViewModel.Phone,
                CompanyPercentageOfOrder = repViewModel.CompanyPercentageOfOrder,
                GovernorateId = repViewModel.GovernorateId,
                BranchId = repViewModel.BranchId,
                DiscountTypeId = repViewModel.DiscountTypeId,
                IsDeleted = repViewModel.IsDeleted,
            };
            _representativeRepostiory.Edit(rep);
            _representativeRepostiory.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _representativeRepostiory.Delete(id);
            _representativeRepostiory.Save();
            return Content("sucsses");
        }



    }

}
