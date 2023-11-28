using infrastructure.Models;
using infrastructure.Repositories;

namespace service;

public class UserService
{
    private readonly UserRepository _repository;

    public UserService(UserRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Users> GetAll()
    {
        return _repository.GetAll();
    }

}