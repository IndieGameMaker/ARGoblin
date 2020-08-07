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
        anim = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        // Vector3 dir = new Vector3(tigerTr.position.x, 0, tigerTr.position.z) 
        //             - new Vector3(tr.position.x, 0, tr.position.z);

        //방향벡터를 산출 (타이거좌표 - 고블린좌표)
        Vector3 lookDir = tigerTr.position - tr.position;

        //방향벡터의 각도(Quaternion)
        Quaternion rot = Quaternion.LookRotation(lookDir);

        //Slerp 보간 회전
        tr.localRotation = Quaternion.Slerp(tr.localRotation, rot, Time.deltaTime * 5.0f);
        //이동  
        //tr.Translate(Vector3.forward * Time.deltaTime * 5.0f);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("TIGER"))
        {
            anim.SetBool("isAttack", true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("TIGER"))
        {
            anim.SetBool("isAttack", false);
        }        
    }
}
