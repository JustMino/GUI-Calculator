using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator
{
    public interface ISolve
    {
        void Accumulate(string s);
        void Clear();
        double Solve();
    }
}
