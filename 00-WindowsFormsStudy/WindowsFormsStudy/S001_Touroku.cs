using System;
using System.Windows.Forms;
// 导包,导入我们自定义的数据库连接类工具所在的命名空间
using WindowsFormsStudy.DBConnect;

namespace WindowsFormsStudy
{
    public partial class S001_Touroku : Form
    {
        string torihikiCdStr = string.Empty;

        public S001_Touroku()
        {
            // 窗口关闭的时候,窗口监听函数触发定义好的函数
            // this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.S001_Touroku_FormClosing);
            InitializeComponent();

            // 当取引先コード光标失去焦点的时候,触发TorihikiCdCheck函数进行校验
            this.torihikiCd.LostFocus += new EventHandler(TorihikiCdCheck);
        }

        /// <summary>
        /// 当取引先コード光标失去焦点的时候,进行校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TorihikiCdCheck(object sender, EventArgs e)
        {
            torihikiCdStr = torihikiCd.Text;
            // 取引先コードcheck
            if (string.IsNullOrWhiteSpace(torihikiCdStr))
            {
                MessageBox.Show("取引先コード不能为空!");

                // 当被校验之后,清空文本框输入的内容,并且将焦点放置到当前文本输入框之内.
                // 也就意味着直到输入的输入符合校验规则才能离开当前输入框
                this.torihikiCd.Text = string.Empty;
                // 将焦点放置到当前文本框之内
                this.torihikiCd.Focus();
            }
            else if (torihikiCdStr.Length > 10)
            {
                MessageBox.Show("取引先コード最多为10位!");
                this.torihikiCd.Text = "";
                this.torihikiCd.Focus();
            }
        }

        /// <summary>
        /// 点击登录按钮实现添加数据到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addData_Click(object sender, EventArgs e)
        {
            // 从画面获取文本框输入的内容
            
            string toriNmStr = toriNm.Text;
            string torirkNmStr = torirkNm.Text;
            string torijyusyoStr = torijyusyo.Text;
            string yubinStr = yubin.Text;
            string telNoStr = telNo.Text;
            string faxNoStr = faxNo.Text;
            string tantoNmStr = tantoNm.Text;

            // 取引先名称check
            if (string.IsNullOrWhiteSpace(toriNmStr))
            {
                MessageBox.Show("取引先名称不能为空!");
                return;
            }
            else if (toriNmStr.Length > 80)
            {
                MessageBox.Show("取引先名称最多为80位!");
                return;
            }

            // 取引先略称check
            if (string.IsNullOrWhiteSpace(torirkNmStr))
            {
                MessageBox.Show("取引先略称不能为空!");
                return;
            }
            else if (torirkNmStr.Length > 40)
            {
                MessageBox.Show("取引先略称最多为40位!");
                return;
            }

            // 取引先住所check
            if (string.IsNullOrWhiteSpace(torijyusyoStr))
            {
                MessageBox.Show("取引先住所不能为空!");
                return;
            }
            else if (torijyusyoStr.Length > 80)
            {
                MessageBox.Show("取引先住所最多为80位!");
                return;
            }

            // 郵便番号check
            if (string.IsNullOrWhiteSpace(yubinStr))
            {
                MessageBox.Show("郵便番号不能为空!");
                return;
            }
            else if (yubinStr.Length > 8)
            {
                MessageBox.Show("郵便番号最多为8位!");
                return;
            }

            // 電話番号check
            if (string.IsNullOrWhiteSpace(telNoStr))
            {
                MessageBox.Show("電話番号不能为空!");
                return;
            }
            else if (telNoStr.Length > 16)
            {
                MessageBox.Show("電話番号最多为16位!");
                return;
            }

            // FAX check
            if (string.IsNullOrWhiteSpace(faxNoStr))
            {
                MessageBox.Show("FAX不能为空!");
                return;
            }
            else if (faxNoStr.Length > 16)
            {
                MessageBox.Show("FAX最多为16位!");
                return;
            }

            // 担当者名check
            if (string.IsNullOrWhiteSpace(tantoNmStr))
            {
                MessageBox.Show("担当者名不能为空!");
                return;
            }
            else if (tantoNmStr.Length > 10)
            {
                MessageBox.Show("担当者名最多为10位!");
                return;
            }

            // 准备登录用的sql
            string sql = $@"
                INSERT 
                INTO [dbo].[batch_csvDataStart] (
                  [torihikiCd]
                  , [toriNm]
                  , [torirkNm]
                  , [torijyusyo]
                  , [yubin]
                  , [telNo]
                  , [faxNo]
                  , [tantoNm]
                  , [shoriFlg]
                  , [kousinYMD]
                  , [kosinCd]
                ) 
                VALUES ( 
                  '{torihikiCdStr}'
                  , '{toriNmStr}'
                  , '{torirkNmStr}'
                  , '{torijyusyoStr}'
                  , '{yubinStr}'
                  , '{telNoStr}'
                  , '{faxNoStr}'
                  , '{telNoStr}'
                  , '0'
                  , '{DateTime.Now}'
                  , '{tantoNmStr}'
                ) 
            ";

            DBHandler dbHandler = new DBHandler();
            int result = dbHandler.executeNonQuery(sql);

            // 关闭当前窗口
            this.Hide();

            // 插入完成之后，打开数据一览画面
            S002_dateSearch searchForm = new S002_dateSearch(this);
            //显示一览窗口
            searchForm.Show();

        }

        /// <summary>
        /// 显示データ一覧窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void データ一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            S002_dateSearch searchForm = new S002_dateSearch(this);
            searchForm.Show();
        }

        /// <summary>
        /// 显示バーチ処理窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void バーチ処理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            S003_batch batch = new S003_batch(this);
            batch.Show();
        }

        /// <summary>
        /// 显示バーチ处理履历窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void バーチ处理履历ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            S004_batchLog batchLog = new S004_batchLog(this);
            batchLog.Show();
        }

        /// <summary>
        /// 当点击关闭按钮的时候,触发下面的函数,弹出消息提示框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void S001_Touroku_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出吗?", "退出确认", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                // 清除所有线程,退出程序
                Environment.Exit(0);
            } 
            else
            {
                // 用户点击取消按钮,就不退出了
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 当页面加载完毕之后首先就执行这个函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void S001_Touroku_Load(object sender, EventArgs e)
        {
            // 从Resources.resx文件中获取提前放置好的值
            string name = Properties.Resources.testName;
            Console.WriteLine($"提前设置好的name值为:{name}");

            // 从Settings.settings中获取提前设置好的值
            string user = Properties.Settings.Default.User;
            string password = Properties.Settings.Default.Password;
            Console.WriteLine($"提前设置好的user值为:{user}");
            Console.WriteLine($"提前设置好的password值为:{password}");
        }
    }
}
