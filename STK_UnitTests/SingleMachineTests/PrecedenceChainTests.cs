using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SchedulingToolKit;
using STK_SingleMachine;

namespace STK_UnitTests.SingleMachineTests
{
    public class PrecedenceChainTests
    {

        PrecedenceChain _precedenceChain;

        [SetUp]
        public void Setup()
        {
            _precedenceChain = new PrecedenceChain();
        }
    }
}
