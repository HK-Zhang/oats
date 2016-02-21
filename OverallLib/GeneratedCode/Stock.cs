﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Stock
{
	public virtual string StockCode
	{
		get;
		set;
	}

	/// <summary>
	/// 总市值
	/// </summary>
	public virtual Double TotalMarketCap
	{
		get;
		set;
	}

	/// <summary>
	/// 流通市值
	/// </summary>
	public virtual Double NegotiableMarketCap
	{
		get;
		set;
	}

	/// <summary>
	/// 今开
	/// </summary>
	public virtual Double OpenPrice
	{
		get;
		set;
	}

	/// <summary>
	/// 换手
	/// </summary>
	public virtual Double HandOver
	{
		get;
		set;
	}

	/// <summary>
	/// 成交量
	/// </summary>
	public virtual Double Volume
	{
		get;
		set;
	}

	/// <summary>
	/// 最高
	/// </summary>
	public virtual Double TodayHigh
	{
		get;
		set;
	}

	/// <summary>
	/// 最低
	/// </summary>
	public virtual Double TodayLow
	{
		get;
		set;
	}

	/// <summary>
	/// 最新
	/// </summary>
	public virtual Double LatestPrice
	{
		get;
		set;
	}

	/// <summary>
	/// 昨收
	/// </summary>
	public virtual Double PreviousClose
	{
		get;
		set;
	}

	/// <summary>
	/// 成交额
	/// </summary>
	public virtual Double Value
	{
		get;
		set;
	}

	/// <summary>
	/// 市净
	/// </summary>
	public virtual Double mrp
	{
		get;
		set;
	}

	/// <summary>
	/// 市盈
	/// </summary>
	public virtual Double ttm
	{
		get;
		set;
	}

	/// <summary>
	/// 均价
	/// </summary>
	public virtual Double MeanPrice
	{
		get;
		set;
	}

	/// <summary>
	/// 外盘
	/// </summary>
	public virtual int ExternalExp
	{
		get;
		set;
	}

	/// <summary>
	/// 内盘
	/// </summary>
	public virtual int InternalExp
	{
		get;
		set;
	}

}

