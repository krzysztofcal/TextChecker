namespace TextChecker.Core
{
    interface ITextCheckerService
    {
        bool CheckText(string text, string value, bool caseSensitive, ConditionEnum condition);
    }
}
