using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hero : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.point);
                agent.SetDestination(hit.point);
            }
        }
		
        // ��������������� ���ۣ�ֻ�Ǵ���һ���µ��������鿴�Ƿ����䵽main camera�ĺ�������ϣ�������Ծ�true����������Ծ�false��
        //Ray ray2 = Camera.main.ScreenPointToRay(new Vector3(23.6f, 0f, 4.7f));
        //RaycastHit hit2;
        //if (Physics.Raycast(ray2, out hit2))
        //{
        //    print($"{hit2.point} Got it��");
        //}
        ani.SetFloat("speed", agent.velocity.magnitude);
    }
}
