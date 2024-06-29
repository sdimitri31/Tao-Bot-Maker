using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<Sequence> LoadSequenceAsync(string name, CancellationToken token)
        {
            try
            {
                token.ThrowIfCancellationRequested();
                Exception loadingException = null;

                if (name == null) return null;

                Sequence sequence = await Task.Run(() =>
                {
                    string filePath = Path.Combine(sequencesFolderPath, $"{name}.json");
                    if (!File.Exists(filePath))
                    {
                        loadingException = new Exception($"Cannot locate file at : \"{filePath}\"");
                        return null;
                    }

                    try
                    {
                        string json = File.ReadAllText(filePath);
                        return JsonConvert.DeserializeObject<Sequence>(json, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto,
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                    }
                    catch
                    {
                        loadingException = new Exception($"Cannot load sequence \"{name}\", file is corrupted");
                        return null;
                    }
                }, token);

                if (loadingException != null)
                {
                    throw loadingException;
                }

                return sequence;
            }
            catch (OperationCanceledException ex)
            {
                throw new OperationCanceledException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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

        public Sequence GetSequence(string name)
        {
            if (name == null) return null;

            string filePath = Path.Combine(sequencesFolderPath, $"{name}.json");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Cannot locate file at : \"{filePath}\"");
            }

            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Sequence>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            catch
            {
                throw new Exception($"Cannot load sequence \"{name}\", file is corrupted");
            }
        }
    }
}
