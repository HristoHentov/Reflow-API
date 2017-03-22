using System.Threading.Tasks;

namespace ReflowCore.Reflow
{
    #pragma warning disable 1998
    /// <summary>
    /// Serves as an interface for the front end JS.
    /// </summary>
    public class ReflowController
    {
        /// <summary>
        /// Returns all tags that the app contains.
        /// </summary>
        /// <returns>JSON: Name, Options - OptionType, OptionName.</returns>
        public async Task<object> GetTags()
        {
            return null;
        }
        /// <summary>
        /// Returns all filters for selecting files.        
        /// </summary>
        /// <returns>JSON: FilterName, FilterOptions </returns>
        public async Task<object> GetFilters()
        {
            return null;
        }
        /// <summary>
        /// Gets all files in a given directory (Excluding folders)
        /// </summary>
        /// <param name="directoryPath">Path to the directory to get the files from.</param>
        /// <returns>JSON: CustomFile (Check ReflowFile class to see fields)</returns>
        public async Task<object> GetFilesInDirectory(object directoryPath)
        {
            return null;
        }
        /// <summary>
        /// Updates filenames (UI only), based on an object[] containing the options that the attributes use.
        /// </summary>
        /// <param name="tagAttributes">An array of KVP, containg the name of the attribute and its parameters</param>
        /// <returns>JSON: Old Filename, NewFilename</returns>
        public async Task<object> UpdateFileNames(params object[] tagAttributes)
        {
            return null;
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
        public async Task<object> Rename()
        {
            return null;
        }
        /// <summary>
        /// Performes the actual on-disk renaming of files, taking into account all user preferences.
        /// This overload is gets all user options from the frontend.
        /// </summary>
        /// <returns>Return success or error</returns>
        public async Task<object> Rename(string directoryPath, string fileList)
        {
            return null;
        }
    }
}
#pragma warning restore 1998