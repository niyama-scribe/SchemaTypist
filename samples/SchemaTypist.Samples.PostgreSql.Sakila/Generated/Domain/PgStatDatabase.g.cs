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
using System.Reflection;

namespace SchemaTypist.Generated.Domain
{
	public partial class PgStatDatabase
	{
		public double ActiveTime { get; set; }
		public double BlkReadTime { get; set; }
		public double BlkWriteTime { get; set; }
		public long BlksHit { get; set; }
		public long BlksRead { get; set; }
		public long ChecksumFailure { get; set; }
		public DateTime ChecksumLastFailure { get; set; }
		public long Conflict { get; set; }
		public uint Datid { get; set; }
		public string Datname { get; set; }
		public long Deadlock { get; set; }
		public double IdleInTransactionTime { get; set; }
		public int Numbackend { get; set; }
		public double SessionTime { get; set; }
		public long Session { get; set; }
		public long SessionsAbandoned { get; set; }
		public long SessionsFatal { get; set; }
		public long SessionsKilled { get; set; }
		public DateTime StatsReset { get; set; }
		public long TempByte { get; set; }
		public long TempFile { get; set; }
		public long TupDeleted { get; set; }
		public long TupFetched { get; set; }
		public long TupInserted { get; set; }
		public long TupReturned { get; set; }
		public long TupUpdated { get; set; }
		public long XactCommit { get; set; }
		public long XactRollback { get; set; }
	}
}