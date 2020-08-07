using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCtrl : MonoBehaviour
{
    private Transform tr;       //고블린의 Transform
    private Transform tigerTr;  //호랑이의 Transform
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        GameObject tigerObj = GameObject.FindGameObjectWithTag("TIGER");
        if (tigerObj != null)
        {
            tigerTr = tigerObj.GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
