# 文件操作
## 判断文件或文件夹是否存在
```C#
    // 判断文件是否存在
    if (!File.Exists("文件绝对路径"))
    {
        // 创建文件
    }

    // 当文件夹不存在的时候,创建新文件夹
    if (!Directory.Exists("文件夹绝对路径")) {
        Directory.CreateDirectory("文件夹绝对路径");
    }
```

## 读取文件
```C#
    // 读取txt文件中的所有内容
    string content = File.ReadAllText("文件绝对路径");
```
```C#
    FileInfo fileInfo = new FileInfo("文件绝对路径");
    FileStream fileStream = fileInfo.Open(FileMode.Open);

    int fsLength = (int)fileStream.Length;
    byte[] fileMessageByte = new byte[fsLength];

    // 把文件信息读取到字节数组中
    fileStream.Read(fileMessageByte, 0, fsLength);
    // 关闭流
    fileStream.Close();
```

## 写入文件
```C#
    FileStream fs = new FileStream("文件绝对路径", FileMode.Create);
    StreamWriter wr = new StreamWriter(fs);
    wr.Write("写入文件的内容");
    
    // 关闭流
    wr.Close();
    fs.Close();
```

## 文件移动
```C#
    FileInfo fileInfo = new FileInfo("移动之前的文件所在的绝对路径");
    string newFilePath = Path.Combine("文件要移入的文件夹绝对路径", fileInfo.Name);
    // 使用.MoveTo()进行文件移动
    fileInfo.MoveTo(newFilePath);
```

## 获取一个文件夹中所有文件的信息(名称)
```C#
    // 根据文件夹路径获取文件夹对象
    DirectoryInfo dirInfo = new DirectoryInfo("文件夹路径");
    // 通过文件夹对象获取文件夹中所有文件的信息,获取到一个文件数组对象
    FileInfo[] fileList = dirInfo.GetFiles();
    // 遍历文件夹中所有的文件,打印文件名称
    foreach (FileInfo file in fileList)
    {
        // 获取文件名称
        Console.WriteLine(file.Name);
        // 获取文件的绝对路径
        Console.WriteLine(file.FullName);
    }
```

## 路径拼接
```C#
    // 根据文件路径和文件名称拼接成全路径
    string fullPath = Path.Combine("文件绝对路径", "文件名称");
```

