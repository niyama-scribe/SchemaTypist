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

public partial record NicerButSlowerFilmList
{
	public string? Actor { get; init; }
	public string? Category { get; init; }
	public string? Description { get; init; }
	public int? Fid { get; init; }
	public short? Length { get; init; }
	public decimal? Price { get; init; }
	public object? Rating { get; init; }
	public string? Title { get; init; }
}
