using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    int num_Scene;

    public Animator anim;

    public GameObject buttons;

    private void Awake()
    {
        num_Scene = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        StartCoroutine(StartAnim());
    }

    public void OnClickGoMain()
    {
        SceneManager.LoadScene("MainTitle");
    }
    public void OnClickPlayDemo()
    {
        SceneManager.LoadScene(num_Scene + 1);
    }
    public void OnClickReplayCredit()
    {
        anim.SetTrigger("replay");
    }

    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(3f);
        anim.SetBool("start", true);
        yield return new WaitForSeconds(12f);
        buttons.SetActive(true);
    }
}
