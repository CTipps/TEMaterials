using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture
{
   public interface IMakeSound
    {
        string Name { get; }
        string Sound { get; }

        int GetAge();
    }
}
