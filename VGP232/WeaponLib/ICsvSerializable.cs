using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponLib
{
    // LC3: make this public
    public interface ICsvSerializable
    {
        public bool LoadCSV(string path);
        public bool SaveAsCSV(string path);
    }
}
