using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace toss_coin_app
{
    public partial class AppForm : Form
    {
        private static Random rand;

        public AppForm()
        {
            rand = new Random();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var totalText = textBox1.Text.Trim();
            var unitText = textBox2.Text.Trim();

            if (!Int64.TryParse(totalText, out Int64 total))
            {
                MessageBox.Show("请输入有效的数值！");
                return;
            }
            if (!Int64.TryParse(unitText, out Int64 unit))
            {
                MessageBox.Show("请输入有效的数值！");
                return;
            }

            var dict = new Dictionary<Int64, Int64>();
            for (int i = 0; i <= unit; i++)
            {
                dict.Add(i, 0);
            }

            for (int i = 0; i < total; i++)
            {
                dict[GetFrontCount(unit)]++;
            }

            Int64 sum = total * unit;

            Int64 sumFront = dict.Where(x => x.Value != 0).Sum(x => x.Value * x.Key);
            double frontRate = sumFront / (double)sum;

            Int64 sumBack = sum - sumFront;
            double backRate = sumBack / (double)sum;

            label3.Text = $"正面：{sumFront}    比例：{frontRate:N4}\n反面：{sumBack}    比例：{backRate:N4}";

            var output = new StringBuilder();
            var len = GetNumberLength(unit);
            var _fmt = "{0," + len + "} |";
            for (var i = 0; i <= unit; i++)
            {
                var head = string.Format(_fmt, i);
                output.Append(head);
                var pos = (int)((dict[i]) / (double)total * 80);
                //output.Append("|");
                for (var j = 0; j < pos - 1; j++)
                    output.Append("▮");
                output.AppendFormat(" {0}\n", dict[i]);

                //if (dict[i] != 0)
                //    output.AppendFormat(" {0}", dict[i]);
                //output.Append("\n");
            }
            label4.Text = output.ToString();
        }

        private int GetNumberLength(Int64 number)
        {
            if (number >= 0 && number < 10)
                return 1;
            else
                return 1 + GetNumberLength(number/10);
        }

        private Int64 GetFrontCount(Int64 n)
        {
            // 1 正面
            // 0 反面
            Int64 sum_1 = 0; // 正面总次数
            for (int i = 0; i < n; i++)
            {
                sum_1 += rand.Next(2); // 1 or 0
            }
            //Console.WriteLine(sum_1);
            return sum_1;
        }

    }

}
