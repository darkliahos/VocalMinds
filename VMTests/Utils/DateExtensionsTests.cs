using System;
using Xunit;
using VMUtils.Extensions;

namespace VMTests.Utils
{
    public class DateExtensionsTests
    {
        [Fact]
        public void TimeElapsed_ElapsedTimeTests()
        {
            Assert.Equal(true,DateTime.UtcNow.IsTimeWithinXSeconds(5));
            Assert.Equal(false,DateTime.UtcNow.AddMinutes(-3).IsTimeWithinXSeconds(5));
            Assert.Equal(true,DateTime.UtcNow.AddSeconds(-4).IsTimeWithinXSeconds(5));
            Assert.Equal(false,DateTime.UtcNow.AddSeconds(-5).IsTimeWithinXSeconds(5));
        }
    }
}
