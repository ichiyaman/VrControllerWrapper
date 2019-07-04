using UnityEngine;
using System.Collections.Generic;

namespace _MyProject.Script.Common
{
    [System.Serializable]
    public static class Game
    {
        public const string KeyPlayerProf = "PlayerProf";
        // ---- InGame ----         
        public const int MaxStage = 3; 

        // ---- PlayFab ----         
        public const int LeaderboardGetCount = 10; 
        public const string PlayfabKeyStatsTotalScore = "TotalScore";
        public const string PrefPlayerName = "PlayerName";
        public const string PrefPlayerGuid = "PlayerGuid";
        public const string PrefStageBestScore = "_BestScore";
        public const int ScoreLimit = 999999999;
        public const string PlayerfabTitleId = "abcd";
        public const string PlayerfabCustomId = "abcd";
        

        // ---- ゲームの状態(scene) ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- 
        public enum Type
        {
            Clip,
            Youtbue,
        }
        public enum Difficulity
        {
            Easy,
            Normal,
            Hard,
            Ultimate,
        }
        // ---- ゲームの状態(scene) ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- 
        public enum Stat
        {
            None,
            Init,
            Title,
            StartGame,
            NewWave,
            InGame,
            Pause,
            Result,
            GameOver,
            Quit,
#if RELEASE
#else
            Debug,
#endif
        }
#if RELEASE
        public const bool IsDebug = false; 
#else
        public const bool IsDebug = true;

        public enum DebugStat
        {
            None,
            Normal,
            UI,                    // 敵でない
            Tool,                  // 敵でない。弾でない
        }

        public enum DebugBit
        {
            None,
            Invincible,
            AllStage,
            EnableDebugObject, 
            Dying,                 // 瀕死
            NoSave,                // 保存しない
            ForceInitPlayerPrefs,  // 強制初期化
            NoYoutube,
        }
#endif
        public struct MusicData {
            [Tooltip("最初のリズムまでの時間(秒)\n※設定必須")]
            public float firstBeatDelay;
            public AudioClip clip;
        }
        
        // ---- Playerの状態 ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ----
        [System.Serializable]
        public struct PlayerProf
        {
            public string Name; // ToDo:起動時の選択画面で名前入力させよとのこと
            public int HighScore;
            public int Score;
            public int Damage;
            public int HighStage;
            public Rank[] AryHighRank;
            public PlayerPowerUpStat Ppus ; 
        }
        [System.Serializable]
        public struct PlayerPowerUpStat
        {
            public uint LevelScale;
            public uint LevelSpeed;
            public bool IsPierce;
        }
        public enum Rank
        {
            S, // damage =  0 
            A, // damage =  1 - 33
            B, // damage = 34 - 66
            C, // damage = 67 -100
        }
    }
}
