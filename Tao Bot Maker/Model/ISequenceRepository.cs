using System.Collections.Generic;

namespace Tao_Bot_Maker.Model
{
    public interface ISequenceRepository
    {
        IEnumerable<string> GetAllSequenceNames();
        bool RemoveSequence(string name);
        Sequence LoadSequence(string name);
        void SaveSequence(Sequence sequence, string name);
    }
}
