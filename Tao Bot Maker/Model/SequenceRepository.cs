using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Tao_Bot_Maker.Model
{
    public class SequenceRepository : ISequenceRepository
    {
        private string sequencesFolderPath = "Sequences";

        public SequenceRepository()
        {
            if (!Directory.Exists(sequencesFolderPath))
            {
                Directory.CreateDirectory(sequencesFolderPath);
            }
        }
        public IEnumerable<string> GetAllSequenceNames()
        {
            List<string> sequenceNames = new List<string>();
            foreach (var file in Directory.GetFiles(sequencesFolderPath, "*.json"))
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                sequenceNames.Add(fileName);
            }
            return sequenceNames;
        }

        public bool RemoveSequence(string name)
        {
            if (name == null) return false;

            string filePath = Path.Combine(sequencesFolderPath, $"{name}.json");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

        public Sequence GetSequence(string name)
        {
            if (name == null) return null;

            string filePath = Path.Combine(sequencesFolderPath, $"{name}.json");
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<Sequence>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                } catch
                {
                    throw new Exception("Corrupted sequence file.");
                }
            }
            return null;
        }

        public void SaveSequence(Sequence sequence, string name)
        {
            string filePath = Path.Combine(sequencesFolderPath, $"{name}.json");
            string json = JsonConvert.SerializeObject(sequence, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(filePath, json);
        }

    }
}
