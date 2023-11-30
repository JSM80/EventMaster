using System.Reflection.Metadata;
using Npgsql;
using Dapper;
using infrastructure.Models;

namespace infrastructure.Repositories;

public class UserRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public UserRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    //Create User
    public UserModel Create(string firstName, string lastName, string userName, string email, string address1,
        string address2, string zip, string city, string country, float lat, float longtitude)
    {
        const string sql =
            $@"INSERT INTO Users (firstName, lastName, userName, email, address1, address2, zip, city, country, lat, longtitude) VALUES (@firstName, @lastName, @userName, @email, @address1, @address2, @zip, @city, @country, @lat, @longtitude)
        RETURNING
        id as {nameof(UserModel.Id)}
        firstName as {nameof(UserModel.FirstName)}
        lastName as {nameof(UserModel.LastName)}
        userName as {nameof(UserModel.UserName)}
        email as {nameof(UserModel.Email)}
        address1 as {nameof(UserModel.Address1)}
        address2 as {nameof(UserModel.Address2)}
        zip as {nameof(UserModel.Zip)}
        city as {nameof(UserModel.City)}
        country as {nameof(UserModel.Country)}
        lat as {nameof(UserModel.Lat)}
        longtitude as {nameof(UserModel.Longtitude)};
        ";
        using var connection = _dataSource.OpenConnection();
        return connection.QueryFirst<UserModel>(sql,
            new { firstName, lastName, userName, email, address1, address2, zip, city, country, lat, longtitude });

    }
    
    // Get User by ID

    public UserModel? GetById(int id)
    {
        const string sql = $@"
        SELECT
        id as {nameof(UserModel.Id)}
        firstName as {nameof(UserModel.FirstName)}
        lastName as {nameof(UserModel.LastName)}
        userName as {nameof(UserModel.UserName)}
        email as {nameof(UserModel.Email)}
        address1 as {nameof(UserModel.Address1)}
        address2 as {nameof(UserModel.Address2)}
        zip as {nameof(UserModel.Zip)}
        city as {nameof(UserModel.City)}
        country as {nameof(UserModel.Country)}
        lat as {nameof(UserModel.Lat)}
        longtitude as {nameof(UserModel.Longtitude)};
        FROM Users
        WHERE id = @id;
        ";
        using var connection = _dataSource.OpenConnection();
        return connection.QueryFirst<UserModel>(sql, new { @id });

    }
    
}