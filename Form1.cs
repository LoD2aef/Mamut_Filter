﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;
using System.Text.RegularExpressions;

namespace MaMut_Inactive_User_Filter {
    public partial class Form1 : Form {
        string FilePathCSV1;
        string FilePathCSV2;
        string PathNewFile;
        string[] FieldsName;
        DataTableCollection tableCollection;
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
        }
        private void MainSelectFile_Click(object sender, EventArgs e) {
            FindItem(1);
            EnabledOrNotLocation();
        }
        private void SecondSelectFile_Click(object sender, EventArgs e) {
            FindItem(2);
            EnabledOrNotLocation();
        }
        private void DeleteSelect_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            string path_Name_Type = (PathNewFile + "\\" + "missing uniconta");
            FileWriter(path_Name_Type, FieldsName);
            string[] ExcelRows = ReadLines(FilePathCSV1);
            progressBar1.Maximum = ExcelRows.Length;
            // this is okey if only it was not a nest loop
            for (int i = 1; i < ExcelRows.Length; i++) {
                progressBar1.Value = i;
                // FileWriter(path_Name_Type,ExcelRows);
                // need more logic. mabye splite some function out in classes, and dif filewriter calls 
                string[] data = ExcelRows[i].Split(';');
                /*
                 MessageBox.Show(data[0]);
                */
                bool demo = DeleteThisRow(data, SecondComparePoint.SelectedIndex, FilePathCSV2);
                if (!demo) {
                    FileWriter(path_Name_Type, data);
                }
                /*
                //MessageBox.Show(ExcelRows.Length.ToString());
                AddParaToIt(data, SecondComparePoint.SelectedIndex, FilePathCSV2, path_Name_Type);
                if (!(data[34] == "x" || data[33] == "1")) {
                    FileWriter(path_Name_Type, data);
                }
                */
            }
            MessageBox.Show("File er lavet");
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
        }

        private void EndProgram_Click(object sender, EventArgs e) {
            Close();
        }
        private void FindItem(int a) {
            using (OpenFileDialog OFD = new OpenFileDialog() {
                Filter = "CSV (Comma delimited)|*.csv|Excel Workbook(.xlsx)|*.xlsx|Excel 97-2003 Workbook (.xls)|*.xls|All files|*.*"
            }) {
                if (OFD.ShowDialog() == DialogResult.OK) {
                    PathSpilt(a, OFD);
                }
            }
        }
        private string PathSpilt(int FileNum, OpenFileDialog FilePath) {
            string FilePathName = FilePath.FileName;
            string[] SplitPath = FilePathName.Split('\\');
            string strFNL = SplitPath.Last();
            if (FileNum == 1) {
                PathNewFile = Path.GetDirectoryName(FilePathName);
                FilePathCSV1 = FilePathName;
                MainFileName.Text = strFNL;
                ComboBoxFiller(FileNum, FilePathName);
            } else if (FileNum == 2) {
                FilePathCSV2 = FilePathName;
                SecondFileName.Text = strFNL;
                ComboBoxFiller(FileNum, FilePathName);
            }
            return strFNL;
        }
        private void ComboBoxFiller(int a, string filepath) {
            try {
                string[] lines = ReadLines(filepath);
                string[] fileFields = lines[0].Split(';');
                if (a == 1) {
                    MainComparePoint.Items.Clear();
                    FieldsName = fileFields;
                    for (int i = 0; i < fileFields.Length; i++) {
                        MainComparePoint.Items.Add(fileFields[i]);
                    }
                    MainComparePoint.SelectedIndex = 0;
                } else if (a == 2) {
                    SecondComparePoint.Items.Clear();
                    for (int i = 0; i < fileFields.Length; i++) {
                        SecondComparePoint.Items.Add(fileFields[i]);
                    }
                    SecondComparePoint.SelectedIndex = 0;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        private string[] ReadLines(string filePath) {
            try {
                if (Path.GetExtension(filePath) == ".csv") {
                    string[] lines = File.ReadAllLines(filePath, Encoding.Default);
                    return lines;
                } else if (Path.GetExtension(filePath) == ".txt") {
                    string[] lines = File.ReadAllLines(filePath, Encoding.Default);
                    return lines;
                } else {
                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read)) {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream)) {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration() {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            DataTable dt = tableCollection[0];
                            List<string> list = new List<string>();
                            string[] stringColumns = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                            string oneColumn = string.Join(";", stringColumns);
                            list.Add(oneColumn);
                            for (int i = 0; i < dt.Rows.Count; i++) {
                                string[] stringRows = dt.Rows[i].ItemArray.Select(x => x.ToString()).ToArray();
                                string oneRow = string.Join(";", stringRows);
                                list.Add(oneRow);
                            }
                            string[] lines = list.ToArray();
                            return lines;
                        }
                    }
                }
            } catch (Exception ex) {
                throw new ApplicationException("error :", ex);
            }
        }
        private void EnabledOrNotLocation() {
            if (FilePathCSV1 != null && FilePathCSV2 != null) {
                DeleteSelect.Enabled = true;
            }
        }
        // this is bad!
        private bool DeleteThisRow(string[] FileStringData, int positionOfSearchTerm, string SecendFileFilePath) {
            try {
                string[] lines = ReadLines(SecendFileFilePath);
                for (int i = 0; i < lines.Length; i++) {
                    string[] fields = lines[i].Split(';');
                    if (fields.Length > positionOfSearchTerm) {
                        if (fields[positionOfSearchTerm].Equals(FileStringData[MainComparePoint.SelectedIndex])) {
                            return true;
                        }
                    }
                }
            } catch (Exception ex) {
                throw new ApplicationException("error :", ex);
            }
            return false;
        }
        
        private bool DeleteThisRow2Para(string[] FileStringData, int positionOfSearchTerm, string SecendFileFilePath) {
            try {
                string[] lines = ReadLines(SecendFileFilePath);
                for (int i = 0; i < lines.Length; i++) {
                    string[] fields = lines[i].Split(';');
                    if (fields.Length > positionOfSearchTerm) {
                        string filter2 = FileStringData[7] + ", " + FileStringData[6];
                        //MessageBox.Show(filter2 + " - " + fields[1] + " return : " + fields[1].Equals(filter2));
                        if (fields[positionOfSearchTerm].Equals(FileStringData[MainComparePoint.SelectedIndex]) && fields[1].Equals(filter2)) {
                            return true;
                        }
                    }
                }
            } catch (Exception ex) {
                throw new ApplicationException("error :", ex);
            }
            return false;
        }
        // THIS IS BAD!!!!
        private void AddParaToIt(string[] FileStringData, int positionOfSearchTerm, string SecendFileFilePath, string path_Name_Type) {
            try {
                string[] lines = ReadLines(SecendFileFilePath);
                for (int i = 0; i < lines.Length; i++) {
                    string[] fields = lines[i].Split(';'); //fields is secfile
                    if (FileStringData.Length >= 36) {
                        if (fields[positionOfSearchTerm].Equals(FileStringData[MainComparePoint.SelectedIndex])) {
                            bool val = Convert.ToBoolean(fields[6]);
                            if (val) {
                                FileStringData[33] = "1";
                                FileStringData[35] = "Stykliste";
                                FileWriter(path_Name_Type, FileStringData);
                            } else {
                                FileStringData[34] = "x";
                                FileWriter(path_Name_Type, FileStringData);
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                throw new ApplicationException("error :", ex);
            }
        }
        private string[] stringSplitter(string stringData) {
            string[] newLines = Regex.Split(stringData, @"\W+");
            string[] temp = new string[] { "1", "2" };
            return temp;
        }

        private void FileWriter(string pathNameType, string[] fieldsMain) {
            try {
                using (StreamWriter file = new StreamWriter(pathNameType + ".CSV", true, Encoding.Default)) {
                    string fields = ConvertStringArrayToString(fieldsMain);
                    file.WriteLine(fields);
                }
            } catch (Exception ex) {
                MessageBox.Show("error Excel File could not be created : " + ex.Message);
            }
        }
        static string ConvertStringArrayToString(string[] MainArr) {
            StringBuilder builder = new StringBuilder();
            foreach (string value in MainArr) {
                builder.Append(value);
                builder.Append(';');
            }
            return builder.ToString();
        }

        private void WinFormRemoveButton_Click(object sender, EventArgs e) {
            WinFormRemover wfr = new WinFormRemover();
            wfr.ShowDialog(); // Maim Form locked, and will push you to wfr instead
            //wfr.Show(); // Main Form still aktive, could lead to problems, so not vaild
        }
    }
}