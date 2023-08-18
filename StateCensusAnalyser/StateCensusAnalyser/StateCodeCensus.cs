using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateCensusAnalyser
{
    public class StateCodeCensus
    {
        public static int ReadStateCodeData(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.FILE_NOT_EXISTS, "File Not Exists");
            }
            if (!Path.GetExtension(filepath).Equals(".csv"))
            {
                throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.FILE_INCORRECT, "File Extension incorrect");
            }
            if (File.ReadAllLines(filepath)[0].Contains("/") || File.ReadAllLines(filepath)[0].Contains("|"))
            {
                throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.DELIMETER_INCORRECT, "Delimeter Incorrect");
            }
            if (!File.ReadAllLines(filepath)[0].Equals("SrNo,StateName,TIN,StateCode"))
            {
                throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.HEADER_INCORRECT, "Header Incorrect");
            }
            using (var reader = new StreamReader(filepath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StateCodeData>().ToList();
                    Console.WriteLine("Read Data From CSV");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.SrNo + "----" + data.StateName + "----" + data.TIN + "----" + data.StateCode);
                    }
                    return records.Count();
                }
            }
        }
    }
}
