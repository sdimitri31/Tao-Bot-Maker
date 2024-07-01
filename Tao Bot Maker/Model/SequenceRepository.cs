using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    public class SequenceRepository : ISequenceRepository
    {
        private readonly string sequencesFolderPath = "Sequences";

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

                Sequence sequence = await Task.Run(() =>
                {
                    try
                    {
                        return GetSequence(name);
                    }
                    catch (Exception ex)
                    {
                        loadingException = new Exception(ex.Message);
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
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Converters = new List<JsonConverter> { new ActionConverter() }

            });
            File.WriteAllText(filePath, json);
        }

        public Sequence GetSequence(string name)
        {
            if (name == null)
            {
                string errorMessage = string.Format(Resources.Strings.ErrorMessageEmptySequenceName);
                throw new FileNotFoundException(errorMessage);
            }

            string filePath = Path.Combine(sequencesFolderPath, $"{name}.json");
            if (!File.Exists(filePath))
            {
                string errorMessage = string.Format(Resources.Strings.ErrorMessageFileNotFound, filePath);
                throw new FileNotFoundException(errorMessage);
            }

            try
            {
                string json = File.ReadAllText(filePath);

                Sequence sequence = JsonConvert.DeserializeObject<Sequence>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Converters = new List<JsonConverter> { new ActionConverter() }
                });

                return sequence ?? throw new Exception();
            }
            catch
            {
                string errorMessage = string.Format(Resources.Strings.ErrorMessageCorruptedSequenceFile, name);
                throw new Exception(errorMessage);
            }
        }
    }
}
