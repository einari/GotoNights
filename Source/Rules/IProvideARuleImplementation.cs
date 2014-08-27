using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules
{
    public interface IProvideARuleImplementation<out TImp>
    {
        TImp GetImplementation();
    }
}
