namespace EMSA.Infrastructure.Entities
{
    /// <summary>
    /// DateTimeOffset sử dụng thời gian đa vùng
    /// </summary>
    public interface ICreatedEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedId { get; set; }
    }

    public interface IUpdatedEntity
    {
        public DateTimeOffset UpdatedAt { get; set; }
        public string UpdatedId { get; set; }
    }

    public class BaseEntity
    {
        public long Id { get; set; }
    }
}