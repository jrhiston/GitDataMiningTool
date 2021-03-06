﻿using GitDataMiningTool.Pipes;
using System;
using System.Collections.Generic;
using System.IO;

namespace GitDataMiningTool.Commands
{
    internal class DataAnalysisFileReaderCommand : CommandResultVisitorBase
    {
        private readonly string _fileToRead;
        private readonly DataAnalysisResultType _type;
        private readonly RepositoryDestination _repositoryDestination;

        public DataAnalysisFileReaderCommand(
            string fileToRead,
            DataAnalysisResultType type,
            RepositoryDestination repositoryDestination)
        {
            if (fileToRead == null)
                throw new ArgumentNullException(nameof(fileToRead));

            _fileToRead = fileToRead;
            _type = type;
            _repositoryDestination = repositoryDestination;
        }

        public override IEnumerator<ICommandResult> GetEnumerator()
        {
            yield return new DataAnalysisResult(
                File.ReadAllText(Path.Combine(_repositoryDestination.ToString(), _fileToRead)),
                _type);
        }
    }
}
