using System;

namespace SqlKata.Extensions
{
    public static class ColumnExtensions
    {
        public static ArithmeticColumn Arithmetic(this AbstractColumn left, string op, AbstractColumn right)
        {
            return new ArithmeticColumn
            {
                Left = left,
                Operator = op,
                Right = right
            };
        }

        public static ArithmeticColumn Arithmetic(this AbstractColumn left, string op, object value)
        {
            return left.Arithmetic(op, new NumberColumn { Value = value });
        }

        public static ArithmeticColumn Add(this AbstractColumn left, AbstractColumn right) => left.Arithmetic("+", right);
        public static ArithmeticColumn Add(this AbstractColumn left, object value) => left.Arithmetic("+", value);

        public static ArithmeticColumn Subtract(this AbstractColumn left, AbstractColumn right) => left.Arithmetic("-", right);
        public static AbstractColumn Subtract(this AbstractColumn left, object value) => left.Arithmetic("-", value);

        public static ArithmeticColumn Multiply(this AbstractColumn left, AbstractColumn right) => left.Arithmetic("*", right);
        public static ArithmeticColumn Multiply(this AbstractColumn left, object value) => left.Arithmetic("*", value);

        public static ArithmeticColumn Divide(this AbstractColumn left, AbstractColumn right) => left.Arithmetic("/", right);
        public static ArithmeticColumn Divide(this AbstractColumn left, object value) => left.Arithmetic("/", value);

        public static ArithmeticColumn As(this ArithmeticColumn column, string alias)
        {
            column.Alias = alias;
            return column;
        }
        
        /// <summary>
        /// Helper to turn a string into a Column
        /// </summary>
        public static Column C(this string name)
        {
            return new Column { Name = name };
        }
    }
}
