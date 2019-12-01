using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnterOfGame
{
    public partial class Form1 : Form
    {
        int x = 0; //フォームの横幅
        int y = 0; //フォームの縦幅
        int nowTop = 0; //上座標の差
        int nowLeft = 0; //左座標の差
        String direction = "左上"; //ボールの動く向き


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nowTop = ball.Top; //現在のボールの上辺の位置を取得
            nowLeft = ball.Left; //現在のボールの左辺の位置を取得

            x = this.Width; //フォームの横幅を取得
            y = this.Height; //フォームの高さを取得





        }

        private void BtnStart_Click(object sender, EventArgs e) //スタートボタンクリック時の動作
        {
            timer1.Enabled = true; //タイマー起動
            BtnStart.Visible = false; //ボタンを見えないようにする
        }

        private void timer1_Tick(object sender, EventArgs e) //タイマーが起動したら
        {
            int zahyouX = 7; //ずらしたいx座標の数値
            int zahyouY = 3; //ずらしたいy座標の数値

            if (ball.Left >= zahyouX && ball.Top >= zahyouY && direction == "左上")
            {
                ball.Top -= zahyouY; //ボールの左辺の座標をzahyou分ずらす　上方向へ
                ball.Left -= zahyouX; //ボールの左辺の座標をzahyou分ずらす　左方向へ
            }
            else if (ball.Left >= zahyouX && ball.Bottom <= y - zahyouY && direction == "左下")
            {
                ball.Top += zahyouY; //ボールの上辺の座標をzahyou分ずらす　下方向へ
                ball.Left -= zahyouX; //ボールの左辺の座標をzahyou分ずらす　左方向へ
            }
            else if (ball.Right <= x -zahyouX && ball.Bottom <= y - zahyouY && direction == "右下")
            {
                ball.Top += zahyouY; //ボールの上辺の座標をzahyou分ずらす　下方向へ
                ball.Left += zahyouX; //ボールの左辺の座標をzahyou分ずらす　右方向へ
            }
            else if (ball.Right <= x - zahyouX && ball.Top >= zahyouY && direction == "右上")
            {
                ball.Top -= zahyouY; //ボールの上辺の座標をzahyou分ずらす　上方向へ
                ball.Left += zahyouX; //ボールの左辺の座標をzahyou分ずらす　右方向へ
            }
            else if (0 < ball.Top && ball.Top < zahyouY) //もしボールの上辺の座標がForm上辺に達しそうになったら
            {
                ball.Top = 0; //ボールの上辺をFormの上辺にくっつける
                if (direction == "左上") //ボールが左上に向かっていたら
                {
                    ball.Left -= zahyouX; //ボールの左辺の座標をzahyou分ずらす　左へ
                }
                else if (direction == "右上") //ボールが右上に向かっていたら
                {
                    ball.Left += zahyouX; //ボールの左辺の座標をzahyou分ずらす　右へ
                }
            }
            else if (ball.Top == 0) //ボールがFormの上辺についたら
            {
                if (direction == "左上") //ボールが左上に向かっていたら
                {
                    ball.Top += zahyouY; //ボールの左辺の座標をzahyou分ずらす　下方向へ
                    ball.Left -= zahyouX; //ボールの左辺の座標をzahyou分ずらす　左方向へ
                    if (ball.Left < 0) //ボールがFormの左辺を超える場合
                    {
                        ball.Left = 0; //ボールをFormの左辺にくっつける
                    }
                    direction = "左下";
                }
                else if (direction == "右上") //ボールが右上に向かっていたら
                {
                    ball.Top += zahyouY; //ボールの左辺の座標をzahyou分ずらす　下方向へ
                    ball.Left += zahyouX; //ボールの左辺の座標をzahyou分ずらす　右方向へ
                    if (ball.Right > x) //ボールがFormの右辺を超える場合
                    {
                        ball.Left = x - ball.Size.Width; //ボールの右辺をFormの右辺にくっつける
                    }
                    direction = "右下";
                }
            }
            else if (0 < ball.Left && ball.Left < zahyouX) //もしボールの左辺の座標がForm左辺に達しそうになったら
            {
                ball.Left = 0; //ボールの左辺をFormの左辺にくっつける

                if (direction == "左下") //ボールが左下に向かっていたら
                {
                    ball.Top += zahyouY; //ボールの上辺の座標をzahyou分ずらす　下へ
                }
                else if (direction == "左上") //ボールが左上に向かっていたら
                {
                    ball.Top -= zahyouY; //ボールの上辺の座標をzahyou分ずらす　上へ
                }
            }
            else if (ball.Left == 0) //ボールがFormの左辺についたら
            {
                if (direction == "左下") //ボールが左下に向かっていたら
                {
                    ball.Top += zahyouY; //ボールの上辺の座標をzahyou分ずらす　下方向へ
                    ball.Left += zahyouX; //ボールの左辺の座標をzahyou分ずらす　右方向へ
                    if (ball.Bottom > y) //ボールがFormの底辺を超える場合
                    {
                        ball.Top = y - ball.Size.Height; //ボールの底辺をFormの底辺にくっつける
                    }
                    direction = "右下";
                }
                else if (direction == "左上") //ボールが左上に向かっていたら
                {
                    ball.Top -= zahyouY; //ボールの上辺の座標をzahyou分ずらす　上方向へ
                    ball.Left += zahyouX; //ボールの左辺の座標をzahyou分ずらす　右方向へ
                    if (ball.Top < 0) //ボールがFormの上辺を超える場合
                    {
                        ball.Top = 0; //ボールの上辺をFormの上辺にくっつける
                    }
                    direction = "右上";
                }
            }
            else if (y > ball.Bottom && ball.Bottom > y - zahyouY) //もしボールの底辺の座標がForm底辺に達しそうになったら
            {
                ball.Top = y - ball.Size.Height ; //ボールの底辺をFormの底辺にくっつける

                if (direction == "右下") //ボールが右下に向かっていたら
                {
                    ball.Left += zahyouX; //ボールの左辺の座標をzahyou分ずらす　右へ
                }
                else if (direction == "左下") //ボールが左下に向かっていたら
                {
                    ball.Left -= zahyouX; //ボールの左辺の座標をzahyou分ずらす　左へ
                }
            }
            else if (ball.Bottom == y) //ボールがFormの底辺についたら
            {
                if (direction == "左下" && ball.Left - zahyouX >= 0) //ボールが左下に向かっていたら
                {
                    ball.Top -= zahyouY; //ボールの上辺の座標をzahyou分ずらす　上方向へ
                    ball.Left -= zahyouX; //ボールの左辺の座標をzahyou分ずらす　左方向へ
                    if (ball.Left < 0) //ボールがFormの左辺を超える場合
                    {
                        ball.Left = 0; //ボールをFormの左辺にくっつける
                    }
                    direction = "左上";
                }
                else if (direction == "右下") //ボールが右下に向かっていたら
                {
                    ball.Top -= zahyouY; //ボールの上辺の座標をzahyou分ずらす　上方向へ
                    ball.Left += zahyouX; //ボールの左辺の座標をzahyou分ずらす　右方向へ
                    if (ball.Right > x) //ボールがFormの右辺を超える場合
                    {
                        ball.Left = x - ball.Size.Width; //ボールの右辺をFormの右辺にくっつける
                    }                                                                          
                    direction = "右上";
                }
            }
            else if (x > ball.Right && ball.Right > x - zahyouX) //もしボールの右辺の座標がForm右辺に達しそうになったら
            {
                ball.Left = x - ball.Size.Width; //ボールの右辺をFormの右辺にくっつける

                if (direction == "右上") //ボールが右上に向かっていたら
                {
                    ball.Top -= zahyouY; //ボールの上辺の座標をzahyou分ずらす　上へ
                }
                else if (direction == "右下") //ボールが右下に向かっていたら
                {
                    ball.Top += zahyouY; //ボールの上辺の座標をzahyou分ずらす　下へ
                }
            }
            else if (ball.Right == x) //ボールがFormの右辺についたら
            {
                if (direction == "右上") //ボールが右上に向かっていたら
                {
                    ball.Top -= zahyouY; //ボールの上辺の座標をzahyou分ずらす　上方向へ
                    ball.Left -= zahyouX; //ボールの左辺の座標をzahyou分ずらす　左方向へ
                    if (ball.Top < 0) //ボールがFormの上辺を超える場合
                    {
                        ball.Top = 0; //ボールの上辺をFormの上辺にくっつける
                    }
                    direction = "左上";
                }
                else if (direction == "右下") //ボールが右下に向かっていたら
                {
                    ball.Top += zahyouY; //ボールの上辺の座標をzahyou分ずらす　下方向へ
                    ball.Left -= zahyouX; //ボールの左辺の座標をzahyou分ずらす　左方向へ
                    if (ball.Bottom > y) //ボールがFormの底辺を超える場合
                    {
                        ball.Top = y - ball.Size.Height; //ボールの底辺をFormの底辺にくっつける
                    }
                    direction = "左下";
                }
            }
        }


    }
}
