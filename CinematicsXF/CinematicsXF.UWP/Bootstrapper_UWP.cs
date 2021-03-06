﻿using CinematicsXF.Core;
using CinematicsXF.UWP.Helpers;

namespace CinematicsXF.UWP
{
    public class Bootstrapper_UWP
    {
        public static void Initialize()
        {
            // Register common types
            Bootstrapper.RegisterTypes();

            // Register device specific types
            RegisterTypes();
        }

        private static void RegisterTypes()
        {
            // Services
            ComponentContainer.Current.Register<ILocalizeService, LocalizeService_UWP>();
            ComponentContainer.Current.Register<ILocalFileSystemService, LocalFileSystemService_UWP>(singelton: true);
        }
    }
}
