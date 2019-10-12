using MakeJsonFile.Model;
using MakeJsonFile.Properties;
using MakeJsonFile.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeJsonFile
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Importbutton_Click(object sender, EventArgs e)
        {

            
            string ImportFilePath = ImporttextBox.Text.Trim('"');

            var rootmodel = new RootModel();

            rootmodel = SaveLoader.Load(ImportFilePath);
            //RootModel.Station[] s = SaveLoader.OriginalLoad(ImportFilePath);


            Dictionary<string, RootModel.Stations> Newrootmodel = new Dictionary<string, RootModel.Stations>();
            
            int inc = rootmodel.incrementID;
            foreach (var metroItem in rootmodel.Station)
            {
                RootModel.Stations row = new RootModel.Stations();

                String PrimaryKey = metroItem.lineID.ToString() + (metroItem.stationID+1).ToString("00");
                var current = Newrootmodel.Where(q => q.Key == PrimaryKey).FirstOrDefault();
                
                if (current.Key == null)
                {
                    row = current.Value;
                }

                #region 表示順設定
                //if (metroItem.lineName.Contains("御堂筋線"))
                //{
                //    var id = metroItem.id.ToString().Substring(metroItem.id.ToString().Length - 2, 2);
                //    row.御堂筋線表示順 = int.Parse(id);
                //}
                //else if (metroItem.lineName.Contains("谷町線"))
                //{
                //    var id = metroItem.id.ToString().Substring(metroItem.id.ToString().Length - 2, 2);
                //    row.谷町線表示順 = int.Parse(id);
                //}
                //else if (metroItem.lineName.Contains("四つ橋線"))
                //{
                //    var id = metroItem.id.ToString().Substring(metroItem.id.ToString().Length - 2, 2);
                //    row.四つ橋線表示順 = int.Parse(id);
                //}
                //else if (metroItem.lineName.Contains("中央線"))
                //{
                //    var id = metroItem.id.ToString().Substring(metroItem.id.ToString().Length - 2, 2);
                //    row.中央線表示順 = int.Parse(id);
                //}
                //else if (metroItem.lineName.Contains("千日前線"))
                //{
                //    var id = metroItem.id.ToString().Substring(metroItem.id.ToString().Length - 2, 2);
                //    row.千日前線表示順 = int.Parse(id);
                //}
                //else if (metroItem.lineName.Contains("堺筋線"))
                //{
                //    var id = metroItem.id.ToString().Substring(metroItem.id.ToString().Length - 2, 2);
                //    row.堺筋線表示順 = int.Parse(id);
                //}
                //else if (metroItem.lineName.Contains("長堀鶴見緑地線"))
                //{
                //    var id = metroItem.id.ToString().Substring(metroItem.id.ToString().Length - 2, 2);
                //    row.長堀鶴見緑地線表示順 = int.Parse(id);
                //}
                //else if (metroItem.lineName.Contains("南港ポートタウン線"))
                //{
                //    var id = metroItem.id.ToString().Substring(metroItem.id.ToString().Length - 2, 2);
                //    row.南港ポートタウン線表示順 = int.Parse(id);
                //}
                //else if (metroItem.lineName.Contains("今里筋線"))
                //{
                //    var id = metroItem.id.ToString().Substring(metroItem.id.ToString().Length - 2, 2);
                //    row.今里筋線表示順 = int.Parse(id);
                //}

                #endregion

                if (current.Key == null)
                {
                    var station = new RootModel.Stations {
                        id = metroItem.id,
                        name = metroItem.name,
                        Color = "#FFFFFF", //白
                        score = 1,
                        //御堂筋線表示順 = row.御堂筋線表示順,
                        //谷町線表示順 = row.谷町線表示順,
                        //四つ橋線表示順 = row.四つ橋線表示順,
                        //中央線表示順 = row.中央線表示順,
                        //千日前線表示順 = row.千日前線表示順,
                        //堺筋線表示順 = row.堺筋線表示順,
                        //長堀鶴見緑地線表示順 = row.長堀鶴見緑地線表示順,
                        //南港ポートタウン線表示順 = row.南港ポートタウン線表示順,
                        //今里筋線表示順 = row.今里筋線表示順,
                        groupID = metroItem.groupID,
                        lineID = metroItem.lineID,
                        stationID = metroItem.stationID, 
                        Visible = true,
                        lineName = metroItem.lineName
                    };

                    Newrootmodel.Add(PrimaryKey, station);
                }
                
            }
            rootmodel.StationFirebaseOnlyList = Newrootmodel;
            rootmodel.incrementID = inc;
            rootmodel.Station.Clear();
            SaveLoader.Save(rootmodel, Settings.Default.ファイルパス);
            var result = MessageBox.Show("設定しました。開きますか?","確認",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Process.Start(Settings.Default.ファイルパス);
            }

            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ImporttextBox.Text = @"Z:\stations.json";
            ChangeFiletextBox.Text = @"file.json";

            var rootmodel = SaveLoader.Load(Settings.Default.ファイルパス);
            foreach (var item in rootmodel.NotVisible)
            {
                NotVisibletextBox.Text += item.name + "\r\n";
            }
            
        }

        private void NotVisiblebutton_Click(object sender, EventArgs e)
        {
            var list = new ObservableCollection<RootModel.NotVisibles>();
            var listMaster = SaveLoader.Load(ChangeFiletextBox.Text);

            foreach (var line in NotVisibletextBox.Lines)
            {
                //var addName = line.Replace("\r\n", "");

                /////visible
                //var checkName = listMaster. .Where(q => q.name == addName).FirstOrDefault();
                //if (checkName != null)
                //{
                //    checkName.Visible = false;
                //}

                /////非表示リスト追加
                //var current = listMaster.NotVisible.Where(q => q.name == addName).FirstOrDefault();
                //if (current == null)
                //{
                //    list.Add(
                //        new RootModel.NotVisibles
                //        {
                //            name = addName,
                            
                //        }
                //    );
                //}

               
                
                
            }
            listMaster.NotVisible = list;

            SaveLoader.Save(listMaster, Settings.Default.ファイルパス);
            var result = MessageBox.Show("設定しました。開きますか?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Process.Start(Settings.Default.ファイルパス);
            }
            Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rootmodel = SaveLoader.Load(Settings.Default.ファイルパス);

            foreach (var item in rootmodel.StationFirebaseOnlyList)
            {
                if (rootmodel.LineList.Where(q=>q.LineID == item.Value.lineID.ToString()).Count()>0)
                {
                    continue;
                }
                rootmodel.LineList.Add(new RootModel.LineNameList {
                    LineID = item.Value.lineID.ToString(),
                    LineName = item.Value.lineName.ToString(),
                });
            }
            SaveLoader.Save(rootmodel, Settings.Default.ファイルパス);


            MessageBox.Show("保存しました");
        }
    }
}
