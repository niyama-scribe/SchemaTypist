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
	public partial class PgStatXactSysTable
	{
		public long IdxScan { get; set; }
		public long IdxTupFetch { get; set; }
		public long NTupDel { get; set; }
		public long NTupHotUpd { get; set; }
		public long NTupIn { get; set; }
		public long NTupUpd { get; set; }
		public uint Relid { get; set; }
		public string Relname { get; set; }
		public string Schemaname { get; set; }
		public long SeqScan { get; set; }
		public long SeqTupRead { get; set; }
	}
}