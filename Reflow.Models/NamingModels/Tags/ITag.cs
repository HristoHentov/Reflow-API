﻿using System.Collections.Generic;
using ReflowModels.ViewModels;

namespace ReflowModels.NamingModels.Tags
{
    public interface ITag
    {
        string Name { get; }

        string ToString(string fileName, IDictionary<string, FileViewModel> files);
    }
}
