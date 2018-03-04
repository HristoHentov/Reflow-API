using System.Collections.Generic;
using System.Linq;
using ReflowCore.Exchange;
using ReflowCore.Services;
using ReflowModels.EntityModels;
using System;
using Logger;
using Logger.Contract;

namespace ReflowCore.Controllers
{
    internal class RenamingController : IReflowController
    {
        private readonly RenamingService _service;
        private readonly IExporter _exporter;
        private readonly ILog _log;

        public RenamingController()
            :this(null, new JsonExporter(), new RenamingService())
        {  
        }

        public RenamingController(ILog log)
           : this(log, new JsonExporter(), new RenamingService())
        {
        }

        public RenamingController(ILog log, IExporter exporter, RenamingService service)
        {
            this._log = log ?? new ConsoleLogger(); // Until we get DI working and find a way to call ctors from electron.
            this._exporter = exporter;
            this._service = service;
            this._service.Log = _log; // Until we have DI and some Singleton/Factory
        }

        public void Initialize()
        {
            
        }

        public string GetTags()
        {
            IEnumerable<Tag> reflowTags = _service.GetTags();
            return _exporter.Export(reflowTags);
        }

        public string GetFilters()
        {
            var filters = _service.GetFilters().ToList();
            return _exporter.Export(filters);
        }

        public string GetFiles(string directoryPath)
        {
            try
            {
                var files = _service.GetFileNamesByDir(directoryPath);
                _service.FillCache(files);
                return _exporter.Export(files.Values);
            }
            catch(Exception e)
            {
                return e.Message + "\n" + e.StackTrace;
            }
            
        }

        public string GetFileCount()
        {
            return _exporter.Export(_service.GetFileCount());
        }

        public string RenameFiles()
        {
            return _exporter.Export(_service.RenameFiles());
        }

        public string UpdateTagsStructure(string json)
        {
            return _exporter.Export(_service.UpdateTagsStructureInternal(json));
        }

        public string UpdateTagsData(string json)
        {
            return _exporter.Export(_service.UpdateTagsDataInternal(json));
        }
    }
}
