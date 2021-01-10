using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsStudy.DBConnect;

namespace WindowsFormsStudy
{
    public partial class S004_batchLog : Form
    {
        // 定义一个变量保存s001_Touroku
        private S001_Touroku s001_Touroku = null;

        public S004_batchLog(S001_Touroku touroku)
        {
            InitializeComponent();
            s001_Touroku = touroku;
        }

        private void S004_batchLog_Load(object sender, EventArgs e)
        {
            // 查询数据履历中所有的数据,并显示在页面上
            string selectSql = $@"
                SELECT
                  [name]
                  , [jikkouYMD]
                  , [jikkouResult]
                  , [message]
                  , [kousinYMD]
                  , [kosinCd] 
                FROM
                  [dbo].[tm_batch] 
                WHERE
                  [kosinCd] = 'jia'
                ORDER BY
                  [id]
            ";

            DBHandler dBHandler = new DBHandler();
            DataSet dataSet = dBHandler.executeQuery(selectSql);

            // 把查询到的数据保存到表格控件中
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        // 当关闭当前窗口的时候，把S001_Touroku给显示出来
        private void S004_batchLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.s001_Touroku.Visible = true;
        }
    }
}
