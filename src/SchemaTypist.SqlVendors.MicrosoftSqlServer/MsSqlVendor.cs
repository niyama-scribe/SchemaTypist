using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.SqlVendors;
using SqlKata.Compilers;

namespace SchemaTypist.SqlVendors.MicrosoftSqlServer
{
    [SqlVendorDefinition]
    public class MsSqlVendor : ISqlVendor
    {
        public (IDbConnection, Compiler) GetDbInterfaceProviders(CodeGenConfig config)
        {
            return (new SqlConnection(config.ConnectionString), new SqlServerCompiler());
        }

        public ISqlDialect Dialect => new MsSqlDialect();
        public IMetadataQueryBuilder MetadataQueryBuilder => new MetadataQueryBuilder();
        public SqlVendorType VendorType => SqlVendorType.MicrosoftSqlServer;


        private class MsSqlDialect : ISqlDialect
        {
            private static readonly List<string> DefaultKeywords = new()
            {
                "ADD",
                "ALL",
                "ALTER",
                "AND",
                "ANY",
                "AS",
                "ASC",
                "AUTHORIZATION",
                "BACKUP",
                "BEGIN",
                "BETWEEN",
                "BREAK",
                "BROWSE",
                "BULK",
                "BY",
                "CASCADE",
                "CASE",
                "CHECK",
                "CHECKPOINT",
                "CLOSE",
                "CLUSTERED",
                "COALESCE",
                "COLLATE",
                "COLUMN",
                "COMMIT",
                "COMPUTE",
                "CONSTRAINT",
                "CONTAINS",
                "CONTAINSTABLE",
                "CONTINUE",
                "CONVERT",
                "CREATE",
                "CROSS",
                "CURRENT",
                "CURRENT_DATE",
                "CURRENT_TIME",
                "CURRENT_TIMESTAMP",
                "CURRENT_USER",
                "CURSOR",
                "DATABASE",
                "DBCC",
                "DEALLOCATE",
                "DECLARE",
                "DEFAULT",
                "DELETE",
                "DENY",
                "DESC",
                "DISK",
                "DISTINCT",
                "DISTRIBUTED",
                "DOUBLE",
                "DROP",
                "DUMP",
                "ELSE",
                "END",
                "ERRLVL",
                "ESCAPE",
                "EXCEPT",
                "EXEC",
                "EXECUTE",
                "EXISTS",
                "EXIT",
                "EXTERNAL",
                "FETCH",
                "FILE",
                "FILLFACTOR",
                "FOR",
                "FOREIGN",
                "FREETEXT",
                "FREETEXTTABLE",
                "FROM",
                "FULL",
                "FUNCTION",
                "GOTO",
                "GRANT",
                "GROUP",
                "HAVING",
                "HOLDLOCK",
                "IDENTITY",
                "IDENTITY_INSERT",
                "IDENTITYCOL",
                "IF",
                "IN",
                "INDEX",
                "INNER",
                "INSERT",
                "INTERSECT",
                "INTO",
                "IS",
                "JOIN",
                "KEY",
                "KILL",
                "LEFT",
                "LIKE",
                "LINENO",
                "LOAD",
                "MERGE",
                "NATIONAL",
                "NOCHECK",
                "NONCLUSTERED",
                "NOT",
                "NULL",
                "NULLIF",
                "OF",
                "OFF",
                "OFFSETS",
                "ON",
                "OPEN",
                "OPENDATASOURCE",
                "OPENQUERY",
                "OPENROWSET",
                "OPENXML",
                "OPTION",
                "OR",
                "ORDER",
                "OUTER",
                "OVER",
                "PERCENT",
                "PIVOT",
                "PLAN",
                "PRECISION",
                "PRIMARY",
                "PRINT",
                "PROC",
                "PROCEDURE",
                "PUBLIC",
                "RAISERROR",
                "READ",
                "READTEXT",
                "RECONFIGURE",
                "REFERENCES",
                "REPLICATION",
                "RESTORE",
                "RESTRICT",
                "RETURN",
                "REVERT",
                "REVOKE",
                "RIGHT",
                "ROLLBACK",
                "ROWCOUNT",
                "ROWGUIDCOL",
                "RULE",
                "SAVE",
                "SCHEMA",
                "SECURITYAUDIT",
                "SELECT",
                "SEMANTICKEYPHRASETABLE",
                "SEMANTICSIMILARITYDETAILSTABLE",
                "SEMANTICSIMILARITYTABLE",
                "SESSION_USER",
                "SET",
                "SETUSER",
                "SHUTDOWN",
                "SOME",
                "STATISTICS",
                "SYSTEM_USER",
                "TABLE",
                "TABLESAMPLE",
                "TEXTSIZE",
                "THEN",
                "TO",
                "TOP",
                "TRAN",
                "TRANSACTION",
                "TRIGGER",
                "TRUNCATE",
                "TRY_CONVERT",
                "TSEQUAL",
                "UNION",
                "UNIQUE",
                "UNPIVOT",
                "UPDATE",
                "UPDATETEXT",
                "USE",
                "USER",
                "VALUES",
                "VARYING",
                "VIEW",
                "WAITFOR",
                "WHEN",
                "WHERE",
                "WHILE",
                "WITH",
                "WITHIN GROUP",
                "WRITETEXT"
            };

