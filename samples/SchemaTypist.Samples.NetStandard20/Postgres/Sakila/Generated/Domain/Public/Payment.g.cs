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

namespace SchemaTypist.Samples.NetStandard20.Postgres.Sakila.Generated.Domain.Public
{
	public partial class Payment
	{
		public decimal Amount { get; set; }
		public short CustomerId { get; set; }
		public DateTime PaymentDate { get; set; }
		public int PaymentId { get; set; }
		public int RentalId { get; set; }
		public short StaffId { get; set; }
	}
}