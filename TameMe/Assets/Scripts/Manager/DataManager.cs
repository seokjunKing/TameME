using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PlayerData
{
    // 저장
    // 가장 마지막 활성화 된 체크포인트 지점 불러오기
    // 스테이지 넘버 1-1 => 1 1-2 => 2...
    // 세이브 x => 0
    public int stageNum = 0;

    // 호감도
    public int pointFox = 0;
    public int pointRose = 0;

}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public PlayerData nowPlayer = new PlayerData();

    public string path;

    private void Awake()
    {
        #region 싱글톤
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        #endregion

        path = Application.persistentDataPath + "/save";
        print(path);
    }
    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path, data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path);
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowPlayer = new PlayerData();
    }
}
