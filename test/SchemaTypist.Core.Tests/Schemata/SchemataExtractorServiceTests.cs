using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using Auzaar.AutoFixture;
using FluentAssertions;
using Moq;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Schemata;
using SchemaTypist.Core.Schemata.Dto;
using SchemaTypist.Core.SqlVendors;
using SqlKata;
using SqlKata.Compilers;
using Xunit;

namespace SchemaTypist.Core.Tests.Schemata
{
    public class SchemataExtractorServiceTests
    {
        [Theory, AutoTestParams]
        internal void ExtractDbMetadata_WhenValid_ThenConnectionCreatesCommand(
            [Frozen] Mock<IDbConnection> conn, [Frozen] DbCommand cmd,
            [Frozen] Compiler compiler, [Frozen] Mock<ISqlVendorService> sv,
            CodeGenConfig cdc, SchemataExtractorService sut)
        {
            //Arrange
            sv.Setup(vendorSvc => vendorSvc.GetDbInterfaceProviders(cdc)).Returns((conn.Object, compiler));
            conn.Setup(c => c.CreateCommand()).Returns(cmd);
            conn.SetupGet(c => c.State).Returns(ConnectionState.Open);
            
            //Act
            var metadata = sut.ExtractDbMetadata(cdc).GetAwaiter().GetResult();

            //Assert
            conn.Verify();
            metadata.TablesMetadata.Should().BeEmpty();
        }

        [Fact]
        public void ExtractDbMetadata_WhenInputIsValid_ThenConnectionCreatesCommand()
        {
            //Arrange
            var fixture = new Fixture();
            var conn = new Mock<IDbConnection>();
            var cmd = new FakeDbCommand();
            var compiler = new FakeCompiler();
            var sv = new Mock<ISqlVendorService>();
            var cdc = fixture.Create<CodeGenConfig>();
            var sut = new SchemataExtractorService(sv.Object);
            
            sv.Setup(vendorSvc => vendorSvc.GetDbInterfaceProviders(cdc)).Returns((conn.Object, compiler));
            sv.Setup(vendorSvc => vendorSvc.GetMetadataQueryBuilder(cdc))
                .Returns(new FakeMetadataQueryBuilder());
            conn.Setup(c => c.CreateCommand()).Returns(cmd);
            conn.SetupGet(c => c.State).Returns(ConnectionState.Open);

            //Act
            var metadata = sut.ExtractDbMetadata(cdc).GetAwaiter().GetResult();

            //Assert
            conn.Verify();
            metadata.TablesMetadata.Should().BeEmpty();
        }
    }

    internal class FakeMetadataQueryBuilder : AnsiSqlMetadataQueryBuilder
    {
        public override Query BuildRoutinesQuery()
        {
            throw new NotImplementedException();
        }

        public override Query BuildTableValuedParametersQuery()
        {
            throw new NotImplementedException();
        }

        public override Query BuildRoutinesReturnTypesQuery()
        {
            throw new NotImplementedException();
        }
    }

    internal class FakeDbCommand : DbCommand
    {
        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public override object? ExecuteScalar()
        {
            throw new NotImplementedException();
        }

        public override void Prepare()
        {
            throw new NotImplementedException();
        }

        public override string CommandText { get; set; }
        public override int CommandTimeout { get; set; }
        public override CommandType CommandType { get; set; }
        public override UpdateRowSource UpdatedRowSource { get; set; }
        protected override DbConnection? DbConnection { get; set; }
        protected override DbTransaction? DbTransaction { get; set; }
        public override bool DesignTimeVisible { get; set; }
        protected override DbParameterCollection DbParameterCollection { get; } = Mock.Of<DbParameterCollection>();
        protected override DbParameter CreateDbParameter() => Mock.Of<DbParameter>();
        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior) => Mock.Of<DbDataReader>();

    }

}
