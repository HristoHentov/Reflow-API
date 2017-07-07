using System.Collections.Generic;
using System.Linq;
using ReflowCore.Exchange;
using ReflowCore.Services;
using ReflowModels.EntityModels;
using System;

namespace ReflowCore.Controllers
{
    internal class RenamingController : IReflowController
    {
        private RenamingService service;
        private IExporter exporter;

        public RenamingController()
            :this(new JsonExporter(), new RenamingService())
        {
            
        }

        public RenamingController(IExporter exporter, RenamingService service)
        {
            this.exporter = exporter;
            this.service = service;
        }

        public void Initialize()
        {
            
        }

        public string GetTags()
        {
            IEnumerable<TagEntityModel> reflowTags = service.GetTags();
            return exporter.Export(reflowTags);
        }

        public string GetFilters()
        {
            var filters = service.GetFilters().ToList();
            return exporter.Export(filters);
        }

        public string GetFiles(string directoryPath)
        {
            try
            {
                var files = service.GetFileNamesByDir(directoryPath);
                service.FillCache(files);
                return exporter.Export(files.Values);
            }
            catch(Exception e)
            {
                return e.Message + "\n" + e.StackTrace;
            }
            
        }

        public string GetFileCount()
        {
            return exporter.Export(service.GetFileCount());
        }

        public string UpdateFiles(string attributesJson)
        {
            return exporter.Export(service.UpdateFiles(attributesJson));
        }

        public string RenameFiles()
        {
            return exporter.Export(service.RenameFiles());
        }

    }
}
