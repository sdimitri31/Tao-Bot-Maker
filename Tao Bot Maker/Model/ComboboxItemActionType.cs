using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_Bot_Maker.Model
{
    public class ComboboxItemActionType
    {   
        public string DisplayText { get; set; }
        public object ActionTypeId { get; set; }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
