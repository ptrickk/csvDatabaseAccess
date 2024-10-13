namespace SqlBuilder
{
    public partial class Query
    {
        public Query Is
        {
            get
            {
                return new Query(_query, "=", _tables);
            }
        }

        public Query Equal
        {
            get
            {
                return Is;
            }
        }

        public Query LessThan
        {
            get
            {
                return new Query(_query, "<", _tables);
            }
        }

        public Query LessOrEqualThan
        {
            get
            {
                return new Query(_query, "<=", _tables);
            }
        }

        public Query GreaterThan
        {
            get
            {
                return new Query(_query, ">", _tables);
            }
        }

        public Query GreaterOrEqualThan
        {
            get
            {
                return new Query(_query, ">=", _tables);
            }
        }

        public Query Operator(string @operator)
        {
            if (@operator.Equals("="))
                return Is;
            else if (@operator.Equals("<"))
                return LessThan;
            else if (@operator.Equals("<="))
                return LessOrEqualThan;
            else if (@operator.Equals(">"))
                return GreaterThan;
            else if (@operator.Equals(">="))
                return GreaterOrEqualThan;

            throw new ArgumentException("Unkown Operator");
        }

        public Query Op(string @operator)
        {
            return Operator(@operator);
        }
    }
}