            private static readonly List<string> DefaultDataTypes = new()
            {
                "bigint",
                "binary",
                "bit",
                "char",
                "date",
                "datetime",
                "datetime2",
                "datetimeoffset",
                "decimal",
                "float",
                "image",
                "int",
                "money",
                "nchar",
                "ntext",
                "numeric",
                "nvarchar",
                "real",
                "rowversion",
                "smalldatetime",
                "smallint",
                "sql_variant",
                "text",
                "time",
                "timestamp",
                "tinyint",
                "uniqueidentifier",
                "varbinary",
                "varchar",
                "xml"
            };

            public IEnumerable<string> Keywords => DefaultKeywords;
            public IEnumerable<string> DataTypes => DefaultDataTypes;

            public bool HasConflict(string proposedName)
            {
                return Keywords.Contains(proposedName, StringComparer.InvariantCultureIgnoreCase)
                       || DataTypes.Contains(proposedName, StringComparer.InvariantCultureIgnoreCase);
            }

            public string DetermineDotNetDataType(string sqlDataType, bool isNullable)
            {
                //https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings

                var retVal = (sqlDataType, isNullable) switch
                {
                    ("bigint", false) => "long",
                    ("bigint", true) => "long?",
                    ("binary", false) => "byte[]",
                    ("binary", true) => "byte[]",
                    ("bit", false) => "bool",
                    ("bit", true) => "bool?",
                    ("char", false) => "char",
                    ("char", true) => "char?",
                    ("date", false) => "DateTime",
                    ("date", true) => "DateTime?",
                    ("datetime", false) => "DateTime",
                    ("datetime", true) => "DateTime?",
                    ("datetime2", false) => "DateTime",
                    ("datetime2", true) => "DateTime?",
                    ("datetimeoffset", false) => "DateTimeOffset",
                    ("datetimeoffset", true) => "DateTimeOffset?",
                    ("decimal", false) => "decimal",
                    ("decimal", true) => "decimal?",
                    ("float", false) => "double",
                    ("float", true) => "double?",
                    ("image", false) => "byte[]",
                    ("image", true) => "byte[]",
                    ("int", false) => "int",
                    ("int", true) => "int?",
                    ("money", false) => "decimal",
                    ("money", true) => "decimal?",
                    ("nchar", false) => "string",
                    ("nchar", true) => "string",
                    ("ntext", false) => "string",
                    ("ntext", true) => "string",
                    ("numeric", false) => "decimal",
                    ("numeric", true) => "decimal",
                    ("nvarchar", false) => "string",
                    ("nvarchar", true) => "string",
                    ("real", false) => "float",
                    ("real", true) => "float?",
                    ("rowversion", false) => "byte[]",
                    ("rowversion", true) => "byte[]",
                    ("smalldatetime", false) => "DateTime",
                    ("smalldatetime", true) => "DateTime?",
                    ("smallint", false) => "short",
                    ("smallint", true) => "short?",
                    ("smallmoney", false) => "decimal",
                    ("smallmoney", true) => "decimal?",
                    ("sql_variant", false) => "object",
                    ("sql_variant", true) => "object",
                    ("text", false) => "string",
                    ("text", true) => "string",
                    ("time", false) => "TimeSpan",
                    ("time", true) => "TimeSpan?",
                    ("timestamp", false) => "byte[]",
                    ("timestamp", true) => "byte[]",
                    ("tinyint", false) => "byte",
                    ("tinyint", true) => "byte?",
                    ("uniqueidentifier", false) => "Guid",
                    ("uniqueidentifier", true) => "Guid?",
                    ("varbinary", false) => "byte[]",
                    ("varbinary", true) => "byte[]",
                    ("varchar", false) => "string",
                    ("varchar", true) => "string",
                    ("xml", false) => "string",
                    ("xml", true) => "string",
                    _ => "object"
                };
                return retVal;
            }

            public string BuildQualifiedName(TabularStructure tabularStructure)
            {
                //Fully qualified name for tabular structures in mssql is catalog.schema.tableName.
                return $"{tabularStructure.SqlCatalog}.{tabularStructure.SqlSchema}.{tabularStructure.SqlName}";
            }

            public string DetermineDefaultValue(string columnDefault)
            {
                if (columnDefault is null) return null; //No columnDefault has been set.
                if (columnDefault == "(NULL)") return "null"; //Default is to assign null to that column.
                //Strip all enclosing brackets.
                var s = columnDefault;
                while (s.StartsWith("(") && s.EndsWith(")")) s = s.Substring(1, s.Length - 2);

                //If string still ends with ), then it is a sql function call, in which case ignore
                if (s.EndsWith(")")) return null;

                //The rest are literals.  Replace any single quotes with double-quotes
                s = s.Replace("'", "");

                return s;
            }
        }
    }
}