using TechSolutionsLibs.Settings;
using TechSolutionsLibs.Settings.Interface;
using Xunit;

namespace XUnitTestProject1
{
    public class DBSettingsUnitTest
    {
        /// <summary>
        /// Ensure connection is not empty
        /// </summary>
        [Fact]
        public void ConnectionStringIsNotEmptyTest()
        {
            //arrange
            IDBSettings dBSettings = new DBSettings();            

            //act

            //assert
            Assert.NotEmpty(dBSettings.ConnectionString);
        }
    }
}
