﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dapper;
using SchemaTypist.Generated.Domain;

namespace SchemaTypist.Generated.Persistence.Mapping
{
	static partial class DapperTypeMapping
	{
		static partial void BeforeInit();

		public static void Init()
        {
			BeforeInit();
			
			SqlMapper.SetTypeMap(typeof(Actor), Public.ActorMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(ActorInfo), Public.ActorInfoMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(Address), Public.AddressMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(Category), Public.CategoryMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(City), Public.CityMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(Country), Public.CountryMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(Customer), Public.CustomerMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(CustomerList), Public.CustomerListMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(Film), Public.FilmMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(FilmActor), Public.FilmActorMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(FilmCategory), Public.FilmCategoryMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(FilmList), Public.FilmListMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(Inventory), Public.InventoryMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(Language), Public.LanguageMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(NicerButSlowerFilmList), Public.NicerButSlowerFilmListMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(Payment), Public.PaymentMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(PaymentP200701), Public.PaymentP200701Mapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(PaymentP200702), Public.PaymentP200702Mapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(PaymentP200703), Public.PaymentP200703Mapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(PaymentP200704), Public.PaymentP200704Mapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(PaymentP200705), Public.PaymentP200705Mapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(PaymentP200706), Public.PaymentP200706Mapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(Rental), Public.RentalMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SalesByFilmCategory), Public.SalesByFilmCategoryMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(SalesByStore), Public.SalesByStoreMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(Staff), Public.StaffMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(StaffList), Public.StaffListMapper.QueryResults.GetTypeMap());
			SqlMapper.SetTypeMap(typeof(Store), Public.StoreMapper.QueryResults.GetTypeMap());
			
			AfterInit();
		}

		static partial void AfterInit();
	}
}