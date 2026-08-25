using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NeuralNetworkProject
{

    internal class NeuralNetwork
    {
        // Events
        public event Action<NeuralNetwork> FinishedBatch;
        public event Action<NeuralNetwork, int> UpdateGuess;
        public event Action<NeuralNetwork, double> UpdateConfidence;
        public event Action<NeuralNetwork, double> UpdateAverageLoss;

        // Parameters
        double LearningRate;
        Random Random;

        // Statistical data
        double TotalLoss;
        int TotalCorrect;
        public int SamplesProcessed;

        // LAYER 0  -- 256 neurons
        double[,] Weights0;
        double[] Biases0;

        double[] Z0; // Pre-activation values
        double[] A0; // Post-activation values

        double[,] WeightGradients0;
        double[] BiasGradients0; // Or, dCost_dZ0

        // LAYER 1 -- 128 neurons
        double[,] Weights1;
        double[] Biases1;

        double[] Z1;
        double[] A1;

        double[,] WeightGradients1;
        double[] BiasGradients1;

        // LAYER 2 (Output layer) -- 26 neurons
        double[,] Weights2;
        double[] Biases2;

        double[] Z2;
        double[] A2;

        double[,] WeightGradients2;
        double[] BiasGradients2;


        public NeuralNetwork()
        {
            LearningRate = 0.01;
            Random = new Random();

            // Layer 0
            Weights0 = new double[256, 784];
            Biases0 = new double[256];
            Z0 = new double[256];
            A0 = new double[256];
            WeightGradients0 = new double[256, 784];
            BiasGradients0 = new double[256];

            // Layer 1
            Weights1 = new double[128, 256];
            Biases1 = new double[128];
            Z1 = new double[128];
            A1 = new double[128];
            WeightGradients1 = new double[128, 256];
            BiasGradients1 = new double[128];

            // Layer 2
            Weights2 = new double[26, 128];
            Biases2 = new double[26];
            Z2 = new double[26];
            A2 = new double[26];
            WeightGradients2 = new double[26, 128];
            BiasGradients2 = new double[26];

        }

        public void TrainBatch(TrainingSample[] batch)
        {
            double batchLoss = 0.0;
            int batchCorrect = 0;

            for (int i=0; i < batch.Length; i++)
            {
                ForwardPropagate(batch[i]);

                int guess = GetGuess();
                if (guess == batch[i].Symbol)
                {
                    batchCorrect++;
                }
                batchLoss += CrossEntropyLoss(batch[i].Symbol);


                Backpropagate(batch[i].Symbol, batch[i].Inputs);
                // Debug.WriteLine($"Finished full pass through sample {i+1} ({i+1}/{batch.Length}) ({(char)(batch[i].Symbol+65)})");
            }

            double averageLoss = batchLoss / batch.Length;
            double accuracy = (double)batchCorrect / (double)batch.Length;

            Debug.WriteLine($"Completed batch: Loss: {averageLoss:F2} | Accuracy: {(accuracy * 100):F2}% ");


            AverageGradients(batch.Length);
            GradientDescent();
            FinishedBatch?.Invoke(this);
        }

        public void ForwardPropagate(TrainingSample sample, bool guessMode=false)
        {
            double[] input = sample.Inputs;

            // Input --> Layer 0
            for (int i = 0; i < 256; i++)
            {
                double sum = Biases0[i];

                for (int j = 0; j < 784; j++)
                {
                    sum += Weights0[i, j] * input[j];
                }

                Z0[i] = sum;
                A0[i] = RELU(sum);
            }

            // Layer 0 --> Layer 1
            for (int i = 0; i < 128; i++)
            {
                double sum = Biases1[i];

                for (int j = 0; j < 256; j++)
                {
                    sum += Weights1[i, j] * A0[j];
                }

                Z1[i] = sum;
                A1[i] = RELU(sum);
            }

            // Layer 1 --> Layer 2
            for (int i = 0; i < 26; i++)
            {
                double sum = Biases2[i];

                for (int j = 0; j < 128; j++)
                {
                    sum += Weights2[i, j] * A1[j];
                }

                Z2[i] = sum;
            }
            SoftMax();

            // Update metadata
            int guess = GetGuess();

            if (guessMode)
            {
                UpdateGuess?.Invoke(this, guess);
                UpdateConfidence?.Invoke(this, A2[guess]);
            }
            else
            {
                SamplesProcessed++;
                if (guess == sample.Symbol)
                {
                    TotalCorrect++;
                }
                TotalLoss += CrossEntropyLoss(sample.Symbol);
                UpdateAverageLoss?.Invoke(this, (TotalLoss / SamplesProcessed));
            }
            
        }

        public void Backpropagate(int target, double[] input)
        {

            double[] dCost_dZ2 = new double[26];

            // COST --> LAYER 2
            for (int i = 0; i < 26; i++)
            {
                double targetValue = (target == i) ? 1.0 : 0.0;

                dCost_dZ2[i] = A2[i] - targetValue;

                // dC/dB2
                BiasGradients2[i] += dCost_dZ2[i];

                // dC/dW2
                for (int j = 0; j < 128; j++)
                {
                    WeightGradients2[i, j] += dCost_dZ2[i] * A1[j];
                }
            }

            // LAYER 2 --> LAYER 1
            double[] dCost_dA1 = new double[128];
            double[] dCost_dZ1 = new double[128];

            for (int j = 0; j < 128; j++)
            {
                double sum = 0;

                for (int i = 0; i < 26; i++)
                {
                    sum += dCost_dZ2[i] * Weights2[i, j];
                }

                dCost_dA1[j] = sum;
            }

            for (int j = 0; j < 128; j++)
            {
                double reluDerivative = ReluDerivative(Z1[j]);

                // dCost_dZ1
                dCost_dZ1[j] = dCost_dA1[j] * reluDerivative;
                BiasGradients1[j] += dCost_dZ1[j];
            }

            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    WeightGradients1[i, j] += dCost_dZ1[i] * A0[j];
                }
            }

            // LAYER 1 --> LAYER 0
            double[] dCost_dA0 = new double[256];
            double[] dCost_dZ0 = new double[256];

            for (int j = 0; j < 256; j++)
            {
                double sum = 0;

                for (int i = 0; i < 128; i++)
                {
                    sum += dCost_dZ1[i] * Weights1[i, j];
                }
                dCost_dA0[j] = sum;
            }

            
            for (int j = 0; j < 256; j++)
            {
                double reluDerivative = ReluDerivative(Z0[j]);

                dCost_dZ0[j] = dCost_dA0[j] * reluDerivative;
                BiasGradients0[j] += dCost_dZ0[j];
            }

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 784; j++)
                {
                    WeightGradients0[i, j] += dCost_dZ0[i] * input[j];
                }
            }

        }

        private void AverageGradients(int batchSize)
        {
            // LAYER 0
            for (int i = 0; i < 256; i++)
            {
                BiasGradients0[i] /= batchSize;

                for (int j = 0; j < 784; j++)
                {
                    WeightGradients0[i, j] /= batchSize;
                }
            }

            // LAYER 1
            for (int i = 0; i < 128; i++)
            {
                BiasGradients1[i] /= batchSize;
                for (int j = 0; j < 256; j++)
                {
                    WeightGradients1[i, j] /= batchSize;
                }
            }

            // LAYER 2
            for (int i = 0; i < 26; i++)
            {
                BiasGradients2[i] /= batchSize;
                for (int j = 0; j < 128; j++)
                {
                    WeightGradients2[i, j] /= batchSize;
                }
            }
        }

        private void GradientDescent()
        {
            // NOTE: Also resets all gradients to 0.

            // LAYER 2
            for (int i = 0; i < 26; i++)
            {
                Biases2[i] -= BiasGradients2[i] * LearningRate;
                BiasGradients2[i] = 0;
                for (int j = 0; j < 128; j++)
                {
                    Weights2[i, j] -= WeightGradients2[i, j] * LearningRate;
                    WeightGradients2[i, j] = 0;
                }
            }

            // LAYER 1
            for (int i = 0; i < 128; i++)
            {
                Biases1[i] -= BiasGradients1[i] * LearningRate;
                BiasGradients1[i] = 0;
                for (int j = 0;j < 256; j++)
                {
                    Weights1[i, j] -= WeightGradients1[i, j] * LearningRate;
                    WeightGradients1[i, j] = 0;
                }
            }

            // LAYER 0
            for (int i = 0; i < 256; i++)
            {
                Biases0[i] -= BiasGradients0[i] * LearningRate;
                BiasGradients0[i] = 0;
                for (int j = 0; j < 784; j++)
                {
                    Weights0[i, j] -= WeightGradients0[i, j] * LearningRate;
                    WeightGradients0[i, j] = 0;
                }
            }
        }

        public void RandomlyInitializeWeights()
        {
            // LAYER 0 (He initialization)
            double stdDev0 = Math.Sqrt(2.0 / 784.0);

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 784; j++)
                {
                    Weights0[i, j] = RandomNormal(0, stdDev0);
                }
            }

            // LAYER 1 (He initialization)
            double stdDev1 = Math.Sqrt(2.0 / 256.0);

            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    Weights1[i, j] = RandomNormal(0, stdDev1);
                }
            }

            // LAYER 2 (Xavier/Glorot initialization)
            double stdDev2 = Math.Sqrt(2.0 / 154.0); // 128.0 + 26.0

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    Weights2[i, j] = RandomNormal(0, stdDev2);
                }
            }

        }

        public void Save(string fileName)
        {
            if (!File.Exists(fileName))
            {
                using (File.Create(fileName)) { }
            }


            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                // Metadata
                writer.Write(TotalLoss);
                writer.Write(TotalCorrect);
                writer.Write(SamplesProcessed);

                // Layer 0
                for (int i = 0; i < 256; i++)
                {
                    for (int j = 0; j < 784; j++)
                    {
                        writer.Write(Weights0[i, j]);
                    }
                }

                for (int i = 0; i < 256; i++)
                {
                    writer.Write(Biases0[i]);
                }

                // Layer 1
                for (int i = 0; i < 128; i++)
                {
                    for (int j = 0; j < 256; j++)
                    {
                        writer.Write(Weights1[i, j]);
                    }
                }

                for (int i = 0; i < 128; i++)
                {
                    writer.Write(Biases1[i]);
                }

                // Layer 2
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < 128; j++)
                    {
                        writer.Write(Weights2[i, j]);
                    }
                }

                for (int i = 0; i < 26; i++)
                {
                    writer.Write(Biases2[i]);
                }
            }
        }

        public void Load(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"The file {fileName} was not found.");
            }

            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                // Metadata
                TotalLoss = reader.ReadDouble();
                TotalCorrect = reader.ReadInt32();
                SamplesProcessed = reader.ReadInt32();


                // Layer 0
                for (int i = 0; i < 256; i++)
                {
                    for (int j = 0; j < 784; j++)
                    {
                        Weights0[i, j] = reader.ReadDouble();
                    }
                }

                for (int i = 0; i < 256; i++)
                {
                    Biases0[i] = reader.ReadDouble();
                }

                // Layer 1
                for (int i = 0; i < 128; i++)
                {
                    for (int j = 0; j < 256; j++)
                    {
                        Weights1[i, j] = reader.ReadDouble();
                    }
                }

                for (int i = 0; i < 128; i++)
                {
                    Biases1[i] = reader.ReadDouble();
                }

                // Layer 2
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < 128; j++)
                    {
                        Weights2[i, j] = reader.ReadDouble();
                    }
                }

                for (int i = 0; i < 26; i++)
                {
                    Biases2[i] = reader.ReadDouble();
                }
            }
        }


        private double RELU(double x)
        {
            return Math.Max(x, 0);
        }

        private double Sigmoid(double x)
        {
            return ( 1.0 / (1.0 + Math.Exp(-x)) );
        }

        private double SigmoidDerivative(double activation) // Calculates from activation A, NOT Z.
        {
            return activation * (1 - activation);
        }

        private double MeanSquaredError(double actual, double expectedValue) // expectedValue is either 0 or 1
        {
            return Math.Pow(actual - (expectedValue ), 2);
        }

        private double CrossEntropyLoss(int target) // target is the index of the symbol
        {
            return -Math.Log(Math.Max(A2[target], 1e-15)); // 1e-15 prevents Log(0) errors
        }

        private double ReluDerivative(double x)
        {
            if (x > 0)
            {
                return 1;
            }

            return 0;
        }

        private double RandomNormal(double mean=0, double stdDev=1)
        {
            double u1 = 1.0 - Random.NextDouble();
            double u2 = 1.0 - Random.NextDouble();

            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return mean + stdDev * randStdNormal;
        }

        private void SoftMax()
        {
            double max = Z2.Max();
            double sum = 0;

            for (int i = 0; i < 26; i++)
            {
                A2[i] = Math.Exp(Z2[i] - max);
                sum += A2[i];
            }

            for (int i = 0; i < 26; i++)
            {
                A2[i] /= sum;
            }

        }

        private int GetGuess()
        {
            int highestIndex = 0;
            double highestValue = A2[0];

            for (int i = 0; i < 26; i++)
            {
                if (A2[i] > highestValue)
                {
                    highestIndex = i;
                    highestValue = A2[i];
                }
            }

            return highestIndex;
        }

    }
}
