using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Npgsql;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.SqlVendors;
using SqlKata.Compilers;

namespace SchemaTypist.SqlVendors.PostgreSql
{
    [SqlVendorDefinition]
    public class Postgres : ISqlVendor 
    {
        public (IDbConnection, Compiler) GetDbInterfaceProviders(CodeGenConfig config)
        {
            return (new NpgsqlConnection(config.ConnectionString), new PostgresCompiler());
        }

        public SqlVendorType VendorType => SqlVendorType.PostgreSql;

        public ISqlDialect Dialect => new PostgresDialect();

        private class PostgresDialect : ISqlDialect
        {
            public IEnumerable<string> Keywords { get; } = new List<string>()
            {
                "A", "ABORT", "ABS", "ABSENT", "ABSOLUTE", "ACCESS", "ACCORDING",
                "ACOS", "ACTION", "ADA", "ADD", "ADMIN", "AFTER", "AGGREGATE", "ALL",
                "ALLOCATE", "ALSO", "ALTER", "ALWAYS", "ANALYSE", "ANALYZE", "AND",
                "ANY", "ARE", "ARRAY", "ARRAY_AGG", "ARRAY_​MAX_​CARDINALITY",
                "AS", "ASC", "ASENSITIVE", "ASIN", "ASSERTION", "ASSIGNMENT",
                "ASYMMETRIC", "AT", "ATAN", "ATOMIC", "ATTACH", "ATTRIBUTE", "ATTRIBUTES",
                "AUTHORIZATION", "AVG", "BACKWARD", "BASE64", "BEFORE", "BEGIN",
                "BEGIN_FRAME", "BEGIN_PARTITION", "BERNOULLI", "BETWEEN", "BIGINT",
                "BINARY", "BIT", "BIT_LENGTH", "BLOB", "BLOCKED", "BOM", "BOOLEAN",
                "BOTH", "BREADTH", "BY", "C", "CACHE", "CALL", "CALLED", "CARDINALITY",
                "CASCADE", "CASCADED", "CASE", "CAST", "CATALOG", "CATALOG_NAME",
                "CEIL", "CEILING", "CHAIN", "CHAINING", "CHAR", "CHARACTER", "CHARACTERISTICS",
                "CHARACTERS", "CHARACTER_LENGTH", "CHARACTER_​SET_​CATALOG", "CHARACTER_SET_NAME",
                "CHARACTER_SET_SCHEMA", "CHAR_LENGTH", "CHECK", "CHECKPOINT",
                "CLASS", "CLASSIFIER", "CLASS_ORIGIN", "CLOB", "CLOSE", "CLUSTER",
                "COALESCE", "COBOL", "COLLATE", "COLLATION", "COLLATION_CATALOG", "COLLATION_NAME",
                "COLLATION_SCHEMA", "COLLECT", "COLUMN", "COLUMNS", "COLUMN_NAME",
                "COMMAND_FUNCTION", "COMMAND_​FUNCTION_​CODE", "COMMENT", "COMMENTS", "COMMIT",
                "COMMITTED", "COMPRESSION", "CONCURRENTLY", "CONDITION", "CONDITIONAL",
                "CONDITION_NUMBER", "CONFIGURATION", "CONFLICT", "CONNECT", "CONNECTION",
                "CONNECTION_NAME", "CONSTRAINT", "CONSTRAINTS", "CONSTRAINT_CATALOG",
                "CONSTRAINT_NAME", "CONSTRAINT_SCHEMA", "CONSTRUCTOR", "CONTAINS", "CONTENT",
                "CONTINUE", "CONTROL", "CONVERSION", "CONVERT", "COPY", "CORR", "CORRESPONDING",
                "COS", "COSH", "COST", "COUNT", "COVAR_POP", "COVAR_SAMP", "CREATE",
                "CROSS", "CSV", "CUBE", "CUME_DIST", "CURRENT", "CURRENT_CATALOG",
                "CURRENT_DATE", "CURRENT_​DEFAULT_​TRANSFORM_​GROUP", "CURRENT_PATH", "CURRENT_ROLE",
                "CURRENT_ROW", "CURRENT_SCHEMA", "CURRENT_TIME", "CURRENT_TIMESTAMP",
                "CURRENT_​TRANSFORM_​GROUP_​FOR_​TYPE", "CURRENT_USER", "CURSOR", "CURSOR_NAME",
                "CYCLE", "DATA", "DATABASE", "DATALINK", "DATE", "DATETIME_​INTERVAL_​CODE",
                "DATETIME_​INTERVAL_​PRECISION", "DAY", "DB", "DEALLOCATE", "DEC",
                "DECFLOAT", "DECIMAL", "DECLARE", "DEFAULT", "DEFAULTS", "DEFERRABLE",
                "DEFERRED", "DEFINE", "DEFINED", "DEFINER", "DEGREE", "DELETE", "DELIMITER",
                "DELIMITERS", "DENSE_RANK", "DEPENDS", "DEPTH", "DEREF", "DERIVED", "DESC",
                "DESCRIBE", "DESCRIPTOR", "DETACH", "DETERMINISTIC", "DIAGNOSTICS",
                "DICTIONARY", "DISABLE", "DISCARD", "DISCONNECT", "DISPATCH", "DISTINCT",
                "DLNEWCOPY", "DLPREVIOUSCOPY", "DLURLCOMPLETE", "DLURLCOMPLETEONLY",
                "DLURLCOMPLETEWRITE", "DLURLPATH", "DLURLPATHONLY", "DLURLPATHWRITE",
                "DLURLSCHEME", "DLURLSERVER", "DLVALUE", "DO", "DOCUMENT", "DOMAIN", "DOUBLE",
                "DROP", "DYNAMIC", "DYNAMIC_FUNCTION", "DYNAMIC_​FUNCTION_​CODE", "EACH",
                "ELEMENT", "ELSE", "EMPTY", "ENABLE", "ENCODING", "ENCRYPTED", "END",
                "END-EXEC", "END_FRAME", "END_PARTITION", "ENFORCED", "ENUM", "EQUALS",
                "ERROR", "ESCAPE", "EVENT", "EVERY", "EXCEPT", "EXCEPTION", "EXCLUDE",
                "EXCLUDING", "EXCLUSIVE", "EXEC", "EXECUTE", "EXISTS", "EXP", "EXPLAIN",
                "EXPRESSION", "EXTENSION", "EXTERNAL", "EXTRACT", "FALSE", "FAMILY",
                "FETCH", "FILE", "FILTER", "FINAL", "FINALIZE", "FINISH", "FIRST", "FIRST_VALUE",
                "FLAG", "FLOAT", "FLOOR", "FOLLOWING", "FOR", "FORCE", "FOREIGN",
                "FORMAT", "FORTRAN", "FORWARD", "FOUND", "FRAME_ROW", "FREE", "FREEZE",
                "FROM", "FS", "FULFILL", "FULL", "FUNCTION", "FUNCTIONS", "FUSION", "G",
                "GENERAL", "GENERATED", "GET", "GLOBAL", "GO", "GOTO", "GRANT", "GRANTED",
                "GREATEST", "GROUP", "GROUPING", "GROUPS", "HANDLER", "HAVING", "HEADER",
                "HEX", "HIERARCHY", "HOLD", "HOUR", "ID", "IDENTITY", "IF", "IGNORE", "ILIKE",
                "IMMEDIATE", "IMMEDIATELY", "IMMUTABLE", "IMPLEMENTATION", "IMPLICIT",
                "IMPORT", "IN", "INCLUDE", "INCLUDING", "INCREMENT", "INDENT", "INDEX",
                "INDEXES", "INDICATOR", "INHERIT", "INHERITS", "INITIAL", "INITIALLY",
                "INLINE", "INNER", "INOUT", "INPUT", "INSENSITIVE", "INSERT", "INSTANCE",
                "INSTANTIABLE", "INSTEAD", "INT", "INTEGER", "INTEGRITY", "INTERSECT",
                "INTERSECTION", "INTERVAL", "INTO", "INVOKER", "IS", "ISNULL", "ISOLATION",
                "JOIN", "JSON", "JSON_ARRAY", "JSON_ARRAYAGG", "JSON_EXISTS", "JSON_OBJECT",
                "JSON_OBJECTAGG", "JSON_QUERY", "JSON_TABLE", "JSON_TABLE_PRIMITIVE",
                "JSON_VALUE", "K", "KEEP", "KEY", "KEYS", "KEY_MEMBER", "KEY_TYPE", "LABEL", "LAG",
                "LANGUAGE", "LARGE", "LAST", "LAST_VALUE", "LATERAL", "LEAD", "LEADING",
                "LEAKPROOF", "LEAST", "LEFT", "LENGTH", "LEVEL", "LIBRARY", "LIKE", "LIKE_REGEX",
                "LIMIT", "LINK", "LISTAGG", "LISTEN", "LN", "LOAD", "LOCAL", "LOCALTIME",
                "LOCALTIMESTAMP", "LOCATION", "LOCATOR", "LOCK", "LOCKED", "LOG", "LOG10", "LOGGED",
                "LOWER", "M", "MAP", "MAPPING", "MATCH", "MATCHED", "MATCHES", "MATCH_NUMBER",
                "MATCH_RECOGNIZE", "MATERIALIZED", "MAX", "MAXVALUE", "MEASURES", "MEMBER",
                "MERGE", "MESSAGE_LENGTH", "MESSAGE_OCTET_LENGTH", "MESSAGE_TEXT", "METHOD",
                "MIN", "MINUTE", "MINVALUE", "MOD", "MODE", "MODIFIES", "MODULE", "MONTH",
                "MORE", "MOVE", "MULTISET", "MUMPS", "NAME", "NAMES", "NAMESPACE", "NATIONAL",
                "NATURAL", "NCHAR", "NCLOB", "NESTED", "NESTING", "NEW", "NEXT", "NFC",
                "NFD", "NFKC", "NFKD", "NIL", "NO", "NONE", "NORMALIZE", "NORMALIZED", "NOT",
                "NOTHING", "NOTIFY", "NOTNULL", "NOWAIT", "NTH_VALUE", "NTILE", "NULL",
                "NULLABLE", "NULLIF", "NULLS", "NUMBER", "NUMERIC", "OBJECT", "OCCURRENCES_REGEX",
                "OCTETS", "OCTET_LENGTH", "OF", "OFF", "OFFSET", "OIDS", "OLD", "OMIT",
                "ON", "ONE", "ONLY", "OPEN", "OPERATOR", "OPTION", "OPTIONS", "OR", "ORDER",
                "ORDERING", "ORDINALITY", "OTHERS", "OUT", "OUTER", "OUTPUT", "OVER", "OVERFLOW",
                "OVERLAPS", "OVERLAY", "OVERRIDING", "OWNED", "OWNER", "P", "PAD", "PARALLEL",
                "PARAMETER", "PARAMETER_MODE", "PARAMETER_NAME", "PARAMETER_​ORDINAL_​POSITION",
                "PARAMETER_​SPECIFIC_​CATALOG", "PARAMETER_​SPECIFIC_​NAME", "PARAMETER_​SPECIFIC_​SCHEMA",
                "PARSER", "PARTIAL", "PARTITION", "PASCAL", "PASS", "PASSING", "PASSTHROUGH",
                "PASSWORD", "PAST", "PATH", "PATTERN", "PER", "PERCENT", "PERCENTILE_CONT",
                "PERCENTILE_DISC", "PERCENT_RANK", "PERIOD", "PERMISSION", "PERMUTE", "PLACING",
                "PLAN", "PLANS", "PLI", "POLICY", "PORTION", "POSITION", "POSITION_REGEX", "POWER",
                "PRECEDES", "PRECEDING", "PRECISION", "PREPARE", "PREPARED", "PRESERVE",
                "PRIMARY", "PRIOR", "PRIVATE", "PRIVILEGES", "PROCEDURAL", "PROCEDURE", "PROCEDURES",
                "PROGRAM", "PRUNE", "PTF", "PUBLIC", "PUBLICATION", "QUOTE", "QUOTES",
                "RANGE", "RANK", "READ", "READS", "REAL", "REASSIGN", "RECHECK", "RECOVERY",
                "RECURSIVE", "REF", "REFERENCES", "REFERENCING", "REFRESH", "REGR_AVGX",
                "REGR_AVGY", "REGR_COUNT", "REGR_INTERCEPT", "REGR_R2", "REGR_SLOPE", "REGR_SXX",
                "REGR_SXY", "REGR_SYY", "REINDEX", "RELATIVE", "RELEASE", "RENAME", "REPEATABLE",
                "REPLACE", "REPLICA", "REQUIRING", "RESET", "RESPECT", "RESTART", "RESTORE",
                "RESTRICT", "RESULT", "RETURN", "RETURNED_CARDINALITY", "RETURNED_LENGTH",
                "RETURNED_​OCTET_​LENGTH", "RETURNED_SQLSTATE", "RETURNING", "RETURNS", "REVOKE",
                "RIGHT", "ROLE", "ROLLBACK", "ROLLUP", "ROUTINE", "ROUTINES", "ROUTINE_CATALOG",
                "ROUTINE_NAME", "ROUTINE_SCHEMA", "ROW", "ROWS", "ROW_COUNT", "ROW_NUMBER", "RULE",
                "RUNNING", "SAVEPOINT", "SCALAR", "SCALE", "SCHEMA", "SCHEMAS", "SCHEMA_NAME",
                "SCOPE", "SCOPE_CATALOG", "SCOPE_NAME", "SCOPE_SCHEMA", "SCROLL", "SEARCH",
                "SECOND", "SECTION", "SECURITY", "SEEK", "SELECT", "SELECTIVE", "SELF", "SENSITIVE",
                "SEQUENCE", "SEQUENCES", "SERIALIZABLE", "SERVER", "SERVER_NAME", "SESSION",
                "SESSION_USER", "SET", "SETOF", "SETS", "SHARE", "SHOW", "SIMILAR", "SIMPLE",
                "SIN", "SINH", "SIZE", "SKIP", "SMALLINT", "SNAPSHOT", "SOME", "SOURCE", "SPACE",
                "SPECIFIC", "SPECIFICTYPE", "SPECIFIC_NAME", "SQL", "SQLCODE", "SQLERROR",
                "SQLEXCEPTION", "SQLSTATE", "SQLWARNING", "SQRT", "STABLE", "STANDALONE", "START",
                "STATE", "STATEMENT", "STATIC", "STATISTICS", "STDDEV_POP", "STDDEV_SAMP",
                "STDIN", "STDOUT", "STORAGE", "STORED", "STRICT", "STRING", "STRIP", "STRUCTURE",
                "STYLE", "SUBCLASS_ORIGIN", "SUBMULTISET", "SUBSCRIPTION", "SUBSET", "SUBSTRING",
                "SUBSTRING_REGEX", "SUCCEEDS", "SUM", "SUPPORT", "SYMMETRIC", "SYSID", "SYSTEM",
                "SYSTEM_TIME", "SYSTEM_USER", "T", "TABLE", "TABLES", "TABLESAMPLE", "TABLESPACE",
                "TABLE_NAME", "TAN", "TANH", "TEMP", "TEMPLATE", "TEMPORARY", "TEXT", "THEN",
                "THROUGH", "TIES", "TIME", "TIMESTAMP", "TIMEZONE_HOUR", "TIMEZONE_MINUTE", "TO",
                "TOKEN", "TOP_LEVEL_COUNT", "TRAILING", "TRANSACTION", "TRANSACTIONS_​COMMITTED",
                "TRANSACTIONS_​ROLLED_​BACK", "TRANSACTION_ACTIVE", "TRANSFORM", "TRANSFORMS",
                "TRANSLATE", "TRANSLATE_REGEX", "TRANSLATION", "TREAT", "TRIGGER", "TRIGGER_CATALOG",
                "TRIGGER_NAME", "TRIGGER_SCHEMA", "TRIM", "TRIM_ARRAY", "TRUE", "TRUNCATE",
                "TRUSTED", "TYPE", "TYPES", "UESCAPE", "UNBOUNDED", "UNCOMMITTED", "UNCONDITIONAL",
                "UNDER", "UNENCRYPTED", "UNION", "UNIQUE", "UNKNOWN", "UNLINK", "UNLISTEN",
                "UNLOGGED", "UNMATCHED", "UNNAMED", "UNNEST", "UNTIL", "UNTYPED", "UPDATE",
                "UPPER", "URI", "USAGE", "USER", "USER_​DEFINED_​TYPE_​CATALOG",
                "USER_​DEFINED_​TYPE_​CODE", "USER_​DEFINED_​TYPE_​NAME", "USER_​DEFINED_​TYPE_​SCHEMA",
                "USING", "UTF16", "UTF32", "UTF8", "VACUUM", "VALID", "VALIDATE", "VALIDATOR",
                "VALUE", "VALUES", "VALUE_OF", "VARBINARY", "VARCHAR", "VARIADIC", "VARYING",
                "VAR_POP", "VAR_SAMP", "VERBOSE", "VERSION", "VERSIONING", "VIEW", "VIEWS",
                "VOLATILE", "WHEN", "WHENEVER", "WHERE", "WHITESPACE", "WIDTH_BUCKET", "WINDOW",
                "WITH", "WITHIN", "WITHOUT", "WORK", "WRAPPER", "WRITE", "XML", "XMLAGG",
                "XMLATTRIBUTES", "XMLBINARY", "XMLCAST", "XMLCOMMENT", "XMLCONCAT",
                "XMLDECLARATION", "XMLDOCUMENT", "XMLELEMENT", "XMLEXISTS", "XMLFOREST", "XMLITERATE",
                "XMLNAMESPACES", "XMLPARSE", "XMLPI", "XMLQUERY", "XMLROOT", "XMLSCHEMA",
                "XMLSERIALIZE", "XMLTABLE", "XMLTEXT", "XMLVALIDATE", "YEAR", "YES", "ZONE"
            };

