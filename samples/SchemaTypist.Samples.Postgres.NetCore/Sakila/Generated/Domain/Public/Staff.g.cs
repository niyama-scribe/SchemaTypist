//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by SchemaTypist.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

#nullable enable

namespace SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public;

public partial record Staff
{
	public bool Active { get; init; }
	public short AddressId { get; init; }
	public string? Email { get; init; }
	public string FirstName { get; init; } = default!; 
	public string LastName { get; init; } = default!; 
	public DateTime LastUpdate { get; init; }
	public string? Password { get; init; }
	public byte[]? Picture { get; init; }
	public int StaffId { get; init; }
	public short StoreId { get; init; }
	public string Username { get; init; } = default!; 
}