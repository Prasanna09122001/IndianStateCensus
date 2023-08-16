using StateCensusAnalyser;
namespace IndianStateCensusDataTest

{
    public class Tests
    {
        public string stateCensusDataFilepath = @"D:\Bridgelabz Statement\IndianStatesCensus\IndianStateCensus\StateCensusAnalyser\StateCensusAnalyser\File\StateCensusData.csv";
        [Test]
        public void GivenStateCensusData_WhenAnalysed_RecordsShouldBeMatched()
        {
            Assert.AreEqual(StateCensus.ReadStateCensusData(stateCensusDataFilepath), CSVStateCensus.ReadStateCensusData(stateCensusDataFilepath));   
        }
    }
}