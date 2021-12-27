using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptFinish : MonoBehaviour
{
    public GameObject mainCamera, secondCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FinishActive()
    {
        mainCamera.SetActive(false);
        secondCamera.SetActive(true);
    }
}
