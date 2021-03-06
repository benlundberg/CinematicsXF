﻿using CinematicsXF.Core;

namespace CinematicsXF.iOS
{
    public class Bootstrapper_iOS
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
            ComponentContainer.Current.Register<ILocalizeService, LocalizeService_iOS>();
            ComponentContainer.Current.Register<ILocalFileSystemService, LocalFileSystemService_iOS>(singelton: true);
        }
    }
}
