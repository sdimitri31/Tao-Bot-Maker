using System.Collections.Generic;

namespace Tao_Bot_Maker.Model
{
    public interface ISequenceRepository
    {
        IEnumerable<string> GetAllSequenceNames();
        void RemoveSequence(string name);
        Sequence GetSequence(string name);
        void SaveSequence(Sequence sequence, string name);
    }
}
