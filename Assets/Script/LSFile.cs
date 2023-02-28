using System.Collections.Generic;
using System.IO;

namespace LSFile
{
    public class pathFile
    {
        public string path, file, col;
        private bool ExistFile;

        string all = "";

        public pathFile(string _path)
        {
            path = _path;

            ExistFile = File.Exists(path);
        }
        public pathFile(string _path, string _file)
        {
            path = _path;
            file = _file;
            ExistFile = File.Exists(path + file);
        }
        public pathFile(string _path, string _file, string _col)
        {
            path = _path;
            file = _file;
            col = _col;

            ExistFile = File.Exists(path + file);
        }

        public string ExiFile()
        {
            if (ExistFile == false) return "NotFile";
            else return "FileOK";
        }

        public List<string> Load(bool _colLoad = false)
        {
            // 如果檔案存在
            if (ExistFile == false)
                return null;

            List<string> FileData = new List<string>(); // 最終返回值
            string[] CSV_FileLines; // 每排資料的陣列

            CSV_FileLines = File.ReadAllLines(path + file); // 切排

            if (CSV_FileLines.Length <= 1) // 如果沒有資料
                return null;
            if (_colLoad == true) // 是否也要抓類別
                for (int i = 0; i < CSV_FileLines.Length; i++)
                    FileData.Add(CSV_FileLines[i]);
            else
                for (int i = 1; i < CSV_FileLines.Length; i++)
                    FileData.Add(CSV_FileLines[i]);

            return FileData;
        }

        public List<string> Load(string _path, bool _colLoad = false)
        {
            path = _path;
            ExistFile = File.Exists(path);
            // 如果檔案存在
            if (ExistFile == false)
                return null;

            List<string> FileData = new List<string>(); // 最終返回值
            string[] CSV_FileLines; // 每排資料的陣列

            CSV_FileLines = File.ReadAllLines(path); // 切排

            if (CSV_FileLines.Length <= 1) // 如果沒有資料
                return null;
            if (_colLoad == true) // 是否也要抓類別
                for (int i = 0; i < CSV_FileLines.Length; i++)
                    FileData.Add(CSV_FileLines[i]);
            else
                for (int i = 1; i < CSV_FileLines.Length; i++)
                    FileData.Add(CSV_FileLines[i]);

            return FileData;
        }

        public void Save(string _col, List<string> _list, string filename)
        {
            all = "";
            col = _col;
            all += col + "\n"; // 第一行類別
            for (int i = 0; i < _list.Count; i++)
                all += _list[i] + "\n";

            File.WriteAllText(path + file + filename + ".csv", all, System.Text.Encoding.UTF8);
        }
        public void Save(string _col, string _data, string filename)
        {
            all = "";
            col = _col;
            all += col + "\n" + _data; // 第一行類別

            File.WriteAllText(path + file + filename + ".csv", all, System.Text.Encoding.UTF8);
        }
        public void Save(List<string> _list, string _path, string filename)
        {
            path = _path;
            all = "";
            all += col + "\n"; // 第一行類別
            for (int i = 0; i < _list.Count; i++)
                all += _list[i] + "\n";

            File.WriteAllText(path + file + filename + ".csv", all, System.Text.Encoding.UTF8);
            
        }

        public void Edit(List<string> _list, int _index, string _value)
        {
            _list[_index - 1] = _value;
        }

        public void EditLast(List<string> _list, string _value)
        {
            _list[_list.Count - 1] = _value;
        }

        public void DeleteTarget(List<string> _list, int _target)
        {

            if (_target < 1 || _target > _list.Count - 1)
                return;

            _list.RemoveAt(_target - 1);
        }

        public void DeleteRange(List<string> _list, int _count = 1)
        {
            int j = _list.Count - 1;

            if (_count < 1 || _count >= j)
                return;

            for (int i = j; i > j - _count; i--)
            {
                _list.RemoveAt(i);
            }
        }

        public void DeleteTargetRange(List<string> _list, int _startCount, int _endCount)
        {
            int j = _list.Count;

            if (_startCount < 1 || _startCount > j || _startCount >= _endCount
                || _endCount < 1 || _endCount > j || _endCount <= _startCount
                )
                return;

            _list.RemoveRange(_startCount - 1, _endCount - _startCount + 1);
        }

    }
}