## 文件操作案例
```C#
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 源文件路径
            string sourcePath = @"C:\a";
            // 目标文件夹路径
            string destPath = @"D:\b";

            MoveFolder(sourcePath, destPath);

            // 源文件路径
            string sourcePath1 = @"D:\a";
            // 目标文件夹路径
            string destPath2 = @"E:\b";
            CopyFilefolder(sourcePath1, destPath2);
        }

        /// <summary>
        /// 文件夹中所有的文件移动
        /// </summary>
        /// <param name="sourcePath">源文件夹路径</param>
        /// <param name="destPath">目标文件夹路径</param>
        public static void MoveFolder(string sourcePath, string destPath)
        {
            // 判断源文件夹是否存在
            if (Directory.Exists(sourcePath))
            {
                // 如果目标目录不存在则创建  
                if (!Directory.Exists(destPath))
                {
                    try
                    {
                        Directory.CreateDirectory(destPath);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("创建目标目录失败：" + ex.Message);
                    }
                }

                // 获得源文件下所有文件  
                List<string> files = new List<string>(Directory.GetFiles(sourcePath));
                files.ForEach(file =>
                {
                    string destFileFullName = Path.Combine(destPath, Path.GetFileName(file));
                    // 若文件存在的话,就进行删除
                    if (File.Exists(destFileFullName))
                    {
                        File.Delete(destFileFullName);
                    }
                    // 进行文件移动
                    // 参数1: 源文件绝对路径
                    // 参数2: 目标文件绝对路径
                    File.Move(file, destFileFullName);
                });


                // 获得源文件下所有的文件夹
                List<string> folders = new List<string>(Directory.GetDirectories(sourcePath));
                folders.ForEach(folder =>
                {
                    // Directory.Move必须要在同一个根目录下移动才有效，不能在不同卷中移动。  
                    // Directory.Move(c, destDir);  

                    string destDir = Path.Combine(new string[] { destPath, Path.GetFileName(folder) });
                    //采用递归的方法实现  
                    MoveFolder(folder, destDir);
                });
            }
        }

        /// <summary>
        /// 文件夹中所有的文件复制
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="targetFilePath"></param>
        public static void CopyFilefolder(string sourceFilePath, string targetFilePath)
        {
            // 获取源文件夹中的所有非目录文件
            string[] files = Directory.GetFiles(sourceFilePath);
            string fileName;
            string destFile;
            // 如果目标文件夹不存在，则新建目标文件夹
            if (!Directory.Exists(targetFilePath))
            {
                Directory.CreateDirectory(targetFilePath);
            }
            // 将获取到的文件一个一个拷贝到目标文件夹中  
            foreach (string s in files)
            {
                fileName = Path.GetFileName(s);
                destFile = Path.Combine(targetFilePath, fileName);
                File.Copy(s, destFile, true);
            }

            // 获取并存储源文件夹中的文件夹名
            string[] filefolders = Directory.GetFiles(sourceFilePath);
            // 创建Directoryinfo实例 
            DirectoryInfo dirinfo = new DirectoryInfo(sourceFilePath);
            // 获取得源文件夹下的所有子文件夹名
            DirectoryInfo[] subFileFolder = dirinfo.GetDirectories();

            for (int j = 0; j < subFileFolder.Length; j++)
            {
                // 获取所有子文件夹名 
                string subSourcePath = sourceFilePath + "\\" + subFileFolder[j].ToString();
                string subTargetPath = targetFilePath + "\\" + subFileFolder[j].ToString();
                // 把得到的子文件夹当成新的源文件夹，递归调用CopyFilefolder
                CopyFilefolder(subSourcePath, subTargetPath);
            }
        }
    }
}
```

# 字符串操作
## 字符串判空
```C#
    if(string.IsNullOrWhiteSpace("字符串"))
    {
        // XXX
    }
```

## 字符串转字节，并对字节进行切割,返回新字符串
```C#
    // 字符串转字节
    byte[] byteInfo = Encoding.UTF8.GetBytes("字符串");
    // 对字节进行切割,返回一个字符串
    string str = Encoding.UTF8.GetString(byteInfo, 3, 10);  // 从字节的第三位开始切割,向后切割10位
```

## 字符串格式化
```C#
    string count1 = "1";
    string newName1 = string.Format("{0:D4}", count1);
    Console.WriteLine(newName1);  // "0001"

    string count2 = "22";
    string newName2 = string.Format("{0:D4}", count2);
    Console.WriteLine(newName2);  // "0022"

    string dataStr = string.Format("{0:yyyyMMdd}", DateTime.Now);
    Console.WriteLine(dataStr);  // "20201216"
```
## 通过$来构建模板字符串
```C#
    string name = "张三";
    string content = $"我的名字是: '{name}' "
```
## 字符串中@的使用
```C#
    // 使用@符号可以实现字符串的换行
    String sql = @"SELECT * FROM USERS
                   WHERE DELFLAG = '0'
                   AND AGE > 20";
    
    // 使用@符号可以忽略转义字符(在文件路径中常用)
    // 使用@符号之前的文件路径
    string fileName = "D:\\文本文件\\text.txt";

    // 使用@符号之后的文件路径
    string fileName = @"D:\文本文件\text.txt";
```

