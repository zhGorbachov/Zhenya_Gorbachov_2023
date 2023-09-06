namespace Dal.Entities;

public class Question : BaseEntity
{
    public string Text { get; set; }
    public Guid TestId { get; set; }
    
    public virtual Test Test { get; set; }
    public virtual ICollection<Answer>? Answers { get; set; }
}