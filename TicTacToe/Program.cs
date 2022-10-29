///////////
void Welcome() //выводит правила игры и ждет нажатия любой клавиши
{
    Console.Clear();
    string[] welcome = {"                                  КРЕСТИКИ - НОЛИКИ            _________________",   //0
                        "          Два игрока по очереди ставят крестики или нолики    |     |     |     |",  //1
                        "     на игровом поле, нажимая клавиши цифровой клавиатуры,    |  7  |  8  |  9  |",  //2
                        "     соответствующие ячейкам игрового поля.                   |_____|_____|_____|",  //3
                        "          Выигрывает тот кто первым заполнит своими знаками   |     |     |     |",  //4
                        "     вертикальную, горизонтальную или диагональную линию.     |  4  |  5  |  6  |",  //5
                        "          Так что определяемся, кто ходит первым - тянем      |_____|_____|_____|",  //6
                        "     спичку, бросаем монетку и т.д. И в бой!!                 |     |     |     |",  //7
                        "          Первыми ходят крестики. Для продолжения нажмите     |  1  |  2  |  3  |",  //8
                        "     любую клавишу.                                           |_____|_____|_____|"}; //9
    Console.WriteLine();
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(welcome[i]);
    }
    Console.ReadKey();  //ожидает нажатия любой клавиши
}
///////////
// bool PazleXO()
// {
//     Console.Clear();
//     bool ArrowRLPressed = false;
//     bool choiceXO = true;
//     bool userChoice = true;
//     int random = new Random().Next(1, 11);
//     bool pazleChoice = random % 2 == 0;
//     Console.WriteLine();
//     Console.WriteLine("Привет! Меня зовут Пазл! И со мной тебе придется сразится!");
//     Console.WriteLine("  Для начала давай решим кто играет крестиками и ходит первым.");
//     Console.WriteLine("     Я загадываю число, а ты попробуешь угадать:");
//     Console.WriteLine("         ЧЕТ <== [стрелка влево]    или    [стрелка вправо]  ==> НЕЧЕТ");
//     while (!ArrowRLPressed)
//     {
//         ConsoleKey answer = Console.ReadKey(false).Key;
//         if (answer == ConsoleKey.LeftArrow || answer == ConsoleKey.RightArrow)
//         {
//             userChoice = (answer == ConsoleKey.LeftArrow ? true : false);
//             ArrowRLPressed = true;
//         };
//     };

