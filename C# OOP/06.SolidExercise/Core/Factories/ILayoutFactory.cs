using _07.Solid.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Solid.Core.Factories
{
   public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
