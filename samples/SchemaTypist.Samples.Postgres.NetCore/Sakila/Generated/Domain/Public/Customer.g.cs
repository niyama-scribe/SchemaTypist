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
	public partial record Customer
	{
		public int? Active { get; init; }
		public bool Activebool { get; init; }
		public short AddressId { get; init; }
		public DateTime CreateDate { get; init; }
		public int CustomerId { get; init; }
		public string? Email { get; init; }
		public string FirstName { get; init; } = default!; 
		public string LastName { get; init; } = default!; 
		public DateTime? LastUpdate { get; init; }
		public short StoreId { get; init; }
	}
}