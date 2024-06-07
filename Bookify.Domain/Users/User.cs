using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users;

public class User: Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public User(Guid id) : base(id)
    {
    }
}