using Microsoft.Msagl;

namespace ShortestCycleDirGraph.Core
{
    class SettingsItem
    {
        public SettingsItem(string name, LayoutAlgorithmSettings settings)
        {
            Name = name;
            Settings = settings;
        }

        public string Name { get; set; }
        public LayoutAlgorithmSettings Settings { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
