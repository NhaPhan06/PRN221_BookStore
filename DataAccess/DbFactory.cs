namespace DataAccess;

public class DbFactory : IDbFactory
{
    private PRN_BookStoreContext dbContext;

    public PRN_BookStoreContext Init()
    {
        return dbContext ?? (dbContext = new PRN_BookStoreContext());
    }
}