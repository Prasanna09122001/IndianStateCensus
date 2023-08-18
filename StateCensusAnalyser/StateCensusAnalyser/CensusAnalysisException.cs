using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateCensusAnalyser
{
    public class CensusAnalysisException : Exception
    {
        public enum ExceptionType
        {
            FILE_INCORRECT,FILE_NOT_EXISTS,HEADER_INCORRECT,DELIMETER_INCORRECT
        }
        public ExceptionType type;
        public CensusAnalysisException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
