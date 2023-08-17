using CsvHelper;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace StateCensusAnalyser
{
    public class StateCensus
    {
        public static int ReadStateCensusData(string filepath)
        {
            if(!File.Exists(filepath))
            {
                throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.FILE_NOT_EXISTS, "File Not Exists");
            }
            if(!Path.GetExtension(filepath).Equals(".csv"))
            {
                throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.FILE_INCORRECT, "File Extension incorrect");
            }
            if (!File.ReadAllLines(filepath)[0].Equals("State,Population,AreaInSqKm,DensityPerSqKm"))
            {
                throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.HEADER_INCORRECT, "Header Incorrect");
            }
            using (var reader = new StreamReader(filepath))
            {
                using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StateCensusData>().ToList();
                    Console.WriteLine("Read Data From CSV");
                    foreach(var data in records)
                    {
                        Console.WriteLine(data.State+"----"+data.Population+"----"+data.AreaInSqKm+"----"+data.DensityPerSqKm);
                    }
                    return records.Count() - 1;
                }
            }
        }

    }
}