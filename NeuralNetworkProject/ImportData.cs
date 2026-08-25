using System;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace NeuralNetworkProject
{
    public struct TrainingSample
    {
        public double[] Inputs; // The flattened image, row by row
        public int Symbol; // The target letter/symbol
    }

    // In EMNIST datasets, black = 255 and white = 0.
    // LoadNextBatch() function squishes these values to black = 1 and white = 0. 

    // EMNIST datasets are also 1-indexed; this model fixes this.

    internal class ImportData
    {
        private StreamReader reader;
        
        public int SamplesRead;

        public ImportData(string path, int samplesRead = 0)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"The file {path} was not found.");
                throw new FileNotFoundException();
            }

            reader = new StreamReader(path);

            // If resuming from a unique index, skip to that index
            for (long i = 0; i < samplesRead; i++)
            {
                if (reader.ReadLine() == null)
                {
                    break;
                }
            }

            SamplesRead = samplesRead;
        }

        public TrainingSample[] LoadNextBatch(int batchSize)
        {
            TrainingSample[] batch = new TrainingSample[batchSize];

            for (int i = 0; i < batchSize; i++)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                string[] values = line.Split(',');
                int targetVal = int.Parse(values[0]) - 1; // -1 to convert to 0-indexing

                batch[i].Inputs = Array.ConvertAll(values.Skip(1).ToArray(), double.Parse);
                batch[i].Symbol = targetVal;

                // Squish black values between 0 and 1
                for (int j = 0; j < 784; j++)
                {
                    batch[i].Inputs[j] /= 255;
                }

                SamplesRead++;
            }

            if (batch[batch.Length - 1].Inputs == null)
            {
                Debug.WriteLine($"Error with CSV at line {SamplesRead}");
                throw new Exception("Reached end of CSV; could not create a full batch.");
            }

            return batch;
        }


    }
}
