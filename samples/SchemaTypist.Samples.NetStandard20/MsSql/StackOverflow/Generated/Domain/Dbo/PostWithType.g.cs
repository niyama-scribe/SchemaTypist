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
	public partial class PostWithType
	{
	
		private PostWithType()
		{
		}
		
		public partial class Builder
		{
			public Builder()
			{
			}
			
    	private int? _setAcceptedAnswerId;
    	public Builder WithAcceptedAnswerId(int? val)
    	{
    	    _setAcceptedAnswerId = val;
    	    return this;
    	}
    	private int? _setAnswerCount;
    	public Builder WithAnswerCount(int? val)
    	{
    	    _setAnswerCount = val;
    	    return this;
    	}
    	private string _setBody;
    	public Builder WithBody(string val)
    	{
    	    _setBody = val;
    	    return this;
    	}
    	private DateTime? _setClosedDate;
    	public Builder WithClosedDate(DateTime? val)
    	{
    	    _setClosedDate = val;
    	    return this;
    	}
    	private int? _setCommentCount;
    	public Builder WithCommentCount(int? val)
    	{
    	    _setCommentCount = val;
    	    return this;
    	}
    	private DateTime? _setCommunityOwnedDate;
    	public Builder WithCommunityOwnedDate(DateTime? val)
    	{
    	    _setCommunityOwnedDate = val;
    	    return this;
    	}
    	private DateTime _setCreationDate;
    	public Builder WithCreationDate(DateTime val)
    	{
    	    _setCreationDate = val;
    	    return this;
    	}
    	private int? _setFavoriteCount;
    	public Builder WithFavoriteCount(int? val)
    	{
    	    _setFavoriteCount = val;
    	    return this;
    	}
    	private int? _setHalflife;
    	public Builder WithHalflife(int? val)
    	{
    	    _setHalflife = val;
    	    return this;
    	}
    	private int _setId;
    	public Builder WithId(int val)
    	{
    	    _setId = val;
    	    return this;
    	}
    	private DateTime _setLastActivityDate;
    	public Builder WithLastActivityDate(DateTime val)
    	{
    	    _setLastActivityDate = val;
    	    return this;
    	}
    	private DateTime? _setLastEditDate;
    	public Builder WithLastEditDate(DateTime? val)
    	{
    	    _setLastEditDate = val;
    	    return this;
    	}
    	private string _setLastEditorDisplayName;
    	public Builder WithLastEditorDisplayName(string val)
    	{
    	    _setLastEditorDisplayName = val;
    	    return this;
    	}
    	private int? _setLastEditorUserId;
    	public Builder WithLastEditorUserId(int? val)
    	{
    	    _setLastEditorUserId = val;
    	    return this;
    	}
    	private int? _setOwnerUserId;
    	public Builder WithOwnerUserId(int? val)
    	{
    	    _setOwnerUserId = val;
    	    return this;
    	}
    	private int? _setParentId;
    	public Builder WithParentId(int? val)
    	{
    	    _setParentId = val;
    	    return this;
    	}
    	private int _setPostTypeId;
    	public Builder WithPostTypeId(int val)
    	{
    	    _setPostTypeId = val;
    	    return this;
    	}
    	private int _setScore;
    	public Builder WithScore(int val)
    	{
    	    _setScore = val;
    	    return this;
    	}
    	private string _setTag;
    	public Builder WithTag(string val)
    	{
    	    _setTag = val;
    	    return this;
    	}
    	private string _setTitle;
    	public Builder WithTitle(string val)
    	{
    	    _setTitle = val;
    	    return this;
    	}
    	private string _setType;
    	public Builder WithType(string val)
    	{
    	    _setType = val;
    	    return this;
    	}
    	private int _setViewCount;
    	public Builder WithViewCount(int val)
    	{
    	    _setViewCount = val;
    	    return this;
    	}
	    	
	    	public PostWithType Build() 
	    	{
	    	    var retVal = new PostWithType()
	    	    {
    	            AcceptedAnswerId = _setAcceptedAnswerId,
    	            AnswerCount = _setAnswerCount,
    	            Body = _setBody,
    	            ClosedDate = _setClosedDate,
    	            CommentCount = _setCommentCount,
    	            CommunityOwnedDate = _setCommunityOwnedDate,
    	            CreationDate = _setCreationDate,
    	            FavoriteCount = _setFavoriteCount,
    	            Halflife = _setHalflife,
    	            Id = _setId,
    	            LastActivityDate = _setLastActivityDate,
    	            LastEditDate = _setLastEditDate,
    	            LastEditorDisplayName = _setLastEditorDisplayName,
    	            LastEditorUserId = _setLastEditorUserId,
    	            OwnerUserId = _setOwnerUserId,
    	            ParentId = _setParentId,
    	            PostTypeId = _setPostTypeId,
    	            Score = _setScore,
    	            Tag = _setTag,
    	            Title = _setTitle,
    	            Type = _setType,
    	            ViewCount = _setViewCount,
	    	    };
	    	    CustomizeBuild(retVal);
	    	    return retVal;
	    	}
	    	
	    	partial void CustomizeBuild(PostWithType entity);
		}
		
    public int? AcceptedAnswerId { get; private set; }
    public int? AnswerCount { get; private set; }
    public string Body { get; private set; }
    public DateTime? ClosedDate { get; private set; }
    public int? CommentCount { get; private set; }
    public DateTime? CommunityOwnedDate { get; private set; }
    public DateTime CreationDate { get; private set; }
    public int? FavoriteCount { get; private set; }
    public int? Halflife { get; private set; }
    public int Id { get; private set; }
    public DateTime LastActivityDate { get; private set; }
    public DateTime? LastEditDate { get; private set; }
    public string LastEditorDisplayName { get; private set; }
    public int? LastEditorUserId { get; private set; }
    public int? OwnerUserId { get; private set; }
    public int? ParentId { get; private set; }
    public int PostTypeId { get; private set; }
    public int Score { get; private set; }
    public string Tag { get; private set; }
    public string Title { get; private set; }
    public string Type { get; private set; }
    public int ViewCount { get; private set; }
	    		
	}
}
