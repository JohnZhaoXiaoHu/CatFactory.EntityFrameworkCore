﻿using CatFactory.SqlServer;
using Xunit;

namespace CatFactory.EntityFrameworkCore.Tests
{
    public class ImportTests
    {
        [Fact]
        public void ProjectScaffoldingForStoreDatabaseTest()
        {
            // Create database factory
            var databaseFactory = new SqlServerDatabaseFactory(SqlServerDatabaseFactory.GetLogger())
            {
                DatabaseImportSettings = new DatabaseImportSettings
                {
                    ConnectionString = "server=(local);database=Store;integrated security=yes;",
                    Exclusions =
                    {
                        "dbo.sysdiagrams",
                        "dbo.fn_diagramobjects"
                    },
                    ImportScalarFunctions = true
                }
            };

            // Import database
            var database = databaseFactory.Import();

            // Create instance of Entity Framework Core project
            var project = new EntityFrameworkCoreProject
            {
                Name = "Store",
                Database = database,
                OutputDirectory = "C:\\Temp\\CatFactory.EntityFrameworkCore\\Store"
            };

            // Apply settings for Entity Framework Core project
            project.GlobalSelection(settings =>
            {
                settings.ForceOverwrite = true;
                settings.AuditEntity = new AuditEntity("CreationUser", "CreationDateTime", "LastUpdateUser", "LastUpdateDateTime");
                settings.ConcurrencyToken = "Timestamp";
            });

            project.Select("Sales.Order", settings => settings.EntitiesWithDataContracts = true);

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Add event handlers to before and after of scaffold

            project.ScaffoldingDefinition += (source, args) =>
            {
                // Add code to perform operations with code builder instance before to create code file
            };

            project.ScaffoldedDefinition += (source, args) =>
            {
                // Add code to perform operations after of create code file
            };

            // Scaffolding =^^=
            project
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();
        }

        [Fact]
        public void ProjectScaffoldingWithDataAnnotationsForStoreDatabaseTest()
        {
            // Import database
            var database = SqlServerDatabaseFactory
                .Import(SqlServerDatabaseFactory.GetLogger(), "server=(local);database=Store;integrated security=yes;", "dbo.sysdiagrams");

            // Create instance of Entity Framework Core Project
            var project = new EntityFrameworkCoreProject
            {
                Name = "StoreWithDataAnnotations",
                Database = database,
                OutputDirectory = "C:\\Temp\\CatFactory.EntityFrameworkCore\\StoreWithDataAnnotations"
            };

            // Apply settings for Entity Framework Core project
            project.GlobalSelection(settings =>
            {
                settings.ForceOverwrite = true;
                settings.AuditEntity = new AuditEntity("CreationUser", "CreationDateTime", "LastUpdateUser", "LastUpdateDateTime");
                settings.ConcurrencyToken = "Timestamp";
                settings.UseDataAnnotations = true;
            });

            project.Select("Sales.Order", settings => settings.EntitiesWithDataContracts = true);

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Add event handlers to before and after of scaffold

            project.ScaffoldingDefinition += (source, args) =>
            {
                // Add code to perform operations with code builder instance before to create code file
            };

            project.ScaffoldedDefinition += (source, args) =>
            {
                // Add code to perform operations after of create code file
            };

            // Scaffolding =^^=
            project
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();
        }

        [Fact]
        public void ProjectScaffoldingWithModifiedNamespacesForNorthwindDatabaseTest()
        {
            // Import database
            var database = SqlServerDatabaseFactory
                .Import(SqlServerDatabaseFactory.GetLogger(), "server=(local);database=Northwind;integrated security=yes;", "dbo.sysdiagrams");

            // Create instance of Entity Framework Core Project
            var project = new EntityFrameworkCoreProject
            {
                Name = "Northwind",
                Database = database,
                OutputDirectory = "C:\\Temp\\CatFactory.EntityFrameworkCore\\ModifiedNorthwind"
            };

            // Apply settings for Entity Framework Core project
            project.GlobalSelection(settings =>
            {
                settings.ForceOverwrite = true;
            });

            // Set custom namespaces
            project.Namespaces.EntityLayer = "EL";
            project.Namespaces.DataLayer = "DL";
            project.Namespaces.Contracts = "Interfaces";
            project.Namespaces.DataContracts = "Dtos";
            project.Namespaces.Repositories = "Implementations";

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Add event handlers to before and after of scaffold

            project.ScaffoldingDefinition += (source, args) =>
            {
                // Add code to perform operations with code builder instance before to create code file
            };

            project.ScaffoldedDefinition += (source, args) =>
            {
                // Add code to perform operations after of create code file
            };

            // Scaffolding =^^=
            project
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();
        }

