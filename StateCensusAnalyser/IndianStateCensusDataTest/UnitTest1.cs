using StateCensusAnalyser;
namespace IndianStateCensusDataTest

{
    public class Tests
    {
        public string stateCensusDataFilepath = @"D:\Bridgelabz Statement\IndianStatesCensus\IndianStateCensus\StateCensusAnalyser\StateCensusAnalyser\File\StateCensusData.csv";
        public string stateCensusDataFilepath1 = @"D:\Bridgelabz Statement\IndianStatesCensus\IndianStateCensus\StateCensusAnalyser\StateCensusAnalyser\File\StateCensusData.txt";
        public string stateCensusDataFilepath2= @"D:\Bridgelabz Statement\IndianStatesCensus\IndianStateCensus\StateCensusAnalyser\StateCensusAnalyser\File\StateCensusDat.csv";
        public string stateCensusDataFilepath3 = @"D:\Bridgelabz Statement\IndianStatesCensus\IndianStateCensus\StateCensusAnalyser\StateCensusAnalyser\File\StateCensus.csv";
        public string stateCensusDataFilePath4 = @"D:\Bridgelabz Statement\IndianStatesCensus\IndianStateCensus\StateCensusAnalyser\StateCensusAnalyser\File\StateCencsusDelimeter.csv";
        [Test]
        public void GivenStateCensusData_WhenAnalysed_RecordsShouldBeMatched()
        {
            Assert.AreEqual(StateCensus.ReadStateCensusData(stateCensusDataFilepath), CSVStateCensus.ReadStateCensusData(stateCensusDataFilepath));   
        }
        [Test]
        public void GivenStateCensusData_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensus.ReadStateCensusData(stateCensusDataFilepath1);
            }
            catch (CensusAnalysisException ex)
            {
                Assert.AreEqual(ex.Message, "File Extension incorrect");
            }
        }
        [Test]
        public void GivenStateCensusNoData_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensus.ReadStateCensusData(stateCensusDataFilepath2);
            }
            catch (CensusAnalysisException ex)
            {
                Assert.AreEqual(ex.Message, "File Not Exists");
            }
        }
        [Test]
        public void GivenStateCensusHeaderIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensus.ReadStateCensusData(stateCensusDataFilepath3);
            }
            catch (CensusAnalysisException ex)
            {
                Assert.AreEqual(ex.Message, "Header Incorrect");
            }
        }
        [Test]
        public void GivenStateCensusDelimeterIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensus.ReadStateCensusData(stateCensusDataFilePath4);
            }
            catch (CensusAnalysisException ex)
            {
                Assert.AreEqual(ex.Message, "Delimeter Incorrect");
            }
        }
    }
}