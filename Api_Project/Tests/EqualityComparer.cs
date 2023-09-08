using System.Diagnostics.CodeAnalysis;
using Dal.Entities;

namespace Tests;

internal class TestEqualityComparer : IEqualityComparer<Test>
{
    public bool Equals([AllowNull] Test x, [AllowNull] Test y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return x.Id == y.Id
               && x.CreatedForUserId == y.CreatedForUserId
               && x.Description == y.Description
               && x.Title == y.Title;
    }

    public int GetHashCode([DisallowNull] Test obj)
    {
        return obj.GetHashCode();
    }
}

internal class QuestionEqualityComparer : IEqualityComparer<Question>
{
    public bool Equals([AllowNull] Question x, [AllowNull] Question y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return x.Id == y.Id
               && x.Text == y.Text
               && x.TestId == y.TestId;
    }

    public int GetHashCode([DisallowNull] Question obj)
    {
        return obj.GetHashCode();
    }
}

internal class UserEqualityComparer : IEqualityComparer<User>
{
    public bool Equals([AllowNull] User x, [AllowNull] User y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return x.Id == y.Id
               && x.Name == y.Name
               && x.Surname == y.Surname
               && x.Password == y.Password;
    }

    public int GetHashCode([DisallowNull] User obj)
    {
        return obj.GetHashCode();
    }
}

internal class AnswerEqualityComparer : IEqualityComparer<Answer>
{
    public bool Equals([AllowNull] Answer x, [AllowNull] Answer y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return x.Id == y.Id
               && x.Text == y.Text
               && x.QuestionId == y.QuestionId
               && x.IsCorrect == y.IsCorrect;
    }

    public int GetHashCode([DisallowNull] Answer obj)
    {
        return obj.GetHashCode();
    }
}