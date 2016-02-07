using RepositoryAndUnitOfWorkPattern.Universal;
using SQLite.Net;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RepositoryAndUnitOfWorkPattern.ThirdSolution
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly SQLiteConnection Connection;

        public Repository(SQLiteConnection connection)
        {
            Connection = connection;
        }

        public int Count()
        {
            string query = String.Format("SELECT COUNT(*) AS Count FROM '{0}'", GetTableName());
            var result = Connection.Query<TableCountMap>(query);
            var firstItem = result.First();
            return firstItem.NumberOfItems;
        }

        public IEnumerable<T> GetAll()
        {
            return Connection.Table<T>().AsEnumerable();
        }

        public int Insert(T item)
        {
            return Connection.Insert(item);
        }

        public T GetById(string idValue)
        {
            var query = String.Format("SELECT * FROM {0} WHERE {1} = '{2}'", GetTableName(), GetPrimaryKeys().First(), idValue);

            return Connection.Query<T>(query).Single();
        }

        public void InsertOrReplace(T item)
        {
            Connection.InsertOrReplace(item);
        }

        public void Delete(T item)
        {
            Connection.Delete(item);
        }

        public void InsertAll(IEnumerable<T> items)
        {
            Connection.InsertAll(items);
        }

        public void InsertOrReplaceAll(IEnumerable<T> items)
        {
            Connection.InsertOrReplaceAll(items);
        }

        public void ClearTable()
        {
            var query = String.Format("DELETE FROM {0}", GetTableName());
            Connection.Execute(query);
        }

        public void Update(T item)
        {
            Connection.Update(item);
        }

        public void UpdateAll(IEnumerable<T> items)
        {
            Connection.UpdateAll(items);
        }

        private string GetTableName()
        {
            var attributes = typeof(T).GetTypeInfo().GetCustomAttributes(false);
            var columnMapping = attributes.FirstOrDefault(m => m.GetType() == typeof(TableAttribute));

            var mapsTo = (TableAttribute)columnMapping;
            return mapsTo.Name;
        }

        private IEnumerable<PropertyInfo> GetPrimaryKeys()
        {
            var primaryKeysProperty =
                typeof(T).GetTypeInfo()
                    .DeclaredProperties.Where(
                        m => m.GetCustomAttributes(false).Any(at => at.GetType() == typeof(PrimaryKeyAttribute)));

            return primaryKeysProperty;
        }

        internal class TableCountMap
        {
            public int NumberOfItems { get; set; }
        }
    }
}