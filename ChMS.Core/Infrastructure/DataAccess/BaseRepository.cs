﻿using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Infrastructure.DataAccess
{
    public class BaseRepository
    {
        protected IConnectionString _connectionString { get; }
        public BaseRepository(IConnectionString connectionString)
        {
            _connectionString = connectionString;

        }
        public async Task<List<T>> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString.GetConnectionString()))
            {
                var rows = await connection.QueryAsync<T>(sql);
                return rows.ToList();
            }

        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString.GetConnectionString()))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);
                return rows.ToList();
            }

        }

        public async Task<T> LoadSingleData<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString.GetConnectionString()))
            {
                var rows = await connection.QuerySingleOrDefaultAsync<T>(sql, parameters);
                return rows;
            }

        }

        public Task SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString.GetConnectionString()))
            {

                return connection.ExecuteAsync(sql, parameters);

            }

        }

        public Task<int> SaveMany<T>(string sql, List<T> parameters)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString.GetConnectionString()))
            {
                connection.Open();
                var trans = connection.BeginTransaction();
                var returned = connection.ExecuteAsync(sql, parameters, transaction: trans);
                trans.Commit();
                connection.Close();
                return returned;
            }

        }

        public Task<T> GetLastInsertId<T>()
        {
            return LoadSingleData<T, object>("select last_insert_id()", new { });
        }
    }
}