        [Fact]
        public void ProjectScaffoldingForNorthwindDatabaseTest()
        {
            // Import database
            var database = SqlServerDatabaseFactory
                .Import(SqlServerDatabaseFactory.GetLogger(), "server=(local);database=Northwind;integrated security=yes;", "dbo.sysdiagrams");

            // Create instance of Entity Framework Core Project
            var project = new EntityFrameworkCoreProject
            {
                Name = "Northwind",
                Database = database,
                OutputDirectory = "C:\\VsCode\\Northwind\\src"
            };

            // Apply settings for Entity Framework Core project
            project.GlobalSelection(settings => settings.ForceOverwrite = true);

            project.Select("Orders", settings => settings.EntitiesWithDataContracts = true);

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Add event handlers to before and after of scaffold

            project.ScaffoldingDefinition += (source, args) =>
            {
                // Add code to perform operations with code builder instance before to create code file
            };

            project.ScaffoldedDefinition += (source, args) =>
            {
                // Add code to perform operations after of create code file
            };

            // Scaffolding =^^=
            project
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();
        }

        [Fact]
        public void ProjectScaffoldingForAdventureWorksDatabaseTest()
        {
            // Create instance of factory for SQL Server
            var factory = new SqlServerDatabaseFactory(SqlServerDatabaseFactory.GetLogger())
            {
                DatabaseImportSettings = new DatabaseImportSettings
                {
                    ConnectionString = "server=(local);database=AdventureWorks2017;integrated security=yes;",
                    Exclusions = { "dbo.sysdiagrams" }
                }
            };

            // Import database
            var database = factory.Import();

            // Create instance of Entity Framework Core Project
            var project = new EntityFrameworkCoreProject
            {
                Name = "AdventureWorks",
                Database = database,
                OutputDirectory = "C:\\Temp\\CatFactory.EntityFrameworkCore\\AdventureWorks"
            };

            // Apply settings for Entity Framework Core project
            project.GlobalSelection(settings =>
            {
                settings.ForceOverwrite = true;
            });

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Add event handlers to before and after of scaffold

            project.ScaffoldingDefinition += (source, args) =>
            {
                // Add code to perform operations with code builder instance before to create code file
            };

            project.ScaffoldedDefinition += (source, args) =>
            {
                // Add code to perform operations after of create code file
            };

            // Scaffolding =^^=
            project
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();
        }

        [Fact]
        public void ProjectScaffoldingForWideWorldImportersDatabaseTest()
        {
            // Import database
            var database = SqlServerDatabaseFactory
                .Import(SqlServerDatabaseFactory.GetLogger(), "server=(local);database=WideWorldImporters;integrated security=yes;", "dbo.sysdiagrams");

            // Create instance of Entity Framework Core project
            var project = new EntityFrameworkCoreProject
            {
                Name = "Store",
                Database = database,
                OutputDirectory = "C:\\Temp\\CatFactory.EntityFrameworkCore\\WideWorldImporters"
            };

            // Apply settings for Entity Framework Core project
            project.GlobalSelection(settings => settings.ForceOverwrite = true);

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Add event handlers to before and after of scaffold

            project.ScaffoldingDefinition += (source, args) =>
            {
                // Add code to perform operations with code builder instance before to create code file
            };

            project.ScaffoldedDefinition += (source, args) =>
            {
                // Add code to perform operations after of create code file
            };

            // Scaffolding =^^=
            project
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();
        }
    }
}