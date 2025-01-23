# Dice Game 🎲   

The **Dice Game** is an interactive console-based program where a user plays a dice game against the computer. The program uses HMAC for ensuring fair play and includes advanced features like calculating probabilities, displaying helpful tables, and dynamic dice selection.

## Features

- **Interactive Gameplay**: Play against the computer in a strategic dice game.
- **Fair Randomness**: Ensures fairness using cryptographic HMAC for random number generation.
- **Probability Calculation**: Displays a table showing the win probability for different dice configurations.
- **Dynamic Dice Configuration**: Supports custom dice configurations entered as arguments during program execution.
- **Help System**: Provides help and explanations during the game.

---

## Installation and Setup

Follow these steps to set up and run the Dice Game on your machine:

### Prerequisites

- **.NET SDK**: The program requires .NET Core SDK to compile and run.  
  [Download and install .NET SDK](https://dotnet.microsoft.com/download).

### Clone the Repository

1. Open your terminal or command prompt.
2. Clone the project repository:
   ```bash
   git clone https://github.com/tstazbid/dicegame.git
   cd dicegame
   ```

### Build the Project

Run the following command to build the project:
```bash
dotnet build
```

---

## Running the Game

### Syntax
To start the game, use the following command:
```bash
dotnet run <dice1> <dice2> <dice3> ...
```
- Replace `<dice1>`, `<dice2>`, etc., with your dice configurations, each consisting of exactly six integers separated by commas.

### Example
```bash
dotnet run 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3
```

In the above example:
- The first dice has faces: `2, 2, 4, 4, 9, 9`
- The second dice has faces: `6, 8, 1, 1, 8, 6`
- The third dice has faces: `7, 5, 3, 7, 5, 3`

---

## Gameplay Instructions

1. **Start the Game**: Run the program with the dice configurations as shown above.
2. **Guess the First Move**: Guess whether the computer's choice is `0` or `1`. 
   - If you guess correctly, you get to select your dice first.
3. **Select Your Dice**: Choose a dice from the list provided.
4. **Play the Rounds**:
   - Both you and the computer roll your dice.
   - Results are calculated based on modular arithmetic, and the winner of each round is announced.
5. **Help Table**: At any time, type `?` for a table showing the win probabilities for different dice combinations.
6. **Exit the Game**: Type `X` to exit the game.

---

## Dependencies

The project uses the following libraries:
- **Spectre.Console**: For rendering styled tables and text in the console.  
  Install using:
  ```bash
  dotnet add package Spectre.Console
  ```
- **ConsoleTables**: For creating simple console tables.  
  Install using:
  ```bash
  dotnet add package ConsoleTables
  ```

Make sure to install these dependencies before running the project.

---

## Files in the Project

- **Program.cs**: Contains the main program logic and handles user input/output.
- **DiceGame.cs**: Implements the core game logic, including dice selection and round play.
- **Dice.cs**: Represents a dice with six faces.
- **FairRandomGenerator.cs**: Handles fair random number generation using HMAC.
- **HelpTableGenerator.cs**: Generates and displays the probability help table.
- **ProbabilityCalculator.cs**: Calculates win probabilities for dice combinations.

---

Enjoy playing the Dice Game! 🎲