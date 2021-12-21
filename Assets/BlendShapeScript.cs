using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Awake()
    {
        skinnedMeshRenderer = Ball.GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = Ball.GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    void Start()
    {
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
            if (blendOne > 0)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(0, blendOne);
                blendOne -= blendSpeed;
            }
        }
    }
}
