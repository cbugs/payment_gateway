using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Data.Models;
using PaymentGateway.Data.Context;
using PaymentGateway.Data.Repository.Interface;
using PaymentGateway.Merchant.Admin.Models;
using AutoMapper;

namespace MerchantAdmin.Controllers
{
    public class MerchantController : Controller
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public MerchantController(IMerchantRepository merchantRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        [Route("/")]
        public ActionResult Index()
        {
            return View(_merchantRepository.GetAll().ToList());
        }

        public ActionResult Node(Guid id = new Guid())
        {
            if (id == Guid.Empty)
                return View(new MerchantViewModel());
            else
                return View(_mapper.Map<MerchantViewModel>(_merchantRepository.Get(id)));
        }

        [HttpPost]
        public ActionResult Node(MerchantViewModel merchant)
        {
            // if user already exists and there is a change on username
            if (_merchantRepository.CheckIfUsernameExists(merchant.Username) && merchant.Username != merchant.OldUsername)
            {
                ModelState.AddModelError("Username", "User Already Exists.");
            }

            // if new merchant create
            if (merchant.MerchantId == Guid.Empty)
            {
                // check if password has been set on create return RedirectToAction("Index");
                if (String.IsNullOrEmpty(merchant.Password))
                {
                    ModelState.AddModelError("Password", "Please enter a password.");
                }
                if (ModelState.IsValid)
                {
                    _merchantRepository.Add(_mapper.Map<Merchant>(merchant));
                    return RedirectToAction("Index");
                }
            }

            // try to update
            if (ModelState.IsValid)
            {
                _merchantRepository.Update(_mapper.Map<Merchant>(merchant));
                return RedirectToAction("Index");
            }
           
            return View(merchant);
        }

        public ActionResult Delete(Guid id)
        {
            var merchant = _merchantRepository.Get(id);
            _merchantRepository.Delete(merchant);
            return RedirectToAction("Index");
        }
    }
}
