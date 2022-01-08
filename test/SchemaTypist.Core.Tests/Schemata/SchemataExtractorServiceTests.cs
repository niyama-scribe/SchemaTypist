using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Schemata;
using SchemaTypist.Core.Schemata.Dto;
using SchemaTypist.Core.SqlVendors;
using SqlKata.Compilers;
using Xunit;

namespace SchemaTypist.Core.Tests.Schemata
{
    public class SchemataExtractorServiceTests
    {
        [Theory]
        [AutoDomainData]
        internal void ExtractDbMetadata_WhenValid_CallsDbConnection(
            [Frozen] Mock<IDbConnection> conn, [Frozen] DbCommand cmd,
            [Frozen] Compiler compiler,
            [Frozen] Mock<ISqlVendorService> sv,
            CodeGenConfig cdc, SchemataExtractorService sut)
        {
            //Arrange
            sv.Setup(vendorSvc => vendorSvc.GetDbInterfaceProviders(cdc)).Returns((conn.Object, compiler));
            conn.Setup(c => c.CreateCommand()).Returns(cmd);
            conn.SetupGet(c => c.State).Returns(ConnectionState.Open);
            
            //Act
            var columns = sut.ExtractDbMetadata(cdc).GetAwaiter().GetResult();

            //Assert
            columns.Should().BeEmpty();
        }
    }
}
