﻿using Xunit;

namespace CatFactory.EfCore.Tests
{
    public class MockGenerationTests
    {
        [Fact]
        public void ProjectGenerationWithDefaultsFromMockDatabaseTest()
        {
            // Create instance of EF Core Project
            var project = new EfCoreProject
            {
                Name = "Store",
                Database = Databases.Store,
                OutputDirectory = "C:\\Temp\\CatFactory.EfCore\\Store.Mock"
            };

            // Apply settings for EF Core project
            project.Settings.ForceOverwrite = true;
            project.Settings.AuditEntity = new AuditEntity("CreationUser", "CreationDateTime", "LastUpdateUser", "LastUpdateDateTime");
            project.Settings.ConcurrencyToken = "Timestamp";
            project.Settings.EntitiesWithDataContracts.Add("Sales.Order");

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Generate code =^^=
            project
                .GenerateEntityLayer()
                .GenerateDataLayer();
        }

        [Fact]
        public void ProjectGenerationWithDataBindingsFromMockDatabaseTest()
        {
            // Create instance of EF Core Project
            var project = new EfCoreProject
            {
                Name = "Store",
                Database = Databases.Store,
                OutputDirectory = "C:\\Temp\\CatFactory.EfCore\\Store.Mock.DataBindings"
            };

            // Apply settings for EF Core project
            project.Settings.ForceOverwrite = true;
            project.Settings.EnableDataBindings = true;
            project.Settings.AuditEntity = new AuditEntity("CreationUser", "CreationDateTime", "LastUpdateUser", "LastUpdateDateTime");
            project.Settings.ConcurrencyToken = "Timestamp";
            project.Settings.EntitiesWithDataContracts.Add("Sales.Order");

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Generate code =^^=
            project
                .GenerateEntityLayer()
                .GenerateDataLayer();
        }

        [Fact]
        public void ProjectGenerationWithDefaultsFromClassicMockDatabaseTest()
        {
            // Create instance of EF Core Project
            var project = new EfCoreProject
            {
                Name = "School",
                Database = Databases.School,
                OutputDirectory = "C:\\Temp\\CatFactory.EfCore\\School.Mock"
            };

            // Apply settings for EF Core project
            project.Settings.ForceOverwrite = true;

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Generate code =^^=
            project
                .GenerateEntityLayer()
                .GenerateDataLayer();
        }

        [Fact]
        public void ProjectGenerationWithDbSetPropertiesAndDataAnnotationsTest()
        {
            // Create instance of EF Core Project
            var project = new EfCoreProject
            {
                Name = "Store",
                Database = Databases.Store,
                OutputDirectory = "C:\\Temp\\CatFactory.EfCore\\StoreWithDbSetPropertiesAndDataAnnotations.Mock"
            };

            // Apply settings for EF Core project
            project.Settings.ForceOverwrite = true;
            project.Settings.UseDataAnnotations = true;
            project.Settings.DeclareDbSetPropertiesInDbContext = true;

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Generate code =^^=
            project
                .GenerateEntityLayer()
                .GenerateDataLayer();
        }

        [Fact]
        public void ProjectGenerationWithModifiedNamespacesFromMockDatabaseTest()
        {
            // Create instance of EF Core Project
            var project = new EfCoreProject
            {
                Name = "Store",
                Database = Databases.Store,
                OutputDirectory = "C:\\Temp\\CatFactory.EfCore\\ModifiedStore.Mock"
            };

            // Apply settings for EF Core project
            project.Settings.ForceOverwrite = true;

            project.Namespaces.EntityLayer = "EL";
            project.Namespaces.DataLayer = "DL";

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Generate code =^^=
            project
                .GenerateEntityLayer()
                .GenerateDataLayer();
        }

        // todo: add logic to this feature
        //[Fact]
        //public void ProjectGenerationWithTddFromMockDatabaseTest()
        //{
        //    var project = new EfCoreProject
        //    {
        //        Name = "Store",
        //        Database = Databases.Store,
        //        OutputDirectory = "C:\\Temp\\CatFactory.EfCore\\Store.Tdd.Mock",
        //    };

        //    project.Settings.ForceOverwrite = true;
        //    project.Settings.ConcurrencyToken = "Timestamp";
        //    project.Settings.AuditEntity = new AuditEntity("CreationUser", "CreationDateTime", "LastUpdateUser", "LastUpdateDateTime");

        //    project.UpdateExclusions.AddRange(new string[] { "CreationUser", "CreationDateTime" });

        //    project.BuildFeatures();

        //    project
        //        .GenerateEntityLayer()
        //        .GenerateDataLayer();
        //}
    }
}
