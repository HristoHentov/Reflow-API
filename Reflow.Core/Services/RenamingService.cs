using System;
using System.Collections.Generic;
using System.IO;
using Reflow.Data;
using Reflow.Data.Contracts;
using ReflowCore.Utility;
using ReflowModels;
using ReflowModels.ViewModels;

namespace ReflowCore.Services
{
    internal class RenamingService
    {
        private readonly IUnitOfWork database;

        public RenamingService()
        {
            this.database = new UnitOfWork();
        }
        internal IDictionary<string, FileViewModel> GetFileNamesByDir(string path)
        {
            var inFiles = Directory.EnumerateFiles(path);
            var files = new Dictionary<string, FileViewModel>();
            foreach (var file in inFiles)
            {
                var fileName = Utils.GetFullFilename(file);
                files.Add(fileName[0] + "." + fileName[1], new FileViewModel()
                {
                    Name = fileName[0],
                    Type = fileName[1],
                    Size = GetFileSize(file)
                });
            }

            return files;
        }

        internal IEnumerable<Tag> GetTags()
        {
            return database.Tags.Entities;
        }

        public IEnumerable<Filter> GetFilters()
        {
            return database.Filters.Entities;
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
    }
}
