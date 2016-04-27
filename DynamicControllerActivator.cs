using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace DynamicMvc
{
    /// <summary>
    /// <see cref="IControllerActivator"/> that uses type activation to create controllers.
    /// </summary>
    public class DynamicontrollerActivator : DefaultControllerActivator
    {
        /// <inheritdoc />
        public DynamicontrollerActivator(ITypeActivatorCache typeActivatorCache)
        : base(typeActivatorCache)
        {

        }
    }
}