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

        /// <inheritdoc />
        public virtual object Create(ControllerContext controllerContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException(nameof(controllerContext));
            }

            if (controllerContext.ActionDescriptor == null)
            {
                throw new ArgumentException(Resources.FormatPropertyOfTypeCannotBeNull(
                    nameof(ControllerContext.ActionDescriptor),
                    nameof(ControllerContext)));
            }

            var controllerTypeInfo = controllerContext.ActionDescriptor.ControllerTypeInfo;

            if (controllerTypeInfo == null)
            {
                throw new ArgumentException(Resources.FormatPropertyOfTypeCannotBeNull(
                    nameof(controllerContext.ActionDescriptor.ControllerTypeInfo),
                    nameof(ControllerContext.ActionDescriptor)));
            }

            var serviceProvider = controllerContext.HttpContext.RequestServices;
            return _typeActivatorCache.CreateInstance<object>(serviceProvider, controllerTypeInfo.AsType());
        }

        /// <inheritdoc />
        public virtual void Release(ControllerContext context, object controller)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            var disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}