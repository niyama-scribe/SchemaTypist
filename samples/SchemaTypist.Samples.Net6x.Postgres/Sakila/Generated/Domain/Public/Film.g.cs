//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SchemaTypist.Samples.Net6x.Postgres.Sakila.Generated.Domain.Public
{
	
	public partial record Film
	{
		public string Description { get; init; }
		public int FilmId { get; init; }
		public Object Fulltext { get; init; }
		public short LanguageId { get; init; }
		public DateTime LastUpdate { get; init; }
		public short? Length { get; init; }
		public short? OriginalLanguageId { get; init; }
		public Object Rating { get; init; }
		public int? ReleaseYear { get; init; }
		public short RentalDuration { get; init; }
		public decimal RentalRate { get; init; }
		public decimal ReplacementCost { get; init; }
		public Object SpecialFeature { get; init; }
		public string Title { get; init; }
	}
	

}