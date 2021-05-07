using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinJarAPI.Interfaces;
using CoinJarAPI.Provider;


namespace CoinJarAPI.Implementation
{
    /// <summary>
    /// MyCoinJar Implementation fom IcoinJar Interface
    /// </summary>
    public class MyCoinJar:ICoinJar
    {
        private List<ICoin> Coins;
        private decimal TotalAmount { get; set; }
        private decimal TotalVolume { get; set; }
        private decimal UsedVolume { get; set; }

 
        /// <summary>
        /// Constructor 
        /// </summary>
        public MyCoinJar()
        {
            this.Coins = new List<ICoin>();
            this.TotalAmount = 0m;
            this.TotalVolume = 42m;
            this.UsedVolume = 0m;
        }

        /// <summary>
        /// Add coin to the List and set the amount and value
        /// </summary>
        /// <param name="coin"></param>
        public void AddCoin(ICoin coin)
        {
            if (coin.GetType().BaseType != typeof(UsCoin))
                throw new InValidCoinException("MyCoinJar accepts only UsCoin");
            if (this.TotalVolume < (this.UsedVolume + coin.Volume))
                throw new CoinOverFlowException();

            Coins.Add(coin);
            this.TotalAmount += coin.Amount;
            this.UsedVolume += coin.Volume;
        }

        /// <summary>
        /// Get The TotalAmount
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalAmount()
        { 
            return Coins.Select(c => (decimal)c.Volume * (decimal)c.Amount).Sum();
        }

        /// <summary>
        /// Reset
        /// </summary>
        public void Reset()
        {
            Coins = new List<ICoin>();
            this.TotalAmount = 0m;
            this.UsedVolume = 0m;
        }

        #region Custom Exceptions
        /// <summary>
        /// Coin Overflowed Exception
        /// </summary>
        public class CoinOverFlowException : Exception
        {
            public CoinOverFlowException()
                : base("Coins overflowed the jar")
            {
            }
        }

        /// <summary>
        /// Invalid Coin Exception
        /// </summary>
        public class InValidCoinException : Exception
        {
            public InValidCoinException(string message)
                : base(message)
            {
            }
        }

        #endregion
    }
}
