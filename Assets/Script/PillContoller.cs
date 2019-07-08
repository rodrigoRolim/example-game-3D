using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PillContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pills;
    private int pillNumbers;


    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (pills.transform.GetChildCount() == 0) {
            SceneManager.LoadScene(1);
        }
    }
}
