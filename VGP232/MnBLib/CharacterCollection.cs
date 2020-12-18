using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace MnBLib
{
    public class CharacterCollection : List<Character>
    {
        public void AddCharacter(Character c)
        {
            this.Add(c);
        }

        public void ApplyChangesToCharacter(Character newChar, int index)
        {
            if (index > this.Count || index < 0 || this.Count == 0 || newChar == null)
            {
                return;
            }
            this[index] = newChar;

        }
        public void ApplyChangesToCharacter(Character newChar, string name)
        {
            for(int i = 0;i<this.Count;++i)
            {
                if (this[i].name == name)
                {
                    this[i] = newChar;
                    return;
                }
            }
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

        // LC: you mentioned that you want that custom format here, you'll need to do your own parsing like Assignment 1, 
        // using StreamReader read line and seperate the line by the '=' character, trim it and use some kind of dictionary 
        // or reflection to iterate through all the fields/properties to find where to set the value.
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

        public CharacterCollection()
        {

        }
    }
}
