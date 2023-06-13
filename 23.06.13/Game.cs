using System;
using System.Xml.Serialization;

namespace _23._06._13
{
    internal class Game
    {
        Random random = new Random();
        public string[,] array = new string[15, 15]; //배열의선언
        int size; //입력받는 배열의 크기
        int playerX; //플레이어 가로좌표
        int playerY; //플레이어 세로좌표
        int wallX;   //벽의 가로좌표
        int wallY;   //벽의 세로좌표   
        int coinX;  //코인의 가로좌표
        int coinY;  //코인의 세로좌표
        int score;  //점수
        int movingCount = 0; //무빙카운트
        int coinExist;  //코인의 존재유무
        int wallCount = 0;  //벽의 갯수
        public void InputSize()  //사이즈 입력받는 함수
        {
            Console.WriteLine("5~15사이의 숫자를 입력해주십시오");
            size = int.Parse(Console.ReadLine());
            while ((size < 5) || (size > 15))
            {
                Console.WriteLine("틀렸습니다 올바른 숫자를 입력해주십시오");
                size = int.Parse(Console.ReadLine());
            }
        }
        public void Initailize() //초기화
        {

            for (int height = 0; height < 15; height++)
            {
                for (int width = 0; width < 15; width++)
                {
                    array[height, width] = "□";
                }
            }
            Console.WriteLine("player의 x좌표와 y좌표를 입력하세요");
            playerX = int.Parse(Console.ReadLine());
            playerY = int.Parse(Console.ReadLine());
            array[playerX, playerY] = "▣";
        }
        public void PrintMap()  //맵 출력
        {
            for (int height = 0; height < size + 2; height++)
            { Console.Write("ㅡ"); }
            Console.WriteLine();
            for (int height = 0; height < size; height++)
            {
                Console.Write("ㅣ");
                for (int width = 0; width < size; width++)
                {
                    Console.Write(array[height, width]);
                }
                Console.Write("ㅣ");
                Console.WriteLine();
            }
            for (int height = 0; height < size + 2; height++)
            { Console.Write("ㅡ"); }
            Console.WriteLine();
            Console.WriteLine("현재 점수는 {0}입니다.", score);
        }
        public void Moving()  //움직이는 함수
        {
            string input;
            input = Console.ReadLine();
            array[playerX, playerY] = "□";  //플레이어의 위치를 *로 만듬
            switch (input) //input의 결과에  따라 플레이어의 x와 y좌표를 옮김
            {
                case "a": //a를 받았을때
                    if (playerY > 0) //배열밖으로 나가지않도록하는 조건문
                    {
                        if (array[playerX, playerY - 1] == "■") // 현재플레이어 왼쪽블럭이 벽이라면
                        {
                            if (playerY - 2 >= 0) // 현재플레이어 왼쪽왼쪽이 0보다 크다면 벽을 밀었을때 밖으로 나가지 않게해주는 조건문
                            {
                                if (array[playerX, playerY - 2] == "◈") // 왼쪽의왼쪽이 코인일 경우 
                                {
                                    array[playerX, playerY - 2] = array[playerX, playerY - 1];
                                    array[playerX, playerY - 1] = "□";
                                    coinExist = 0;
                                }
                                else if (array[playerX, playerY - 2] == "■") // 왼쪽,왼쪽이 벽벽일경우 
                                {
                                    //아무것도 안해서움직이지않음
                                }
                                else //나머지의 경우
                                {
                                    array[playerX, playerY - 2] = array[playerX, playerY - 1];
                                    array[playerX, playerY - 1] = "□";
                                }
                            }
                        }
                        else
                        {
                            playerY--;
                        }
                    }
                    break;
                case "w":
                    if (playerX > 0)
                    {
                        if (array[playerX-1, playerY] == "■")
                        {
                            if (playerX - 2 >= 0)
                            {
                                if (array[playerX - 2, playerY] == "◈")
                                {
                                    array[playerX - 2, playerY] = array[playerX - 1, playerY];
                                    array[playerX - 1, playerY] = "□";
                                    coinExist = 0;
                                }
                                else if (array[playerX-2, playerY] == "■")
                                {

                                }
                                else
                                {
                                    array[playerX - 2, playerY] = array[playerX - 1, playerY];
                                    array[playerX - 1, playerY] = "□";
                                }
                            }
                        }
                        else
                        {
                            playerX--;
                        }
                    }
                    break;
                case "s":
                    if (playerX < size - 1)
                    {
                        if (array[playerX + 1, playerY] == "■")
                        {
                            if (playerX + 2 <= size - 1)
                            {
                                if (array[playerX + 2, playerY] == "◈")
                                {
                                    array[playerX + 2, playerY] = array[playerX + 1, playerY];
                                    array[playerX + 1, playerY] = "□";
                                    coinExist = 0;
                                }
                                else if (array[playerX+2, playerY] == "■")
                                {

                                }
                                else
                                {
                                    array[playerX + 2, playerY] = array[playerX + 1, playerY];
                                    array[playerX + 1, playerY] = "□";
                                }
                            }
                        }
                        else
                        {
                            playerX++;
                        }
                    }
                    break;
                case "d":
                    if (playerY < size - 1)
                    {
                        if (array[playerX, playerY + 1] == "■")
                        {
                            if (playerY + 2 <= size - 1)
                            {
                                if (array[playerX, playerY + 2] == "◈")
                                {
                                    array[playerX , playerY+2] = array[playerX , playerY+1];
                                    array[playerX , playerY+1] = "□";
                                    coinExist = 0;
                                }
                                else if (array[playerX, playerY + 2] == "■")
                                {

                                }
                                else
                                {
                                    array[playerX, playerY + 2] = array[playerX, playerY + 1];
                                    array[playerX, playerY + 1] = "□";
                                }
                            }
                        }
                        else
                        {
                            playerY++;
                        }
                    }
                    break;
            }
            array[playerX, playerY] = "▣"; // 옮긴 player의 좌표에 '0'을 넣음.
            movingCount += 1;
        }
        public void CreateCoin()  // 코인만들기
        {
            if (((movingCount - 1) % 3 == 0) && (coinExist == 0))
            {
                coinX = random.Next(0, size);
                coinY = random.Next(0, size);
                array[coinX, coinY] = "◈";
                coinExist += 1;
            }
        }
        public void Check() //코인유무체크
        {
            
            if ((playerX == coinX) && (playerY == coinY))
            {
                score += 1;
                coinExist = 0;
            }
        }
        public void CreateWalls() // 벽갯수 받아서 만들기
        {
            Console.WriteLine("몇개의 벽을생성할지입력해주십시오");
            wallCount = int.Parse(Console.ReadLine());
            for (int i = 0; i <= wallCount; i++)
            {
                CreateWall();
            }
        }
        public void CreateWall() // 벽만들기
        {
            wallX = random.Next(0, size);
            wallY = random.Next(0, size);

            array[wallX, wallY] = "■";
        }
        public void GamePlay() // 게임플레이
        { //사이즈 입력받기-> 초기화-> 벽입력받아서 만들기-> [ 출력-> 코인만들기-> 움직이기-> 코인유무체크-> 클리어 ]
            InputSize();
            Initailize();
            CreateWalls();
            while (true)
            {
                PrintMap();
                CreateCoin();
                Moving();
                Check();
                Console.Clear();
            }
        }
    }
}
