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

namespace SchemaTypist.Samples.Postgres.NetFramework.Postgres.Sakila.Generated.Domain.Public
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
