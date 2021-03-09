﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.InterfacesAndAbstractionExersice
{
    public class StationaryPhone : ICalling
    {

        public string Call(string number)
        {
            if (number.Any(x => char.IsLetter(x)))
            {
                return "Invalid number!";
            }

            return $"Dialing... {number}";
        }
    }
}
