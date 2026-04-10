namespace SqlKata
{
    public abstract class AbstractColumn : AbstractClause
    {
    }

    /// <summary>
    /// Represents "column" or "column as alias" clause.
    /// </summary>
    /// <seealso cref="AbstractColumn" />
    public class Column : AbstractColumn
    {
        /// <summary>
        /// Gets or sets the column name. Can be "columnName" or "columnName as columnAlias".
        /// </summary>
        /// <value>
        /// The column name.
        /// </value>
        public string Name { get; set; }

        /// <inheritdoc />
        public override AbstractClause Clone()
        {
            return new Column
            {
                Engine = Engine,
                Name = Name,
                Component = Component,
            };
        }
    }

    /// <summary>
    /// Represents column clause calculated using query.
    /// </summary>
    /// <seealso cref="AbstractColumn" />
    public class QueryColumn : AbstractColumn
    {
        /// <summary>
        /// Gets or sets the query that will be used for column value calculation.
        /// </summary>
        /// <value>
        /// The query for column value calculation.
        /// </value>
        public Query Query { get; set; }
        public override AbstractClause Clone()
        {
            return new QueryColumn
            {
                Engine = Engine,
                Query = Query.Clone(),
                Component = Component,
            };
        }
    }

    public class RawColumn : AbstractColumn
    {
        /// <summary>
        /// Gets or sets the RAW expression.
        /// </summary>
        /// <value>
        /// The RAW expression.
        /// </value>
        public string Expression { get; set; }
        public object[] Bindings { set; get; }

        /// <inheritdoc />
        public override AbstractClause Clone()
        {
            return new RawColumn
            {
                Engine = Engine,
                Expression = Expression,
                Bindings = Bindings,
                Component = Component,
            };
        }
    }

    /// <summary>
    /// Represents an aggregated column clause with an optional filter
    /// </summary>
    /// <seealso cref="AbstractColumn" />
    public class AggregatedColumn : AbstractColumn
    {
        /// <summary>
        /// Gets or sets the a query that used to filter the data, 
        /// the compiler will consider only the `Where` clause.
        /// </summary>
        /// <value>
        /// The filter query.
        /// </value>
        public Query Filter { get; set; } = null;
        public string Aggregate { get; set; }
        public AbstractColumn Column { get; set; }
        public override AbstractClause Clone()
        {
            return new AggregatedColumn
            {
                Engine = Engine,
                Filter = Filter?.Clone(),
                Column = Column.Clone() as AbstractColumn,
                Aggregate = Aggregate,
                Component = Component,
            };
        }
    }

    /// <summary>
    /// Represents an arithmetic column clause.
    /// </summary>
    /// <seealso cref="AbstractColumn" />
    public class ArithmeticColumn : AbstractColumn
    {
        /// <summary>
        /// Gets or sets the left operand.
        /// </summary>
        /// <value>
        /// The left operand.
        /// </value>
        public AbstractColumn Left { get; set; }
        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>
        /// The operator.
        /// </value>
        public string Operator { get; set; }
        /// <summary>
        /// Gets or sets the right operand.
        /// </summary>
        /// <value>
        /// The right operand.
        /// </value>
        public AbstractColumn Right { get; set; }
        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>
        /// The alias.
        /// </value>
        public string Alias { get; set; }

        public override AbstractClause Clone()
        {
            return new ArithmeticColumn
            {
                Engine = Engine,
                Component = Component,
                Left = Left.Clone() as AbstractColumn,
                Operator = Operator,
                Right = Right.Clone() as AbstractColumn,
                Alias = Alias,
            };
        }
    }

    public class NumberColumn : AbstractColumn
    {
        public object Value { get; set; }

        public override AbstractClause Clone()
        {
            return new NumberColumn
            {
                Engine = Engine,
                Component = Component,
                Value = Value,
            };
        }
    }
}
