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
	public partial class Trigger
	{
		public string ActionCondition { get; set; }
		public int ActionOrder { get; set; }
		public string ActionOrientation { get; set; }
		public string ActionReferenceNewRow { get; set; }
		public string ActionReferenceNewTable { get; set; }
		public string ActionReferenceOldRow { get; set; }
		public string ActionReferenceOldTable { get; set; }
		public string ActionStatement { get; set; }
		public string ActionTiming { get; set; }
		public DateTime Created { get; set; }
		public string EventManipulation { get; set; }
		public string EventObjectCatalog { get; set; }
		public string EventObjectSchema { get; set; }
		public string EventObjectTable { get; set; }
		public string TriggerCatalog { get; set; }
		public string TriggerName { get; set; }
		public string TriggerSchema { get; set; }
	}
}