namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        Fixture _fixture;
        Random _rnd;
        IIndexFinder _indexFinder;

        [TestInitialize]
        public void initialize()
        {
            _fixture = new Fixture();
            _rnd = new Random();
            _indexFinder = new IndexFinder();
        }

        // the first half of the test file uses the for loop that iterates over the entire array
        // the second half of the test file uses the while loop that searches from both ends of the array

        // Most tests use randomly generated int[] in order to ensure that the methods work using data that wasn't hand picked
        // for the randomly generated arrays:
        // first it generates the length of the test array, then generates an int[] of that length
        // the no match test removes all matches before calling the method
        // the one match test removes all matches then adds one back before calling the method
        // the two match method adds two matches to ensure there's at least two in that array
        // all generated arrays are scrambled before calling the methods
        // the asserts are done using the baked-in array methods getIndexOf and getLastIndexOf 
        // this ensures that the manual searching returns the same results as the baked-in methods

        // test for provided test cases 2, 3, and 4 plus one more to verify that it will never return
        // -1 for the first position and an index for the second position
        [DataTestMethod]
        [DataRow(new int[] { 2, 4, 5, 5, 5, 5, 5, 7, 9, 9 }, 5, new int[] { 2, 6 })]
        [DataRow(new int[] { 2, 4, 5, 5, 5, 5, 5, 7, 9, 9 }, 2, new int[] { 0, -1 })]
        [DataRow(new int[] { 2, 4, 5, 5, 5, 5, 5, 7, 9, 9 }, 8, new int[] { -1, -1 })]
        [DataRow(new int[] { 2, 4, 5, 5, 5, 5, 5, 7, 8, 9 }, 9, new int[] { 9, -1 })]
        public void ForMethodDataDriven(int[] arr, int target, int[] expected)
        {
            // arrange

            // act
            int[] result = _indexFinder.getFirstAndLastFor(arr, target);

            // assert
            CollectionAssert.AreEqual(expected, result);
        }

        // don't find anything if it's not there
        [TestMethod]
        public void ForMethodNoTargets()
        {
            // arrange
            int testArrayLength = _fixture.Create<int>();
            int testTarget = _fixture.Create<int>();
            List<int> testArrayData = _fixture.CreateMany<int>(Math.Abs(testArrayLength)).ToList();
            testArrayData.RemoveAll(x => x == testTarget);
            int[] testArray = testArrayData.OrderBy(x => _rnd.Next()).ToArray();

            // act
            int[] result = _indexFinder.getFirstAndLastFor(testArray, testTarget);

            // assert
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(-1, result[1]);
        }

        // find the only matching value and return the index in the first position
        [TestMethod]
        public void ForMethodOneTarget()
        {
            // arrange
            int testArrayLength = _fixture.Create<int>();
            int testTarget = _fixture.Create<int>();
            List<int> testArrayData = _fixture.CreateMany<int>(Math.Abs(testArrayLength)).ToList();
            testArrayData.RemoveAll(x => x == testTarget);
            testArrayData.Add(testTarget);
            int[] testArray = testArrayData.OrderBy(x => _rnd.Next()).ToArray();

            // act
            int[] result = _indexFinder.getFirstAndLastFor(testArray, testTarget);

            // assert
            Assert.AreEqual(Array.IndexOf(testArray, testTarget), result[0]);
            Assert.AreEqual(-1, result[1]);
        }

        // find the index of first and last matches 
        [TestMethod]
        public void ForMethodTwoTargets()
        {
            // arrange
            int testArrayLength = _fixture.Create<int>();
            int testTarget = _fixture.Create<int>();
            List<int> testArrayData = _fixture.CreateMany<int>(Math.Abs(testArrayLength)).ToList();
            testArrayData.Add(testTarget);
            testArrayData.Add(testTarget);
            int[] testArray = testArrayData.OrderBy(x => _rnd.Next()).ToArray();

            // act
            int[] result = _indexFinder.getFirstAndLastFor(testArray, testTarget);

            // assert
            Assert.AreEqual(Array.IndexOf(testArray, testTarget), result[0]);
            Assert.AreEqual(Array.LastIndexOf(testArray, testTarget), result[1]);
        }

        // return the default result if the input array doesn't have any elements to iterate through
        [TestMethod]
        public void ForMethodZeroLengthArray()
        {
            // arrange
            int[] zeroLengthArray = { };
            int testTarget = _fixture.Create<int>();

            // act
            int[] result = _indexFinder.getFirstAndLastFor(zeroLengthArray, testTarget);

            // assert
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(-1, result[1]);
        }

        // return the default array if the input array is actuall null
        [TestMethod]
        public void ForMethodNullArray()
        {
            // arrange
            int[] zeroLengthArray = null;
            int testTarget = _fixture.Create<int>();

            // act
            int[] result = _indexFinder.getFirstAndLastFor(zeroLengthArray, testTarget);

            // assert
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(-1, result[1]);
        }

        // test for provided test cases 2, 3, and 4 plus one more to verify that it will never return
        // -1 for the first position and an index for the second position
        [DataTestMethod]
        [DataRow(new int[] { 2, 4, 5, 5, 5, 5, 5, 7, 9, 9 }, 5, new int[] { 2, 6 })]
        [DataRow(new int[] { 2, 4, 5, 5, 5, 5, 5, 7, 9, 9 }, 2, new int[] { 0, -1 })]
        [DataRow(new int[] { 2, 4, 5, 5, 5, 5, 5, 7, 9, 9 }, 8, new int[] { -1, -1 })]
        [DataRow(new int[] { 2, 4, 5, 5, 5, 5, 5, 7, 8, 9 }, 9, new int[] { 9, -1 })]
        public void WhileMethodDataDriven(int[] arr, int target, int[] expected)
        {
            // arrange

            // act
            int[] result = _indexFinder.getFirstAndLastWhile(arr, target);

            // assert
            CollectionAssert.AreEqual(expected, result);
        }

        // don't find anything if it's not there
        [TestMethod]
        public void WhileMethodNoTargets()
        {
            // arrange
            int testArrayLength = _fixture.Create<int>();
            int testTarget = _fixture.Create<int>();
            List<int> testArrayData = _fixture.CreateMany<int>(Math.Abs(testArrayLength)).ToList();
            testArrayData.RemoveAll(x => x == testTarget);
            int[] testArray = testArrayData.OrderBy(x => _rnd.Next()).ToArray();

            // act
            var result = _indexFinder.getFirstAndLastWhile(testArray, testTarget);

            // assert
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(-1, result[1]);
        }

        // if there's only one match, return the index in the first position
        [TestMethod]
        public void WhileMethodOneTarget()
        {
            // arrange
            int testArrayLength = _fixture.Create<int>();
            int testTarget = _fixture.Create<int>();
            List<int> testArrayData = _fixture.CreateMany<int>(Math.Abs(testArrayLength)).ToList();
            testArrayData.RemoveAll(x => x == testTarget);
            testArrayData.Add(testTarget);
            int[] testArray = testArrayData.OrderBy(x => _rnd.Next()).ToArray();

            // act
            int[] result = _indexFinder.getFirstAndLastWhile(testArray, testTarget);


            // assert
            Assert.AreEqual(Array.IndexOf(testArray, testTarget), result[0]);
            Assert.AreEqual(-1, result[1]);
        }

        // if there's two or more matches, return the first and last index of the matches
        [TestMethod]
        public void WhileMethodTwoTargets()
        {
            // arrange
            int testArrayLength = _fixture.Create<int>();
            int testTarget = _fixture.Create<int>();
            List<int> testArrayData = _fixture.CreateMany<int>(Math.Abs(testArrayLength)).ToList();
            testArrayData.Add(testTarget);
            testArrayData.Add(testTarget);
            int[] testArray = testArrayData.OrderBy(x => _rnd.Next()).ToArray();

            // act
            int[] result = _indexFinder.getFirstAndLastWhile(testArray, testTarget);

            // assert
            Assert.AreEqual(Array.IndexOf(testArray, testTarget), result[0]);
            Assert.AreEqual(Array.LastIndexOf(testArray, testTarget), result[1]);
        }

        // return the default result if there's no elements in the array to iterate over
        [TestMethod]
        public void WhileMethodZeroLengthArray()
        {
            // arrange
            int[] zeroLengthArray = { };
            int testTarget = _fixture.Create<int>();

            // act
            int[] result =  _indexFinder.getFirstAndLastWhile(zeroLengthArray, testTarget);

            // assert
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(-1, result[1]);
        }

        // return the default result if the array passed in is actually null
        [TestMethod]
        public void WhileMethodNullArray()
        {
            // arrange
            int[] zeroLengthArray = null;
            int testTarget = _fixture.Create<int>();

            // act
            int[] result = _indexFinder.getFirstAndLastWhile(zeroLengthArray, testTarget);

            // assert
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(-1, result[1]);
        }
    }
}