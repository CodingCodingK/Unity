using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseWindow
{
	#region ��������

	/// <summary>
	/// ����
	/// </summary>
	protected Transform transform;
	/// <summary>
	/// ��Դ����
	/// </summary>
	protected string resName;
	/// <summary>
	/// �Ƿ�פ
	/// </summary>
	protected bool resident;
	/// <summary>
	/// �Ƿ�ɼ�
	/// </summary>
	protected bool visible = false;
	/// <summary>
	/// ��������
	/// </summary>
	protected WindowsType windowType;
	/// <summary>
	/// ��������
	/// </summary>
	protected ScenesType sceneType;

	#endregion

	#region �ؼ��б�

	/// <summary>
	/// UI�ؼ� ��ť
	/// </summary>
	protected Button[] buttonList;

	#endregion

	/// <summary>
	/// ��ʼ��
	/// </summary>
	protected virtual void Awake()
	{
		//��ʾ���ص�����Ҳ�����
		buttonList = transform.GetComponentsInChildren<Button>(true);
		RegisterUIEvent();
	}

	/// <summary>
	/// UI�¼�ע��
	/// </summary>
	protected virtual void RegisterUIEvent()
	{

	}

	/// <summary>
	/// ��Ӽ���
	/// </summary>
	protected virtual void OnAddListener()
	{

	}

	/// <summary>
	/// �Ƴ�����
	/// </summary>
	protected virtual void OnRemoveListener()
	{

	}

	/// <summary>
	/// ÿ������
	/// </summary>
	protected virtual void OnEnable()
	{

	}

	/// <summary>
	/// ÿ�ν���
	/// </summary>
	protected virtual void OnDisable()
	{

	}

	/// <summary>
	/// ����
	/// </summary>
	public virtual void Update(float deltaTime)
	{

	}


    #region For WindowManager

    public void Open()
    {
	    if (transform == null)
	    {
		    if (Create())
		    {
			    Awake();//��ʼ��
		    }
	    }

	    if (transform.gameObject.activeSelf == false)
	    {
		    UIRoot.SetParent(transform, true, windowType == WindowsType.TipsWindow);
		    transform.gameObject.SetActive(true);
		    visible = true;
		    OnEnable();//���ü���ʱ�򴥷����¼�
		    OnAddListener();//����¼�
	    }
    }

    public void Close(bool isDestroy = false)
    {
	    if (transform.gameObject.activeSelf == true)
	    {
		    OnRemoveListener();//�Ƴ���Ϸ�¼�
		    OnDisable();//����ʱ�򴥷����¼�
		    if (isDestroy == false)
		    {
			    if (resident)
			    {
				    transform.gameObject.SetActive(false);
				    UIRoot.SetParent(transform, false, false);

			    }
			    else
			    {
				    GameObject.Destroy(transform.gameObject);
				    transform = null;
			    }
		    }
		    else
		    {
			    GameObject.Destroy(transform.gameObject);
			    transform = null;
		    }


	    }
	    //���ɼ���״̬
	    visible = false;
    }

    public void PreLoad()
    {
	    if (transform == null)
	    {
		    if (Create())
		    {
			    Awake();
		    }
	    }
    }

    //��ȡ��������
    public ScenesType GetScenesType()
    {
	    return sceneType;
    }

    //��������
    public WindowsType GetWindowType()
    {
	    return windowType;
    }

    //��ȡ���ڵ�
    public Transform GetRoot()
    {
	    return transform;
    }

    //�Ƿ�ɼ�
    public bool IsVisible()
    {
	    return visible;
    }

    //�Ƿ�פ
    public bool IsREsident()
    {
	    return resident;
    }

    #endregion


    private bool Create()
    {
        if (string.IsNullOrEmpty(resName))
        {
            return false;
        }

        if (transform == null)
        {
            var obj = Resources.Load<GameObject>(resName);
            if (obj == null)
            {
                Debug.LogError($"δ�ҵ�UIԤ�Ƽ�{windowType}");
                return false;
            }
            transform = GameObject.Instantiate(obj).transform;

            transform.gameObject.SetActive(false);

            UIRoot.SetParent(transform, false, windowType == WindowsType.TipsWindow);
        }

        return true;
    }

}

/// <summary>
/// ��������
/// </summary>
public enum WindowsType
{
	LoginWindow,
	StoreWindow,
	TipsWindow,
}

/// <summary>
/// �������ͣ������ṩ�ĳ������ͽ���Ԥ����
/// </summary>
public enum ScenesType
{
	None,
	Login,
	Battle
}