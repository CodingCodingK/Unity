/****************************************************
    文件：SystemBase.cs
    作者：YAN
    邮箱：2470939431@qq.com
    日期：2021/8/20 7:45:3
    功能：Unknown
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemBase : MonoBehaviour
{
    protected ResSvc resSvc;
    protected AudioSvc audioSvc;
    protected NetSvc netSvc;
    protected GameRootResources gameRootResources;

    public virtual void InitSys()
    {
        resSvc = ResSvc.Instance();
        audioSvc = AudioSvc.Instance();
        netSvc = NetSvc.Instance();
        gameRootResources = GameRootResources.Instance();
    }
}
