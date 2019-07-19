using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
using UnityEngine.SceneManagement;
public class AdvanceonWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         GetComponent<PlayerController>().winEvent.AddListener(win);   
    }

    private void win()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
