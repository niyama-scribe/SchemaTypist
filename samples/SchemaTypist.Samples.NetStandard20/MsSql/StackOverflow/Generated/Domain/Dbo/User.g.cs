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
	public partial class User
	{
	   private User()
		{
		}
		
		public partial class Builder
		{
			public Builder()
			{
			}
			
            private string _setAboutMe;
            public Builder WithAboutMe(string val)
            {
                _setAboutMe = val;
                return this;
            }
            private int? _setAccountId;
            public Builder WithAccountId(int? val)
            {
                _setAccountId = val;
                return this;
            }
            private int? _setAge;
            public Builder WithAge(int? val)
            {
                _setAge = val;
                return this;
            }
            private DateTime _setCreationDate;
            public Builder WithCreationDate(DateTime val)
            {
                _setCreationDate = val;
                return this;
            }
            private string _setDisplayName;
            public Builder WithDisplayName(string val)
            {
                _setDisplayName = val;
                return this;
            }
            private int _setDownVote;
            public Builder WithDownVote(int val)
            {
                _setDownVote = val;
                return this;
            }
            private string _setEmailHash;
            public Builder WithEmailHash(string val)
            {
                _setEmailHash = val;
                return this;
            }
            private int _setId;
            public Builder WithId(int val)
            {
                _setId = val;
                return this;
            }
            private DateTime _setLastAccessDate;
            public Builder WithLastAccessDate(DateTime val)
            {
                _setLastAccessDate = val;
                return this;
            }
            private string _setLocation;
            public Builder WithLocation(string val)
            {
                _setLocation = val;
                return this;
            }
            private int _setReputation;
            public Builder WithReputation(int val)
            {
                _setReputation = val;
                return this;
            }
            private int _setUpVote;
            public Builder WithUpVote(int val)
            {
                _setUpVote = val;
                return this;
            }
            private int _setView;
            public Builder WithView(int val)
            {
                _setView = val;
                return this;
            }
            private string _setWebsiteUrl;
            public Builder WithWebsiteUrl(string val)
            {
                _setWebsiteUrl = val;
                return this;
            }
	    	
	    	public User Build() 
	    	{
	    	    var retVal = new User()
	    	    {
    	            AboutMe = _setAboutMe,
    	            AccountId = _setAccountId,
    	            Age = _setAge,
    	            CreationDate = _setCreationDate,
    	            DisplayName = _setDisplayName,
    	            DownVote = _setDownVote,
    	            EmailHash = _setEmailHash,
    	            Id = _setId,
    	            LastAccessDate = _setLastAccessDate,
    	            Location = _setLocation,
    	            Reputation = _setReputation,
    	            UpVote = _setUpVote,
    	            View = _setView,
    	            WebsiteUrl = _setWebsiteUrl,
	    	    };
	    	    CustomizeBuild(retVal);
	    	    return retVal;
	    	}
	    	
	    	partial void CustomizeBuild(User entity);
		}
        public string AboutMe { get; private set; }
        public int? AccountId { get; private set; }
        public int? Age { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string DisplayName { get; private set; }
        public int DownVote { get; private set; }
        public string EmailHash { get; private set; }
        public int Id { get; private set; }
        public DateTime LastAccessDate { get; private set; }
        public string Location { get; private set; }
        public int Reputation { get; private set; }
        public int UpVote { get; private set; }
        public int View { get; private set; }
        public string WebsiteUrl { get; private set; }
	    
	}
}
