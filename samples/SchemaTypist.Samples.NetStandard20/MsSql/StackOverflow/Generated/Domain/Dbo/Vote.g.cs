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
	public partial class Vote
	{
	
		private Vote()
		{
		}
		
		public partial class Builder
		{
			public Builder()
			{
			}
			
    	private int? _setBountyAmount;
    	public Builder WithBountyAmount(int? val)
    	{
    	    _setBountyAmount = val;
    	    return this;
    	}
    	private DateTime _setCreationDate;
    	public Builder WithCreationDate(DateTime val)
    	{
    	    _setCreationDate = val;
    	    return this;
    	}
    	private int _setId;
    	public Builder WithId(int val)
    	{
    	    _setId = val;
    	    return this;
    	}
    	private int _setPostId;
    	public Builder WithPostId(int val)
    	{
    	    _setPostId = val;
    	    return this;
    	}
    	private int? _setUserId;
    	public Builder WithUserId(int? val)
    	{
    	    _setUserId = val;
    	    return this;
    	}
    	private int _setVoteTypeId;
    	public Builder WithVoteTypeId(int val)
    	{
    	    _setVoteTypeId = val;
    	    return this;
    	}
	    	
	    	public Vote Build() 
	    	{
	    	    var retVal = new Vote()
	    	    {
    	            BountyAmount = _setBountyAmount,
    	            CreationDate = _setCreationDate,
    	            Id = _setId,
    	            PostId = _setPostId,
    	            UserId = _setUserId,
    	            VoteTypeId = _setVoteTypeId,
	    	    };
	    	    CustomizeBuild(retVal);
	    	    return retVal;
	    	}
	    	
	    	partial void CustomizeBuild(Vote entity);
		}
		
    public int? BountyAmount { get; private set; }
    public DateTime CreationDate { get; private set; }
    public int Id { get; private set; }
    public int PostId { get; private set; }
    public int? UserId { get; private set; }
    public int VoteTypeId { get; private set; }
	    		
	}
}
