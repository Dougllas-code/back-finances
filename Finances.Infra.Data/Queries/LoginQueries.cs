namespace Finances.Infra.Data.Queries
{
    public class LoginQueries
    {
        public const string GET_USER = @"
            SELECT 
                *
            FROM
                users
            WHERE
                email = @Email
                    AND password = @Password
        ";
    }
}
