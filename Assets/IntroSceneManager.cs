using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

   IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(42);
        SceneManager.LoadScene("MainMenu");
    }
}
