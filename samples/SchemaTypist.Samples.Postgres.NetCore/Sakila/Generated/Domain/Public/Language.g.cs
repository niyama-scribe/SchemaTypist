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

public partial record Language
{
	public int LanguageId { get; init; }
	public DateTime LastUpdate { get; init; }
	public string Name { get; init; } = default!; 
}
