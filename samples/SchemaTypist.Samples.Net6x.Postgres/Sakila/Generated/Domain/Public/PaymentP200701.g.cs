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

namespace SchemaTypist.Samples.Net6x.Postgres.Sakila.Generated.Domain.Public
{
	
	public partial record PaymentP200701
	{
		public decimal Amount { get; init; }
		public short CustomerId { get; init; }
		public DateTime PaymentDate { get; init; }
		public int PaymentId { get; init; }
		public int RentalId { get; init; }
		public short StaffId { get; init; }
	}
	

}