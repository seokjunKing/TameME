using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class SelectLoadData : MonoBehaviour
{
    public Text[] slotText;		// ���Թ�ư �Ʒ��� �����ϴ� Text��
    public Text[] slotText2;

    public GameObject LoadSlotPanel;
    public GameObject NewSlotPanel;

    public GameObject newGame;

    bool[] savefile = new bool[3];	// ���̺����� �������� ����

    void Start()
    {
        // ���Ժ��� ����� �����Ͱ� �����ϴ��� �Ǵ�.
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))	// �����Ͱ� �ִ� ���
            {
                savefile[i] = true;			// �ش� ���� ��ȣ�� bool�迭 true�� ��ȯ
                DataManager.instance.nowSlot = i;	// ������ ���� ��ȣ ����
                DataManager.instance.LoadData();	// �ش� ���� ������ �ҷ���
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
                    slotText[i].text = "�� ����";
                    slotText2[i].text = "�� ����";
                }
            }
            else	// �����Ͱ� ���� ���
            {
                slotText[i].text = "�� ����";
                slotText2[i].text = "�� ����";
            }
        }
        // �ҷ��� �����͸� �ʱ�ȭ��Ŵ.(��ư�� �г����� ǥ���ϱ������̾��� ����)
        DataManager.instance.DataClear();
    }

    public void Slot(int number)	// ������ ��� ����
    {
        DataManager.instance.nowSlot = number;	// ������ ��ȣ�� ���Թ�ȣ�� �Է���.

        if (savefile[number])	// bool �迭���� ���� ���Թ�ȣ�� true��� = ������ �����Ѵٴ� ��
        {
            DataManager.instance.LoadData();	// �����͸� �ε��ϰ�
            GoGame(DataManager.instance.nowPlayer.stageNum);	// ���Ӿ����� �̵�
        }
        else	// bool �迭���� ���� ���Թ�ȣ�� false��� �����Ͱ� ���ٴ� ��
        {
            GoGame(2);	// �÷��̾� �г��� �Է� UI Ȱ��ȭ
        }
    }

    public void newSlot(int number)	// ������ ��� ����
    {
        DataManager.instance.nowSlot = number;	// ������ ��ȣ�� ���Թ�ȣ�� �Է���.

        if (savefile[number])	// bool �迭���� ���� ���Թ�ȣ�� true��� = ������ �����Ѵٴ� ��
        {
            newGame.SetActive(true);// ������ ����Ǿ� �ִ� �����͸� �����Ͻðڽ��ϱ�?
        }
        else	// bool �迭���� ���� ���Թ�ȣ�� false��� �����Ͱ� ���ٴ� ��
        {
            GoGame(2);
        }
    }

    public void GoGame(int num)	// ���Ӿ����� �̵�
    {
        if (!savefile[DataManager.instance.nowSlot])	// ���� ���Թ�ȣ�� �����Ͱ� ���ٸ�
        {
            DataManager.instance.SaveData(); // ���� ������ ������.
            SceneManager.LoadScene("EventScene"); // ���Ӿ����� �̵�
        }
        else    // �����Ͱ� ������
        {
            SceneManager.LoadScene(num);    // �ش� ������ �̵�
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
    public void ClearLoadData() // ��
    {
        GoGame(2);	// ���Ӿ����� �̵�
        newGame.SetActive(false);
    }
    public void CancelNewGame() // �ƴϿ�
    {
        newGame.SetActive(false);
    }
}
