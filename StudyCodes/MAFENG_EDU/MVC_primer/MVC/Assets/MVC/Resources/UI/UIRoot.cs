using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot
{
	/// <summary>
	/// UIRoot
	/// </summary>
	public static Transform transform;

	/// <summary>
	/// ���յĴ��� ����
	/// </summary>
	public static Transform recyclePool;

	/// <summary>
	/// ǰ̨��ʾ�������Ĵ���
	/// </summary>
	public static Transform workstation;

	/// <summary>
	/// ��ʾ���͵Ĵ���
	/// </summary>
	public static Transform noticestation;

	public static bool isInit;

	public static void Init()
	{
		if (transform == null)
		{
			var obj = Resources.Load<GameObject>("UI/UIRoot");
			transform = GameObject.Instantiate(obj).transform;
		}

		if (recyclePool == null)
		{
			recyclePool = transform.Find("recyclePool");
		}

		if (workstation == null)
		{
			workstation = transform.Find("workstation");
		}

		if (noticestation == null)
		{
			noticestation = transform.Find("noticestation");
		}

		isInit = true;
	}

	public static void SetParent(Transform window,bool isOpen,bool isTipsWindow = false)
	{
		if (!isInit)
		{
			Init();
		}

		if (isOpen)
		{
			if (isTipsWindow)
			{
				window.SetParent(noticestation, false);
			}
			else
			{
				window.SetParent(workstation, false);
			}
		}
		else
		{
			window.SetParent(recyclePool, false);
		}
	}

}
