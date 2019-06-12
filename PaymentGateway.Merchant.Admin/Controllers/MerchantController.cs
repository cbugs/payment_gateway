using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaymentGatewayData.Models;
using PaymentGatewayData.Context;
using PaymentGatewayData.Repository.Interface;

namespace MerchantAdmin.Controllers
{
    public class MerchantController : Controller
    {
        private readonly IMerchantRepository _merchantRepository;

        public MerchantController(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        [Route("/")]
        public ActionResult Index()
        {
            return View(_merchantRepository.GetAll().ToList());
        }

        public ActionResult Node(Guid id = new Guid())
        {
            if (id == Guid.Empty)
                return View(new Merchant());
            else
                return View(_merchantRepository.Get(id));
        }

        [HttpPost]
        public ActionResult Node(Merchant merchant)
        {
            if(!String.IsNullOrEmpty(merchant.Username) && !String.IsNullOrEmpty(merchant.Password))
            {
                if (merchant.MerchantId == Guid.Empty)
                {
                    //if user already exists redirect to index
                    if (_merchantRepository.CheckIfUsernameExists(merchant.Username))
                    {
                        return RedirectToAction("Index");
                    }
                    _merchantRepository.Add(merchant);
                }
                else
                {
                    _merchantRepository.Update(merchant);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var merchant = _merchantRepository.Get(id);
            _merchantRepository.Delete(merchant);
            return RedirectToAction("Index");
        }
    }
}
