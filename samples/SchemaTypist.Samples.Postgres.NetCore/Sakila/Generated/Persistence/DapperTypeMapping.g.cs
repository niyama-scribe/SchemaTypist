//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by SchemaTypist.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dapper;

namespace SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence;

internal static partial class DapperTypeMapping
{
	static partial void BeforeInit();

	public static void Init()
    {
		BeforeInit();
		
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Actor), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.ActorDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.ActorInfo), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.ActorInfoDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Address), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.AddressDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Category), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.CategoryDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.City), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.CityDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Country), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.CountryDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Customer), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.CustomerDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.CustomerList), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.CustomerListDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Film), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.FilmDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.FilmActor), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.FilmActorDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.FilmCategory), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.FilmCategoryDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.FilmList), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.FilmListDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Inventory), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.InventoryDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Language), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.LanguageDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.NicerButSlowerFilmList), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.NicerButSlowerFilmListDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Payment), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.PaymentDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.PaymentP200701), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.PaymentP200701Dao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.PaymentP200702), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.PaymentP200702Dao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.PaymentP200703), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.PaymentP200703Dao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.PaymentP200704), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.PaymentP200704Dao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.PaymentP200705), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.PaymentP200705Dao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.PaymentP200706), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.PaymentP200706Dao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Rental), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.RentalDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.SalesByFilmCategory), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.SalesByFilmCategoryDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.SalesByStore), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.SalesByStoreDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Staff), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.StaffDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.StaffList), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.StaffListDao.QueryResults.GetTypeMap());
		SqlMapper.SetTypeMap(typeof(SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public.Store), SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public.StoreDao.QueryResults.GetTypeMap());
		
		AfterInit();
	}

	static partial void AfterInit();
}