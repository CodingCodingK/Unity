using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoSingleton<WindowManager>
{
	Dictionary<WindowsType, BaseWindow> windowDIC = new Dictionary<WindowsType, BaseWindow>();

	//���캯�� ��ʼ��
	public WindowManager()
	{
		//�̵�
		windowDIC.Add(WindowsType.StoreWindow, new StoreWindow());
	}

	public void Update()
	{
		foreach (var window in windowDIC.Values)
		{
			if (window.IsVisible())
			{
				window.Update(Time.deltaTime);
			}
		}

	}

	//�򿪴���
	public BaseWindow OpenWindow(WindowsType type)
	{
		BaseWindow window;
		if (windowDIC.TryGetValue(type, out window))
		{
			window.Open();
			return window;
		}
		else
		{
			Debug.LogError($"Open Error:{type}");
			return null;
		}
	}

	//�رմ���
	public void CloseWindow(WindowsType type)
	{
		BaseWindow window;
		if (windowDIC.TryGetValue(type, out window))
		{
			window.Close();
		}
		else
		{
			Debug.LogError($"Open Error:{type}");
		}
	}

	//Ԥ����
	public void PreLoadWindow(ScenesType type)
	{
		foreach (var item in windowDIC.Values)
		{
			if (item.GetScenesType() == type)
			{
				item.PreLoad();
			}
		}
	}

	//���ص�ĳ�����͵����д���
	public void HideAllWindow(ScenesType type, bool isDestroy = false)
	{

		foreach (var item in windowDIC.Values)
		{
			if (item.GetScenesType() == type)
			{
				item.Close(isDestroy);
			}
		}
	}
}