using System;
using Xunit;

namespace Snakey.Snacks.Tests
{
    public class MysteryAppleTests
    {

        [StaFact]
        public void CloneTest()
        {
            var apple = new MysteryApple();
            var original = apple.ToString();
            var clonedApple = apple.Clone();
            var cloned = clonedApple.ToString();
            Assert.True(original == cloned);
        }

        [StaFact]
        public void MysteryAppleTest()
        {
            var apple = new MysteryApple();
            Assert.IsType<MysteryApple>(apple);
        }

        [StaFact]
        public void ToStringTest()
        {
            var apple = new MysteryApple();
            Random r = new Random();
            apple.rnd = r;
            var expected = r.GetHashCode().ToString();
            var result = apple.ToString();
            Assert.True(expected.Equals(result));
        }

        [StaFact]
        public void DeepCloneTest()
        {
            var apple = new MysteryApple();
            var original = apple.ToString();
            var clonedApple = apple.DeepClone();
            var cloned = clonedApple.ToString();
            Assert.False(original == cloned);
        }


    }
}