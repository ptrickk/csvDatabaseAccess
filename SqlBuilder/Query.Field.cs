using SqlBuilder.Enums;

namespace SqlBuilder
{
    public partial class Query
    {
        public Query Field(string field, Aggregate? aggregate = null)
        {
            if (aggregate.HasValue)
            {
                switch (aggregate.Value)
                {
                    case Aggregate.SUM:
                        return new Query(_query, $"SUM({field})", _tables);
                    case Aggregate.AVG:
                        return new Query(_query, $"AVG({field})", _tables);
                    case Aggregate.COUNT:
                        return new Query(_query, $"COUNT({field})", _tables);
                    case Aggregate.MIN:
                        return new Query(_query, $"MIN({field})", _tables);
                    case Aggregate.MAX:
                        return new Query(_query, $"MAX({field})", _tables);
                }
            }
            return new Query(_query, field, _tables);
        }

        public Query FieldFromTable(int tableIndex, string field)
        {
            return new Query(_query, $"{_tables[tableIndex]}.{field}", _tables);
        }

        public Query FieldsInParentheses(IEnumerable<string> fields)
        {
            return Fields(fields.ToArray(), true);
        }

        public Query Fields(IEnumerable<string> fields, bool parentheses = false)
        {
            return Fields(fields.ToArray(), parentheses);
        }

        public Query Fields(string[] fields, bool parentheses = false)
        {
            string listedFields = string.Empty;
            foreach (var field in fields)
            {
                listedFields += $"{field}, ";
            }
            listedFields = listedFields.Remove(listedFields.Length - 2);

            if (parentheses)
                return new Query(_query, $"({listedFields})", _tables);
            else
                return new Query(_query, listedFields, _tables);
        }
    }
}
