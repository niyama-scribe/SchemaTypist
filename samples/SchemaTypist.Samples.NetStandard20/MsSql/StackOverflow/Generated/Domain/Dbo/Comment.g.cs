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
	public partial class Comment
	{
	
		private Comment()
		{
		}
		
		public partial class Builder
		{
			public Builder()
			{
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
    	private int? _setScore;
    	public Builder WithScore(int? val)
    	{
    	    _setScore = val;
    	    return this;
    	}
    	private string _setText;
    	public Builder WithText(string val)
    	{
    	    _setText = val;
    	    return this;
    	}
    	private int? _setUserId;
    	public Builder WithUserId(int? val)
    	{
    	    _setUserId = val;
    	    return this;
    	}
	    	
	    	public Comment Build() 
	    	{
	    	    var retVal = new Comment()
	    	    {
    	            CreationDate = _setCreationDate,
    	            Id = _setId,
    	            PostId = _setPostId,
    	            Score = _setScore,
    	            Text = _setText,
    	            UserId = _setUserId,
	    	    };
	    	    CustomizeBuild(retVal);
	    	    return retVal;
	    	}
	    	
	    	partial void CustomizeBuild(Comment entity);
		}
		
    public DateTime CreationDate { get; private set; }
    public int Id { get; private set; }
    public int PostId { get; private set; }
    public int? Score { get; private set; }
    public string Text { get; private set; }
    public int? UserId { get; private set; }
	    		
	}
}
