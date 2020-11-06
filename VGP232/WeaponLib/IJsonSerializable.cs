using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponLib
{
    // LC3: make this public
    public interface IJsonSerializable
    {
        bool LoadJSON(string path);
        bool SaveAsJSON(string path);

    }
}
