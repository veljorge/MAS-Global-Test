using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.AspNet.Mvc;
using Unity.RegistrationByConvention;

namespace EmpoyerTestApplication
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(t => t.GetCustomAttributes<UnityExposeAttribute>(true).Any()),
                GetInterfacesFromAttributeOrDefault,
                WithName.Default, (type) => new PerRequestLifetimeManager());
        }

        private static IEnumerable<Type> GetInterfacesFromAttributeOrDefault(Type type)
        {
            var decoratedInterfaces = type.GetCustomAttributes<UnityExposeAttribute>(true)
                .Where(x => x.ExposedInterfaces != null)
                .SelectMany(x => x.ExposedInterfaces);

            if (decoratedInterfaces.Count() > 0)
            {
                return decoratedInterfaces;
            }

            var interfacesOfType = type.GetInterfaces();
            if (interfacesOfType.Length == 0)
            {
                throw new InvalidOperationException($"No interface found for UnityExposed type '{type.Name}'");
            }
            return interfacesOfType;
        }
    }
}