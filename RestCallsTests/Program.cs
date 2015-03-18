using RestCallsTests.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallsTests
{
    class Program
    {
        static void Main(string[] args)
        {

            var v = new ICMeterAPI();
            var data = v.GetIndoorData(new DateTime(2014, 08, 31, 22, 00, 00), new DateTime(2014, 09, 30, 22, 00, 00));

        }
    }
}
