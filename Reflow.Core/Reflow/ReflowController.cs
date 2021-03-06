﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logger.Contract;
using Reflow.Data;
using Reflow.Data.Contracts;
using ReflowModels.Naming;
using ReflowModels.EntityModels;
using ReflowCore.Controllers;

namespace ReflowCore.Reflow
{
#pragma warning disable 1998
    /// <summary>
    /// Serves as an interface for the front end JS.
    /// </summary>
    public class ReflowController
    {

        private ICollection<IReflowController> _components;
        private readonly RenamingController _renamingController;
        private readonly ILog _log;

        public ReflowController()
            : this(null, new DirectoryStructureController(), new RenamingController())
        {
        }

        public ReflowController(ILog log)
            : this(log, new DirectoryStructureController(log), new RenamingController(log))
        {
        }

        internal ReflowController(ILog log, params IReflowController[] reflowControllers)
        {
            PokeSingletons();
            Load(reflowControllers);
            foreach (var component in _components)
            {
                component.Initialize();
            }
            _renamingController = (RenamingController)this._components.FirstOrDefault(c => c.GetType() == typeof(RenamingController));
        }

        
        /// <summary>
        /// Returns all tags that the app contains.
        /// </summary>
        /// <returns>JSON: Name, Options - OptionType, OptionName.</returns>
        public async Task<object> GetTags()
        {
            return _renamingController.GetTags();
        }

        /// <summary>
        /// Returns all filters for selecting files.        
        /// </summary>
        /// <returns>JSON: FilterName, FilterOptions </returns>
        public async Task<object> GetFilters()
        {
            return _renamingController.GetFilters();
        }

        /// <summary>
        /// Gets all files in a given directory (Excluding folders)
        /// </summary>
        /// <param name="directoryPath">Path to the directory to get the files from.</param>
        /// <returns>JSON: CustomFile (Check ReflowFile class to see fields)</returns>
        public async Task<object> GetFilesInDirectory(object directoryPath)
        {
            return _renamingController.GetFiles(directoryPath.ToString());
        }

        public async Task<object> GetDir(object stuff)
        {
            return AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        }
        
        /// <summary>
        /// Returns all currently loaded files.
        /// </summary>
        /// <param name="optional"></param>
        /// <returns></returns>
        public async Task<object> GetFilesCount(object optional)
        {
            return _renamingController.GetFileCount();
        }

        public async Task<object> UpdateTagsStructure(string json)
        {
            return _renamingController.UpdateTagsStructure(json);
        }

        public async Task<object> UpdateTagsData(string json)
        {
            return _renamingController.UpdateTagsData(json);
        }

        /// <summary>
        /// Sets all global renaming options that the user has chosen.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<object> SetOptions(string config)
        {
            return null;
        }
        
        /// <summary>
        /// Performes the actual on-disk renaming of files, taking into account all user preferences.
        /// This overload is for when all user options are saved into variables on the backend.
        /// </summary>
        /// <returns>Return success or error</returns>
        public async Task<object> RenameFiles()
        {
            return _renamingController.RenameFiles();
        }

        public void AddTag(string name)
        {
            IUnitOfWork database = new UnitOfWork();
            database.Tags.Add(new Tag() { Name = name });
            database.SaveChanges();
        }

        private void Load(params IReflowController[] reflowControllers)
        {
            this._components = new HashSet<IReflowController>();
            foreach (var component in reflowControllers)
            {
                this._components.Add(component);
            }
        }

        private static void PokeSingletons()
        {
            var a = NameBuilder.Instance.GetType();
        }
    }
}
#pragma warning restore 1998