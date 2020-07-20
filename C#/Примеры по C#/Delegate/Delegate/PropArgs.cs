using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class PropArgs : EventArgs
    {
        public string propName;
        public string oldValue;
        public string newValue;

        public PropArgs(string propName,string oldValue,string newValue)
        {
            this.propName = propName;
            this.oldValue = oldValue;
            this.newValue = newValue;
        }
    }
}
