using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Data.Repository.Interface;
using PaymentGateway.MerchantAdmin.Models;
using AutoMapper;
using PaymentGateway.Service.Interface;
using PaymentGateway.Data.Entity;
using System.Threading.Tasks;

namespace MerchantAdmin.Controllers
{
    public class MerchantController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMerchantService _merchantService;

        public MerchantController(IMerchantService merchantService, IMapper mapper)
        {
            _merchantService = merchantService;
            _mapper = mapper;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            return View(await _merchantService.ListMerchants());
        }

        public async Task<IActionResult> Node(Guid id = new Guid())
        {
            if (id == Guid.Empty)
            {
                return View(new MerchantViewModel());
            }
            else
            {
                Merchant merchant = await _merchantService.GetMerchant(id);
                //hide password value
                merchant.Password = "";
                return View(_mapper.Map<MerchantViewModel>(merchant));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Node(MerchantViewModel merchant)
        {
            // if user already exists and there is a change on username
            if (await _merchantService.CheckIfUsernameExists(merchant.Username) && merchant.Username != merchant.OldUsername)
            {
                ModelState.AddModelError("Username", "User Already Exists.");
            }

            // if new merchant create
            if (merchant.Id == Guid.Empty)
            {
                // check if password has been set on create return RedirectToAction("Index");
                if (String.IsNullOrEmpty(merchant.Password))
                {
                    ModelState.AddModelError("Password", "Please enter a password.");
                }
                if (ModelState.IsValid)
                {
                    await _merchantService.CreateMerchant(_mapper.Map<Merchant>(merchant));
                    return RedirectToAction("Index");
                }
            }

            // try to update
            if (ModelState.IsValid)
            {
                await _merchantService.UpdateMerchant(_mapper.Map<Merchant>(merchant));
                return RedirectToAction("Index");
            }
           
            return View(merchant);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var merchant = await _merchantService.GetMerchant(id);
            await _merchantService.DeleteMerchant(merchant);
            return RedirectToAction("Index");
        }
    }
}
