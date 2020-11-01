using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2b
{
    // LC3: make this public
    interface ICsvSerializable
    {
        bool LoadCSV(string path);
        bool SaveAsCSV(string path);
    }
}
