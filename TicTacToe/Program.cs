// Два игрока по очереди ставят крестики или нолики
// на игровом поле, нажимая клавиши цифровой клавиатуры,
// соответствующие ячейкам игрового поля. 
// Выигрывает тот кто первым заполнит своими знаками
// вертикальную, горизонтальную или диагональную линию.

//          _________________ 
//         |     |     |     |
//         |  7  |  8  |  9  |
//         |_____|_____|_____|
//         |     |     |     |
//         |  4  |  5  |  6  |
//         |_____|_____|_____|
//         |     |     |     |
//         |  1  |  2  |  3  |
//         |_____|_____|_____|




void PrintGameBoard(char[][] board)
{
    Console.Clear();
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 19; j++)
        {
            Console.Write(board[i][j]);
        }
        Console.WriteLine();
    }
}

void KeyPressed(ConsoleKeyInfo key, char[][] board, char tictac)
{
    switch (key.Key)
    {
        case ConsoleKey.D1: 
            if (board[8][3] == ' ') board[8][3] = tictac;
            break;
        case ConsoleKey.D2: 
            if (board[8][9] == ' ') board[8][9] = tictac;
            break;
        case ConsoleKey.D3: 
            if (board[8][15] == ' ') board[8][15] = tictac;
            break;
        case ConsoleKey.D4: 
            if (board[5][3] == ' ') board[5][3] = tictac;
            break;
        case ConsoleKey.D5: 
            if (board[5][9] == ' ') board[5][9] = tictac;
            break;
        case ConsoleKey.D6: 
            if (board[5][15] == ' ') board[5][15] = tictac;
            break;
        case ConsoleKey.D7: 
            if (board[2][3] == ' ') board[2][3] = tictac;
            break;
        case ConsoleKey.D8: 
            if (board[2][9] == ' ') board[2][9] = tictac;
            break;
        case ConsoleKey.D9: 
            if (board[2][15] == ' ') board[2][15] = tictac;
            break;
    }

}

char[][] gameBoard = new char[10][]
{               //0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15  16  17  18
    new char[]  {' ','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_',' '}, //0
    new char[]  {'|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|'}, //1
    new char[]  {'|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|'}, //2
    new char[]  {'|','_','_','_','_','_','|','_','_','_','_','_','|','_','_','_','_','_','|'}, //3
    new char[]  {'|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|'}, //4
    new char[]  {'|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|'}, //5'
    new char[]  {'|','_','_','_','_','_','|','_','_','_','_','_','|','_','_','_','_','_','|'}, //6
    new char[]  {'|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|'}, //7
    new char[]  {'|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|',' ',' ',' ',' ',' ','|'}, //8
    new char[]  {'|','_','_','_','_','_','|','_','_','_','_','_','|','_','_','_','_','_','|'}  //9
};
// bool win = (gameBoard[2][3] !=' ' && gameBoard[2][3] == gameBoard[2][9] && gameBoard[2][3] == gameBoard[2][15]) || ;


PrintGameBoard(gameBoard);
KeyPressed(Console.ReadKey(), gameBoard, 'X');




// ConsoleKeyInfo key = Console.ReadKey();
// if (key.Key == ConsoleKey.D5) Console.WriteLine("5");
// Console.WriteLine("Go!!");