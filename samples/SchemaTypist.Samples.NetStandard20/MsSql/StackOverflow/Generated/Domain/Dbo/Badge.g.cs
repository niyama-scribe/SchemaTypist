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

namespace SchemaTypist.Samples.NetStandard20.MsSql.StackOverflow.Generated.Domain.Dbo
{
	public partial class Badge
	{
	private Badge()
		{
		}
		
		public partial class Builder
		{
			public Builder()
			{
			}
			
            private DateTime _setDate;
            public Builder WithDate(DateTime val)
            {
                _setDate = val;
                return this;
            }
            private int _setId;
            public Builder WithId(int val)
            {
                _setId = val;
                return this;
            }
            private string _setName;
            public Builder WithName(string val)
            {
                _setName = val;
                return this;
            }
            private int _setUserId;
            public Builder WithUserId(int val)
            {
                _setUserId = val;
                return this;
            }
	    	
	    	public Badge Build() 
	    	{
	    	    var retVal = new Badge()
	    	    {
    	            Date = _setDate,
    	            Id = _setId,
    	            Name = _setName,
    	            UserId = _setUserId,
	    	    };
	    	    CustomizeBuild(retVal);
	    	    return retVal;
	    	}
	    	
	    	partial void CustomizeBuild(Badge entity);
		}
    public DateTime Date { get; private set; }
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int UserId { get; private set; }
	    }
}
