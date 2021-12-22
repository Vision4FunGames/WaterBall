using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BlendShapeScript : MonoBehaviour
{
    public GameObject Ball;
    int blendShapeCount;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    float blendOne = 0f;
    float blendTwo = 0f;
    public float blendSpeed = 2f;
    bool blendOneFinished = false;
    public bool isFail;

    CinemachineVirtualCamera cm;

    void Awake()
    {
        skinnedMeshRenderer = Ball.GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = Ball.GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    void Start()
    {
        cm = FindObjectOfType<CinemachineVirtualCamera>();
        blendShapeCount = skinnedMesh.blendShapeCount;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (blendOne < 100f)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(0, blendOne);
                blendOne += blendSpeed;
            }
        }
        else
        {
            if (blendOne > 0 && !isFail)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(0, blendOne);
                blendOne -= blendSpeed;
            }
        }
        if (isFail)
        {
            failCond();
        }
        print(blendOne);
    }
    public void failCond()
    {
        if (blendOne < 100f)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(0, blendOne);
            blendOne += blendSpeed;
        }
    }
    public void cameraBlock()
    {
        cm.Follow = null;
        GameManager.instance.loseP.SetActive(true);
    }
}
