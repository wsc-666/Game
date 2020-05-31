using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Button button;
    public GameObject gamePanle;
    private bool panleIsTrue = false;
    private bool isPause = false;
    public void OnBtnClick()
    {

        OpenPanel();

    }

    public void OnBtnStartClick()
    {

        Pause();

    }
    public void OnBtnLoadClick()
    {

        Load();

    }
    public void Load()
    {

        SceneManager.LoadScene(0);

    }
    public void Pause()
    {
        Time.timeScale = isPause ? 1 : 0;
        isPause = !isPause;
    }
    public void OpenPanel()
    {
        if (!panleIsTrue)
        {
            gamePanle.SetActive(true);
        }
        else
        {
            gamePanle.SetActive(false);
        }
        panleIsTrue = !panleIsTrue;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
