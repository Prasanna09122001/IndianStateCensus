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