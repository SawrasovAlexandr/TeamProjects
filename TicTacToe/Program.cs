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
                        "          Игра ведется до трех побед! Первыми ходят крестики. |_____|_____|_____|",  //6
                        "     Право играть крестиками в первый раз разыгрывается. А    |     |     |     |",  //7
                        "     далее чередуется от партии к партии.  Для продолжения    |  1  |  2  |  3  |",  //8
                        "     нажмите любую клавишу.                                   |_____|_____|_____|"}; //9
    Console.WriteLine();
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(welcome[i]);
    }
    Console.ReadKey();  //ожидает нажатия любой клавиши
}
///////////
bool PazzleXO()   // представляется Пазлом, предлагает сыграть в чет/нечет, что бы решить кто играет крестиками, и возвращает 
{                 // результат в зависимости от удачи игрока: возвращает true, если крестики выпали Пазлу, иначе false 
    Console.Clear();
    bool ArrowRLPress = true;   // определяет нажата ли стрелка вправо/влево
    bool choiceXO = true;         // определяет значение, которое вернется функции
    bool userChoice = true;     // хранит выбор игрока
    int random = new Random().Next(1, 101);     // случайное число от 1 до 100
    bool pazleChoice = random % 2 == 0;       // проверяет четное ли random и сохраняет результат, как выбор Пазла
    Console.WriteLine();
    Console.WriteLine("         Привет! Меня зовут Пазл! И со мной ты будешь играть!");
    Console.WriteLine("     Для начала давай решим кто играет крестиками и ходит первым.");
    Console.WriteLine("     Я загадываю число от 1 до 100, а ты попробуешь угадать четное оно или нет:");
    Console.WriteLine();
    Console.WriteLine("        ЧЕТ <== [стрелка влево]    или    [стрелка вправо]  ==> НЕЧЕТ");
    Console.WriteLine();
    while (ArrowRLPress)        // выполнять пока не нажата стрелка вправо/влево
    {
        ConsoleKey whatKey = Console.ReadKey(true).Key;             // сохраняет в whatKey какая клавиша была нажата
        if (whatKey == ConsoleKey.LeftArrow || whatKey == ConsoleKey.RightArrow)  // если нажата стрелка вправо или стрелка влево
        {
            userChoice = (whatKey == ConsoleKey.LeftArrow ? true : false); // записать в userChoice true если был выбран ЧЕТ, иначе false
            ArrowRLPress = false;       // стрелка нажата - выходим из цикла
        }
    }
    if (userChoice == pazleChoice)  // если игрок угадал что было "загадано" Пазлом
    {
        Console.WriteLine($"    Угадал! Я загадывал - {random}. Ты играешь крестиками и ходишь первым.");
        choiceXO = false; // функции вернется false
    }
    else // иначе значение в choiceXO останется true
    {
        Console.WriteLine($"    Не угадал! Я загадывал - {random}. Крестиками играю я! ");
    }
    Console.WriteLine();
    Console.WriteLine("     Если готов начинать - нажми любую клавишу.");
    Console.ReadKey();          // ожидает нажатия любой клавиши
    return choiceXO;        //возвращает значение функции
};
///////////
void PrintGameBoard(char[] cell)  //перерисовывает игровое поле с учетом изменений содержимого клеток(cell)
{
    Console.Clear();
    string tab = "                                                    "; //отступ, что б поле было в центре экрана
    string[] gameBoard = {  " _________________ ",              //0
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
        Console.WriteLine(tab + gameBoard[i]);
    }
}
///////////
bool FullLine(char[] cell, char checkSign, char pasteSigh) // проверяет есть ли на игровом поле cell линии с двумя клетками  
{                                       // с символами checkSign и одной пустой, и найдя записывает в пустую pastSigh
    bool full = false; // проверяет была ли заполнена линия
    string boardA = new string(cell); // слепок игрового поля до начала проверки
    if (cell[5] == checkSign && cell[1] == checkSign && cell[9] == ' ') cell[9] = pasteSigh;
    else if (cell[5] == checkSign && cell[2] == checkSign && cell[8] == ' ') cell[8] = pasteSigh;
    else if (cell[5] == checkSign && cell[3] == checkSign && cell[7] == ' ') cell[7] = pasteSigh;
    else if (cell[5] == checkSign && cell[4] == checkSign && cell[6] == ' ') cell[6] = pasteSigh;
    else if (cell[5] == checkSign && cell[6] == checkSign && cell[4] == ' ') cell[4] = pasteSigh;
    else if (cell[5] == checkSign && cell[7] == checkSign && cell[3] == ' ') cell[3] = pasteSigh;
    else if (cell[5] == checkSign && cell[8] == checkSign && cell[2] == ' ') cell[2] = pasteSigh;
    else if (cell[5] == checkSign && cell[9] == checkSign && cell[1] == ' ') cell[1] = pasteSigh;
    else if (cell[7] == checkSign && cell[3] == checkSign && cell[5] == ' ') cell[5] = pasteSigh;
    else if (cell[1] == checkSign && cell[9] == checkSign && cell[5] == ' ') cell[5] = pasteSigh;
    else if (cell[4] == checkSign && cell[6] == checkSign && cell[5] == ' ') cell[5] = pasteSigh;
    else if (cell[2] == checkSign && cell[8] == checkSign && cell[5] == ' ') cell[5] = pasteSigh;
    else if (cell[7] == checkSign && cell[8] == checkSign && cell[9] == ' ') cell[9] = pasteSigh;
    else if (cell[7] == checkSign && cell[9] == checkSign && cell[8] == ' ') cell[8] = pasteSigh;
    else if (cell[7] == checkSign && cell[4] == checkSign && cell[1] == ' ') cell[1] = pasteSigh;
    else if (cell[7] == checkSign && cell[1] == checkSign && cell[4] == ' ') cell[4] = pasteSigh;
    else if (cell[4] == checkSign && cell[1] == checkSign && cell[7] == ' ') cell[7] = pasteSigh;
    else if (cell[8] == checkSign && cell[9] == checkSign && cell[7] == ' ') cell[7] = pasteSigh;
    else if (cell[3] == checkSign && cell[1] == checkSign && cell[2] == ' ') cell[2] = pasteSigh;
    else if (cell[3] == checkSign && cell[2] == checkSign && cell[1] == ' ') cell[1] = pasteSigh;
    else if (cell[3] == checkSign && cell[6] == checkSign && cell[9] == ' ') cell[9] = pasteSigh;
    else if (cell[3] == checkSign && cell[9] == checkSign && cell[6] == ' ') cell[6] = pasteSigh;
    else if (cell[2] == checkSign && cell[1] == checkSign && cell[3] == ' ') cell[3] = pasteSigh;
    else if (cell[6] == checkSign && cell[9] == checkSign && cell[3] == ' ') cell[3] = pasteSigh;
    string boardZ = new string(cell);   // слепок игрового поля после проверки
    full = (boardA != boardZ);      // если изменения есть, то true
    return full;                // возвращает значение функции
}
///////////
int[] RandomIndex()     //создаем массив со случайно расположенными цифрами от 1 до 9
{
    int[] index = {1, 2, 3, 4, 5, 6, 7, 8, 9}; 
    for (int i = 0; i < 9; i++)
    {
        int random = new Random().Next(0, 9);
        int x = index[i];
        index[i] = index[random];
        index[random] = x;
    }
    return index;
}
///////////
void PazzleKeyPressed(bool whoWins, char[] cell, char pazzleSign) // делает ход Пазла
{
    Thread.Sleep(700);          // задержка перед ходом в 0.7 сек.
    char userSign = (pazzleSign == 'X' ? 'O' : 'X');    // записывает знак игрока, противоположный знаку Пазла
    int[] index = RandomIndex(); //создаем массив со случайно расположенными индексами от 1 до 9
    if (FullLine(cell, pazzleSign, pazzleSign)) return;   // если может выиграть(Х/ /Х) - выигрывает(Х/Х/Х)
    else if (FullLine(cell, userSign, pazzleSign)) return;   //если может не дать выиграть(О/ /О) - не дает выиграть(О/Х/О)
    else if (whoWins)                                     //если Пазл выигрывает, то ходит случайным образом
    {
        for (int i = 0; i < 9; i++)
        {
            if (cell[index[i]] == ' ') 
            {
                cell[index[i]] = pazzleSign;
                return;
            }
        }
    }
    else if (cell[5] == ' ') cell[5] = pazzleSign;     //иначе проверяет свободные клетки и делает более осмысленный ход
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
void UserKeyPressed(ConsoleKey key, char[] cell, char sign) //если нажата клавиша 1..9 та записывает значение Х или О(sign) в 
{                                                           //соответствующую клетку(cell)
    switch (key)
    {
        case ConsoleKey.D1:                     //если нажата 1
            if (cell[1] == ' ') cell[1] = sign; //если в первой клетке пробел(она пуста) то туда записывает Х или О
            break;
        case ConsoleKey.D2:                     //и т.д.
            if (cell[2] == ' ') cell[2] = sign;
            break;
        case ConsoleKey.D3:
            if (cell[3] == ' ') cell[3] = sign;
            break;
        case ConsoleKey.D4:
            if (cell[4] == ' ') cell[4] = sign;
            break;
        case ConsoleKey.D5:
            if (cell[5] == ' ') cell[5] = sign;
            break;
        case ConsoleKey.D6:
            if (cell[6] == ' ') cell[6] = sign;
            break;
        case ConsoleKey.D7:
            if (cell[7] == ' ') cell[7] = sign;
            break;
        case ConsoleKey.D8:
            if (cell[8] == ' ') cell[8] = sign;
            break;
        case ConsoleKey.D9:
            if (cell[9] == ' ') cell[9] = sign;
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

int count = 0;          //счетчик сыгранных партий
int userWin = 0;      //счетчик побед игрока
int pazzleWin = 0;      //счетчик побед Пазла
string tab = "                                                    ";    //отступ, что б поле было в центре экрана
Welcome();                //выводит правила игры
bool pazzleX = PazzleXO(); //знакомство с Пазлом, выбор чем играть(Х/О) и запись выбора в pazzleX
bool whoWins = true;      //определяет поведение Пазла в зависимости от счета
while (userWin < 3 && pazzleWin < 3) //выполнять пока кем то не будет набрано 3 победы
{
    char[] gameCells = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }; //начальные значения игровых клеток(пустые)
    char ticTac = 'X';      //значение записываемое в игровые клетки во время хода
    int step = 0;         //счетчик ходов
    bool whoseStep = true;  //определяет кто ходит - крестики или нолики
    bool pazzleTurn = true;  //true, если ход Пазла
    PrintGameBoard(gameCells);   //рисует пустое игровое поле
    while (!Win(gameCells) && step < 9) //выполнять пока не выпадет выигрыш и пока сделано менее 9 ходов
    {
        Console.WriteLine();
        pazzleTurn = (pazzleX ? whoseStep : !whoseStep); //если Пазл играет крестиками, то pazzleTurn равен whoseStep, иначе противоположен
        Console.WriteLine(tab + (whoseStep ? "  Ходят Крестики!" : "   Ходят Нолики!"));  //объявляет чей ход
        string boardA = new string(gameCells);               //запоминает значения клеток до хода
        if (pazzleTurn) PazzleKeyPressed(whoWins, gameCells, ticTac); // если ход Пазла, то изменяет значение на ticTac в соответствующей клетке(gameCells)
        else UserKeyPressed(Console.ReadKey().Key, gameCells, ticTac);  //иначе ждет нажатия клавиши игроком, и если нажата 1..9 изменяет значение на ticTac в соответствующей клетке(gameCells)
        string boardZ = new string(gameCells);               //запоминает значения клеток после хода
        PrintGameBoard(gameCells);                         //обновляет игровое поле
        Win(gameCells);                                      //проверяет не выпала ли выигрышная комбинация
        step = (boardA == boardZ ? step : ++step);        //если игровое поле изменилось то увеличивает счетчик на 1
        whoseStep = (step % 2 == 0);                          //если ход четный возвращает true
        ticTac = (whoseStep ? 'X' : 'O');                   //Х - если четный ход, О - если нечетный
    };
    Console.WriteLine();
    if (Win(gameCells)) ///если кому то выпал выигрыш
    {
        Console.WriteLine(tab + (pazzleTurn ? "   Пазл выиграл!" : "    Ты выиграл!")); 
        if (pazzleTurn) pazzleWin++; //если выиграл Пазл, то счетчик его побед увеличивается
        else userWin++;     //иначе увеличивается счетчик игрока
    }
    if (Win(gameCells)) Console.WriteLine(tab + (whoseStep ? " Нолики победили!!" : "Крестики победили!!")); //если выпал выигрыш то объявляет знак победителя
    else Console.WriteLine(tab + "   Боевая ничья!");                   //иначе ничья
    Console.WriteLine();
    count++; //увеличивает счетчик сыгранных партий
    pazzleX = !pazzleX; //если Пазл играл крестиками, то теперь играет ноликами
    Console.WriteLine($"                                        Сыграно партий: {count}. Счет - Игрок: {userWin}  Пазл: {pazzleWin}");
    if (userWin == 2 && userWin == pazzleWin) whoWins = !whoWins; //если накопилось по два выигрыша, то с каждой партией меняет значение на противоположное
    else whoWins = (userWin <= pazzleWin);          //true пока игрок не вырвался вперед
    Console.WriteLine();
    Console.WriteLine($"                                               Теперь ты играешь {(pazzleX ? "ноликами." : "крестиками.")}");
    Console.WriteLine("                                        Если готов продолжить - нажми любую клавишу.");
    Console.ReadKey();          // ожидает нажатия любой клавиши
}
Console.WriteLine();
Console.WriteLine(userWin == 3 ? "                                                   Поздравляю с победой!" :
                                 "                                              Это прескорбно, но вы проиграли.");
Console.WriteLine();
