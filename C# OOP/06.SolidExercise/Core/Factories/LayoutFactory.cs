using _07.Solid.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Solid.Core.Factories
{
   public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout;

            switch (type)
            {
                case nameof(SimpleLayout):
                    layout = new SimpleLayout();
                    break;
                case nameof(XmlLayout):
                    layout = new XmlLayout();
                    break;
                default:
                    throw new Exception($"{type} is not valid layout.");
            }

            return layout;
        }
    }
}
