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
	public partial class PgStatArchiver
	{
		public long ArchivedCount { get; set; }
		public long FailedCount { get; set; }
		public DateTime LastArchivedTime { get; set; }
		public string LastArchivedWal { get; set; }
		public DateTime LastFailedTime { get; set; }
		public string LastFailedWal { get; set; }
		public DateTime StatsReset { get; set; }
	}
}