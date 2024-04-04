using UnityEngine;

namespace CMG
{

    public class SaveLoadManager : MonoBehaviour
    {
        // Save a float value
        public static void SaveFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
            Debug.Log($"Saved {key} with value {value}");
        }

        //Check if key exist
        public static bool KeyExist(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        // Load a float value
        public static float LoadFloat(string key, float defaultValue = 0.0f)
        {
            float value = PlayerPrefs.GetFloat(key, defaultValue);
            Debug.Log($"Loaded {key} with value {value}");
            return value;
        }

        // Save an integer value
        public static void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
            Debug.Log($"Saved {key} with value {value}");
        }

        // Load an integer value
        public static int LoadInt(string key, int defaultValue = 0)
        {
            int value = PlayerPrefs.GetInt(key, defaultValue);
            Debug.Log($"Loaded {key} with value {value}");
            return value;
        }

        // Save a string value
        public static void SaveString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
            Debug.Log($"Saved {key} with value {value}");
        }

        // Load a string value
        public static string LoadString(string key, string defaultValue = "")
        {
            string value = PlayerPrefs.GetString(key, defaultValue);
            Debug.Log($"Loaded {key} with value {value}");
            return value;
        }
    }
}
