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
                        "          Первыми ходят крестики. Для начала игры нажмите     |  1  |  2  |  3  |",  //8
                        "     любую клавишу.                                           |_____|_____|_____|"}; //9
    Console.WriteLine();
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(welcome[i]);
    }
    Console.ReadKey();  //ожидает нажатия любой клавиши
}
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
void KeyPressed(ConsoleKeyInfo key, char[] cage, char tag) //если нажата клавиша 1..9 та записывает значение Х или О(tag) в 
{                                                           //соответствующую клетку(cage)
    switch (key.Key) 
    {
        case ConsoleKey.D1:                     //если нажата 1
            if (cage[1] == ' ') cage[1] = tag; //если в первой клетке пробел(она пуста) то туда записывает Х или О
            break;
        case ConsoleKey.D2:                     //и т.д.
            if (cage[2] == ' ') cage[2] = tag;
            break;
        case ConsoleKey.D3:
            if (cage[3] == ' ') cage[3] = tag;
            break;
        case ConsoleKey.D4:
            if (cage[4] == ' ') cage[4] = tag;
            break;
        case ConsoleKey.D5:
            if (cage[5] == ' ') cage[5] = tag;
            break;
        case ConsoleKey.D6:
            if (cage[6] == ' ') cage[6] = tag;
            break;
        case ConsoleKey.D7:
            if (cage[7] == ' ') cage[7] = tag;
            break;
        case ConsoleKey.D8:
            if (cage[8] == ' ') cage[8] = tag;
            break;
        case ConsoleKey.D9:
            if (cage[9] == ' ') cage[9] = tag;
            break;
    }
}
///////////
bool Win(char[] cage) // возвращает true, если выпала выиграшная комбинация
{                                                                               //если в клетке 7 не пробел(а Х или О) и ее содержимое 
    bool row =  cage[7] != ' ' && cage[7] == cage[8] && cage[7] == cage[9] ||   //равно клетке 8 и 9(верхний горизонтальный ряд)
                cage[4] != ' ' && cage[4] == cage[5] && cage[4] == cage[6] ||     //средний горизонтальный
                cage[1] != ' ' && cage[1] == cage[2] && cage[1] == cage[3] ||   //нижний горизонтальный
                cage[7] != ' ' && cage[7] == cage[4] && cage[7] == cage[1] ||     //левый вертикальный
                cage[8] != ' ' && cage[8] == cage[5] && cage[8] == cage[2] ||   //средний вертикальный
                cage[9] != ' ' && cage[9] == cage[6] && cage[9] == cage[3] ||     //правый вертикальный
                cage[7] != ' ' && cage[7] == cage[5] && cage[7] == cage[3] ||   //диагональный\
                cage[1] != ' ' && cage[1] == cage[5] && cage[1] == cage[9];       //другой диагональный/
    return row;
}
///////////// начало программы
char[] gamecage = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }; //начальные значения игровых клеток(пустые)
char tictac = 'X';      //значение записываемое в игровые клетки во время хода
int turn = 0;         //счетчик ходов
bool whoseturn = true;  //определяет кто ходит
string tab = "                                                    ";    //отступ, что б поле было в центре экрана
Welcome();                //выводит правила игры
PrintGameBoard(gamecage);   //рисует пустое игровое поле
while (!Win(gamecage) && turn < 9) //выполнять пока не выпадет выигрыш и пока сделано менее 9 ходов
{
    Console.WriteLine();
    Console.WriteLine(tab + (whoseturn ? "  Ходят Крестики!" : "   Ходят Нолики!"));  //объявляет чей ход
    string boardA = new string(gamecage);               //запоминает значения клеток до нажатия клавиши
    KeyPressed(Console.ReadKey(), gamecage, tictac);  //ждет нажатия клавиши, если нажата 1..9 изменяет значение на tictac в соответствующей клетке(gamecage)
    string boardZ = new string(gamecage);               //запоминает значения клеток после нажатия клавиши
    PrintGameBoard(gamecage);                         //обновляет игровое поле
    Win(gamecage);                                      //проверяет не выпала ли выигрышная комбинация
    turn = (boardA == boardZ ? turn : ++turn);        //если игровое поле изменилось то увеличивает счетчик на 1
    whoseturn = (turn % 2 == 0);                          //если ход четный возвращает true
    tictac = (whoseturn ? 'X' : 'O');                   //Х - если четный ход, О - если нечетный
};
Console.WriteLine();
Console.Write(tab);
if (Win(gamecage)) Console.WriteLine(whoseturn ? " Нолики победили!!" : "Крестики победили!!"); //если выпал выигрыш то объявляет победителя
else Console.WriteLine("   Боевая ничья!");                                                 //иначе ничья
Console.WriteLine();

