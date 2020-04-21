using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundParallax : MonoBehaviour
{
    public Transform[] backgrounds;
    //相机移动时，背景相对移动的比例
    public float parallaxScale = 0.5f;
    //层间的运动比例
    public float layerScale = 0.5f;
    public float smooth = 5f;

    private Transform CamTransfrom;
    private Vector3 previousCamPos;

    private void Awake()
    {
        CamTransfrom = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = CamTransfrom.position;
        Debug.Log("AAAAAAAAAAAAAAAAAAAA");
    }

    // Update is called once per frame
    void Update()
    {
        float parallax = (previousCamPos.x - CamTransfrom.position.x) * parallaxScale;
        for(int i = 0; i < backgrounds.Length; i++)
        {
            float targetX = backgrounds[i].position.x + parallax * (1 + i * layerScale);
            Vector3 targetPos = new Vector3(targetX, backgrounds[i].position.y, backgrounds[i].position.z);
            Debug.Log("BBBBBBBBBBBBBBBBBBB");
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPos, smooth * Time.deltaTime);
        }
        previousCamPos = CamTransfrom.position;
    }
}

