namespace Application.Exceptions;

public class UserServiceException : Exception, IApplicationException
{
    private UserServiceException(string msg) : base(msg)
    {
    }


    public static UserServiceException UserNotFound(string email)
    {
        return new UserServiceException($"User with email {email} not found.");
    }
    
}