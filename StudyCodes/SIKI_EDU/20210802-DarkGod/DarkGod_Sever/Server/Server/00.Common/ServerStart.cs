﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 服务器入口
/// </summary>
public class ServerStart
{
    static void Main(string[] args)
    {
        ServerRoot.Instance().Init();


        while (true)
        {
            ServerRoot.Instance().Update();
			// 降低执行频率
			Thread.Sleep(20);
        }
    }
}