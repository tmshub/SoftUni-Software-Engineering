﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
   public interface IRobot : IIdentification
    {
        public string Model { get;}
    }
}
