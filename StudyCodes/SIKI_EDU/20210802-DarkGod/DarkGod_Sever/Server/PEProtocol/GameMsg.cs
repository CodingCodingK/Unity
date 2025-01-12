﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PENet;

namespace PEProtocol
{
    /// <summary>
    /// 网络通信协议（客户端服务端共用）
    /// </summary>
    [Serializable]
    public class GameMsg : PEMsg
    {
        #region 登陆相关
        public ReqLogin reqLogin;
        public RspLogin rspLogin;
        public ReqRename reqRename;
        public RspRename rspRename;
		#endregion

		#region 主城相关
		public ReqGuide reqGuide;
		public RspGuide rspGuide;
		public ReqStrong reqStrong;
		public RspStrong rspStrong;
		public SendChat sendChat;
		public PushChat pushChat;
		public ReqBuy reqBuy;
		public RspBuy rspBuy;
		public PushPower pushPower;
		public ReqTask reqTask;
		public RspTask rspTask;
		public PushTaskPrgs pushTaskPrgs;

		#endregion

		#region 副本战斗相关

		public ReqDungeon reqDungeon;
		public RspDungeon rspDungeon;
		public ReqDungeonEnd reqDungeonEnd;
		public RspDungeonEnd rspDungeonEnd;

		#endregion
    }

	#region 登陆相关

	/// <summary>
	/// 登录请求
	/// </summary>
	[Serializable]
    public class ReqLogin
    {
        public string acct { get; set; }
        public string pass { get; set; }
    }

    /// <summary>
    /// 登录回应
    /// </summary>
    [Serializable]
    public class RspLogin
    {
        public PlayerData playerData;
    }

    /// <summary>
    /// 重命名请求
    /// </summary>
    [Serializable]
    public class ReqRename
    {
        public string name { get; set; }
    }

    /// <summary>
    /// 重命名回应
    /// </summary>
    [Serializable]
    public class RspRename
    {
        public string name { get; set; }
    }
	#endregion

	#region 主城相关


	/// <summary>
	/// 引导请求
	/// </summary>
	[Serializable]
	public class ReqGuide
	{
		public int guideid { get; set; }
	}

	/// <summary>
	/// 引导回应
	/// </summary>
	[Serializable]
	public class RspGuide
	{
		public int guideid { get; set; }
		public int coin { get; set; }
		public int lv { get; set; }
		public int exp { get; set; }
	}

	/// <summary>
	/// 强化请求
	/// </summary>
	[Serializable]
	public class ReqStrong
	{
		public int pos { get; set; }
	}

	/// <summary>
	/// 强化回应
	/// </summary>
	[Serializable]
	public class RspStrong
	{
		public int coin { get; set; }
		public int crystal { get; set; }
		public int hp { get; set; }
		public int ad { get; set; }
		public int ap { get; set; }
		public int addef { get; set; }
		public int apdef { get; set; }
		public int[] strongArr;
	}

	/// <summary>
	/// 聊天请求
	/// </summary>
	[Serializable]
	public class SendChat
	{
		public string chat { get; set; }
	}

	/// <summary>
	/// 推送聊天
	/// </summary>
	[Serializable]
	public class PushChat
	{
		public string name { get; set; }
		public string chat { get; set; }
	}

	/// <summary>
	/// 购买请求
	/// </summary>
	[Serializable]
	public class ReqBuy
	{
		public int type { get; set; }
		public int cost { get; set; }
	}

	/// <summary>
	/// 购买回应
	/// </summary>
	[Serializable]
	public class RspBuy
	{
		public int type { get; set; }
		public int diamond { get; set; }
		public int coin { get; set; }
		public int power { get; set; }
	}

	/// <summary>
	/// 推送体力增涨
	/// </summary>
	[Serializable]
	public class PushPower
	{
		public int power { get; set; }
	}

	/// <summary>
	/// 任务请求
	/// </summary>
	[Serializable]
	public class ReqTask
	{
		public int rid;
	}

	/// <summary>
	/// 任务回应
	/// </summary>
	[Serializable]
	public class RspTask
	{
		public int coin;
		public int exp;
		public int lv;
		public string[] taskArr;

	}

