using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinJarAPI.Interfaces;
using CoinJarAPI.Provider;
using Newtonsoft.Json;

namespace CoinJarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinJarController : ControllerBase
    {

        private readonly ICoinJar coinJar;

        public CoinJarController(ICoinJar coinJar)
        {
            this.coinJar = coinJar;
        }
        [HttpPost]
        [Route("AddCoin")]
        public void AddCoin([FromBody]ICoin coin)
        {
            try
            {
                this.coinJar.AddCoin(coin);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetTotalAmount")]
        public decimal GetTotalAmount()
        {
            try
            {
                return this.coinJar.GetTotalAmount();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Reset")]
        public void Reset()
        {
            try
            {
                this.coinJar.Reset();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

    }
}
