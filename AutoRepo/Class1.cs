using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoRepo
{
    public abstract class BaseRepository<TModel>
    {
        public TModel Model
        {
            get
            {
                return new Lazy<TModel>().Value;
            }
        }

        public virtual TModel FindById(dynamic id)
        {
            return (TModel)GetDatabase()[GetTableName()].FindById(id);
        }

        public virtual IEnumerable<TModel> FindAll()
        {
            return GetDatabase()[GetTableName()].All().Cast<TModel>();
        }

        public virtual IEnumerable<TModel> FindAllByThisFieldAndValue(Expression<Func<TModel, bool>> func)
        {
            var db = GetDatabase();
            var tableName = GetTableName();

            var param = func.Parameters[0];
            var operation = (BinaryExpression)func.Body;
            var left = (MemberExpression)operation.Left;
            var right = (ConstantExpression) operation.Right;
            var fieldName = left.Member.Name;
            var variable = (ParameterExpression) left.Expression;
            var variableName = variable.Name;


            var operand = (MemberExpression) ((UnaryExpression) func.Body).Operand;

            return db[tableName].FindAll().Cast<TModel>();
        }

        private static string GetTableName()
        {
            return typeof(TModel).Name.Replace("ViewModel", "").Replace("Model", "");
        }        

        protected virtual dynamic GetDatabase()
        {
            return null;
        }
    }
}
