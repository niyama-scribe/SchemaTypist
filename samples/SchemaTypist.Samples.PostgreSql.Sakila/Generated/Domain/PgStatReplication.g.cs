﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;

namespace SchemaTypist.Generated.Domain
{
	public partial class PgStatReplication
	{
		public string ApplicationName { get; set; }
		public DateTime BackendStart { get; set; }
		public uint BackendXmin { get; set; }
		public Object ClientAddr { get; set; }
		public string ClientHostname { get; set; }
		public int ClientPort { get; set; }
		public Object FlushLag { get; set; }
		public Object FlushLsn { get; set; }
		public int Pid { get; set; }
		public Object ReplayLag { get; set; }
		public Object ReplayLsn { get; set; }
		public DateTime ReplyTime { get; set; }
		public Object SentLsn { get; set; }
		public string State { get; set; }
		public int SyncPriority { get; set; }
		public string SyncState { get; set; }
		public string Usename { get; set; }
		public uint Usesysid { get; set; }
		public Object WriteLag { get; set; }
		public Object WriteLsn { get; set; }
	}
}