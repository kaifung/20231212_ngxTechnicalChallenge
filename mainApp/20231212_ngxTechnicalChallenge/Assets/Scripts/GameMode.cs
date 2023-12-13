using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TestLog;
    private int showTextLog;
    void Start()
    {
        showTextLog = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {               
            if (TestLog.activeSelf){
                TestLog.SetActive(false);
           }else{
            TestLog.SetActive(true);
           }
        }
    }
}
