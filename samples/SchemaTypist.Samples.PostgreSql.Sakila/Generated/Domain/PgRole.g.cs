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
	public partial class PgRole
	{
		public uint Oid { get; set; }
		public bool Rolbypassrl { get; set; }
		public bool Rolcanlogin { get; set; }
		public Object Rolconfig { get; set; }
		public int Rolconnlimit { get; set; }
		public bool Rolcreatedb { get; set; }
		public bool Rolcreaterole { get; set; }
		public bool Rolinherit { get; set; }
		public string Rolname { get; set; }
		public string Rolpassword { get; set; }
		public bool Rolreplication { get; set; }
		public bool Rolsuper { get; set; }
		public DateTime Rolvaliduntil { get; set; }
	}
}