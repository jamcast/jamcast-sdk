using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Jamcast.SDK.BuildTasks
{
    public class MakePlugin : Task
    {
        [Required]
        public string ManifestPath { get; set; }

        [Required]
        public string OutputPath { get; set; }

        public override bool Execute()
        {
            string dir = Path.GetDirectoryName(this.ManifestPath);
            string assemblyFileName = null;
            var files = getFileList(out assemblyFileName);
            var zipPath = this.OutputPath;
            using(var fs = File.Create(zipPath))
            {
                using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Create))
                {                    
                    foreach (var file in files)
                    {
                        var entry = zip.CreateEntry(file);
                        using (var stream = entry.Open())
                        using (var writer = new BinaryWriter(stream))
                        {
                            writer.Write(File.ReadAllBytes(Path.Combine(dir, file)));
                        }
                    }
                }
            }            
            return true;
        }

        public string[] getFileList(out string assemblyFileName)
        {            
            XmlDocument doc = new XmlDocument();
            doc.Load(this.ManifestPath);
            XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
            mgr.AddNamespace("ns", "http://sdstechnologies.com/jamcast/plugin/manifest/2.0");
            List<String> files = new List<string>();
            files.Add("plugin.xml");
            XmlNode node = doc.SelectSingleNode("//ns:assemblyFileName", mgr);
            assemblyFileName = node.InnerText;
            files.Add(assemblyFileName);
            foreach(XmlNode n in doc.SelectNodes("//ns:files/ns:file", mgr))
            {
                files.Add(n.InnerText);
            }
            return files.ToArray();
        }
    }
}