//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by SchemaTypist.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dapper;

namespace SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence
{
	internal static partial class DapperTypeMapping
	{
		static partial void BeforeInit();

		public static void Init()
        {
			BeforeInit();
			
			SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.MsSql.Generated.StackOverflow.Domain.Dbo.Badge), SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence.Dbo.BadgeDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.MsSql.Generated.StackOverflow.Domain.Dbo.Comment), SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence.Dbo.CommentDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.MsSql.Generated.StackOverflow.Domain.Dbo.LinkType), SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence.Dbo.LinkTypeDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.MsSql.Generated.StackOverflow.Domain.Dbo.PostLink), SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence.Dbo.PostLinkDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.MsSql.Generated.StackOverflow.Domain.Dbo.Post), SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence.Dbo.PostDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.MsSql.Generated.StackOverflow.Domain.Dbo.PostType), SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence.Dbo.PostTypeDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.MsSql.Generated.StackOverflow.Domain.Dbo.User), SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence.Dbo.UserDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.MsSql.Generated.StackOverflow.Domain.Dbo.Vote), SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence.Dbo.VoteDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.MsSql.Generated.StackOverflow.Domain.Dbo.VoteType), SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence.Dbo.VoteTypeDao.QueryResults.GetTypeMap());
			
			AfterInit();
		}

		static partial void AfterInit();
	}
}