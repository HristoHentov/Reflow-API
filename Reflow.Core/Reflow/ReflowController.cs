using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reflow.Data;
using Reflow.Data.Contracts;
using ReflowCore.Controllers;
using ReflowModels.EntityModels;
using System;
using System.IO;
using Logger;
using Logger.Contract;

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
        /// <summary>
        /// Updates filenames (UI only), based on a JSON containing the attributes and their options.
        /// </summary
        /// <param name="attributesJson">An array of KVP, containg the name of the attribute and its parameters</param>
        /// <returns>JSON: Old Filename, NewFilename</returns>
        public string UpdateFiles(string attributesJson)
        {
            return _renamingController.UpdateFiles(attributesJson);
        }
        /// <summary>
        /// Updates filenames (UI only), based on an JSON, containing the options that the attributes use.
        /// </summary>
        /// <param name="newNames">JSON describing the attribute name and its options.</param>
        /// <returns></returns>
        public async Task<object> UpdateFileNames(string newNames)
        {
            return null;
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
            database.Tags.Add(new TagEntityModel() {Name = name});
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

    }
}
#pragma warning restore 1998