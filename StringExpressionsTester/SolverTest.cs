using String_Expressions;

namespace StringExpressionsTester
{
    [TestClass]
    public sealed class SolverTest
    {
        [TestMethod]
        public void SumTest()
        {
            var sut = new ExpressionSolver();
            var result = sut.Solve("( + 5 ( - 3 2 ) )");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void DivisionTest()
        {
            var sut = new ExpressionSolver();
            var result = sut.Solve("( / 5 ( - 4 2 ) )");

            Assert.AreEqual(2.5, result);
        }

        [TestMethod]
        public void ComplexTest()
        {
            ExpressionSolver sut = new ExpressionSolver();
            var result = sut.Solve("( * ( + ( / 4 2 ) 3 ) ( - 8 6 ) 3 )");
            
            Assert.AreEqual(30, result);
        }
    }
}
