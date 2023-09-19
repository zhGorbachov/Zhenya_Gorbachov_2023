namespace Bll.Models.AddModels;

public class AddAnswerModel
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
    public string? QuestionId { get; set; }
}