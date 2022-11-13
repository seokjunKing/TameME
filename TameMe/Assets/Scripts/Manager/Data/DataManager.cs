using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PlayerData
{
    // ����
    // ���� ������ Ȱ��ȭ �� üũ����Ʈ ���� �ҷ�����
    // ���̺� x => 0
    public int stageNum = 0;

    // ȣ����
    public int pointFox = 0;
    public int pointRose = 0;

}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public PlayerData nowPlayer = new PlayerData();
    public int nowSlot; // ���� ���Թ�ȣ

    public string path;

    private void Awake()
    {
        #region �̱���
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
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}
