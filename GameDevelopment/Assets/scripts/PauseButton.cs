using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public UI_PauseScreen pausescreen;
    

    public void pauseScreen()
    { 
        
        pausescreen.ShowPauseScreen();
        gameObject.SetActive(false);
    }


}
