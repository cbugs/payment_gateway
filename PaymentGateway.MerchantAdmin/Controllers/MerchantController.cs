using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Data.Repository.Interface;
using PaymentGateway.MerchantAdmin.Models;
using AutoMapper;
using PaymentGateway.Service.Interface;
using PaymentGateway.Data.Entity;

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
        public ActionResult Index()
        {
            return View(_merchantService.ListMerchants());
        }

        public ActionResult Node(Guid id = new Guid())
        {
            if (id == Guid.Empty)
            {
                return View(new MerchantViewModel());
            }
            else
            {
                Merchant merchant = _merchantService.GetMerchant(id);
                //hide password value
                merchant.Password = "";
                return View(_mapper.Map<MerchantViewModel>(_merchantService.GetMerchant(id)));
            }
        }

        [HttpPost]
        public ActionResult Node(MerchantViewModel merchant)
        {
            // if user already exists and there is a change on username
            if (_merchantService.CheckIfUsernameExists(merchant.Username) && merchant.Username != merchant.OldUsername)
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
                    _merchantService.CreateMerchant(_mapper.Map<Merchant>(merchant));
                    return RedirectToAction("Index");
                }
            }

            // try to update
            if (ModelState.IsValid)
            {
                _merchantService.UpdateMerchant(_mapper.Map<Merchant>(merchant));
                return RedirectToAction("Index");
            }
           
            return View(merchant);
        }

        public ActionResult Delete(Guid id)
        {
            var merchant = _merchantService.GetMerchant(id);
            _merchantService.DeleteMerchant(merchant);
            return RedirectToAction("Index");
        }
    }
}
