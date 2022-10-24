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




void PrintGameBoard(char[] cage)
{
    Console.Clear();
    string[] gamecage = {  " _________________ ", 
                            "|     |     |     |",
                $"|  {cage[7]}  |  {cage[8]}  |  {cage[9]}  |",
                            "|_____|_____|_____|",
                            "|     |     |     |",
                $"|  {cage[4]}  |  {cage[5]}  |  {cage[6]}  |",
                            "|_____|_____|_____|",
                            "|     |     |     |",
                $"|  {cage[1]}  |  {cage[2]}  |  {cage[3]}  |",
                            "|_____|_____|_____|"};
    for (int i = 0; i < 10; i++)
    {
      Console.WriteLine(gamecage[i]); 
    }
}

void KeyPressed(ConsoleKeyInfo key, char[] cage, char mark)
{
    switch (key.Key)
    {
        case ConsoleKey.D1: 
            if (cage[1] == ' ') cage[1] = mark;
            break;
        case ConsoleKey.D2: 
            if (cage[2] == ' ') cage[2] = mark;
            break;
        case ConsoleKey.D3: 
            if (cage[3] == ' ') cage[3] = mark;
            break;
        case ConsoleKey.D4: 
            if (cage[4] == ' ') cage[4] = mark;
            break;
        case ConsoleKey.D5: 
            if (cage[5] == ' ') cage[5] = mark;
            break;
        case ConsoleKey.D6: 
            if (cage[6] == ' ') cage[6] = mark;
            break;
        case ConsoleKey.D7: 
            if (cage[7] == ' ') cage[7] = mark;
            break;
        case ConsoleKey.D8: 
            if (cage[8] == ' ') cage[8] = mark;
            break;
        case ConsoleKey.D9: 
            if (cage[9] == ' ') cage[9] = mark;
            break;
    }

}
                  //0   1   2   3   4   5   6   7   8   9  
char[] gamecage = {' ',' ',' ',' ',' ',' ',' ',' ',' ',' '};
   
// bool win = (gamecage[7] !=' ' && gamecage[7] == gamecage[8] && gamecage[7] == gamecage[9]) || ;


PrintGameBoard(gamecage);
KeyPressed(Console.ReadKey(), gamecage, 'X');




// ConsoleKeyInfo key = Console.ReadKey();
// if (key.Key == ConsoleKey.D5) Console.WriteLine("5");
// Console.WriteLine("Go!!");