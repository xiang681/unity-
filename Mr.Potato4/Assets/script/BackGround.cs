using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] backGrounds;
    public float fparallax = 0.4f;
    public float layerFraction = 5f;
    public float fSmooth = 5f;
    
    Transform cam;
    Vector3 previousCamPos;
    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    private void Start()
    {
        previousCamPos = cam.position;
    }
    
    void Update()
    {
        float fParrlaxX = (previousCamPos.x - cam.position.x) * fparallax; //计算相机运动量
        for (int i=0;i< backGrounds.Length;i++)
        {
            float fNewX = backGrounds[i].position.x + fParrlaxX * (1 + i * layerFraction);//计算各层的运动量
            Vector3 newPos = new Vector3(fNewX, backGrounds[i].position.y, backGrounds[i].position.z);
            backGrounds[i].position = Vector3.Lerp(backGrounds[i].position, newPos, fSmooth*Time.deltaTime) ;
        }
        previousCamPos = cam.position;
    }
}