## 字符串转换日期,日期进行比较
```C#
    // 日期字符串转换为日期格式
    DateTime dataStr1 = DateTime.ParseExact("日期字符串1", "yyyyMMddHHmmssfff", CultureInfo.CurrentCulture);
    DateTime dataStr2 = DateTime.ParseExact("日期字符串2", "yyyyMMddHHmmssfff", CultureInfo.CurrentCulture);

    // 两个日期对象进行比较
    if(DateTime.Compare(dataStr1, dataStr2) > 0 || DateTime.Compare(dataStr1, dataStr2) = 0 )
    {
        // XXX
    }
```
## 日期转字符串
```C#
    string time1 = DateTime.Now.ToString("yyyy-MM-dd");
    Console.WriteLine("yyyy-MM-dd:{0}", time1);

    string time2 = DateTime.Now.ToString("yyyyMMdd");
    Console.WriteLine("yyyyMMdd:{0}", time2);

    string time3 = DateTime.Now.ToString("yyyy年MM月dd日");
    Console.WriteLine("yyyy年MM月dd日:{0}", time3);
```

# 数组相关操作
```C#
    // 定义一个实体类
    public class Human
    {
        private string name;
        private string hobby;
        private decimal money;

        public string Name { get => name; set => name = value; }
        public string Hobby { get => hobby; set => hobby = value; }
        public decimal Money { get => money; set => money = value; }
    }
```

## 数组转换为逗号分隔的字符串
```C#
    string[] paramList =
    {
        "a",
        "b",
        "c"
    };
    string newStr = string.join(",", paramList);
    Console.WriteLine(newStr);  // "a,b,c"
```

## 数组使用lambda表达式
```C#
    // array.Where()
    int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    var data = array.Where(item => item % 2 != 0);
    data.ToList().ForEach(item => Console.WriteLine(item));
```

## 数组转换为集合
``` C#
    int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    // 数组转换为集合，集合的括号中存放的是可迭代对象
    IList arryList = new ArrayList(array);
    foreach (int item in arryList)
    {
        Console.WriteLine($"--{item}--");
    }
```

## 集合中的lambda表达式
```C#
    // 初始化一个集合
    List<Human> iiList = new List<Human> {
        new Human(){Name="zhangsanli",Hobby="reading", Money=500},
        new Human(){Name="lisi",Hobby="watching", Money=300},
        new Human(){Name="lisi",Hobby="killing", Money=400},
        new Human(){Name="wangwu",Hobby="drinking", Money= 600},
    };
    // 采用lambda表达式的方式进行条件过滤
    List<Human> newList = iiList.Where(item => item.Money > 501)
            .Where(item => item.Money > 502).ToList();
    // 采用lambda表达式的方式进行遍历循环
    newList.ForEach(item => Console.WriteLine(item.Name));

    // 过滤出最长姓名的长度
    Console.WriteLine($"The Max Name Length is:{iiList.Max(item => item.Name.Length)}");

    // 获取出所有人的姓名，并且去除重名的情况
    iiList.Select(item => item.Name)
        // 去除重名的情况
        .Distinct().ToList()
        // 遍历打印去重之后的姓名
        .ForEach(item => Console.WriteLine(item));

    // 求出所有人金额的总数量
    Console.WriteLine($"The Sum money is {iiList.Sum(item => item.Money)}");

    // 求出总金额的平均数
    Console.WriteLine($"The average money is {iiList.Average(item => item.Money)}");

    // 查询名字叫lisi的学生的数量(lisi这个学生重名，有两个)
    Console.WriteLine($"The name is lisi count is :{iiList.Count(item => item.Name == "lisi")}");

    // 查询名字中包含 li 的实体类,并且打印实体类的姓名
    List<Human> humenList = iiList.FindAll(item => item.Name.Contains("li"));
    humenList.ForEach(item => Console.WriteLine($"The Name is {item.Name}"));

    // 查询收入在 350元到550元之间的实体类，并且按照收入从小到大排序
    iiList.Where(item => item.Money > 350 && item.Money < 550)
          //  先按照金钱和名称从小到大排序，然后按照姓名从大大小排序 
          .OrderBy(item => item.Money).ThenBy(item => item.Name).ThenByDescending(item => item.Name)
          .ToList<Human>()
          .ForEach(item => Console.WriteLine($"The Money order is :{item.Money}"));
    // 收入按照从大到小来排序
    iiList.Where(item => item.Money > 350 && item.Money < 550)
          .OrderByDescending(item => item.Money)
          .ToList<Human>()
          .ForEach(item => Console.WriteLine($"The Money order is :{item.Money}"));
```

