using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTranslator.Analysis.Errors;

namespace CTranslator.Analysis
{
    /// <summary>
    /// Тип токена
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// int
        /// </summary>
        INT,
        /// <summary>
        /// long
        /// </summary>
        LONG,
        /// <summary>
        /// bool
        /// </summary>
        BOOL,
        /// <summary>
        /// main
        /// </summary>
        MAIN,
        /// <summary>
        /// while
        /// </summary>
        WHILE,
        /// <summary>
        /// (
        /// </summary>
        LEFTBRACKET,
        /// <summary>
        /// )
        /// </summary>
        RIGHTBRACKET,
        /// <summary>
        /// {
        /// </summary>
        LEFTFIGURE,
        /// <summary>
        /// }
        /// </summary>
        RIGHTFIGURE,
        /// <summary>
        /// =
        /// </summary>
        ASSIGN,
        /// <summary>
        /// +
        /// </summary>
        PLUS,
        /// <summary>
        /// -
        /// </summary>
        MINUS,
        /// <summary>
        /// *
        /// </summary>
        MUL,
        /// <summary>
        /// /
        /// </summary>
        DIV,
        /// <summary>
        /// <
        /// </summary>
        LESS,
        /// <summary>
        /// <=
        /// </summary>
        LESS_OR_EQUAL,
        /// <summary>
        /// >
        /// </summary>
        MORE,
        /// <summary>
        /// >=
        /// </summary>
        MORE_OR_EQUAL,
        /// <summary>
        /// ==
        /// </summary>
        EQUAL,
        /// <summary>
        /// !=
        /// </summary>
        NOT_EQUAL,
        /// <summary>
        /// ,
        /// </summary>
        COMMA,
        /// <summary>
        /// :
        /// </summary>
        COLON,
        /// <summary>
        /// ;
        /// </summary>
        SEMICOLON,
        /// <summary>
        /// Литерал
        /// </summary>
        LITERAL,
        /// <summary>
        /// Идентификатор
        /// </summary>
        IDENTIFIER,
        /// <summary>
        /// Разделитель
        /// </summary>
        DELIMITER,
        /// <summary>
        /// Неопределено
        /// </summary>
        UNDEFINED
    }

    /// <summary>
    /// Токен
    /// </summary>
    public struct Token
    {
        /// <summary>
        /// Тип токена
        /// </summary>
        public TokenType Type;

        /// <summary>
        /// Уточненный тип лексемы
        /// </summary>
        public TokenType LexemType;

        /// <summary>
        /// Значение токена
        /// </summary>
        public string Value;

        /// <summary>
        /// Создает токен с заданным типом и значением
        /// </summary>
        /// <param name="type">Тип токена</param>
        /// <param name="value">Значение токена</param>
        public Token(TokenType type, string value)
        {
            Type = type;
            LexemType = type;
            Value = value;
        }
    }

    /// <summary>
    /// Лексический анализатор (сканер)
    /// </summary>
    public static class Scanner
    {
        /// <summary>
        /// Исходный код программы
        /// </summary>
        static string Code = "";

        /// <summary>
        /// Буфер для считывания лексемы
        /// </summary>
        static string Buffer = "";

        /// <summary>
        /// Индекс текущго символа
        /// </summary>
        static int Index;

        /// <summary>
        /// Список ограничителей
        /// </summary>
        static TokenType[] CommonDelimtters = new TokenType[]
        {
            TokenType.LEFTBRACKET, TokenType.RIGHTBRACKET, TokenType.LEFTFIGURE, TokenType.RIGHTFIGURE, TokenType.ASSIGN,
            TokenType.LESS, TokenType.LESS_OR_EQUAL, TokenType.MORE, TokenType.MORE_OR_EQUAL, TokenType.EQUAL, TokenType.NOT_EQUAL,
            TokenType.PLUS, TokenType.MINUS, TokenType.MUL, TokenType.DIV, TokenType.COMMA, TokenType.SEMICOLON
        };

        /// <summary>
        /// Список специальных слов языка
        /// </summary>
        public static Dictionary<string, TokenType> SpecialWords = new Dictionary<string, TokenType>()
        {
            {"int", TokenType.INT},
            {"long", TokenType.LONG},
            {"bool", TokenType.BOOL},
            {"main", TokenType.MAIN},
            {"while", TokenType.WHILE}
        };

        /// <summary>
        /// Список символов-разделителей
        /// </summary>
        static Dictionary<string, TokenType> SpecialSymbols = new Dictionary<string, TokenType>()
        {
            {",", TokenType.COMMA},
            {":", TokenType.COLON},
            {";", TokenType.SEMICOLON},
            {"(", TokenType.LEFTBRACKET},
            {")", TokenType.RIGHTBRACKET},
            {"=", TokenType.ASSIGN },
            {"+", TokenType.PLUS},
            {"-", TokenType.MINUS},
            {"*", TokenType.MUL},
            {"/", TokenType.DIV},
            {"{", TokenType.LEFTFIGURE },
            {"}", TokenType.RIGHTFIGURE },
            {"<", TokenType.LESS},
            {"<=", TokenType.LESS_OR_EQUAL },
            {">", TokenType.MORE },
            {">=", TokenType.MORE_OR_EQUAL },
            {"==", TokenType.EQUAL },
            {"!=", TokenType.NOT_EQUAL },
        };

        /// <summary>
        /// Сформированный список лексем
        /// </summary>
        public static List<Token> Tokens = new List<Token>();

        /// <summary>
        /// Список литералов
        /// </summary>
        public static List<string> Literals = new List<string>();

        /// <summary>
        /// Список идентификаторов
        /// </summary>
        public static List<string> Identifiers = new List<string>();

        /// <summary>
        /// Список разделителей
        /// </summary>
        public static List<string> Delimiters = new List<string>();

        /// <summary>
        /// Проверяет является ли лексема разделителем
        /// </summary>
        /// <param name="token">Лексема для проверки</param>
        /// <returns>Возвращает true если лексема является разделителем и false в противном случае</returns>
        static bool IsDelimiter(Token token)
        {
            return CommonDelimtters.Contains(token.Type);
        }

        /// <summary>
        /// Проверяет является ли лексема ключевым словом
        /// </summary>
        /// <param name="word">Лексема для проверки</param>
        /// <returns>Возвращает true если лексема является ключевым словом и false в противном случае</returns>
        static bool IsSpecialWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;
            return SpecialWords.ContainsKey(word);
        }

        /// <summary>
        /// Проверяет является ли лексема символом-разделителем
        /// </summary>
        /// <param name="ch">Лексема для проверки</param>
        /// <returns>Возвращает true если лексема является символом-разделителем и false в противном случае</returns>
        static bool IsSpecialSymbol(string ch)
        {
            return SpecialSymbols.ContainsKey(ch);
        }

        /// <summary>
        /// Очищает входной буфер
        /// </summary>
        static void Clear()
        {
            Buffer = string.Empty;
        }

        /// <summary>
        /// Добавляет текущий символ к буферу
        /// </summary>
        static void Add()
        {
            Buffer += Code[Index];
        }

        /// <summary>
        /// Выполняет переход к следующему символу входного потока
        /// </summary>
        static void Next()
        {
            Index++;
        }

        /// <summary>
        /// Добавляет текущее содержимое буфера в выходной поток как лексему с заданым типом
        /// </summary>
        /// <param name="type">Тип текущей лексемы</param>
        static void Out(TokenType type)
        {
            Token token = new Token(type, Buffer);
            Tokens.Add(token);
        }

        /// <summary>
        /// Заполняет таблицу разделителей
        /// </summary>
        static void FillDelimitersTable()
        {
            Delimiters.Clear();
            for (int i = 0; i < SpecialSymbols.Keys.Count; i++)
                Delimiters.Add(SpecialSymbols.Keys.ToList()[i].ToString());
        }

        /// <summary>
        /// Выполняет лексический анализ кода программы
        /// </summary>
        /// <param name="text">Код программы</param>
        /// <returns>Возвращает список токенов</returns>
        /// <exception cref="TooLongIdentifierError"></exception>
        /// <exception cref="UnknownSymbolError"></exception>
        public static List<Token> Analyze(string text)
        {
            Code = text;
            Index = 0;
            int len = Code.Length;
            Tokens.Clear();
            Literals.Clear();
            Identifiers.Clear();
            FillDelimitersTable();
            while (Index != len)
            {
                if (char.IsDigit(Code[Index])) // цифра - собираем литерал
                {
                    bool isDigit = true;
                    while (isDigit)
                    {
                        Add();
                        Next();
                        if (!char.IsDigit(Code[Index]))
                            isDigit = false;
                    }
                    Out(TokenType.LITERAL);
                    Clear();
                }
                else if (char.IsLetter(Code[Index])) // буква - собираем идентификатор 
                {
                    bool isLetter = true;
                    while (isLetter)
                    {
                        Add();
                        Next();
                        if (!char.IsLetterOrDigit(Code[Index]))
                            isLetter = false;
                    }
                    if (Buffer.Length > 8) // если длина идентификатора больше 8 символов - ошибка
                        throw new TooLongIdentifierError(Buffer, Index);
                    Out(TokenType.IDENTIFIER);
                    Clear();
                }
                else if (IsSpecialSymbol(Code[Index].ToString())) // разделитель
                {
                    Add();
                    Next();
                    if ((Buffer == "<" || Buffer == ">" || Buffer == "=") && Code[Index] == '=')
                    {
                        Add();
                        Next();
                    }
                    else
                    { 
                        if (Buffer == "!")
                        {
                            if (Code[Index] == '=')
                            {
                                Add();  
                                Next();
                            }
                            else
                                throw new UnknownSymbolError(Code[Index].ToString(), Index);
                        }
                    }
                    Out(TokenType.DELIMITER);
                    Clear();
                }
                else if (Code[Index] == ' ' || Code[Index] == '\n') // пробельные символы
                    Next();
                else
                    throw new UnknownSymbolError(Code[Index].ToString(), Index); // недопустимый символ
            }
            for (int i = 0; i < Tokens.Count; i++)
            {
                var token = Tokens[i];
                switch (token.Type)
                {
                    case TokenType.LITERAL:
                        token.LexemType = TokenType.LITERAL;
                        if (Literals.IndexOf(token.Value) == -1)
                        {
                            Literals.Add(token.Value);
                        }
                        break;

                   case TokenType.IDENTIFIER:
                        if (IsSpecialWord(token.Value))
                        {
                            token.LexemType = SpecialWords[token.Value];
                        }
                        else
                        {
                            token.LexemType = TokenType.IDENTIFIER;
                            if (Identifiers.IndexOf(token.Value) == -1)
                            {
                                Identifiers.Add(token.Value);
                            }
                        }
                        break;

                    case TokenType.DELIMITER:
                        token.LexemType = SpecialSymbols[token.Value];
                        break;
                }
                Tokens[i] = token;
            }
            return Tokens;
        }
    }

}