﻿using System.IO;

namespace GitDataMiningTool
{
    internal class DefaultFileCopier : IFileCopier
    {
        public void CopyGenerateGitLogFileToPath(
            string source,
            string destination,
            string file)
        {
            var fileDestination = Path.Combine(destination, file);
            if (!File.Exists(fileDestination))
            {
                File.Copy(source, fileDestination);
            }
        }
    }
}
