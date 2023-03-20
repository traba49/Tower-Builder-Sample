using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core
{
    public static class SavingSystem
    {
        static SaveData _savedata;

        public static SaveData LoadedData()
        {
            if (_savedata == null)
            {
                _savedata = Loadgame();
            }
            return _savedata;
        }

        public static void Savegame(SaveData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/towers.save";
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

            formatter.Serialize(stream, data);
            stream.Close();

            _savedata = data;
        }

        static SaveData Loadgame()
        {
            string path = Application.persistentDataPath + "/towers.save";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                SaveData data = formatter.Deserialize(stream) as SaveData;
                stream.Close();

                return data;
            }
            else
            {
                return Newgame();
            }
        }

        static SaveData Newgame()
        {
            SaveData data = new SaveData();
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/towers.save";
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, data);
            stream.Close();

            return data;
        }
    }
}
