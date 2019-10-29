/* PetaPoco v4.0.3 - A Tiny ORMish thing for your POCO's.
* Copyright © 2011 Topten Software.  All Rights Reserved.
* 
* Apache License 2.0 - http://www.toptensoftware.com/petapoco/license
* 
* Special thanks to Rob Conery (@robconery) for original inspiration (ie:Massive) and for 
* use of Subsonic's T4 templates, Rob Sullivan (@DataChomp) for hard core DBA advice 
* and Adam Schroder (@schotime) for lots of suggestions, improvements and Oracle support
*/

using System;
using System.Collections.Generic;
using System.Data;

namespace Allied.PetaPoco.NetCore
{
    public interface IDatabase
    {
        int CommandTimeout { get; set; }
        IDbConnection Connection { get; }
        bool EnableAutoSelect { get; set; }
        bool EnableNamedParams { get; set; }
        bool ForceDateTimesToUtc { get; set; }
        bool KeepConnectionAlive { get; set; }
        object[] LastArgs { get; }
        string LastCommand { get; }
        string LastSQL { get; }
        int OneTimeCommandTimeout { get; set; }

        void AbortTransaction();
        void BeginTransaction();
        void BuildPageQueries<T>(long skip, long take, string sql, ref object[] args, out string sqlCount, out string sqlPage);
        void BulkInsertRecords<T>(IEnumerable<T> collection);
        void CloseSharedConnection();
        void CompleteTransaction();
        IDbCommand CreateCommand(IDbConnection connection, string sql, params object[] args);
        int Delete(object poco);
        int Delete(string tableName, string primaryKeyName, object poco);
        int Delete(string tableName, string primaryKeyName, object poco, object primaryKeyValue);
        int Delete<T>(object pocoOrPrimaryKey);
        int Delete<T>(Sql sql);
        int Delete<T>(string sql, params object[] args);
        void Dispose();
        string EscapeSqlIdentifier(string str);
        string EscapeTableName(string str);
        int Execute(Sql sql);
        int Execute(string sql, params object[] args);
        T ExecuteScalar<T>(Sql sql);
        T ExecuteScalar<T>(string sql, params object[] args);
        bool Exists<T>(object primaryKey);
        List<T> Fetch<T>(int page, int itemsPerPage, Sql sql);
        List<T> Fetch<T>(int page, int itemsPerPage, string sql, params object[] args);
        List<T> Fetch<T>(Sql sql);
        List<T> Fetch<T>(string sql, params object[] args);
        List<TRet> Fetch<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> cb, Sql sql);
        List<TRet> Fetch<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> cb, string sql, params object[] args);
        List<T1> Fetch<T1, T2, T3, T4>(Sql sql);
        List<T1> Fetch<T1, T2, T3, T4>(string sql, params object[] args);
        List<TRet> Fetch<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> cb, Sql sql);
        List<TRet> Fetch<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> cb, string sql, params object[] args);
        List<T1> Fetch<T1, T2, T3>(Sql sql);
        List<T1> Fetch<T1, T2, T3>(string sql, params object[] args);
        List<TRet> Fetch<T1, T2, TRet>(Func<T1, T2, TRet> cb, Sql sql);
        List<TRet> Fetch<T1, T2, TRet>(Func<T1, T2, TRet> cb, string sql, params object[] args);
        List<T1> Fetch<T1, T2>(Sql sql);
        List<T1> Fetch<T1, T2>(string sql, params object[] args);
        T First<T>(Sql sql);
        T First<T>(string sql, params object[] args);
        T FirstOrDefault<T>(Sql sql);
        T FirstOrDefault<T>(string sql, params object[] args);
        string FormatCommand(IDbCommand cmd);
        string FormatCommand(string sql, object[] args);
        object GetAutoMapper(Type[] types);
        Func<IDataReader, object, TRet> GetMultiPocoFactory<TRet>(Type[] types, string sql, IDataReader r);
        Transaction GetTransaction();
        object Insert(object poco);
        object Insert(string tableName, string primaryKeyName, bool autoIncrement, object poco);
        object Insert(string tableName, string primaryKeyName, object poco);
        bool IsNew(object poco);
        bool IsNew(string primaryKeyName, object poco);
        void OnBeginTransaction();
        void OnConnectionClosing(IDbConnection conn);
        IDbConnection OnConnectionOpened(IDbConnection conn);
        void OnEndTransaction();
        void OnException(Exception x);
        void OnExecutedCommand(IDbCommand cmd);
        void OnExecutingCommand(IDbCommand cmd);
        void OpenSharedConnection();
        Page<T> Page<T>(int page, int itemsPerPage, Sql sql);
        Page<T> Page<T>(int page, int itemsPerPage, string sql, params object[] args);
        IEnumerable<T> Query<T>(Sql sql);
        IEnumerable<T> Query<T>(string sql, params object[] args);
        IEnumerable<TRet> Query<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> cb, Sql sql);
        IEnumerable<TRet> Query<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> cb, string sql, params object[] args);
        IEnumerable<T1> Query<T1, T2, T3, T4>(Sql sql);
        IEnumerable<T1> Query<T1, T2, T3, T4>(string sql, params object[] args);
        IEnumerable<TRet> Query<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> cb, Sql sql);
        IEnumerable<TRet> Query<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> cb, string sql, params object[] args);
        IEnumerable<T1> Query<T1, T2, T3>(Sql sql);
        IEnumerable<T1> Query<T1, T2, T3>(string sql, params object[] args);
        IEnumerable<TRet> Query<T1, T2, TRet>(Func<T1, T2, TRet> cb, Sql sql);
        IEnumerable<TRet> Query<T1, T2, TRet>(Func<T1, T2, TRet> cb, string sql, params object[] args);
        IEnumerable<T1> Query<T1, T2>(Sql sql);
        IEnumerable<T1> Query<T1, T2>(string sql, params object[] args);
        IEnumerable<TRet> Query<TRet>(Type[] types, object cb, string sql, params object[] args);
        IGridReader QueryMultiple(Sql sql);
        IGridReader QueryMultiple(string sql, params object[] args);
        int Save(object poco);
        int Save(string tableName, string primaryKeyName, object poco);
        T Single<T>(object primaryKey);
        T Single<T>(Sql sql);
        T Single<T>(string sql, params object[] args);
        T SingleOrDefault<T>(object primaryKey);
        T SingleOrDefault<T>(Sql sql);
        T SingleOrDefault<T>(string sql, params object[] args);
        List<T> SkipTake<T>(int skip, int take, Sql sql);
        List<T> SkipTake<T>(int skip, int take, string sql, params object[] args);
        int Update(object poco);
        int Update(object poco, IEnumerable<string> columns);
        int Update(object poco, object primaryKeyValue);
        int Update(object poco, object primaryKeyValue, IEnumerable<string> columns);
        int Update(string tableName, string primaryKeyName, object poco);
        int Update(string tableName, string primaryKeyName, object poco, IEnumerable<string> columns);
        int Update(string tableName, string primaryKeyName, object poco, object primaryKeyValue);
        int Update(string tableName, string primaryKeyName, object poco, object primaryKeyValue, IEnumerable<string> columns);
        int Update<T>(Sql sql);
        int Update<T>(string sql, params object[] args);
    }
}