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

public partial record ActorInfo
{
	public int? ActorId { get; init; }
	public string? FilmInfo { get; init; }
	public string? FirstName { get; init; }
	public string? LastName { get; init; }
}