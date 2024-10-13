namespace SqlBuilder;

public partial class Query
{
    private string _query;
    private List<string> _tables;

    #region Constructors
    private Query()
    {
        _query = string.Empty;
        _tables = [];
    }
    private Query(string query, string append, List<string> tables)
    {
        _query = $"{query.TrimEnd(';')} {append};";
        _tables = tables;
    }

    private Query(Query query, string append, List<string> tables) : this(query.ToString(), append, tables) { }
    #endregion

    public static Query Create()
    {
        return new Query();
    }

    #region CRUD
    /// <summary>
    /// SELECT Statement;
    /// SQL Syntax: <c>SELECT</c>
    /// </summary>
    public Query Select
    {
        get
        {
            ResetTables();
            return new Query(_query, "SELECT", _tables);
        }
    }

    /// <summary>
    /// SELECT DISTINCT Statement;
    /// SQL Syntax: <c>SELECT DISTINCT</c>
    /// </summary>
    public Query SelectDistinct
    {
        get
        {
            ResetTables();
            return new Query(Select, "DISTINCT", _tables);
        }
    }

    /// <summary>
    /// UPDATE Statement;
    /// SQL Syntax: <c>UPDATE</c>
    /// </summary>
    public Query Update
    {
        get
        {
            ResetTables();
            return new Query(_query, "UPDATE", _tables);
        }
    }

    /// <summary>
    /// DELETE Statement;
    /// SQL Syntax: <c>DELETE</c>
    /// </summary>
    public Query Delete
    {
        get
        {
            ResetTables();
            return new Query(_query, "DELETE", _tables);
        }
    }

    /// <summary>
    /// Shortcut to INSERT INTO Statement;
    /// SQL Syntax: <c>INSERT INTO</c>
    /// </summary>
    public Query Insert
    {
        get
        {
            return InsertInto;
        }
    }

    /// <summary>
    /// INSERT INTO Statement;
    /// SQL Syntax: <c>INSERT INTO</c>
    /// </summary>
    public Query InsertInto
    {
        get
        {
            ResetTables();
            return new Query(_query, "INSERT INTO", _tables);
        }
    }

    private void ResetTables()
    {
        _tables = new();
    }
    #endregion

    #region Everything (*)
    /// <summary>
    /// RETURN ALL COLUMNS Statement;
    /// SQL Syntax: <c>*</c>
    /// </summary>
    public Query Everything
    {
        get
        {
            return new Query(_query, "*", _tables);
        }
    }
    #endregion

    public Query From
    {
        get
        {
            return new Query(_query, "FROM", _tables);
        }
    }

    public Query Table(string table)
    {
        TryAddTable(table);
        return new Query(_query, table, _tables);
    }

    public Query Tables(string[] tables)
    {
        string listedTables = string.Empty;
        foreach (var table in tables)
        {
            TryAddTable(table);
            listedTables += $"{table}, ";
        }
        listedTables = listedTables.Remove(listedTables.Length - 2);
        return new Query(_query, listedTables, _tables);
    }

    private void TryAddTable(string tableName)
    {
        if (!_tables.Contains(tableName))
            _tables.Add(tableName);
    }

    public Query SubQuery(Query subquery)
    {
        return new Query(_query, $"({subquery.ToString().TrimEnd(';')})", _tables);
    }

    public Query Raw(string rawSql)
    {
        return new Query(_query, rawSql, _tables);
    }

    #region Value
    public Query Value(string value)
    {
        return new Query(_query, $"'{value}'", _tables);
    }

    public Query Value(int value)
    {
        return new Query(_query, value.ToString(), _tables);
    }

    public Query Value(double value)
    {
        return new Query(_query, value.ToString(), _tables);
    }

    public Query Value(bool value)
    {
        return new Query(_query, value.ToString().ToLower(), _tables);
    }
    #endregion

    public Query OrderBy
    {
        get
        {
            return new Query(_query, "ODER BY", _tables);
        }
    }

    public Query Asc
    {
        get
        {
            return new Query(_query, "ASC", _tables);
        }
    }

    public Query Ascending
    {
        get
        {
            return Asc;
        }
    }

    public Query Desc
    {
        get
        {
            return new Query(_query, "DESC", _tables);
        }
    }

    public Query Descending
    {
        get
        {
            return Desc;
        }
    }

    public Query Also
    {
        get
        {
            return new Query(_query, ",", _tables);
        }
    }

    public Query Into
    {
        get
        {
            return new Query(_query, "INTO", _tables);
        }
    }

    public override string ToString()
    {
        return _query.Trim();
    }
}

