using System;
using CottonOilFactory.OrderGUI.BaseClasses;

namespace CottonOilFactory.OrderGUI.Factories
{
    public abstract class AbstractWindowFactory
    {
        public virtual void CreateWindow()
        {
            throw new Exception("Shouldn't call this if you need a model");
        }

        public virtual void CreateWindow(ModelBase modelBase)
        {
            throw new Exception("Shouldn't call if you don't need a valid model");
        }
    }
}
