namespace Infrastructure.Dapper.Data
{
    public class BaseRepositoryDP
    {
        protected string ConnectionString { get; }

        public BaseRepositoryDP()
        {
            ConnectionString = "Server=localhost;port=3306;Database=TriManiaV1;user=root;Password=123456";
        }
    }
}
