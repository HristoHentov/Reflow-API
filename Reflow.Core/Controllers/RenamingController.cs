using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ReflowCore.Exchange;
using ReflowCore.Services;
using ReflowModels;

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
            IEnumerable<Tag> reflowTags = service.GetTags();
            return exporter.Export(reflowTags);
        }

        public string GetFilters()
        {
            throw new System.NotImplementedException();
        }

        public string GetFiles(string directoryPath)
        {
            var files = service.GetFileNamesByDir(directoryPath);
            return exporter.Export(files);
        }
    }
}
