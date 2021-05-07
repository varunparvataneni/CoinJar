using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinJarAPI.Interfaces;

namespace CoinJarAPI.Provider
{
    public abstract class UsCoin : ICoin
    {

        public decimal Volume { get; set; }
        public decimal Amount { get; set; }

        public UsCoin(decimal amount, decimal volume)
        { 
            this.Volume = volume;
            this.Amount = amount;
        }

    }

    public class Penny : UsCoin
    {

        public Penny() : base(0.0122m, 0.01m) { }

    }

    public class Nickel : UsCoin
    {

        public Nickel() : base(0.0243m, 0.05m) { }

    }

    public class Dime : UsCoin
    {

        public Dime() : base(0.0115m, 0.1m) { }

    }

    public class Quarter : UsCoin
    {

        public Quarter() : base(0.0270m, 0.25m) { }

    }

    public class HalfDollar : UsCoin
    {

        public HalfDollar() : base(0.0534m, 0.5m) { }

    }

    public class Dollar : UsCoin
    {

        public Dollar() : base(0.0800m, 1.0m) { }

    }
}
