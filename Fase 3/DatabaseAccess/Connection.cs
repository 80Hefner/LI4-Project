public class Connection
{
    private SqlConnection _connection;

    public Connection()
    {
        _connection = new SqlConnection("Server=DESKTOP-EQMTRE4;Database=Olivia;Trusted_Connection=True;");
    }

    public void Close()
    {
        if (_connection.State == System.Data.ConnectionState.Open)
        {
            _connection.Close();
        }
    }

    public SqlConnection Fetch()
    {
        if (_connection.State == System.Data.ConnectionState.Open)
        {
            return _connection;
        }
        else
        {
            return this.Open();
        }
    }

    public SqlConnection Open()
    {
        _connection.Open();
        return _connection;
    }
}