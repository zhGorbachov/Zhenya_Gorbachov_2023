namespace Dal.Entities;

public class Test : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CreatedForUserId { get; set; }
    
    public virtual User User { get; set; }
    public virtual ICollection<Question>? Questions { get; set; }
}