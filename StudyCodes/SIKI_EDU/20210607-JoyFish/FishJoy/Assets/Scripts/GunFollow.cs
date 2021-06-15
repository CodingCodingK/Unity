using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour
{
    public RectTransform UGUICanvas;
    public Camera mainCamera;
    private Vector3 mouseConvertedPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ȡ��Ļ���λ�ò�ת��Ϊ�ֲ�����ϵUGUICanvas�µ�Vector
        RectTransformUtility.ScreenPointToWorldPointInRectangle
		    (UGUICanvas,new Vector2(Input.mousePosition.x, Input.mousePosition.y),mainCamera, out mouseConvertedPosition);
        // ȡ ���λ������̨�����ɵ��� �� ��ֱ�� �ĽǶ�
        var z =
	        mouseConvertedPosition.x > transform.position.x
		        ? -Vector3.Angle(Vector3.up, mouseConvertedPosition - transform.position)
		        : Vector3.Angle(Vector3.up, mouseConvertedPosition - transform.position);
        // ת����̨�Ƕ�
        transform.localRotation = Quaternion.Euler(0, 0, z);

    }

	private void OnCollisionEnter(Collision collision)
	{
		
	}
}
