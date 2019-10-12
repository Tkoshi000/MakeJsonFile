using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeJsonFile.Model
{
    public class RootModel
    {

        /// <summary>
        /// 鉄道APIからの取得用
        /// </summary>
        
        public ObservableCollection<Stations> Station = new ObservableCollection<Stations>();


        /// <summary>
        /// firebase書き込み用
        /// groupid+LineID
        /// </summary>
        public Dictionary<string, Stations> StationFirebaseOnlyList = new Dictionary<string, Stations>();
        /// <summary>
        /// 非表示List
        /// </summary>
        public ObservableCollection<NotVisibles> NotVisible = new ObservableCollection<NotVisibles>();

        /// <summary>
        /// 一覧表示用
        /// </summary>
        public ObservableCollection<LineNameList> LineList = new ObservableCollection<LineNameList>();

        
        public class Stations
        {
            /// <summary>
            /// 一意のID
            /// </summary>
            public int id {
                get;
                set;
            }

            /// <summary>
            /// 駅名
            /// </summary>
            public string name {
                get;
                set;
            }
            /// <summary>
            /// 路線ID　もとのjsonのlが小文字
            /// </summary>
            public int lineID {
                get;
                set;
            }
            /// <summary>
            /// もとのJSONがlが小文字
            /// </summary>
            public string lineName {
                get;
                set;
            }
            /// <summary>
            /// 同じ駅ならその駅のIDを持っている
            /// </summary>
            public int groupID {
                get;
                set;
            }
            /// <summary>
            /// lineid中の順番
            /// </summary>
            public int stationID {
                get;
                set;
            }

            public int 御堂筋線表示順 {
                get;
                set;
            } = -1;
            public int 谷町線表示順 {
                get;
                set;
            } = -1;
            public int 四つ橋線表示順 {
                get;
                set;
            } = -1;
            public int 中央線表示順 {
                get;
                set;
            } = -1;
            public int 千日前線表示順 {
                get;
                set;
            } = -1;
            public int 堺筋線表示順 {
                get;
                set;
            } = -1;
            public int 長堀鶴見緑地線表示順 {
                get;
                set;
            } = -1;
            public int 南港ポートタウン線表示順 {
                get;
                set;
            } = -1;
            public int 今里筋線表示順 {
                get;
                set;
            } = -1;
            public bool Visible {
                get;
                set;
            } = false;

            /// <summary>
            /// red,blue,white
            /// </summary>
            public string Color {
                get;
                set;
            } = "white";

            public int score {
                get;
                set;
            } = 1;
        }

        public class NotVisibles
        {
            /// <summary>
            /// 非表示対象駅
            /// </summary>
            public string name {
                get;
                set;
            }
        }

        public class LineNameList
        {
            public string LineID {
                get;
                set;
            }
            public string LineName {
                get;
                set;
            }
        }

        public int incrementID {
            get;
            set;
        } = 1;
    }
}
