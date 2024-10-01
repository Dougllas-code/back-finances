namespace Finances.Infra.Data.Queries
{
    public class AccountTypeQueries
    {
        public const string CREATE = @"
            INSERT INTO account_types (name, color) VALUES(@Name, @Color);
            SELECT LAST_INSERT_ID();
        ";
        
        public const string GET = @"
            SELECT * FROM account_types WHERE Id = @Id;
        ";
        
        public const string GET_ALL = @"
            SELECT * FROM account_types;
        ";
        
        public const string UPDATE = @"
            UPDATE account_types 
            SET 
                name = @Name,
                color = @Color
            WHERE
                id = @Id;  ;
        ";
    }
}
