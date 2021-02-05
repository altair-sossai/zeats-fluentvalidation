using FluentValidation;
using Zeats.Url;

namespace Zeats.FluentValidation.Validators
{
    public static class UrlValidator
    {
        public static IRuleBuilderOptions<T, string> Url<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(UrlHelper.IsValidUrl);
        }

        public static IRuleBuilderOptions<T, string> HttpUrl<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(UrlHelper.IsValidHttpUrl);
        }

        public static IRuleBuilderOptions<T, string> HttpsUrl<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(UrlHelper.IsValidHttpsUrl);
        }
    }
}