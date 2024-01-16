using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace BaseGame.Data
{
    public class DataHelper
    {
        public static void Save<T>(T data, string filePath)
        {
            var path = Path.Combine(Application.persistentDataPath, filePath);
            var jsonData = JsonConvert.SerializeObject(data);
            var bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
            // Encoding.Convert(Encoding.UTF8, Encoding.Unicode, bytes);

            try
            {
                File.WriteAllBytes(path, bytes);
            }
            catch (Exception e) 
            {
                Debug.LogError("Error catched: "+ e);
            }
        }

        public static T Load<T>(string filePath) where T : class
        {
            var path = Path.Combine(Application.persistentDataPath, filePath);
            if (!File.Exists(path))
            {
                Debug.Log(filePath + "isn't exists");
                return null;
            }
            else
            {
                try
                {
                    var bytes = File.ReadAllBytes(path);
                    var jsonData = System.Text.Encoding.UTF8.GetString(bytes);
                    var data = JsonConvert.DeserializeObject<T>(jsonData);

                    return data;
                } 
                catch (Exception e)
                {
                    Debug.LogError("Error catched: "+ e);
                    return null;
                }
            }
        }

        public static void Delete(string filePath)
        {
            var path = Path.Combine(Application.persistentDataPath, filePath);
            if (!File.Exists(path))
            {
                Debug.Log(filePath + "isn't exists");
                return;
            }
            File.Delete(path);
        }
    }
}
