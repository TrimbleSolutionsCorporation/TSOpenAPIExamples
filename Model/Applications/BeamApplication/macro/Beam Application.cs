namespace Tekla.Technology.Akit.UserScript
{
    using Tekla.Structures;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Tekla Structures required class
    /// </summary>
    public class Script
    {
        /// <summary>
        /// Name of external model application to launch
        /// </summary>
        const string ApplicationName = "BeamApplication.exe";

        /// <summary>
        /// Main code to launch external application
        /// </summary>
        /// <param name="akit">Internal dialog kit</param>
        public static void Run(IScript akit)
        {
            var process = new Tekla.Structures.Internal.TeklaProcessExecuter();
            process.StartInfo.FileName = ApplicationName;
            process.Start();
        }
    }
}