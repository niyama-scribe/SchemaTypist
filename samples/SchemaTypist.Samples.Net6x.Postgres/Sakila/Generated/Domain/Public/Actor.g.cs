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

#nullable enable

namespace SchemaTypist.Samples.Net6x.Postgres.Sakila.Generated.Domain.Public
{
	public partial record Actor
	{
		public int ActorId { get; init; }
		public string FirstName { get; init; } = default!; 
		public string LastName { get; init; } = default!; 
		public DateTime LastUpdate { get; init; }
	}
}

#nullable restore