	/// <summary>
	/// 推送任务进度
	/// </summary>
	[Serializable]
	public class PushTaskPrgs
	{
		public string[] taskArr;
	}

	#endregion

	#region 副本战斗相关

	/// <summary>
	/// 副本请求
	/// </summary>
	[Serializable]
	public class ReqDungeon
	{
		public int dgId;
	}

	/// <summary>
	/// 副本回应
	/// </summary>
	[Serializable]
	public class RspDungeon
	{
		public int dgId;
		public int power;
	}

	/// <summary>
	/// 副本结束请求
	/// </summary>
	[Serializable]
	public class ReqDungeonEnd
	{
		public bool win;
		public int dgId;
		public int restHp;
		public int costTime;
	}

	/// <summary>
	/// 副本结束回应
	/// </summary>
	[Serializable]
	public class RspDungeonEnd
	{
		public bool win;
		public int dgId;
		public int restHp;
		public int costTime;

		// 副本奖励
		public int coin;
		public int lv;
		public int exp;
		public int crystal;
		/// <summary>
		/// 副本进度
		/// </summary>
		public int dg;
	}


	#endregion

	/// <summary>
	/// 用户信息
	/// </summary>
	[Serializable]
    public class PlayerData
    {
        public int id { get; set; }
        public string name { get; set; }
		public int level { get; set; }
		public int exp { get; set; }
		public int power { get; set; }
		public int coin { get; set; }
		public int diamond { get; set; }
		public int crystal { get; set; }
        public int hp { get; set; }
        public int ad { get; set; }
        public int ap { get; set; }
        public int addef { get; set; }
        public int apdef { get; set; }

        /// <summary>
        /// 闪避概率
        /// </summary>
        public int dodge { get; set; }

        /// <summary>
        /// 穿透比率
        /// </summary>
        public int pierce { get; set; }

        /// <summary>
        /// 暴击概率
        /// </summary>
        public int critical { get; set; }

		/// <summary>
		/// 当前自动引导任务ID
		/// </summary>
		public int guideid { get; set; }

		/// <summary>
		/// 不写成属性，手动映射，强化程度
		/// </summary>
		public int[] strongArr;

		/// <summary>
		/// Int64类型,记录上次离线时间
		/// </summary>
		public long time { get; set; }

		/// <summary>
		/// 不写成属性，手动映射，任务程度 1|0|0#1|1|0#1|0|0
		/// </summary>
		public string[] taskArr;

        /// <summary>
        /// 副本进度,默认10001
        /// </summary>
        public int dg { get; set; }

    }

    /// <summary>
    /// Command协议常数
    /// </summary>
    public enum ErrorCode
    {
        None = 0,

        /// <summary>
        /// 服务端数据异常
        /// </summary>
        ServerDataError,
        ClientDataError,

		/// <summary>
		/// 更新数据库出错
		/// </summary>
		UpdateDBError,

        // 登录相关

        /// <summary>
        /// 账号已登陆
        /// </summary>
        AccountIsOnline,

        /// <summary>
        /// 密码错误
        /// </summary>
        WrongPass,

        /// <summary>
        /// 名字已存在
        /// </summary>
        NameExisted,

		LackLevel,
		LackCoin,
		LackCrystal,
		LackDiamond,
		LackPower,

		TaskError,

    }

    /// <summary>
    /// Command协议常数
    /// </summary>
    public enum CMD
    {
        None=0,
        // 登录相关
        ReqLogin=101,
        RspLogin=102,
        ReqRename=103,
        RspRename=104,

		// 主城相关
		ReqGuide = 200,
		RspGuide = 201,
		ReqStrong = 202,
		RspStrong = 203,
		SendChat = 204,
		PushChat = 205,
		ReqBuy = 206,
		RspBuy = 207,
		PushPower = 208,
		ReqTask = 209,
		RspTask = 210,
		PushTaskPrgs = 211,

		ReqDungeon = 301,
		RspDungeon = 302,

		ReqDungeonEnd = 303,
		RspDungeonEnd = 304,

	}

    /// <summary>
    /// 端口号常数
    /// </summary>
    public class ServerConfig
    {
        public const string srvIP = "127.0.0.1";
        public const int srvPort = 17666;
    }
}

