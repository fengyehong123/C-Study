using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsStudy.DBConnect
{
    class DBHandler
    {
        // データベース接続の文字列を宣言する
        private string dataBaseConnection;
        // 検出するデータを格納するDataSetを宣言する
        private DataSet ds = null;
        // データベース接続のオブジェクトを宣言する
        private SqlConnection conn = null;

        /// <summary>
        /// メソッド名：コンストラクター
        /// メソッド説明：Web.Configファイルからデータベース接続の文字列を取得する。
        /// </summary>
        public DBHandler()
        {
            // Web.Configファイルからデータベース接続の文字列を取得する。
            dataBaseConnection = ConfigurationManager.AppSettings["DataBaseConnection"];
        }

        /// <summary>
        /// メソッド名：実行検索
        /// メソッド説明：データベースに検索の操作を行う
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <returns>検出するデータを格納するDataSet</returns>
        public DataSet executeQuery(string sql)
        {
            // 戻るデータを格納するオブジェクトを初期化する
            ds = new DataSet();
            try
            {
                // データベース接続のオブジェクトを初期化する
                conn = new SqlConnection(dataBaseConnection);
                // SqlDataAdapterオブジェクトを初期化する
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                // SQL文を実行する，DataSetに検出するデータを格納する
                adapter.Fill(ds); //默认虚拟表名Table
                //adapter.Fill(ds,"ORDERTEMP"); //ORDERTEMP:自定义虚拟表名
                // 検出するデータを格納するDataSetを戻る
                return ds;
            }
            finally
            {
                // データベース接続を閉める
                conn.Close();
            }
        }

        /// <summary>
        /// メソッド名：実行編集
        /// メソッド説明：データベースに新規、更新、削除の操作を行う
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <returns>操作するデータの件数</returns>
        public int executeNonQuery(string sql)
        {
            try
            {
                // データベース接続のオブジェクトを初期化する
                conn = new SqlConnection(dataBaseConnection);
                // データベース接続を開ける
                conn.Open();
                // SqlCommandオブジェクトを初期化する
                SqlCommand command = new SqlCommand(sql, conn);
                // SQL文を実行する，操作するデータの件数を戻る
                return command.ExecuteNonQuery();
            }
            finally
            {
                // データベース接続を閉める
                conn.Close();
            }
        }


        public SqlDataReader SingleQuery(string sql)
        {
            try
            {
                // データベース接続のオブジェクトを初期化する
                conn = new SqlConnection(dataBaseConnection);
                // データベース接続を開ける
                conn.Open();
                // SqlCommandオブジェクトを初期化する
                SqlCommand command = new SqlCommand(sql, conn);
                // SQL文を実行する，操作するデータの件数を戻る
                return command.ExecuteReader();
            }
            finally
            {
                // データベース接続を閉める
                // conn.Close();
            }
        }

        

        /// <summary>
        /// メソッド名：SQL文濾過
        /// メソッド説明：SQL文濾過
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <returns>濾過したSQL文</returns>
        public static string sqlFilter(string sql)
        {
            // 「'」を「''」に変換する、濾過したSQL文を戻る
            return sql.Replace("'", "''");
        }
    }
}
