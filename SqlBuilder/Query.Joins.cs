namespace SqlBuilder;

public partial class Query
{
    private const string JOIN = "JOIN";

    #region JOIN

    #region INNER
    public Query InnerJoin
    {
        get
        {
            return new Query(_query, $"INNER {JOIN}", _tables);
        }
    }

    public Query JoinInner
    {
        get
        {
            return InnerJoin;
        }
    }
    #endregion

    #region LEFT
    public Query LeftJoin
    {
        get
        {
            return new Query(_query, $"LEFT {JOIN}", _tables);
        }
    }

    public Query JoinLeft
    {
        get
        {
            return LeftJoin;
        }
    }
    #endregion

    #region RIGHT
    public Query RightJoin
    {
        get
        {
            return new Query(_query, $"RIGHT {JOIN}", _tables);
        }
    }

    public Query JoinRight
    {
        get
        {
            return RightJoin;
        }
    }
    #endregion

    #region OUTER
    public Query OuterJoin
    {
        get
        {
            return new Query(_query, $"OUTER {JOIN}", _tables);
        }
    }

    public Query JoinOuter
    {
        get
        {
            return OuterJoin;
        }
    }
    #endregion

    #endregion

    public Query On
    {
        get
        {
            return new Query(_query, "ON", _tables);
        }
    }

    public Query Union
    {
        get
        {
            return new Query(_query, "UNION", _tables);
        }
    }

    public Query GroupBy
    {
        get
        {
            return new Query(_query, "GROUP BY", _tables);
        }
    }
}

