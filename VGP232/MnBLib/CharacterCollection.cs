using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace MnBLib
{
    class CharacterCollection : List<Character>
    {
        public void GenerateCharacter()
        {
            Character newChar = new Character();
            this.Add(newChar);
        }
        public void ApplyChangesToCharacter(Character newChar, int index)
        {
            if (index > this.Count || index < 0 || this.Count == 0 || newChar == null)
            {
                return;
            }
            this[index] = newChar;

        }
        public void RemoveCharacter(int index)
        {
            if (index > this.Count || index < 0 || this.Count == 0)
            {
                return;
            }
            this.RemoveAt(index);
        }
        public void RemoveCharacter(Character chr)
        {
            if (this.Count == 0)
            {
                return;
            }
            this.Remove(chr);
        }
        public bool SaveXMLCharacter(string path, int index)
        {
            if (index > this.Count || index < 0)
            {
                return false;
            }

            XmlSerializer xml = new XmlSerializer(typeof(Character));
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    xml.Serialize(writer, this[index]);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool LoadXMLCharacter(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Character));
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    this.Add((Character)xml.Deserialize(reader));
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        CharacterCollection()
        {

        }
    }
}
