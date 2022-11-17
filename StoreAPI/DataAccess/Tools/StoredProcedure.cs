using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess.Tools
{
    public class StoredProcedure
    {
        private List<SqlParameter> sqlParameters;
        private string name;

        public StoredProcedure(string name)
        {
            sqlParameters = new List<SqlParameter>();
            this.name = name;
        }

        public async Task<DataTable> Execute(string connectionString)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();

                using var sqlCommand = new SqlCommand(name, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (var sqlParameter in sqlParameters)
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                }

                using var sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                var dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                await sqlConnection.CloseAsync();
                await sqlConnection.DisposeAsync();
                sqlParameters.Clear();
                return dataTable;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddParameter(string name, object value)
        {
            sqlParameters.Add(new SqlParameter(name, value));
        }

    }
}

