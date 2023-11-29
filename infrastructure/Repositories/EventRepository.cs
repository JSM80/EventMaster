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
SELECT event_id as {nameof(EventFeedQuery.Id)},
        title as {nameof(EventFeedQuery.Title)},
        description as {nameof(EventFeedQuery.Description)},
        owner as {nameof(EventFeedQuery.OwnerId)},
        event_status as {nameof(EventFeedQuery.eventStatus)},
        eventCardImgUrl as {nameof(EventFeedQuery.eventCardImgUrl)},
        maximum_tickets as {nameof(EventFeedQuery.MaximumTickets)},
        address1 as {nameof(EventFeedQuery.Address1)},
        address2 as {nameof(EventFeedQuery.Address2)},
        zip as {nameof(EventFeedQuery.Zip)},
        city as {nameof(EventFeedQuery.City)},
        country as {nameof(EventFeedQuery.Country)},
        created_at_utc as {nameof(EventFeedQuery.CreatedAtUTC)},
        start_utc as {nameof(EventFeedQuery.StartUTC)},
        end_utc as {nameof(EventFeedQuery.EndUTC)}
        FROM public.events

";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<EventFeedQuery>(sql);
        }
    }

    public Event CreateEvent(string Title, string description, int OwnerId, bool eventStatus, string eventCardImgUrl, int MaximumTickets, string Address1, string Address2, int zip, string city, string country, DateTime CreatedAtUTC, DateTime StartUTC, DateTime EndUTC)
    {
        var sql = $@"";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Event>(sql, new { Title, description, OwnerId, eventStatus, eventCardImgUrl, MaximumTickets, Address1, Address2, zip, city, country, CreatedAtUTC, StartUTC, EndUTC });
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