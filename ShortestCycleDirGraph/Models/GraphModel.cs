using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Msagl;
using Microsoft.Msagl.Mds;
using ShortestCycleDirGraph.Core;

namespace ShortestCycleDirGraph.Models
{
    class GraphModel
    {
        public static Graph<int> Graph { get; set; }
        public static SettingsItem SelectedSettings { get; set; } = new SettingsItem("Układ warstowy", new SugiyamaLayoutSettings());
        public static List<SettingsItem> SettingsList { get; } = new List<SettingsItem>()
        {
             new SettingsItem("Układ warstowy", new SugiyamaLayoutSettings()),
              new SettingsItem("Układ wielowymiarowy", new MdsLayoutSettings())
        };
    }
}
