using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndGameChangeScene());
    }

    IEnumerator EndGameChangeScene()
    {
        yield return new WaitForSeconds(50);
        while(true)
        {
            yield return new WaitForSecondsRealtime(1);
            if(GameObject.FindGameObjectsWithTag("WaterVFX").Length == 0)
            {
                SceneManager.LoadScene("HIScore");
            }
        }
    }
}
