using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponLib
{
    // LC3: make this public
    public interface IJsonSerializable
    {
        public bool LoadJSON(string path);
        public bool SaveAsJSON(string path);

    }
}
