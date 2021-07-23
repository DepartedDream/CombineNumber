using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombineNumber
{
    public partial class GameForm : Form
    {
        private List<Label> calculateNumLabelList;
        private List<Button> operationBtnList;
        private List<Button> signBtnList;
        private Thread runGameThread;
        private Thread runPlayerTurnThread;
        private Thread endGameThread;

        public GameForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            calculateNumLabelList = new List<Label>() { num1Label, num2Label };
            operationBtnList = new List<Button>()
            {
                plusBtn,sevenBtn,eightBtn,nineBtn,
                minusBtn,fourBtn,fiveBtn,sixBtn,
                okBtn,oneBtn,twoBtn,threeBtn
            };
            signBtnList=new List<Button>() {plusBtn,minusBtn};
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.CurrentFormType = null;
            EndGame(false);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Program.CurrentFormType = typeof(MenuForm);
            EndGame(false);
            this.Dispose();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            EndGame(false);
            RunGame();
        }

        private void numBtn_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.SkyBlue)
            {
                foreach (Label numLabel in calculateNumLabelList)
                {
                    if (numLabel.Text == ((Button)sender).Text)
                    {
                        numLabel.Text = "";
                    }
                }
                ((Button)sender).BackColor = Color.White;
            }
            else if (((Button)sender).BackColor == Color.White)
            {
                foreach (Label numLabel in calculateNumLabelList)
                {
                    if (numLabel.Text == "")
                    {
                        numLabel.Text = ((Button)sender).Text;
                        ((Button)sender).BackColor = Color.SkyBlue;
                        break;
                    }
                }
            }
        }

        private void signBtn_Click(object sender, EventArgs e)
        {
            Button otherSignBtn = signBtnList.Find((Button button)=>!((Button)sender).Equals(button));
            otherSignBtn.BackColor = Color.White;
            ((Button)sender).BackColor = Color.SkyBlue;
            signLabel.Text = ((Button)sender).Text[0].ToString();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (SignOperation())
            {
                scoreLabel.Text = (Int32.Parse(scoreLabel.Text) + 10 * (int)Program.CurrentGameDifficulty).ToString();
                SkipPlayerTurn();
            }
        }

        private void RunGame()
        {
            resultNumLabel.Text = "";
            signLabel.Text = "";
            num1Label.Text = "";
            num2Label.Text = "";
            tipLabel.Text = "";
            countDownLabel.Text = "0";
            scoreLabel.Text = "0";
            runGameThread = new Thread(() =>
            {
                while (true)
                {
                    int resultNum = 0;
                    while (resultNum == 0)
                    {
                        resultNum = new Random().Next(-8, 18);
                    }
                    resultNumLabel.Text = resultNum.ToString();
                    RunPlayerTurn();
                }
            });
            runGameThread.Start();
        }

        private void RunPlayerTurn() 
        {
            runPlayerTurnThread = new Thread(()=> 
            {
                foreach (Button button in operationBtnList)
                {
                    button.BackColor = Color.White;
                }
                num1Label.Text = "";
                num2Label.Text = "";
                signLabel.Text = "";
                for (int countTime = 10 - (int)Program.CurrentGameDifficulty * 2 ; countTime >= 0; countTime--)
                {
                    countDownLabel.Text = countTime.ToString();
                    Refresh();
                    Thread.Sleep(1000);
                }
                EndGame(true);
            });
            runPlayerTurnThread.Start();
            runPlayerTurnThread.Join();
        }

        private void SkipPlayerTurn()
        {
            runPlayerTurnThread.Abort();
        }

        private void EndGame(bool isRecord)
        {
            endGameThread = new Thread(() =>
            {
                if (runGameThread != null) runGameThread.Abort();
                if (runPlayerTurnThread != null) runPlayerTurnThread.Abort();
                if (isRecord) 
                {
                    tipLabel.Text = "GameOver";
                    Program.Top10PlayerList.Add(new Player(Program.CurrentPlayerName, Int32.Parse(scoreLabel.Text)));
                    Program.Top10PlayerList.Sort((Player player1, Player player2) =>
                    {
                        return player2.Score.CompareTo(player1.Score);
                    });
                    Program.Top10PlayerList.RemoveAt(Program.Top10PlayerList.Count - 1);
                }
            });
            endGameThread.Start();
            endGameThread.Join();
        }

        private bool SignOperation()
        {
            if (num1Label.Text != "" && num2Label.Text != "" && signLabel.Text != "")
            {
                int resultNum = Int32.Parse(resultNumLabel.Text);
                int num1 = Int32.Parse(num1Label.Text);
                int num2 = Int32.Parse(num2Label.Text);
                if (signLabel.Text == "+")
                {
                    return num1 + num2 == resultNum;
                }
                else if (signLabel.Text == "-")
                {
                    return num1 - num2 == resultNum;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
