﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dapper;

namespace SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence
{
	static partial class DapperTypeMapping
	{
		static partial void BeforeInit();

		public static void Init()
        {
			BeforeInit();
			
			SqlMapper.SetTypeMap(typeof(SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo.Badge), SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo.BadgeDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo.Comment), SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo.CommentDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo.LinkType), SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo.LinkTypeDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo.PostLink), SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo.PostLinkDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo.Post), SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo.PostDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo.PostType), SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo.PostTypeDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo.PostWithType), SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo.PostWithTypeDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo.User), SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo.UserDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo.Vote), SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo.VoteDao.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo.VoteType), SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo.VoteTypeDao.QueryResults.GetTypeMap());
			
			AfterInit();
		}

		static partial void AfterInit();
	}
}