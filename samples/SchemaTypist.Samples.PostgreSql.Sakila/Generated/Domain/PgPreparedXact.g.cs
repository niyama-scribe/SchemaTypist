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
	public partial class PgPreparedXact
	{
		public string Database { get; set; }
		public string Gid { get; set; }
		public string Owner { get; set; }
		public DateTime Prepared { get; set; }
		public uint Transaction { get; set; }
	}
}