            public IEnumerable<string> DataTypes { get; } = Enumerable.Empty<string>();

            public bool HasConflict(string proposedName)
            {
                return false;
            }

            public string DetermineDotNetDataType(string sqlDataType, bool isNullable)
            {
                var retVal = (sqlDataType, isNullable) switch
                {
                    ("boolean", false) => "bool",
                    ("boolean", true) => "bool?",
                    ("smallint", false) => "short",
                    ("smallint", true) => "short?",
                    ("integer", false) => "int",
                    ("integer", true) => "int?",
                    ("bigint", false) => "long",
                    ("bigint", true) => "long?",
                    ("real", false) => "float",
                    ("real", true) => "float?",
                    ("double precision", false) => "double",
                    ("double precision", true) => "double?",
                    ("numeric", false) => "decimal",
                    ("numeric", true) => "decimal?",
                    ("money", false) => "decimal",
                    ("money", true) => "decimal?",
                    ("text", false) => "string",
                    ("text", true) => "string",
                    ("character varying", false) => "string",
                    ("character varying", true) => "string",
                    ("character", false) => "string",
                    ("character", true) => "string",
                    ("citext", false) => "string",
                    ("citext", true) => "string",
                    ("json", false) => "string",
                    ("json", true) => "string",
                    ("jsonb", false) => "string",
                    ("jsonb", true) => "string",
                    ("xml", false) => "string",
                    ("xml", true) => "string",
                    ("uuid", false) => "Guid",
                    ("uuid", true) => "Guid?",
                    ("bytea", false) => "byte[]",
                    ("bytea", true) => "byte[]",
                    ("timestamp without time zone", false) => "DateTime",
                    ("timestamp without time zone", true) => "DateTime?",
                    ("timestamp with time zone", false) => "DateTime",
                    ("timestamp with time zone", true) => "DateTime?",
                    ("date", false) => "DateTime",
                    ("date", true) => "DateTime?",
                    ("time without time zone", false) => "TimeSpan",
                    ("time without time zone", true) => "TimeSpan?",
                    ("time with time zone", false) => "DateTimeOffset",
                    ("time with time zone", true) => "DateTimeOffset?",
                    ("bit(1)", false) => "bool",
                    ("bit(1)", true) => "bool?",
                    ("bit(n)", false) => "BitArray",
                    ("bit(n)", true) => "BitArray",
                    ("bit varying", false) => "BitArray",
                    ("bit varying", true) => "BitArray",
                    ("oid", false) => "uint",
                    ("oid", true) => "uint?",
                    ("xid", false) => "uint",
                    ("xid", true) => "uint?",
                    ("cid", false) => "uint",
                    ("cid", true) => "uint?",
                    ("oidvector", false) => "uint[]",
                    ("oidvector", true) => "uint[]",
                    ("name", false) => "string",
                    ("name", true) => "string",
                    ("char", false) => "char",
                    ("char", true) => "char?",
                    _ => "Object",
                };
                return retVal;
            }

            public string BuildQualifiedName(TabularStructure tabularStructure)
            {
                //Fully qualified name for tabular structures in pgsql is schema.tableName.  Cross-database references are not implemented
                return $"{tabularStructure.SqlSchema}.{tabularStructure.SqlName}";
            }

            public string DetermineDefaultValue(string columnDefault)
            {
                if (columnDefault is null) return null; //No columnDefault has been set.
                
                //If string ends with ), then it is a sql function call, in which case ignore
                if (columnDefault.EndsWith(")")) return null;


                var cd = columnDefault.Split(new []{"::"}, StringSplitOptions.None)[0];
                if (cd is "NULL") return "null"; //Default is to assign null to that column.
                
                //The rest are literals.  Replace single quotes if any.
                return cd.Replace("'", "");
            }
        }
    }
}
