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
	public partial class PostType
	{
	   private PostType()
		{
		}
		
		public partial class Builder
		{
			public Builder()
			{
			}
			
            private int _setId;
            public Builder WithId(int val)
            {
                _setId = val;
                return this;
            }
            private string _setType;
            public Builder WithType(string val)
            {
                _setType = val;
                return this;
            }
	    	
	    	public PostType Build() 
	    	{
	    	    var retVal = new PostType()
	    	    {
    	            Id = _setId,
    	            Type = _setType,
	    	    };
	    	    CustomizeBuild(retVal);
	    	    return retVal;
	    	}
	    	
	    	partial void CustomizeBuild(PostType entity);
		}
        public int Id { get; private set; }
        public string Type { get; private set; }
	    
	}
}
