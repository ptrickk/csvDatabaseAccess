namespace SqlBuilder;

public partial class Query
{

    public Query Where
    {
        get
        {
            return new Query(_query, "WHERE", _tables);
        }
    }

    public Query Or
    {
        get
        {
            return new Query(_query, "OR", _tables);
        }
    }

    public Query And
    {
        get
        {
            return new Query(_query, "AND", _tables);
        }
    }

    public Query Not
    {
        get
        {
            return new Query(_query, "NOT", _tables);
        }
    }

    public Query In
    {
        get
        {
            return new Query(_query, "IN", _tables);
        }
    }

    public Query Having
    {
        get
        {
            return new Query(_query, "HAVING", _tables);
        }
    }

    public Query Between
    {
        get
        {
            return new Query(_query, "BETWEEN", _tables);
        }
    }

    public Query Any
    {
        get
        {
            return new Query(_query, "ANY", _tables);
        }
    }

    public Query All
    {
        get
        {
            return new Query(_query, "ALL", _tables);
        }
    }
}

