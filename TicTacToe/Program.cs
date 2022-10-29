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
                        "         Первыми ходят крестики. Для продолжения нажмите      |_____|_____|_____|",  //6
                        "     любую клавишу.                                           |     |     |     |",  //7
                        "                                                              |  1  |  2  |  3  |",  //8
                        "                                                              |_____|_____|_____|"}; //9
    Console.WriteLine();
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(welcome[i]);
    }
    Console.ReadKey();  //ожидает нажатия любой клавиши
}
///////////
bool PazzleXO()
{
    Console.Clear();
    bool ArrowRLPressed = true;
    bool choiceXO = true;
    bool userChoice = true;
    int random = new Random().Next(1, 101);
    bool pazleChoice = random % 2 == 0;
    Console.WriteLine();
    Console.WriteLine("     Привет! Меня зовут Пазл! И со мной ты будешь играть!");
    Console.WriteLine("     Для начала давай решим кто играет крестиками и ходит первым.");
    Console.WriteLine("     Я загадываю число от 1 до 100, а ты попробуешь угадать четное оно или нет:");
    Console.WriteLine();
    Console.WriteLine("        ЧЕТ <== [стрелка влево]    или    [стрелка вправо]  ==> НЕЧЕТ");
    Console.WriteLine();
    while (ArrowRLPressed)
    {
        ConsoleKey answer = Console.ReadKey(false).Key;
        if (answer == ConsoleKey.LeftArrow || answer == ConsoleKey.RightArrow)
        {
            userChoice = (answer == ConsoleKey.LeftArrow ? true : false);
            ArrowRLPressed = false;
        }
    }
    if (userChoice == pazleChoice)
    {
        Console.WriteLine($"    Угадал! Я загадывал - {random}. Ты играешь крестиками и ходишь первым.");
        choiceXO = false;
    }
    else
    {
        Console.WriteLine($"    Не угадал! Я загадывал - {random}. Крестиками играю я! ");
    }
    Console.WriteLine();
    Console.WriteLine("     Если готов начинать - нажми любую клавишу.");
    Console.ReadKey();
    return choiceXO;
};
///////////
void PrintGameBoard(char[] cell)  //перерисовывает игровое поле с учетом изменений содержимого клеток(cell)
{
    Console.Clear();
    string tab = "                                                    "; //отступ, что б поле было в центре экрана
    string[] gameboard = {  " _________________ ",              //0
                            "|     |     |     |",              //1
                $"|  {cell[7]}  |  {cell[8]}  |  {cell[9]}  |", //2     в центр ячеек игрового поля
                            "|_____|_____|_____|",              //3     записываются значения из
                            "|     |     |     |",              //4     массива cell
                $"|  {cell[4]}  |  {cell[5]}  |  {cell[6]}  |", //5
                            "|_____|_____|_____|",              //6
                            "|     |     |     |",              //7
                $"|  {cell[1]}  |  {cell[2]}  |  {cell[3]}  |", //8
                            "|_____|_____|_____|"};             //9
    Console.WriteLine();
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(tab + gameboard[i]);
    }
}
///////////
bool FullLine(char[] cell, char checkSign, char changeSign)
{
    bool full = false;
    string boardA = new string(cell);
    if (cell[5] == checkSign && cell[1] == checkSign && cell[9] == ' ') cell[9] = changeSign;
    else if (cell[5] == checkSign && cell[2] == checkSign && cell[8] == ' ') cell[8] = changeSign;
    else if (cell[5] == checkSign && cell[3] == checkSign && cell[7] == ' ') cell[7] = changeSign;
    else if (cell[5] == checkSign && cell[4] == checkSign && cell[6] == ' ') cell[6] = changeSign;
    else if (cell[5] == checkSign && cell[6] == checkSign && cell[4] == ' ') cell[4] = changeSign;
    else if (cell[5] == checkSign && cell[7] == checkSign && cell[3] == ' ') cell[3] = changeSign;
    else if (cell[5] == checkSign && cell[8] == checkSign && cell[2] == ' ') cell[2] = changeSign;
    else if (cell[5] == checkSign && cell[9] == checkSign && cell[1] == ' ') cell[1] = changeSign;
    else if (cell[7] == checkSign && cell[8] == checkSign && cell[9] == ' ') cell[9] = changeSign;
    else if (cell[7] == checkSign && cell[9] == checkSign && cell[8] == ' ') cell[8] = changeSign;
    else if (cell[7] == checkSign && cell[4] == checkSign && cell[1] == ' ') cell[1] = changeSign;
    else if (cell[7] == checkSign && cell[1] == checkSign && cell[4] == ' ') cell[4] = changeSign;
    else if (cell[4] == checkSign && cell[1] == checkSign && cell[7] == ' ') cell[7] = changeSign;
    else if (cell[8] == checkSign && cell[9] == checkSign && cell[7] == ' ') cell[7] = changeSign;
    else if (cell[3] == checkSign && cell[1] == checkSign && cell[2] == ' ') cell[2] = changeSign;
    else if (cell[3] == checkSign && cell[2] == checkSign && cell[1] == ' ') cell[1] = changeSign;
    else if (cell[3] == checkSign && cell[6] == checkSign && cell[9] == ' ') cell[9] = changeSign;
    else if (cell[3] == checkSign && cell[9] == checkSign && cell[6] == ' ') cell[6] = changeSign;
    else if (cell[2] == checkSign && cell[1] == checkSign && cell[3] == ' ') cell[3] = changeSign;
    else if (cell[6] == checkSign && cell[9] == checkSign && cell[3] == ' ') cell[3] = changeSign;
    string boardZ = new string(cell);
    full = (boardA != boardZ);
    return full;
}
///////////
void PazleKeyPressed(char[] cell, char pazzleSign)
{
    Thread.Sleep(700);
    char userSign = (pazzleSign == 'X' ? 'O' : 'X');
    if (cell[5] == ' ') cell[5] = pazzleSign;
    else if (FullLine(cell, pazzleSign, pazzleSign)) return;
    else if (FullLine(cell, userSign, pazzleSign)) return;
    else if (cell[7] == ' ') cell[7] = pazzleSign;
    else if (cell[9] == ' ') cell[9] = pazzleSign;
    else if (cell[1] == ' ') cell[1] = pazzleSign;
    else if (cell[3] == ' ') cell[3] = pazzleSign;
    else if (cell[8] == ' ') cell[8] = pazzleSign;
    else if (cell[6] == ' ') cell[6] = pazzleSign;
    else if (cell[2] == ' ') cell[2] = pazzleSign;
    else if (cell[4] == ' ') cell[4] = pazzleSign;
    return;
};
///////////
void UserKeyPressed(ConsoleKey key, char[] cell, char checkSign) //если нажата клавиша 1..9 та записывает значение Х или О(checkSign) в 
{                                                           //соответствующую клетку(cell)
    switch (key)
    {
        case ConsoleKey.D1:                     //если нажата 1
            if (cell[1] == ' ') cell[1] = checkSign; //если в первой клетке пробел(она пуста) то туда записывает Х или О
            break;
        case ConsoleKey.D2:                     //и т.д.
            if (cell[2] == ' ') cell[2] = checkSign;
            break;
        case ConsoleKey.D3:
            if (cell[3] == ' ') cell[3] = checkSign;
            break;
        case ConsoleKey.D4:
            if (cell[4] == ' ') cell[4] = checkSign;
            break;
        case ConsoleKey.D5:
            if (cell[5] == ' ') cell[5] = checkSign;
            break;
        case ConsoleKey.D6:
            if (cell[6] == ' ') cell[6] = checkSign;
            break;
        case ConsoleKey.D7:
            if (cell[7] == ' ') cell[7] = checkSign;
            break;
        case ConsoleKey.D8:
            if (cell[8] == ' ') cell[8] = checkSign;
            break;
        case ConsoleKey.D9:
            if (cell[9] == ' ') cell[9] = checkSign;
            break;
    }
}
///////////
bool Win(char[] cell) // возвращает true, если выпала выиграшная комбинация
{                                                                               //если в клетке 7 не пробел(а Х или О) и ее содержимое 
    bool winLine = cell[7] != ' ' && cell[7] == cell[8] && cell[7] == cell[9] ||   //равно клетке 8 и 9(верхний горизонтальный ряд)
                   cell[4] != ' ' && cell[4] == cell[5] && cell[4] == cell[6] ||     //средний горизонтальный
                   cell[1] != ' ' && cell[1] == cell[2] && cell[1] == cell[3] ||   //нижний горизонтальный
                   cell[7] != ' ' && cell[7] == cell[4] && cell[7] == cell[1] ||     //левый вертикальный
                   cell[8] != ' ' && cell[8] == cell[5] && cell[8] == cell[2] ||   //средний вертикальный
                   cell[9] != ' ' && cell[9] == cell[6] && cell[9] == cell[3] ||     //правый вертикальный
                   cell[7] != ' ' && cell[7] == cell[5] && cell[7] == cell[3] ||   //диагональный\
                   cell[1] != ' ' && cell[1] == cell[5] && cell[1] == cell[9];       //другой диагональный/
    return winLine;
}
///////////// начало программы
char[] gameCells = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }; //начальные значения игровых клеток(пустые)
char ticTac = 'X';      //значение записываемое в игровые клетки во время хода
int turn = 0;         //счетчик ходов
bool whoseTurn = true;  //определяет кто ходит
string tab = "                                                    ";    //отступ, что б поле было в центре экрана
Welcome();                //выводит правила игры
bool pazzleX = PazzleXO();
bool pazzleTurn = true;  
PrintGameBoard(gameCells);   //рисует пустое игровое поле
while (!Win(gameCells) && turn < 9) //выполнять пока не выпадет выигрыш и пока сделано менее 9 ходов
{
    Console.WriteLine();
    pazzleTurn = (pazzleX ? whoseTurn : !whoseTurn);
    Console.WriteLine(tab + (whoseTurn ? "  Ходят Крестики!" : "   Ходят Нолики!"));  //объявляет чей ход
    string boardA = new string(gameCells);               //запоминает значения клеток до нажатия клавиши
    if (pazzleTurn) PazleKeyPressed(gameCells, ticTac);
    else UserKeyPressed(Console.ReadKey().Key, gameCells, ticTac);  //ждет нажатия клавиши, если нажата 1..9 изменяет значение на ticTac в соответствующей клетке(gameCells)
    string boardZ = new string(gameCells);               //запоминает значения клеток после нажатия клавиши
    PrintGameBoard(gameCells);                         //обновляет игровое поле
    Win(gameCells);                                      //проверяет не выпала ли выигрышная комбинация
    turn = (boardA == boardZ ? turn : ++turn);        //если игровое поле изменилось то увеличивает счетчик на 1
    whoseTurn = (turn % 2 == 0);                          //если ход четный возвращает true
    ticTac = (whoseTurn ? 'X' : 'O');                   //Х - если четный ход, О - если нечетный
};
Console.WriteLine();
if (Win(gameCells)) Console.WriteLine(tab + (pazzleTurn ? " Пазл - мегакрут!!" : "    Поздравляю("));
if (Win(gameCells)) Console.WriteLine(tab + (whoseTurn ? " Нолики победили!!" : "Крестики победили!!")); //если выпал выигрыш то объявляет победителя
else Console.WriteLine(tab + "   Боевая ничья!");                                                 //иначе ничья
Console.WriteLine();

