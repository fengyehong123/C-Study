using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsStudy.DBConnect;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace WindowsFormsStudy
{
    public partial class S002_dateSearch : Form
    {
        // 定义一个变量保存s001_Touroku
        private S001_Touroku s001_Touroku = null;

        List<int> list = new List<int>() { };

        // 把S001_Touroku窗体对象传递到S002_dateSearch窗体对象中
        public S002_dateSearch(S001_Touroku touroku)
        {
            InitializeComponent();
            s001_Touroku = touroku;
        }

        /// <summary>
        /// 当S002_dateSearch窗口被调用打开的时候,这个函数会自动执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void S002_dateSearch_Load(object sender, EventArgs e)
        {
            SearchDataFromDB();
        }

        private void SearchDataFromDB()
        {
            // 调用从数据库查询数据的方法
            DataSet dataSet = SearchData();
            // 把从数据库查询到的数据保存到表格控件中
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        // 当关闭当前窗口的时候，把S001_Touroku给显示出来
        private void S002_dateSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 把主窗口显示出来
            this.s001_Touroku.Visible = true;
        }

        private DataSet SearchData()
        {
            // 获取窗体中CheckBox的状态
            string shoriFlg = checkBoxFlag.Checked ? "1" : "0";

            // 准备查询的SQL
            string sql = $@"
                SELECT
                  [id]
                  , [torihikiCd]
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
                FROM
                  [dbo].[batch_csvDataStart] 
                WHERE
                  [shoriFlg] = '{shoriFlg}' 
                ORDER BY
                  [id]
            ";
            DBHandler dbHandler = new DBHandler();
            DataSet dataSet = dbHandler.executeQuery(sql);

            return dataSet;
        }

        /// <summary>
        /// 打印csv文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printCSV_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = $@"
                    SELECT
                      [startPath]
                      , [endPath]
                    FROM
                      [dbo].[path]
                ";

                DBHandler db = new DBHandler();
                DataSet dataSet = db.executeQuery(sql);
                DataTable dataTable = dataSet.Tables[0];
                // 获取出第一行
                DataRow row = dataTable.Rows[0];
                // 获取出第一列
                DataColumn column = dataTable.Columns[0];
                // 获取出第一行第一列的数据(把文件夹的路径获取出来)
                string path = row[column].ToString();

                // 如果文件夹不存在的话,就新建一个文件夹
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";

                string[] titleList =
                {
                    "ID",
                    "取引先コード",
                    "取引先名称",
                    "取引先略称",
                    "取引先住所",
                    "郵便番号",
                    "電話番号",
                    "FAX",
                    "担当者名",
                    "処理フラグ",
                    "更新日付",
                    "更新者コード"
                };
                string title = string.Join(",", titleList);

                string strBufferLine = "";
                StreamWriter strmWriterObj = new StreamWriter(path, false, Encoding.UTF8);
                // strmWriterObj.WriteLine("123");
                strmWriterObj.WriteLine(title);

                DataTable dt = (DataTable)dataGridView1.DataSource;

                List<DataRow> rowList = new List<DataRow>() { };
                for (int i = 0; i < list.Count; i++)
                {
                    // 获取选中的当前行号
                    int index = list[i];
                    rowList.Add(dt.Rows[index]);
                }

                // 克隆DataTable的结构
                DataTable dtObj = dt.Rows[0].Table.Clone();
                for(int j = 0; j < rowList.Count; j++)
                {
                    // 把行数据添加到我们新建的DataTable中
                    dtObj.ImportRow(rowList[j]);
                }

                // 存放被选中的id
                List<string> idList = new List<string>() { };
                for (int k = 0; k < dtObj.Rows.Count; k++)
                {
                    DataRow roww = dtObj.Rows[k];
                    DataColumn col = dtObj.Columns[0];
                    string id = roww[col].ToString();
                    idList.Add(id);
                }


                // 打印行和列,向csv文件中输入数据
                for (int i = 0; i < dtObj.Rows.Count; i++)
                {
                    strBufferLine = "";
                    for (int j = 0; j < dtObj.Columns.Count; j++)
                    {
                        if (j > 0)
                        {
                            strBufferLine += ",";
                            strBufferLine += dtObj.Rows[i][j].ToString();
                        }
                    }
                    strmWriterObj.WriteLine(strBufferLine);
                }
                strmWriterObj.Close();

                // 将处理完成之后的数据的出力flag更新
                foreach (string id in idList)
                {
                    string updateSql = $@"
                        update [dbo].[batch_csvDataStart]
                        set [shoriFlg] = '1'
                        where [id] = '{id}';
                    ";

                    db.executeNonQuery(updateSql);
                }

                // 更新完成之后重新渲染一遍表格组件
                SearchDataFromDB();

                MessageBox.Show($"文件输出成功,位置:{path}");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"文件输出失败,原因:{ex.Message}");
            }
            
        }

        /// <summary>
        /// 复选框点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxFlag_CheckedChanged(object sender, EventArgs e)
        {
            // 获取窗体中CheckBox的状态(选中状态为1,未选中状态未0)
            string shoriFlg = checkBoxFlag.Checked ? "1" : "0";

            // 根据checkBox的状态去更改csv按钮的状态
            if ("1".Equals(shoriFlg))
            {
                printCSV.Enabled = false;
            } else
            {
                printCSV.Enabled = true;
            }

            string sql = $@"
                SELECT
                  [id]
                  , [torihikiCd]
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
                FROM
                  [dbo].[batch_csvDataStart] 
                WHERE
                  [shoriFlg] = '{shoriFlg}' 
                ORDER BY
                  [id]
            ";
            DBHandler dbHandler = new DBHandler();
            DataSet dataSet = dbHandler.executeQuery(sql);

            // 清空原有的数据
            dataGridView1.DataSource = null;
            // 把从数据库查询到的数据保存到表格控件中
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        /// <summary>
        /// 点击单选框,把选中的行号添加到列表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 清空原有的数据
            list.Clear();
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    // 获取表格中checkBox的状态
                    string _selectValue = dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString();
                    // 如果CheckBox已选中，则在此处继续编写代码
                    if (_selectValue == "True")
                    {
                        // 把所有选中的行号添加到列表中
                        list.Add(i);
                    }
                }
            }
        }
    }
}
