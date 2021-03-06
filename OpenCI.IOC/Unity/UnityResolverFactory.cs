﻿namespace OpenCI.IOC.Unity
{
    public static class UnityResolverFactory
    {
        public static UnityResolver CreateResolver()
        {
            var container = UnityContainerFactory.CreateContainer();

            var dependancyResolver = new UnityResolver(container);

            return dependancyResolver;
        }
    }
}