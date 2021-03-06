﻿namespace LinqToQuerystring.TreeNodes.Functions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.Exceptions;
    using LinqToQuerystring.TreeNodes.Base;

    public class MinutesNode : SingleChildNode
    {
        public MinutesNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var childexpression = this.ChildNode.BuildLinqExpression(query, expression, item);

            if (!typeof(DateTime).IsAssignableFrom(childexpression.Type))
            {
                throw new FunctionNotSupportedException(childexpression.Type, "minutes");
            }

            return Expression.Property(childexpression, "Minute");
        }
    }
}