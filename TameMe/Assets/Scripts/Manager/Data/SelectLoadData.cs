using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class SelectLoadData : MonoBehaviour
{
    public Text[] slotText;		// 슬롯버튼 아래에 존재하는 Text들
    public Text[] slotText2;

    public GameObject LoadSlotPanel;
    public GameObject NewSlotPanel;

    public GameObject newGame;

    bool[] savefile = new bool[3];	// 세이브파일 존재유무 저장

    void Start()
    {
        // 슬롯별로 저장된 데이터가 존재하는지 판단.
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))	// 데이터가 있는 경우
            {
                savefile[i] = true;			// 해당 슬롯 번호의 bool배열 true로 변환
                DataManager.instance.nowSlot = i;	// 선택한 슬롯 번호 저장
                DataManager.instance.LoadData();	// 해당 슬롯 데이터 불러옴
                if (DataManager.instance.nowPlayer.stageNum > 5)
                {
                    slotText[i].text = "Chapter1-" + (DataManager.instance.nowPlayer.stageNum - 5);
                    slotText2[i].text = "Chapter1-" + (DataManager.instance.nowPlayer.stageNum - 5);
                }
                else if (DataManager.instance.nowPlayer.stageNum == 2)
                {
                    slotText[i].text = "Prologue";
                    slotText2[i].text = "Prologue";
                }
                else if (DataManager.instance.nowPlayer.stageNum == 3)
                {
                    slotText[i].text = "Prologue";
                    slotText2[i].text = "Prologue";
                }
                else if (DataManager.instance.nowPlayer.stageNum == 4)
                {
                    slotText[i].text = "Prologue";
                    slotText2[i].text = "Prologue";
                }
                else if (DataManager.instance.nowPlayer.stageNum == 5)
                {
                    slotText[i].text = "Prologue";
                    slotText2[i].text = "Prologue";
                }
                else if (DataManager.instance.nowPlayer.stageNum == 1)
                {
                    slotText[i].text = "새 게임";
                    slotText2[i].text = "새 게임";
                }
            }
            else	// 데이터가 없는 경우
            {
                slotText[i].text = "새 게임";
                slotText2[i].text = "새 게임";
            }
        }
        // 불러온 데이터를 초기화시킴.(버튼에 닉네임을 표현하기위함이었기 때문)
        DataManager.instance.DataClear();
    }

    public void Slot(int number)	// 슬롯의 기능 구현
    {
        DataManager.instance.nowSlot = number;	// 슬롯의 번호를 슬롯번호로 입력함.

        if (savefile[number])	// bool 배열에서 현재 슬롯번호가 true라면 = 데이터 존재한다는 뜻
        {
            DataManager.instance.LoadData();	// 데이터를 로드하고
            GoGame(DataManager.instance.nowPlayer.stageNum);	// 게임씬으로 이동
        }
        else	// bool 배열에서 현재 슬롯번호가 false라면 데이터가 없다는 뜻
        {
            GoGame(2);	// 플레이어 닉네임 입력 UI 활성화
        }
    }

    public void newSlot(int number)	// 슬롯의 기능 구현
    {
        DataManager.instance.nowSlot = number;	// 슬롯의 번호를 슬롯번호로 입력함.

        if (savefile[number])	// bool 배열에서 현재 슬롯번호가 true라면 = 데이터 존재한다는 뜻
        {
            newGame.SetActive(true);// 기존에 저장되어 있는 데이터를 삭제하시겠습니까?
        }
        else	// bool 배열에서 현재 슬롯번호가 false라면 데이터가 없다는 뜻
        {
            GoGame(2);
        }
    }

    public void GoGame(int num)	// 게임씬으로 이동
    {
        if (!savefile[DataManager.instance.nowSlot])	// 현재 슬롯번호의 데이터가 없다면
        {
            DataManager.instance.SaveData(); // 현재 정보를 저장함.
            SceneManager.LoadScene("EventScene"); // 게임씬으로 이동
        }
        else    // 데이터가 있으면
        {
            SceneManager.LoadScene(num);    // 해당 씬으로 이동
        }
        
    }
    public void OnButtonNewSlot()
    {
        NewSlotPanel.SetActive(true);
    }
    public void OffButtonNewSlot()
    {
        NewSlotPanel.SetActive(false);
    }
    public void OnButtonLoadSlot()
    {
        LoadSlotPanel.SetActive(true);
    }
    public void OffButtonLoadSlot()
    {
        LoadSlotPanel.SetActive(false);
    }
    public void ClearLoadData() // 예
    {
        GoGame(2);	// 게임씬으로 이동
        newGame.SetActive(false);
    }
    public void CancelNewGame() // 아니요
    {
        newGame.SetActive(false);
    }
}
