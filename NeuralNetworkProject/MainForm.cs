using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkProject
{
    public partial class MainForm : Form
    {
        DrawingBox DisplayArea;
        NeuralNetwork Network;
        ImportData BatchLoader;
        Random Random;

        int BatchSize;
        int BatchCount;

        string SavePath;
        string SamplesPath;

        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.DisplayArea = new DrawingBox();
            this.Controls.Add(this.DisplayArea);

            Network = new NeuralNetwork();
            Network.UpdateGuess += DisplayGuess;
            Network.UpdateConfidence += DisplayConfidence;
            Network.UpdateAverageLoss += DisplayLoss;

            Random = new Random();

            BatchSize = int.Parse(BatchSizeTextBox.Text);
            BatchCount = int.Parse(BatchCountTextBox.Text);

            SavePath = Path.Combine(AppContext.BaseDirectory, "Data", "Save.dat");
            SamplesPath = Path.Combine(AppContext.BaseDirectory, "Data", "emnist-letters-train.csv");
        }


        private void LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                Network.Load(SavePath);
                ConsoleLabel.Text = "* Successfully loaded save.";
                Debug.WriteLine($"Loaded the file {SavePath}");
            }
            catch (Exception ex)
            {
                ConsoleLabel.Text = "* Could not find a save to load from. Creating new one.";
                Network.RandomlyInitializeWeights();
            }
            BatchLoader = new ImportData(SamplesPath, Network.SamplesProcessed);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (BatchLoader == null)
            {
                ConsoleLabel.Text = "* Save unsuccessful; nothing to save.";
                return;
            }

            Network.SamplesProcessed = BatchLoader.SamplesRead;

            Network.Save(SavePath);
            ConsoleLabel.Text = "* Saved.";
            Debug.WriteLine($"Saved the file {SavePath}");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show
            (
                "Are you sure you want to delete your saved network?\n\nThis cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                if (File.Exists(SavePath))
                {
                    File.Delete(SavePath);
                    ConsoleLabel.Text = "* Save deleted. Select 'Load' to create a new one.";
                    Debug.WriteLine($"Deleted the file {SavePath}");
                }
            }
        }

        private async void TrainButton_Click(object sender, EventArgs e)
        {
            if (BatchLoader == null)
            {
                ConsoleLabel.Text = "* Must load a network before attempting to train.";
                return;
            }

            TrainButton.Enabled = false;
            LoadButton.Enabled = false;
            SaveButton.Enabled = false;
            SubmitButton.Enabled = false;
            ResetButton.Enabled = false;
            DeleteButton.Enabled = false;

            ConsoleLabel.Text = $"* Training {BatchCount} batches, each with {BatchSize} unique samples!";

            try
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i < BatchCount; i++)
                    {
                        TrainingSample[] samples = BatchLoader.LoadNextBatch(BatchSize);

                        Network.TrainBatch(samples);

                        if (i % 4 == 0) // Every few batches, show one of the samples
                        {
                            TrainingSample sample = samples[Random.Next(0, BatchSize)];

                            BeginInvoke(new Action(() => { DisplayArea.Display(sample.Inputs); }));
                        }

                    }

                });

                ConsoleLabel.Text = "Finished training.";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Could not train batch: encountered a null sample.");
                ConsoleLabel.Text = "* Training ended early; ran out of samples.";
            }
            finally
            {
                DisplayArea.Reset();
                TrainButton.Enabled = true;
                LoadButton.Enabled = true;
                SaveButton.Enabled = true;
                SubmitButton.Enabled = true;
                ResetButton.Enabled = true;
                DeleteButton.Enabled = true;
            }
        }

        private void DisplayGuess(NeuralNetwork sender, int guess)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    DisplayGuess(sender, guess);
                }));

                return;
            }

            GuessLabel.Text = $"Guess: {(char)(guess + 65)}";
        }

        private void DisplayConfidence(NeuralNetwork sender, double confidence)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    DisplayConfidence(sender, confidence);
                }));

                return;
            }

            ConfidenceLabel.Text = $"Confidence: {(confidence * 100):F1}%";
        }

        private void DisplayLoss(NeuralNetwork sender, double lossPercent)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    DisplayLoss(sender, lossPercent);
                }));

                return;
            }

            LossLabel.Text = $"Loss: {lossPercent:F1}%";
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            DisplayArea.Reset();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Network.ForwardPropagate(DisplayArea.GetSample(), guessMode: true);
        }

        private void BatchSizeTextBox_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(BatchSizeTextBox.Text, out int result))
            {
                ConsoleLabel.Text = "* Batch size must be an integer in range [1, 512]";
                BatchSize = 64;
                BatchSizeTextBox.Text = "64";
                return;
            }

            int tempBatchSize = int.Parse(BatchSizeTextBox.Text);

            if (tempBatchSize < 1 || tempBatchSize > 512)
            {
                ConsoleLabel.Text = "* Batch size must be an integer in range [1, 512]";
                BatchSize = 64;
                BatchSizeTextBox.Text = "64";
            }
            else
            {
                BatchSize = tempBatchSize;
                ConsoleLabel.Text = $"* Batch size set to {BatchSize}.";
            }
        }

        private void BatchCountTextBox_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(BatchCountTextBox.Text, out int result))
            {
                ConsoleLabel.Text = "* Batch count must be an integer in range [1, 2048]";
                BatchCount = 256;
                BatchCountTextBox.Text = "256";
            }

            int tempBatchCount = int.Parse(BatchCountTextBox.Text);

            if (tempBatchCount < 1 || tempBatchCount > 2048)
            {
                ConsoleLabel.Text = "* Batch count must be an integer in range [1, 2048]";
                BatchCount = 256;
                BatchCountTextBox.Text = "256";
            }
            else
            {
                BatchCount = tempBatchCount;
                ConsoleLabel.Text = $"* Batch count set to {BatchCount}.";
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        // Explanation labels 
        private void GuessLabel_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "When you draw a letter and press the 'Guess' button, the network's guess will appear here. The model recognizes both uppercase and lowercase letters, but can't differentiate between the two when guessing.";
        }

        private void ConfidenceLabel_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "When the model guesses what letter you drew, its confidence level appears here. Inactive during training mode.";
        }

        private void LossLabel_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "Loss describes how 'wrong' the network is when training. High loss means overconfidence in wrong guesses or underconfidence in correct guesses. If loss is decreasing, the network is learning.";
        }

        private void ConsoleTitleLabel_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "The console will display error messages and status updates.";
        }

        private void BatchSizeLabel_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "Specifies how many individual samples (drawings of letters) each batch will contain. Higher or lower batch sizes may affect network performance in interesting ways.";
        }

        private void BatchCountLabel_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "Specifies how many batches will be processed during the next training session.";
        }

        private void LoadButton_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "Load a previously-saved network (.dat file), or create a new one if none exists. Keep training from where you left off, or test out a fully trained model.";
        }

        private void SaveButton_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "After training, click 'Save' to store the network into a .dat file. It can later be restored with the 'Load' button.";
        }

        private void TrainButton_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = $"Begin training of the network, with {BatchCount} batches of {BatchSize} samples each. You cannot save or load while the network is in training mode.";
        }

        private void ResetButton_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "Erases the drawing board.";
        }

        private void SubmitButton_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "Once you've trained the network, test it out by drawing a letter in the drawing box. Then, press 'Guess' to see the network's prediction.";
        }
        private void DeleteButton_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "Delete your current neural network save, including all its weights and biases. A new one can be created with 'Load.'";
        }
        private void Form1_MouseHover(object sender, EventArgs e)
        {
            ExplanationLabel.Text = "Hover over a control for information about what it does.";
        }

    }
}
