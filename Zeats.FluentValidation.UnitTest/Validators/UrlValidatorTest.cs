using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeats.FluentValidation.Validators;

namespace Zeats.FluentValidation.UnitTest.Validators
{
    [TestClass]
    public class UrlValidatorTest
    {
        [TestMethod]
        public void IsValid()
        {
            var entity = new TestEntity
            {
                Url = "http://www.google.com/",
                HttpUrl = "http://www.google.com/",
                HttpsUrl = "https://www.google.com/"
            };

            var validator = new TestValidator();
            var result = validator.Validate(entity);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Invalid()
        {
            var entity = new TestEntity
            {
                Url = "ftp://www.google.com/",
                HttpUrl = "https://www.google.com/",
                HttpsUrl = "http://www.google.com/"
            };

            var validator = new TestValidator();
            var result = validator.Validate(entity);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(3, result.Errors.Count);
        }

        public class TestEntity
        {
            public string Url { get; set; }
            public string HttpUrl { get; set; }
            public string HttpsUrl { get; set; }
        }

        public class TestValidator : AbstractValidator<TestEntity>
        {
            public TestValidator()
            {
                RuleFor(r => r.Url).Url();
                RuleFor(r => r.HttpUrl).HttpUrl();
                RuleFor(r => r.HttpsUrl).HttpsUrl();
            }
        }
    }
}