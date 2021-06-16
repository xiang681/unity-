using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerTransfrom;
    public Vector3 offset = new Vector3(0, 1, 0);
    private void Awake()
    {
        playerTransfrom = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransfrom.position + offset;
    }
}
