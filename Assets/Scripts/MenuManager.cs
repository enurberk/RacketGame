using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //on click ekleyebilmek için public olmak zorunda!!!;
    //sahneleri yükleyeceğiz;
    public void load(int index)
    {
        SceneManager.LoadScene(index);
    }
    //uygulamadan çıkmak için;
    public void Quit()
    {
        Application.Quit();
    }
    public void Update()
    {
        //oyun sahnelerinde esc tuşu ile çıkmak için;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            load(0);
        }
    }
}
