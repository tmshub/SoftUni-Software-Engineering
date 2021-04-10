using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;

        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => this.models.AsReadOnly();

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration decoration = null;
            foreach (var item in this.models)
            {
                if(type == item.GetType().Name)
                {
                    return item;
                }
            }

            return decoration;
        }

        public bool Remove(IDecoration model)
        {
            foreach (var item in this.models)
            {
                if (item == model)
                {
                    this.models.Remove(model);
                    return true;
                }
            }

            return false;
        }
    }
}
