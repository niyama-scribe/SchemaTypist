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

namespace SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public
{
	public partial record Category
	{
		public int CategoryId { get; init; }
		public DateTime LastUpdate { get; init; }
		public string Name { get; init; } = default!; 
	}
}