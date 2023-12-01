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
        event_status as {nameof(EventFeedQuery.EventStatus)},
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

    public Event CreateEvent(string title, string description, int ownerId, bool eventStatus, string eventCardImgUrl,
        int maximumTickets, string address1, string address2, int zip, string city, string country, DateTime createdAtUtc, DateTime startUtc, DateTime endUtc)
    {
        var sql = $@"
INSERT INTO public.events (title, description, owner, event_status, eventCardImgUrl, maximum_tickets, address1, address2, zip, city, country, created_at_utc, start_utc, end_utc)
VALUES (@title, @description, @ownerId, @eventStatus, @eventCardImgUrl, @maximumTickets, @address1, @address2, @zip, @city, @country, @createdAtUtc, @startUtc, @endUtc)
RETURNING event_id as {nameof(EventFeedQuery.Id)},
        title as {nameof(EventFeedQuery.Title)},
        description as {nameof(EventFeedQuery.Description)},
        owner as {nameof(EventFeedQuery.OwnerId)},
        event_status as {nameof(EventFeedQuery.EventStatus)},
        eventCardImgUrl as {nameof(EventFeedQuery.eventCardImgUrl)},
        maximum_tickets as {nameof(EventFeedQuery.MaximumTickets)},
        address1 as {nameof(EventFeedQuery.Address1)},
        address2 as {nameof(EventFeedQuery.Address2)},
        zip as {nameof(EventFeedQuery.Zip)},
        city as {nameof(EventFeedQuery.City)},
        country as {nameof(EventFeedQuery.Country)},
        created_at_utc as {nameof(EventFeedQuery.CreatedAtUTC)},
        start_utc as {nameof(EventFeedQuery.StartUTC)},
        end_utc as {nameof(EventFeedQuery.EndUTC)};
    ";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Event>(sql, new { title, description, ownerId, eventStatus, eventCardImgUrl,
                maximumTickets, address1, address2, zip, city, country, createdAtUtc, startUtc, endUtc });
        }
    }

    public Event UpdateEvent(int id, string title, string description, int ownerId, bool eventStatus, string eventCardImgUrl,
        int maximumTickets, string address1, string address2, int zip, string city, string country, DateTime createdAtUtc, DateTime startUtc, DateTime endUtc)
    {
        var sql = $@"
UPDATE public.event SET title = @title, description = @description, owner = @ownerId, event_status = @eventStatus, eventCardImgUrl = @eventCardImgUrl, maximum_tickets = @maximumTickets,
                        address1 = @address1, address2 = @address2, zip = @zip, city = @city, country = @country, created_at_utc = @createdAtUtc, start_utc = @startUtc, end_utc = @endUtc
WHERE event_id = @id
RETURNING event_id as {nameof(EventFeedQuery.Id)},
        title as {nameof(EventFeedQuery.Title)},
        description as {nameof(EventFeedQuery.Description)},
        owner as {nameof(EventFeedQuery.OwnerId)},
        event_status as {nameof(EventFeedQuery.EventStatus)},
        eventCardImgUrl as {nameof(EventFeedQuery.eventCardImgUrl)},
        maximum_tickets as {nameof(EventFeedQuery.MaximumTickets)},
        address1 as {nameof(EventFeedQuery.Address1)},
        address2 as {nameof(EventFeedQuery.Address2)},
        zip as {nameof(EventFeedQuery.Zip)},
        city as {nameof(EventFeedQuery.City)},
        country as {nameof(EventFeedQuery.Country)},
        created_at_utc as {nameof(EventFeedQuery.CreatedAtUTC)},
        start_utc as {nameof(EventFeedQuery.StartUTC)},
        end_utc as {nameof(EventFeedQuery.EndUTC)};
    ";
        
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Event>(sql, new { id, title, description, ownerId, eventStatus, eventCardImgUrl,
                maximumTickets, address1, address2, zip, city, country, createdAtUtc, startUtc, endUtc });
        }
    }

    public bool DeleteEvent(int eventId)
    {
        var sql = @"DELETE FROM public.events WHERE event_id = @eventId;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Execute(sql, new { eventId }) == 1;
        }
    }
    
    public bool DoesEventWithNameExist(string title)
    {
        var sql = $@"SELECT COUNT(*) FROM public.events WHERE title = @title;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.ExecuteScalar<int>(sql, new { title}) == 1;
        }
    }
}