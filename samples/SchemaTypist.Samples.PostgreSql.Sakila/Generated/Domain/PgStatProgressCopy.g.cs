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
	public partial class PgStatProgressCopy
	{
		public long BytesProcessed { get; set; }
		public long BytesTotal { get; set; }
		public string Command { get; set; }
		public uint Datid { get; set; }
		public string Datname { get; set; }
		public int Pid { get; set; }
		public uint Relid { get; set; }
		public long TuplesExcluded { get; set; }
		public long TuplesProcessed { get; set; }
		public string Type { get; set; }
	}
}