﻿using FgisApplicationReaderLib.Models;
using XmlStreamReaderLib;

namespace FgisApplicationReaderLib
{
    public class FgisApplicationReader
    {
        readonly string _path;
        
        public FgisApplicationReader(string path)
        {
            _path = CheckFileExists(path);
        }

        string CheckFileExists(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
            return path;
        }

        public IEnumerable<FgisRecord> Records()
        {
            using (var stream = new FileStream(_path, FileMode.Open))
            using (var reader = new XmlStreamReader<FgisApplication, FgisRecord>(stream))
            {
                return reader.Records();
            }
        }
    }
}
