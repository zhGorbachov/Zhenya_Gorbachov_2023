using AutoMapper;
using Bll.Models;
using Bll.Models.AddModels;
using Bll.Models.UpdateModels;
using Dal.Entities;

namespace Bll.Mapping;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<AddAnswerModel, Answer>()
            .ForMember(answer => answer.Text,
            opt => opt.MapFrom(answerModel => answerModel.Text))
            .ForMember(answer => answer.IsCorrect,
            opt => opt.MapFrom(answerModel => answerModel.IsCorrect))
            .ForMember(answer => answer.QuestionId,
            opt => opt.MapFrom(answerModel => Guid.Parse(answerModel.QuestionId)));

        CreateMap<AddQuestionModel, Question>()
            .ForMember(question => question.Text,
            opt => opt.MapFrom(questionModel => questionModel.Text))
            .ForMember(question => question.TestId,
            opt => opt.MapFrom(questionModel => Guid.Parse(questionModel.TestId)));

        CreateMap<AddTestModel, Test>()
            .ForMember(test => test.Title,
            opt => opt.MapFrom(testModel => testModel.Title))
            .ForMember(test => test.Description,
            opt => opt.MapFrom(testModel => testModel.Description))
            .ForMember(test => test.CreatedForUserId,
            opt => opt.MapFrom(testModel => Guid.Parse(testModel.CreatedForUserId)));

        CreateMap<AddUserModel, User>()
            .ForMember(user => user.Name,
            opt => opt.MapFrom(usermodel => usermodel.Name))
            .ForMember(user => user.Surname,
            opt => opt.MapFrom(userModel => userModel.Surname))
            .ForMember(user => user.Password,
            opt => opt.MapFrom(userModel => userModel.Password));

        
        CreateMap<UpdateUserModel, User>()
            .ForMember(user=>user.Id,
                opt=>opt.MapFrom(userModel=>Guid.Parse(userModel.Id)))
            .ForMember(user => user.Name,
                opt => opt.MapFrom(usermodel => usermodel.Name))
            .ForMember(user => user.Surname,
                opt => opt.MapFrom(userModel => userModel.Surname))
            .ForMember(user => user.Password,
                opt => opt.MapFrom(userModel => userModel.Password));

        CreateMap<UpdateAnswerModel, Answer>()
            .ForMember(answer => answer.Id,
            opt => opt.MapFrom(answerModel => Guid.Parse(answerModel.Id)))
            .ForMember(answer => answer.Text,
            opt => opt.MapFrom(answerModel => answerModel.Text))
            .ForMember(answer => answer.IsCorrect,
            opt => opt.MapFrom(answerModel => answerModel.IsCorrect));

        CreateMap<UpdateTestModel, Test>() 
            .ForMember(test => test.Id,
                opt => opt.MapFrom(testModel => Guid.Parse(testModel.Id)))
            .ForMember(test => test.Title,
                opt => opt.MapFrom(testModel => testModel.Title))
            .ForMember(test => test.Description,
                opt => opt.MapFrom(testModel => testModel.Description))
            .ForMember(test => test.CreatedForUserId,
                opt => opt.MapFrom(testModel => Guid.Parse(testModel.CreatedForUserId)));
        
        CreateMap<UpdateQuestionModel, Question>()
            .ForMember(question => question.Id,
            opt => opt.MapFrom(questionModel => Guid.Parse(questionModel.Id)))
            .ForMember(question => question.Text,
            opt => opt.MapFrom(questionModel => questionModel.Text));
        
        CreateMap<UserModel, User>()
            .ForMember(user => user.Id,
            opt => opt.MapFrom(userModel => userModel.ToString()))
            .ForMember(user => user.Name,
            opt => opt.MapFrom(userModel => userModel.Name))
            .ForMember(user => user.Surname,
            opt => opt.MapFrom(userModel => userModel.Surname))
            .ReverseMap();

        CreateMap<TestModel, Test>()
            .ForMember(test => test.Id,
                opt => opt.MapFrom(testModel => testModel.Id))
            .ForMember(test => test.Description,
                opt => opt.MapFrom(testModel => testModel.Description))
            .ForMember(test => test.Title,
                opt => opt.MapFrom(testModel => testModel.Title))
            .ForMember(test => test.Questions,
                opt => opt.MapFrom(testModel => testModel.QuestionIdList))
            .ReverseMap();

        CreateMap<QuestionModel, Question>()
            .ForMember(question => question.Id,
            opt => opt.MapFrom(questionModel => questionModel.Id.ToString()))
            .ForMember(question => question.Text,
            opt => opt.MapFrom(questionModel => questionModel.Text))
            .ReverseMap();
        
        CreateMap<AnswerModel, Answer>()
            .ForMember(question => question.Id,
                opt => opt.MapFrom(questionModel => questionModel.Id.ToString()))
            .ForMember(question => question.Text,
                opt => opt.MapFrom(questionModel => questionModel.Text))
            .ReverseMap();
    }
}