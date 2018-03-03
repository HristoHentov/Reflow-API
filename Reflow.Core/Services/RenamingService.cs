using System;
using System.Collections.Generic;
using System.IO;
using Logger.Contract;
using Reflow.Data;
using Reflow.Data.Contracts;
using ReflowCore.Cache;
using ReflowCore.Exchange;
using ReflowCore.Utility;
using ReflowModels.EntityModels;
using ReflowModels.Naming;
using ReflowModels.NamingModels.Tags;
using ReflowModels.ViewModels;

namespace ReflowCore.Services
{
    internal class RenamingService
    {
        private readonly IUnitOfWork _database;
        private readonly IImporter _importer;

        public RenamingService()
        {
            this._database = new UnitOfWork();
            this._importer = new JsonImporter();
        }

        internal ILog Log { get; set; }

        internal IDictionary<string, FileViewModel> GetFileNamesByDir(string path)
        {
            try
            {
                var inFiles = Directory.EnumerateFiles(path);
                var files = new Dictionary<string, FileViewModel>();

                var index = 0;
                foreach (var file in inFiles)
                {
                    var fileName = Utils.GetFullFilename(file);
                    files.Add(fileName[0] + "." + fileName[1], new FileViewModel()
                    {
                        Key = index++,
                        OriginalName = fileName[0],
                        NewName = fileName[0],
                        Type = fileName[1] ?? "NONE",
                        Size = GetFileSize(file),
                        Filtered = false
                    });
                }

                return files;
            }
            catch (Exception ex)
            {
                Log.Fatal($"Failed parsing files in {path}. Please check names. Exception message: {ex.Message}");
                throw;
            }
        }

        internal IEnumerable<Tag> GetTags()
        {
            return _database.Tags.Entities;
        }

        public IEnumerable<Filter> GetFilters()
        {
            return _database.Filters.Entities;
        }

        private string GetFileSize(string filePath)
        {
            long chunk = 1024L;
            long oneKb = chunk;
            long oneMb = chunk * oneKb;
            long oneGb = chunk * oneMb;
            long oneTb = chunk * oneGb;

            var size = double.Parse(new FileInfo(filePath).Length.ToString());
            if (size < 0L)
                throw new ArgumentException("Negative file size!");
            if (size >= 0L && size <= oneKb)
                return $"{(int)size / oneKb} KB";
            if (size > oneKb && size <= oneMb)
                return $"{(int)size / oneKb} KB";

            if (size > oneMb && size <= oneGb)
                return $"{size / oneMb:f2} MB";
            if (size > oneGb && size <= oneTb)
                return $"{size / oneGb:f2} GB";
            if (size > oneGb && size <= oneTb)
                return $"{size / oneTb:f2} TB";

            return "1+ PB";
        }

        public void FillCache(IDictionary<string, FileViewModel> files)
        {
            FilesCache.Files = new Dictionary<string, FileViewModel>(files);
        }

        public int GetFileCount()
        {
            return FilesCache.Files.Count;
        }

        public IDictionary<string, string> UpdateFiles(string attributesJson)
        {
            Log.Info("Started resolving tags.");
            NameBuilder nameBuilder = new NameBuilder
            {
                Tags = this.GetNameBuilderTags(attributesJson)
            };

            var res = nameBuilder.Resolve(FilesCache.Files);
            Log.Info("Resolving tags finished successfully.");
            return res;
        }

        private ICollection<ITag> GetNameBuilderTags(string json)
        {
            var cs = new List<ITag> {_importer.Import(json)};
            return cs;
        }

        public string RenameFiles()
        {
            foreach (var file in FilesCache.Files)
            {
                RenameFile(file.Value.OriginalName, file.Value.NewName, file.Value.Type);
            }

            return "Success";
        }

        private bool RenameFile(string oldName, string newName, string fileType)
        {
            try
            {
                System.IO.File.Move
                           (Path.Combine(FilesCache.WorkingDirectory, oldName, fileType),
                            Path.Combine(FilesCache.WorkingDirectory, newName, fileType));
            }
            catch (Exception e)
            {
                Log.Error($"Failed renaming file {oldName} to {newName}. FileType {fileType}. Exception Message: {e.Message}");
                return false;
            }
            return true;
        }
    }
}
