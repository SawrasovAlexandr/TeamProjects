//
//
//
//
//

//
//
//
//





void PrintGameBoard(char[] cage)
{
    Console.Clear();
    string tab = "                                                    ";
    string[] gamecage = {   " _________________ ", 
                            "|     |     |     |",
                $"|  {cage[7]}  |  {cage[8]}  |  {cage[9]}  |",
                            "|_____|_____|_____|",
                            "|     |     |     |",
                $"|  {cage[4]}  |  {cage[5]}  |  {cage[6]}  |",
                            "|_____|_____|_____|",
                            "|     |     |     |",
                $"|  {cage[1]}  |  {cage[2]}  |  {cage[3]}  |",
                            "|_____|_____|_____|"};
    Console.WriteLine();
    for (int i = 0; i < 10; i++)
    {
      Console.WriteLine(tab + gamecage[i]); 
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
string[] welcome = {"                                  КРЕСТИКИ - НОЛИКИ            _________________",
                    "          Два игрока по очереди ставят крестики или нолики    |     |     |     |",
                    "     на игровом поле, нажимая клавиши цифровой клавиатуры,    |  7  |  8  |  9  |",
                    "     соответствующие ячейкам игрового поля.                   |_____|_____|_____|",
                    "          Выигрывает тот кто первым заполнит своими знаками   |     |     |     |",
                    "     вертикальную, горизонтальную или диагональную линию.     |  4  |  5  |  6  |",
                    "          Так что определяемся, кто ходит первым - тянем      |_____|_____|_____|",
                    "     спичку, бросаем монетку и т.д. И в бой!!                 |     |     |     |",
                    "          Первыми ходят крестики. Для начала игры нажмите     |  1  |  2  |  3  |",
                    "     любую клавишу.                                           |_____|_____|_____|"};
bool win = false;
char tictac = 'X';
int turn = 0;
bool wturn = true;
string tab = "                                                    ";
Console.WriteLine();
for (int i = 0; i < 10; i++)
    {
      Console.WriteLine(welcome[i]); 
    }
Console.ReadKey();
PrintGameBoard(gamecage);
while (!win && turn != 9)
{
    string boardA = new string(gamecage);
    Console.WriteLine();
    Console.WriteLine(tab + (wturn ? "  Ходят Крестики!" : "   Ходят Нолики!"));
    KeyPressed(Console.ReadKey(), gamecage, tictac);
    PrintGameBoard(gamecage);
    win =  (gamecage[7] !=' ' && gamecage[7] == gamecage[8] && gamecage[7] == gamecage[9] ||
            gamecage[4] !=' ' && gamecage[4] == gamecage[5] && gamecage[4] == gamecage[6] ||
            gamecage[1] !=' ' && gamecage[1] == gamecage[2] && gamecage[1] == gamecage[3] ||
            gamecage[7] !=' ' && gamecage[7] == gamecage[4] && gamecage[7] == gamecage[1] ||
            gamecage[8] !=' ' && gamecage[8] == gamecage[5] && gamecage[8] == gamecage[2] ||
            gamecage[9] !=' ' && gamecage[9] == gamecage[6] && gamecage[9] == gamecage[3] ||
            gamecage[7] !=' ' && gamecage[7] == gamecage[5] && gamecage[7] == gamecage[3] ||
            gamecage[1] !=' ' && gamecage[1] == gamecage[5] && gamecage[1] == gamecage[9]);
    string boardZ = new string(gamecage);
    turn = (boardA == boardZ ? turn : ++turn);
    wturn = turn % 2 == 0;
    tictac = (wturn ? 'X' : 'O');
};
Console.WriteLine();
Console.Write(tab);
if (win && turn <= 9) Console.WriteLine(wturn ? " Нолики победили!!" : "Крестики победили!!");
else Console.WriteLine("   Боевая ничья!");
Console.WriteLine();
