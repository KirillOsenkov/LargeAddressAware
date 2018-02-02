using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using PEFile;
using SetLargeAddressAware.Properties;
using System;
using System.Resources;

namespace SetLargeAddressAware
{
    /// <summary>
    /// Represents an MSBuild task that can be run during a build.
    /// </summary>
    public sealed class SetLargeAddressAware : Task
    {
        public SetLargeAddressAware()
        {
            TaskResources = new ResourceManager(typeof(Strings));
        }

        /// <summary>
        /// Gets or sets the path to the assembly to modify.
        /// </summary>
        [Required]
        public string FilePath { get; set; }

        /// <inheritdoc cref="Task.Execute"/>
        public override bool Execute()
        {
            try
            {
                Log.LogMessageFromResources("MessageSettingFlag", FilePath);

                LargeAddressAware.SetLargeAddressAware(FilePath);
            }
            catch (Exception e)
            {
                Log.LogErrorFromException(e, showStackTrace: true);
            }

            return !Log.HasLoggedErrors;
        }
    }
}