## LINQ表达式
> 像使用SQL语句一样来进行List操作
```C#
    List<Student> stuList = new List<Student>
    {
        new Student{ Code = "1",Name="fengyehong",Age=18 },
        new Student{ Code = "2",Name="jiafeitian",Age=18 },
        new Student{ Code = "3",Name="lukang",Age=20 },
        new Student{ Code = "4",Name="lvxuwei",Age=21 },
    };

    // 通过LINQ表达式来进行查询
    // 像使用SQL语句一样来进行List操作
    var NQList = from item in stuList
                 where item.Name == "fengyehong" && item.Age == 18
                 select item;
    foreach (var item in NQList)
    {
        // 打印出符合条件的年龄
        Console.WriteLine(item.Age);
    }

    // 从学生中选出年龄小于25岁并且按照年龄降序排列
    var res = from item in stuList
              where item.Age < 25
              // 按照年龄降序排序
              orderby item.Age descending
              select item;
    foreach (var item in res)
    {
        Console.WriteLine($"Name is {item.Name} age is {item.Age}");
    }

    // 同时按照两个字段进行排序
    var res1 = from item in stuList
               // 同时排序两个字段
               orderby item.Age, item.Age
               select item;

    // 按照年龄进行分组，查询相同年龄 > 2 的情况
    var res2 = from item in stuList
               group item by item.Age into a
               where a.Count() >= 2
               select a;
    // 原因暂时未知，但是获取出具体的数据需要嵌套遍历两次
    foreach (var element in res2)
    {
        foreach (var item in element)
        {
            Console.WriteLine($"Name is {item.Name} age is {item.Age}");
        }
    }

    // 查询出集合 oobjListA 中 Code 等于集合 oobjListB 中 Code 的元素，并形成新的集合
    // 定义一个集合 oobjListA
    List< Student > oobjListA = new List<Student>
    {
        new Student{ Code = "1",Name="AA",Age=18 },
        new Student{ Code = "2",Name="BB",Age=18 },
        new Student{ Code = "3",Name="CC",Age=20 },
        new Student{ Code = "4",Name="DD",Age=21 },
    };
    // 定义一个集合 oobjListB
    List<Student> oobjListB = new List<Student>
    {
        new Student{ Code = "1",Name="fengyehong",Age=18 },
        new Student{ Code = "2",Name="jiafeitian",Age=18 },
        new Student{ Code = "3",Name="lukang",Age=20 },
        new Student{ Code = "4",Name="lvxuwei",Age=21 },
    };
    // 两个集合形成新的集合
    var res3 = from t1 in oobjListA
                from t2 in oobjListB
                // 两个集合连接的条件
                where t1.Code == t2.Code
                // 根据条件形成新的集合
                select new {
                    Number = t1.Code,
                    FullName = t1.Name + t2.Name
                };
    foreach (var item in res3)
    {
        // AAfengyehong
        Console.WriteLine($"The Code is :{item.Number} and The FullName is {item.FullName}");
    }
```

# 其他
**C#使用打断点**
```C#
    // 在debug模式下,断点会停留在此处
    System.Diagnostics.Debugger.Break();
```

**获取从命令行传来的参数**
```C#
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace WindowsFormsApp1
    {
        static class Program
        {
            static void Main(string[] args)
            {
                // 主程序中获取从命令行传来的参数
                string param1 = args[0];
                string param2 = args[1];
            }
        }
    }
```
