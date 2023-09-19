namespace Bll.Models.AddModels;

public class AddQuestionModel
{
    public string Text { get; set; }
    public string? TestId { get; set; }

    public List<AddAnswerModel> Answers { get; set; }
}