//     if (userChoice == pazleChoice)
//     {
//         Console.WriteLine($"{random} - Новичкам везет. Ты играешь крестиками.");
//         choiceXO = false;
//     }
//     else
//     {
//         Console.WriteLine($"{random} - Ну что? Влип очкарик? Крестиками играю я!!");
//     }
//     Console.ReadKey();
//     return choiceXO;
// };
///////////
void PrintGameBoard(char[] cage)  //перерисовывает игровое поле с учетом изменений содержимого клеток(cage)
{
    Console.Clear();
    string tab = "                                                    "; //отступ, что б поле было в центре экрана
    string[] gameboard = {  " _________________ ",              //0
                            "|     |     |     |",              //1
                $"|  {cage[7]}  |  {cage[8]}  |  {cage[9]}  |", //2     в центр ячеек игрового поля
                            "|_____|_____|_____|",              //3     записываются значения из
                            "|     |     |     |",              //4     массива cage
                $"|  {cage[4]}  |  {cage[5]}  |  {cage[6]}  |", //5
                            "|_____|_____|_____|",              //6
                            "|     |     |     |",              //7
                $"|  {cage[1]}  |  {cage[2]}  |  {cage[3]}  |", //8
                            "|_____|_____|_____|"};             //9
    Console.WriteLine();
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(tab + gameboard[i]);
    }
}
///////////
void PazleKeyPressed(char[] cage, char symbol)
{
    char antiSymbol = (symbol == 'X' ? 'O' : 'X');
    if (cage[5] == symbol)
    {
        if (cage[1] == symbol && cage[9] == ' ') cage[9] = symbol;
        else if (cage[2] == symbol && cage[8] == ' ') cage[8] = symbol;
        else if (cage[3] == symbol && cage[7] == ' ') cage[7] = symbol;
        else if (cage[4] == symbol && cage[6] == ' ') cage[6] = symbol;
        else if (cage[6] == symbol && cage[4] == ' ') cage[4] = symbol;
        else if (cage[7] == symbol && cage[3] == ' ') cage[3] = symbol;
        else if (cage[8] == symbol && cage[2] == ' ') cage[2] = symbol;
        else if (cage[9] == symbol && cage[1] == ' ') cage[1] = symbol;
    }
    else if (cage[7] == symbol)
    {
        if (cage[8] == symbol && cage[9] == ' ') cage[9] = symbol;
        else if (cage[9] == symbol && cage[8] == ' ') cage[8] = symbol;
        else if (cage[4] == symbol && cage[1] == ' ') cage[1] = symbol;
        else if (cage[1] == symbol && cage[4] == ' ') cage[4] = symbol;
    }
    else if (cage[4] == symbol && cage[1] == symbol && cage[7] == ' ') cage[7] = symbol;
    else if (cage[8] == symbol && cage[9] == symbol && cage[7] == ' ') cage[7] = symbol;
    else if (cage[3] == symbol)
    {
        if (cage[1] == symbol && cage[2] == ' ') cage[2] = symbol;
        else if (cage[2] == symbol && cage[1] == ' ') cage[1] = symbol;
        else if (cage[6] == symbol && cage[9] == ' ') cage[9] = symbol;
        else if (cage[9] == symbol && cage[6] == ' ') cage[6] = symbol;
    }
    else if (cage[2] == symbol && cage[1] == symbol && cage[3] == ' ') cage[3] = symbol;
    else if (cage[6] == symbol && cage[9] == symbol && cage[3] == ' ') cage[3] = symbol;

    if (cage[5] == antiSymbol)
    {
        if (cage[1] == antiSymbol && cage[9] == ' ') cage[9] = symbol;
        else if (cage[2] == antiSymbol && cage[8] == ' ') cage[8] = symbol;
        else if (cage[3] == antiSymbol && cage[7] == ' ') cage[7] = symbol;
        else if (cage[4] == antiSymbol && cage[6] == ' ') cage[6] = symbol;
        else if (cage[6] == antiSymbol && cage[4] == ' ') cage[4] = symbol;
        else if (cage[7] == antiSymbol && cage[3] == ' ') cage[3] = symbol;
        else if (cage[8] == antiSymbol && cage[2] == ' ') cage[2] = symbol;
        else if (cage[9] == antiSymbol && cage[1] == ' ') cage[1] = symbol;
    }
    else if (cage[7] == antiSymbol)
    {
        if (cage[8] == antiSymbol && cage[9] == ' ') cage[9] = symbol;
        else if (cage[9] == antiSymbol && cage[8] == ' ') cage[8] = symbol;
        else if (cage[4] == antiSymbol && cage[1] == ' ') cage[1] = symbol;
        else if (cage[1] == antiSymbol && cage[4] == ' ') cage[4] = symbol;
    }
    else if (cage[4] == antiSymbol && cage[1] == antiSymbol && cage[7] == ' ') cage[7] = symbol;
    else if (cage[8] == antiSymbol && cage[9] == antiSymbol && cage[7] == ' ') cage[7] = symbol;
    else if (cage[3] == antiSymbol)
    {
        if (cage[1] == antiSymbol && cage[2] == ' ') cage[2] = symbol;
        else if (cage[2] == antiSymbol && cage[1] == ' ') cage[1] = symbol;
        else if (cage[6] == antiSymbol && cage[9] == ' ') cage[9] = symbol;
        else if (cage[9] == antiSymbol && cage[6] == ' ') cage[6] = symbol;
    }
    else if (cage[2] == antiSymbol && cage[1] == antiSymbol && cage[3] == ' ') cage[3] = symbol;
    else if (cage[6] == antiSymbol && cage[9] == antiSymbol && cage[3] == ' ') cage[3] = symbol;

    else if (cage[5] == ' ') cage[5] = symbol;
    else if (cage[7] == ' ') cage[7] = symbol;
    else if (cage[9] == ' ') cage[9] = symbol;
    else if (cage[3] == ' ') cage[3] = symbol;
    else if (cage[1] == ' ') cage[1] = symbol;
    else if (cage[8] == ' ') cage[8] = symbol;
    else if (cage[6] == ' ') cage[6] = symbol;
    else if (cage[2] == ' ') cage[2] = symbol;
    else cage[4] = symbol;
    
};
///////////
void UserKeyPressed(ConsoleKey key, char[] cage, char symbol) //если нажата клавиша 1..9 та записывает значение Х или О(symbol) в 
{                                                           //соответствующую клетку(cage)
    switch (key)
    {
        case ConsoleKey.D1:                     //если нажата 1
            if (cage[1] == ' ') cage[1] = symbol; //если в первой клетке пробел(она пуста) то туда записывает Х или О
            break;
        case ConsoleKey.D2:                     //и т.д.
            if (cage[2] == ' ') cage[2] = symbol;
            break;
        case ConsoleKey.D3:
            if (cage[3] == ' ') cage[3] = symbol;
            break;
        case ConsoleKey.D4:
            if (cage[4] == ' ') cage[4] = symbol;
            break;
        case ConsoleKey.D5:
            if (cage[5] == ' ') cage[5] = symbol;
            break;
        case ConsoleKey.D6:
            if (cage[6] == ' ') cage[6] = symbol;
            break;
        case ConsoleKey.D7:
            if (cage[7] == ' ') cage[7] = symbol;
            break;
        case ConsoleKey.D8:
            if (cage[8] == ' ') cage[8] = symbol;
            break;
        case ConsoleKey.D9:
            if (cage[9] == ' ') cage[9] = symbol;
            break;
    }
}
///////////
bool Win(char[] cage) // возвращает true, если выпала выиграшная комбинация
{                                                                               //если в клетке 7 не пробел(а Х или О) и ее содержимое 
    bool winRow = cage[7] != ' ' && cage[7] == cage[8] && cage[7] == cage[9] ||   //равно клетке 8 и 9(верхний горизонтальный ряд)
                cage[4] != ' ' && cage[4] == cage[5] && cage[4] == cage[6] ||     //средний горизонтальный
                cage[1] != ' ' && cage[1] == cage[2] && cage[1] == cage[3] ||   //нижний горизонтальный
                cage[7] != ' ' && cage[7] == cage[4] && cage[7] == cage[1] ||     //левый вертикальный
                cage[8] != ' ' && cage[8] == cage[5] && cage[8] == cage[2] ||   //средний вертикальный
                cage[9] != ' ' && cage[9] == cage[6] && cage[9] == cage[3] ||     //правый вертикальный
                cage[7] != ' ' && cage[7] == cage[5] && cage[7] == cage[3] ||   //диагональный\
                cage[1] != ' ' && cage[1] == cage[5] && cage[1] == cage[9];       //другой диагональный/
    return winRow;
}
///////////// начало программы
char[] gameCage = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }; //начальные значения игровых клеток(пустые)
char ticTac = 'X';      //значение записываемое в игровые клетки во время хода
int turn = 0;         //счетчик ходов
bool whoseTurn = true;  //определяет кто ходит
string tab = "                                                    ";    //отступ, что б поле было в центре экрана
Welcome();                //выводит правила игры
// bool whose = PazleXO();  
PrintGameBoard(gameCage);   //рисует пустое игровое поле
while (!Win(gameCage) && turn < 9) //выполнять пока не выпадет выигрыш и пока сделано менее 9 ходов
{
    Console.WriteLine();
    Console.WriteLine(tab + (whoseTurn ? "  Ходят Крестики!" : "   Ходят Нолики!"));  //объявляет чей ход
    string boardA = new string(gameCage);               //запоминает значения клеток до нажатия клавиши
    if (whoseTurn) PazleKeyPressed(gameCage, ticTac);
    else UserKeyPressed(Console.ReadKey().Key, gameCage, ticTac);  //ждет нажатия клавиши, если нажата 1..9 изменяет значение на ticTac в соответствующей клетке(gameCage)
    string boardZ = new string(gameCage);               //запоминает значения клеток после нажатия клавиши
    PrintGameBoard(gameCage);                         //обновляет игровое поле
    Win(gameCage);                                      //проверяет не выпала ли выигрышная комбинация
    turn = (boardA == boardZ ? turn : ++turn);        //если игровое поле изменилось то увеличивает счетчик на 1
    whoseTurn = (turn % 2 == 0);                          //если ход четный возвращает true
    ticTac = (whoseTurn ? 'X' : 'O');                   //Х - если четный ход, О - если нечетный
    // whose = !whose;
};
Console.WriteLine();
Console.Write(tab);
if (Win(gameCage)) Console.WriteLine(whoseTurn ? " Нолики победили!!" : "Крестики победили!!"); //если выпал выигрыш то объявляет победителя
else Console.WriteLine("   Боевая ничья!");                                                 //иначе ничья
Console.WriteLine();

