using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.SqlServer.Server;

namespace Carable.EntityFrameworkCore.SqlServer
{
    public class StringIdsBuilder
    {
        private readonly TableValuedParameterBuilder _tvp;

        public StringIdsBuilder()
        {
            _tvp = new TableValuedParameterBuilder("dbo.StringIds",
                    new SqlMetaData("Id", SqlDbType.NVarChar, -1));
        }


        public StringIdsBuilder AddRows(IEnumerable<string> rows)
        {
            _tvp.AddRows(rows.Select(v => new object[] { v }).ToArray());
            return this;
        }
        public SqlParameter CreateParameter(string name) => _tvp.CreateParameter(name);
        public static string TypeDeclarationSql = "CREATE TYPE dbo.StringIds AS TABLE (Id NVarChar(MAX));";
    }
}
