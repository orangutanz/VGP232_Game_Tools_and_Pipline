using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2b
{
    // LC3: make this public
    interface IJsonSerializable
    {
        bool LoadJSON(string path);
        bool SaveAsJSON(string path);

    }
}
