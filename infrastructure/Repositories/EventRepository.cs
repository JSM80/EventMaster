using Dapper;
using infrastructure.DataModels;
using infrastructure.QueryModels;
using Npgsql;

namespace infrastructure.Repositories;

public class EventRepository
{
    private NpgsqlDataSource _dataSource;

    public EventRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<EventFeedQuery> GetEventForFeed()
    {
        string sql = $@"



    ";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<EventFeedQuery>(sql);
        }
    }

    public Event CreateEvent(string eventName, string eventOrganiser, string description, string eventCardImgUrl,
        TimeOnly time, double price, int ticketAmount, object address, DateOnly date)
    {
        var sql = $@"";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Event>(sql, new { eventName, eventOrganiser, description, eventCardImgUrl, time, price, ticketAmount, address, date });
        }
    }

    public bool DoesEventWithNameExist(string eventName)
    {
        var sql = $@"";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.ExecuteScalar<int>(sql, new {eventName}) == 1;
        }
    }
}