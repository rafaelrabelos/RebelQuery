namespace RebelQuery
{
    public enum DML
    {
        INSERT = 0,
        UPDATE = 1,
        DELETE = 2,
        MERGE = 3,
        CALL = 4,
        EXPLAIN =5,
        LOCK = 6
    }

    public enum DQL
    {
        SELECT = 0
    }

    public enum DDL
    {
        CREATE = 0,
        ALTER = 1,
        DROP = 2,
        RENAME = 3,
        TRUCATE = 4,
        COMMENT = 5
    }

    public enum SQL
    {
        PRYMARY = 0
    }
}
