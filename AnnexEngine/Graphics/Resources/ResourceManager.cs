using System;
using System.Collections.Generic;
using System.IO;

namespace AnnexEngine.Graphics.Resources
{
    /// <summary>
    /// Manages a collection of resources.
    /// </summary>
    /// <typeparam name="T">The type of resources for the class to manage.</typeparam>
    public class ResourceManager<T>
    {
        /// <summary>
        /// The collection of resources.
        /// </summary>
        private Dictionary<string, T> _resources;

        /// <summary>
        /// Loads all the resources from a given directory, and all subsequent sub-directories.
        /// </summary>
        /// <param name="baseDirectory">The directory to load resources from.</param>
        /// <param name="resourceLoader">The method which handles loading a resource from a filepath.</param>
        /// <param name="filepathValidator">The condition for a file to be loaded or not. If no validator is given, all files are loaded as a resource.</param>
        public void LoadFiles(string baseDirectory, Func<string, T> resourceLoader, Func<string, bool> filepathValidator = null)
        {
            // Initialize the collection of resources if it hasn't been already.
            if (this._resources == null) {
                this._resources = new Dictionary<string, T>();
            }
            
            // TODO: Ensure that the path is a valid directory.
            
            // Go through every file in the given directory.
            foreach (string filepath in Directory.GetFiles(baseDirectory, "*", SearchOption.AllDirectories)) {
                // Make sure the file is accepted by the validator unless the validator is null.
                if (filepathValidator == null || filepathValidator.Invoke(filepath)) {
                    // Retrieve the relative path of the file, and add the resource to the collection with the relative path as the key.
                    string relativePath = filepath.Remove(0, baseDirectory.Length);
                    this._resources.Add(relativePath, resourceLoader.Invoke(filepath));
                }
            }
        }

        /// <summary>
        /// Retrieves a resource with the given path.
        /// </summary>
        /// <param name="resourcePath">The relative path of the resource when it was loaded.</param>
        /// <returns></returns>
        public T GetResource(string resourcePath)
        {
            // If the collection contains the resource, return it.
            if (this._resources.ContainsKey(resourcePath)) {
                return this._resources[resourcePath];
            }

            // Otherwise, return the default value of the type.
            return default(T);
        }
    }
}
