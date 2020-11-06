using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponLib
{
    // LC3: make this public
    public interface ICsvSerializable
    {
        bool LoadCSV(string path);
        bool SaveAsCSV(string path);
    }
}
