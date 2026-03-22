namespace StringExpressionsTester
{
    [TestClass]
    public sealed class StringParserTest
    {
        [TestMethod]
        public void FirstTest()
        {
            var sut = new String_Expressions.StringParser();
            var result = sut.Parser("( + 5 ( - 2 5) )");

            Assert.AreEqual('+', result.Sign);
            Assert.IsNull(result.Val);
            Assert.HasCount(2, result.Operations);
        }
    }
}
