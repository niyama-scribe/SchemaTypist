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
	public partial record Rental
	{
		public short CustomerId { get; init; }
		public int InventoryId { get; init; }
		public DateTime LastUpdate { get; init; }
		public DateTime RentalDate { get; init; }
		public int RentalId { get; init; }
		public DateTime? ReturnDate { get; init; }
		public short StaffId { get; init; }
	}
}