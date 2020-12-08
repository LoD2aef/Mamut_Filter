﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;


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
        private void Button1_Click(object sender, EventArgs e) {  
            FindItem(1); 
            EnabledOrNotLocation(); 
        }
        private void Button2_Click(object sender, EventArgs e) { 
            FindItem(2); 
            EnabledOrNotLocation(); 
        }
        private void Button4_Click(object sender, EventArgs e) { 
            Cursor.Current = Cursors.WaitCursor; 
            string path_Name_Type = (PathNewFile + "\\" + "MaMutUdenInactiveUser");
            FileWriter(path_Name_Type, FieldsName);
            string[] ExcelRows = ReadLines(FilePathCSV1); 
            progressBar1.Maximum = ExcelRows.Length; 
            for (int i = 1; i < ExcelRows.Length; i++) { 
                progressBar1.Value = i; 
                string[] data = ExcelRows[i].Split(';');
                bool demo = DeleteThisRow(data[MainComparePoint.SelectedIndex], SecondComparePoint.SelectedIndex, FilePathCSV2);
                if (!demo) {
                    FileWriter(path_Name_Type, data);
                }
            }
            MessageBox.Show("File er lavet");
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
        }

        private void Button5_Click(object sender, EventArgs e) { 
            Close();
        }
        private void FindItem(int a) { 
            using (OpenFileDialog OFD = new OpenFileDialog() {
                Filter = "CSV (Comma delimited)|*.csv|Excel Workbook(.xlsx)|*.xlsx|Excel 97-2003 Workbook (.xls)|*.xls|All files|*.*"
            }) 
            {
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
        private bool DeleteThisRow(string searchTerm, int positionOfSearchTerm, string filePath) {
            try {
                string[] lines = ReadLines(filePath); 
                for (int i = 0; i < lines.Length; i++) {
                    string[] fields = lines[i].Split(';'); 
                    if (fields[positionOfSearchTerm].Equals(searchTerm)) {
                        return true;
                    }
                }
            } catch (Exception ex) {
                throw new ApplicationException("error :", ex);
            }
            return false;
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
    }
}