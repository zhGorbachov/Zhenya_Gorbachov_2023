﻿namespace Dal.Entities;

public class Answer : BaseEntity
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
    public Guid QuestionId { get; set; }
    
    public virtual Question Question { get; set; }
}