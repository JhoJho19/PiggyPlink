using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProgressAndDataNamespace
{
    public class ProgressData : MonoBehaviour
    {
        public static ProgressData Instance { get; private set; }

        public static int LevelCount { get; set; }
        public static int GoldCoinCounter { get; set; } = 100;
        public static int DoubleCoins { get; set; }
        public static int DoubleBalls { get; set; }
        public static int FasterBonus { get; set; }
        public static bool isYellowBakkOpen { get; set; } = true;
        public static bool isGreenBallOpen { get; set; }
        public static bool isOrangeBallOpen { get; set; }
        public static bool isBlueBallOpen { get; set; }
        public static bool isPinkBallOpen { get; set; }
        public static bool isVioletBallOpen { get; set; }
        public static bool isOrange2BallOpen { get; set; }
        public static bool isRedBallOpen { get; set; }

        public static int currentSkinIndex { get; set; }


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
                return;
            }

            saveWay = Path.Combine(Application.persistentDataPath, "gameProgress.dat");
        }

        public void SaveProgress()
        {
            var formatter = new BinaryFormatter();
            using (var stream = File.Create(saveWay))
            {
                var data = new GameProgressData
                {
                    LevelCount = LevelCount++,
                    GoldCoinCounter = GoldCoinCounter,
                    DoubleCoins = DoubleCoins,
                    DoubleBalls = DoubleBalls,
                    FasterBonus = FasterBonus,
                    isYellowBakkOpen = isYellowBakkOpen,
                    isGreenBallOpen = isGreenBallOpen,
                    isOrangeBallOpen = isOrangeBallOpen,
                    isBlueBallOpen = isBlueBallOpen,
                    isPinkBallOpen = isPinkBallOpen,
                    isVioletBallOpen = isVioletBallOpen,
                    isOrange2BallOpen = isOrange2BallOpen,
                    isRedBallOpen = isRedBallOpen
                };

                formatter.Serialize(stream, data);
            }
        }

        public void LoadProgress()
        {
            if (File.Exists(saveWay))
            {
                var formatter = new BinaryFormatter();
                using (var stream = File.OpenRead(saveWay))
                {
                    var data = (GameProgressData)formatter.Deserialize(stream);

                    LevelCount = data.LevelCount;
                    GoldCoinCounter = data.GoldCoinCounter;
                    DoubleCoins = data.DoubleCoins;
                    DoubleBalls = data.DoubleBalls;
                    FasterBonus = data.FasterBonus;
                    isYellowBakkOpen = data.isYellowBakkOpen;
                    isGreenBallOpen = data.isGreenBallOpen;
                    isOrangeBallOpen = data.isOrangeBallOpen;
                    isBlueBallOpen = data.isBlueBallOpen;
                    isPinkBallOpen = data.isPinkBallOpen;
                    isVioletBallOpen = data.isVioletBallOpen;
                    isOrange2BallOpen = data.isOrange2BallOpen;
                    isRedBallOpen = data.isRedBallOpen;
                }
            }
            else
            {
                // начальные значения по умолчанию
                LevelCount = 1;
                GoldCoinCounter = 1500;
                DoubleCoins = 0;
                DoubleBalls = 0;
                FasterBonus = 0;
                isYellowBakkOpen = true;
                isGreenBallOpen = false;
                isOrangeBallOpen = false;
                isBlueBallOpen = false;
                isPinkBallOpen = false;
                isVioletBallOpen = false;
                isOrange2BallOpen = false;
                isRedBallOpen = false;
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
        public int DoubleCoins;
        public int DoubleBalls;
        public int FasterBonus;
        public bool isYellowBakkOpen;
        public bool isGreenBallOpen;
        public bool isOrangeBallOpen;
        public bool isBlueBallOpen;
        public bool isPinkBallOpen;
        public bool isVioletBallOpen;
        public bool isOrange2BallOpen;
        public bool isRedBallOpen;
    }
}
