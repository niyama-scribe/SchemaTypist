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
	public partial class PgStatDatabaseConflict
	{
		public long ConflBufferpin { get; set; }
		public long ConflDeadlock { get; set; }
		public long ConflLock { get; set; }
		public long ConflSnapshot { get; set; }
		public long ConflTablespace { get; set; }
		public uint Datid { get; set; }
		public string Datname { get; set; }
	}
}