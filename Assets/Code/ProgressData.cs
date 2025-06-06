using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace ProgreaaAndDataNamespace
{
    public class ProgressAndSettings : MonoBehaviour
    {
        public static ProgressAndSettings Instance { get; private set; }

        public static int LevelCount { get; set; }
        public static int GoldCoinCounter { get; set; }
        public static int Quick { get; set; }
        public static int Hatchet { get; set; }
        public static int Bomb { get; set; }
        public static bool isVibroOn { get; set; }
        public static float volume { get; set; }
        public static bool isQuickOpen { get; set; }
        public static bool isHatchetOpen { get; set; }
        public static bool isBombOpen { get; set; }

        private string saveWay;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            saveWay = Application.persistentDataPath + "/gameProgress.dat";
        }

        public void SaveProgress()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = File.Create(saveWay);

            GameProgressData data = new GameProgressData();
            data.LevelCount = LevelCount++;
            data.GoldCoinCounter = GoldCoinCounter;
            data.Quik = Quick;
            data.Hatchet = Hatchet;
            data.Bomb = Bomb;
            data.isQuikOpen = isQuickOpen;
            data.isHatchetOpen = isHatchetOpen;
            data.isBombOpen = isBombOpen;
            data.isVibroOn = isVibroOn;
            data.volume = volume;

            formatter.Serialize(fileStream, data);
            fileStream.Close();
        }

        public void LoadProgress()
        {
            if (File.Exists(saveWay))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = File.Open(saveWay, FileMode.Open);

                GameProgressData data = (GameProgressData)formatter.Deserialize(fileStream);
                fileStream.Close();

                LevelCount = data.LevelCount;
                GoldCoinCounter = data.GoldCoinCounter;
                Quick = data.Hatchet;
                Hatchet = data.Hatchet;
                Bomb = data.Bomb;
                isBombOpen = data.isBombOpen;
                isHatchetOpen = data.isHatchetOpen;
                isQuickOpen = data.isQuikOpen;
                volume = data.volume;
                isVibroOn = data.isVibroOn;
            }
            else
            {
                LevelCount = 1;
                GoldCoinCounter = 1500;
                Quick = 0;
                Hatchet = 0;
                Bomb = 0;
                isBombOpen = false;
                isHatchetOpen = false;
                isQuickOpen = false;
                volume = 0.5f;
                isVibroOn = true;
            }
        }

        public void DeleteSave()
        {
            if (File.Exists(saveWay))
            {
                File.Delete(saveWay);
                Debug.Log("Сохранения удалены.");
            }
            else
            {
                Debug.LogWarning("Сохранения не найдены.");
            }
        }
    }

    [System.Serializable]
    public class GameProgressData
    {
        public int LevelCount;
        public int GoldCoinCounter;
        public int Quik;
        public int Hatchet;
        public int Bomb;
        public bool isQuikOpen;
        public bool isHatchetOpen;
        public bool isBombOpen;
        public bool isVibroOn;
        public float volume;
    }
}
