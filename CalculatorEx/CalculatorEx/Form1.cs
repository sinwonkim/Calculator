using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorEx
{
    public enum Operators { Add,Sub} //열거형 

    public partial class Form1 : Form
    {
        public int Result = 0; // 전역변수로 담을 값 하나 변수 설정
        public bool NewNum = true; // 계산기에서 번호 새로 입력 받았을때 구분 지을려고 사용 변수 
        public Operators Opt = Operators.Add;

        public Form1()
        {
            InitializeComponent();
        }

      public int Add(int number1, int number2)
        {
            int sum = number1 + number2;
            return sum;
        }

        public float Add(float number1, float number2)
        {
            float sum = number1 + number2;
            return sum;
        }

        public int sub(int number1,int number2)
        {
            int sub = number1 - number2;
            return sub;
        }

        private void NumButton1_Click(object sender, EventArgs e)
        {
            Button numButton = (Button)sender; // sender object니깐 버튼 타입으로 변경해서 사용하려고 
            SetNum(numButton.Text);
        }

        // 번호 눌렀을떄 번호 저장후 스크린에 표시되는 용도 메소드
        public void SetNum(String num)
        {
            if (NewNum)
            {
                NumScreen.Text = num;
                NewNum = false;
            }
            else if (NumScreen.Text == "0")
            {
                NumScreen.Text = num;
            }
            else
            {
                NumScreen.Text = NumScreen.Text + num;
            }
        }

        private void NumPlus_Click(object sender, EventArgs e)
        {   
            if(NewNum == false) // 이거 안하면 동일 연산자 눌렀을때 값 이상하게 잡히지 
            {

            
            int num = int.Parse(NumScreen.Text); // NumScreen텍스트 스트링 형태라 인트형태로 파싱
            if (Opt == Operators.Add)
                Result = Result + num;  // 리절트 경우 맨위 전역변수로 0 으로 셋팅 해놨음 
            else if (Opt == Operators.Sub)
                Result = Result - num;

            NumScreen.Text = Result.ToString(); // NumScreen 경우 스트링 형태니깐  리절트 인트형태니깐
                                                // 다시 스크린에 표시해줄려면 스트링 형태로 바꿔줘야지
            NewNum = true; // 이제 그다음 새번호 받을려면 구분 시켜야지 
            }

            //연산자일경우 다음 연산자 작업 하기위해 등호를 저장 용도로 하기위한 설정 
            Button optButton = (Button)sender;
            if (optButton.Text == "+")
                Opt = Operators.Add;
            else if (optButton.Text == "-")
                Opt = Operators.Sub;
        }

        // 리셋버튼
        private void Reset_Click(object sender, EventArgs e)
        {
            Result = 0;
            NewNum = true;
            Opt = Operators.Add;

            NumScreen.Text = "0";
        }
    }
}
