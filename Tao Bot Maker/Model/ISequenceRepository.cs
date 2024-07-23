using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Tao_Bot_Maker.Model
{
    public interface ISequenceRepository
    {
        IEnumerable<string> GetAllSequenceNames();
        bool RemoveSequence(string name);
        Task<Sequence> LoadSequenceAsync(string name, CancellationToken token);
        void SaveSequence(Sequence sequence, string name);
        Sequence GetSequence(string name);
    }
}
