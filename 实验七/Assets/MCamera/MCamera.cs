using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCamera : MonoBehaviour
{
    public Transform playerTran;//主角的Transform
    public float maxDistanceX = 2;
    public float maxDistanceY = 2;
    public float xSpeed = 4;
    public float ySpeed = 4;
    public Vector2 maxXandY;
    public Vector2 minXandY=new Vector2(-8,8);
    // Start is called before the first frame update
    private bool NeedMoveX()//判断X方向是否需要移动摄像机
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTran.position.x)> maxDistanceX)
            bMove = true;
        else
            bMove = false;
        return bMove;
    }
    private bool NeedMoveY()//判断Y方向是否需要移动摄像机
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.y - playerTran.position.y) > maxDistanceY)
            bMove = true;
        else
            bMove = false;
        return bMove;
    }
    void Start()
    {
        
    }
    private void Awake()
    {
        //playerTran = GameObject.Find("Hero").transform;
        playerTran = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void TrackPlayer()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (NeedMoveX())//计算新摄像头位置
            newX = Mathf.Lerp(transform.position.x, playerTran.position.x, xSpeed * Time.deltaTime);
        if (NeedMoveY())
            newY = Mathf.Lerp(transform.position.y, playerTran.position.y, ySpeed * Time.deltaTime);
        //将摄像头位置固定在合法范围内
        newX = Mathf.Clamp(newX, minXandY.x, maxXandY.x);
        newY = Mathf.Clamp(newY, minXandY.y, maxXandY.y);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    private void FixedUpdate()
    {
        TrackPlayer();
    }
}
