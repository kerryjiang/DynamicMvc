using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace DynamicMvc
{
    public class DynamicControllerFactory : DefaultControllerFactory
    {
        public DynamicControllerFactory(
            IControllerActivator controllerActivator,
            IEnumerable<IControllerPropertyActivator> propertyActivators)
            : base(controllerActivator, propertyActivators)
        {
            
        }
        
        public override object CreateController(ControllerContext context)
        {
            return base.CreateController(context);
        }
    }
}