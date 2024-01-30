using TextChecker.Core;

namespace TextChecker.Services
{
    public class TextCheckerService : ITextCheckerService
    {
        public bool CheckText(string text, string value, bool caseSensitive, ConditionEnum condition)
        {
            bool result;
            switch (condition)
            {
                case ConditionEnum.IsEqual:
                    result = caseSensitive ? text == value : text.ToLower() == value.ToLower();
                    break;
                case ConditionEnum.StartsWith:
                    result = caseSensitive ? text.StartsWith(value) : text.ToLower().StartsWith(value.ToLower());
                    break;
                case ConditionEnum.EndsWith:
                    result = caseSensitive ? text.EndsWith(value) : text.ToLower().EndsWith(value.ToLower());
                    break;
                case ConditionEnum.Contains:
                    result = caseSensitive ? text.Contains(value) : text.ToLower().Contains(value.ToLower());
                    break;
                default:
                    throw new System.Exception("Condition enum not defined");
            }

            return result;
        }
    }
}
