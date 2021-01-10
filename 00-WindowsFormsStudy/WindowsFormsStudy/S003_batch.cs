using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using WindowsFormsStudy.DBConnect;

namespace WindowsFormsStudy
{
    public partial class S003_batch : Form
    {
        // 定义一个变量保存s001_Touroku
        private S001_Touroku s001_Touroku = null;

        // 本地文件的全路径
        private string path = string.Empty;

        public S003_batch(S001_Touroku touroku)
        {
            InitializeComponent();
            s001_Touroku = touroku;
        }

        private void S003_batch_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 打开文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // 文件打开窗口
            OpenFileDialog dialog = new OpenFileDialog();
            // 是否允许多选
            dialog.Multiselect = false;
            // 窗口title
            dialog.Title = "请选择要处理的文件";
            // 可选择的文件类型
            dialog.Filter = "文本文件(*.csv)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // 获取文件路径
                path = dialog.FileName;

                // 把我们读取到的文件的路径显示在文本输入框中
                fileFullPath.Text = path;
            }
        }

        /// <summary>
        /// Stream读取.csv文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static DataTable OpenCSV(string filePath)
        {
            DataTable dt = new DataTable();
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
            // 记录每次读取的一行记录
            string strLine = "";
            // 记录每行记录中的各字段内容
            string[] aryLine;
            // 标示列数
            int columnCount = 0;
            // 标示是否是读取的第一行
            bool IsFirst = true;
          
            // 逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                aryLine = strLine.Split(',');
               
                if (IsFirst == true)
                {
                    IsFirst = false;
                    columnCount = aryLine.Length;
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(aryLine[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }

            sr.Close();
            fs.Close();
            return dt;
        }

        // 当关闭当前窗口的时候，把S001_Touroku给显示出来
        private void S003_batch_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.s001_Touroku.Visible = true;
        }

        /// <summary>
        /// 点击Test用バッチ実行按钮,操作执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                // 获取csv中的数据,得到DataTable对象
                DataTable dt = OpenCSV(path);

                // 存放csv文件中读取的数据
                ArrayList arrayList = new ArrayList();
                int rowCount = dt.Rows.Count;
                int columnCount = dt.Columns.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    // 如果是第一列的话,就跳过
                    if (i == 0)
                    {
                        continue;
                    }

                    List<string> list = new List<string>() { };
                    for (int j = 0; j < columnCount; j++)
                    {

                        DataRow row1 = dt.Rows[i];
                        DataColumn column1 = dt.Columns[j];
                        list.Add(row1[column1].ToString());
                    }

                    arrayList.Add(list);
                }

                DBHandler dBHandler = new DBHandler();

                try
                {
                    foreach (List<string> list in arrayList)
                    {
                        // 把文件中读取的数据插入到表格中
                        string insertSql = $@"
                        INSERT 
                        INTO [dbo].[batch_csvDataEND] ( 
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
                          '{list[1]}'
                          , '{list[2]}'
                          , '{list[3]}'
                          , '{list[4]}'
                          , '{list[5]}'
                          , '{list[6]}'
                          , '{list[7]}'
                          , '{list[8]}'
                          , '{list[9]}'
                          , '{list[10]}'
                          , '{list[11]}'
                        ) 
                    ";

                        dBHandler.executeNonQuery(insertSql);
                    }

                    MessageBox.Show("CSV文件保存到数据库成功!");

                    // 保存操作信息到履历表
                    InsertDataTotm_batch("成功", null);
                }
                catch (Exception ex)
                {
                    InsertDataTotm_batch("失败", ex.Message);
                    MessageBox.Show($"CSV文件保存到数据库失败!原因:{ex.Message}");
                }

                // csv文件中的数据保存到数据库中之后,就移动文件
                string sql = $@"
                    SELECT
                      [startPath]
                      , [endPath]
                    FROM
                      [dbo].[path]
                ";

                DBHandler db = new DBHandler();

                // 通过SqlDataReader的方式进行查询(适合查询只有一条数据的情况)
                SqlDataReader sqlDataReader = db.SingleQuery(sql);
                // 判断SQL语句是否执行成功
                if (sqlDataReader.Read())
                {
                    // 我们查询到了一条数据,一条数据有中有两个字段,第二个字段才是我们需要的.因此通过sqlDataReader[1]的这种方式来获取
                    string endStr = sqlDataReader[1].ToString();
                    // 当我们从SqlDataReader对象中获取完数据之后,就可以关闭这个对象了
                    sqlDataReader.Close();

                    string endPath = Path.Combine(endStr, DateTime.Now.ToString("yyyyMMdd"));

                    // 如果文件夹不存在的话,就新建一个文件夹
                    if (!Directory.Exists(endPath))
                    {
                        Directory.CreateDirectory(endPath);
                    }

                    // 通过文件的绝对路径来获取到文件的名称
                    FileInfo fileInfo = new FileInfo(path);
                    // 执行完毕文件夹名称和文件名拼接形成新的路径
                    string endFullPath = Path.Combine(endPath, fileInfo.Name);
                    // 进行文件移动
                    File.Move(path, endFullPath);
                }
            }
        }

        /// <summary>
        /// 将数据插入到履历表中
        /// </summary>
        /// <param name="result">执行结果: 成功/失败</param>
        /// <param name="message">错误消息</param>
        private void InsertDataTotm_batch(string result, string message)
        {
            string a = dateTimePicker1.Text;
            string insertSql = $@"
                INSERT 
                INTO [dbo].[tm_batch] ( 
                  [batchKbn]
                  , [name]
                  , [jikkouYMD]
                  , [jikkouResult]
                  , [message]
                  , [kousinYMD]
                  , [kosinCd]
                ) 
                VALUES ( 
                 '{001}'
                  , 'Test用バーチ処理'
                  , '{dateTimePicker1.Text}'
                  , '{result}'
                  , '{message}'
                  , '{DateTime.Now}'
                  , 'jia'
                ) 
            ";

            DBHandler dBHandler = new DBHandler();
            dBHandler.executeNonQuery(insertSql);
        }

    }
}
