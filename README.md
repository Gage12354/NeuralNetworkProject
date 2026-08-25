# NeuralNetworkProject

-----------------------------------------
				OVERVIEW
-----------------------------------------

A neural network, written from scratch in C#, which can be trained
to recognize handwritten letters using the EMNIST dataset.


-----------------------------------------
				FEATURES
-----------------------------------------

- A 28x28 input grid to write letters
- ReLU middle layers
- Softmax output layer
- Cross-entropy loss
- Batch training
- Backpropagation
- Gradient descent
- Save/load/delete trained models
- A GUI interface, including:
	- A drawing board
	- Loss and accuracy displays
	- Tooltips/explanations
	- A debug console
	- A custom app icon


-----------------------------------------
			   ARCHITECTURE
-----------------------------------------

- Four layers 
- 784 -> 256 -> 128 -> 26 neurons


-----------------------------------------
			 TOOLS & LANGUAGES
-----------------------------------------

- C# 7.3
- .NET Framework 4.8
- Windows Forms
- Git/GitHub


-----------------------------------------
			  HOW TO USE
-----------------------------------------

Initial setup:
- Download the EMNIST dataset via the following link: https://www.kaggle.com/datasets/crawford/emnist?resource=download&select=emnist-letters-train.csv
- Place the 'emnist-letters-train.csv' file inside of the project's Data folder (the same folder as 'Save.dat')


Using the model:

- Click the 'Load' button to create a new model
- Choose a batch size and count, then click 'Train'
	* For full training of the model, do note that the provided EMNIST csv
	  has 88,000 samples. 
- Once the model has been trained, remember to save it with the 'Save' button
- To test the network, use your mouse to draw letters in the drawing grid. 
- After each drawing, click 'Guess' to see the network's evaluation.


-----------------------------------------
			  ATTRIBUTION
-----------------------------------------

Training of this model was made possible by the EMNIST dataset, a free collection of thousands 
of handwritten letter samples. I would like to extend my sincere thanks to everyone involved.

Cohen, G., Afshar, S., Tapson, J., & van Schaik, A. (2017). 
EMNIST: an extension of MNIST to handwritten letters. 
Retrieved from http://arxiv.org/abs/1702.05373

