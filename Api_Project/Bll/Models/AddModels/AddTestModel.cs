namespace Bll.Models.AddModels;

public class AddTestModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CreatedForUserId { get; set; }

    public List<AddQuestionModel> Questions { get; set; }
}