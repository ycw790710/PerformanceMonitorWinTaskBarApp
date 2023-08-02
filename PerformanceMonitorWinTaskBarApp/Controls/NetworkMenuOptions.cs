using PerformanceMonitorWinTaskBarApp.Usages;

namespace PerformanceMonitorWinTaskBarApp.Controls;
class NetworkMenuOptions : IDisposable
{
    readonly List<ToolStripMenuItem> _networkOptions;
    private readonly ContextMenuStrip _menuStrip;
    string _selectedNetworkOption;
    readonly HashSet<string> _cachedOptionInstanceNames;

    public NetworkMenuOptions(ContextMenuStrip menuStrip)
    {
        _networkOptions = new();
        _selectedNetworkOption = "";
        _menuStrip = menuStrip;
        _cachedOptionInstanceNames = new();
    }

    public void Dispose()
    {
        RemoveOptions();
    }

    public void UpdateNetworkOptions()
    {
        if (!IsOptionInstanceNamesChanged())
            return;

        _menuStrip.SuspendLayout();
        RemoveOptions();
        AddOptions();
        _menuStrip.ResumeLayout();

        var selected = false;
        foreach (var networkOption in _networkOptions)
        {
            if (_selectedNetworkOption == (string)networkOption.Tag)
            {
                selected = true;
                networkOption.Checked = true;
            }
        }
        if (!selected)
        {
            var first = _networkOptions.FirstOrDefault();
            if (first != null)
            {
                _selectedNetworkOption = (string)first.Tag;
                first.Checked = true;
            }
            else
            {
                _selectedNetworkOption = "";
            }
            NetworkUsage.SetPerformanceCounter(_selectedNetworkOption);
        }
    }

    private bool IsOptionInstanceNamesChanged()
    {
        var instanceNames = NetworkUsage.GetInstanceOptions().Select(n => n.instanceName);
        var isSupersetOf = _cachedOptionInstanceNames.IsSupersetOf(instanceNames);
        if (isSupersetOf && _cachedOptionInstanceNames.Count == instanceNames.Count())
            return false;
        return true;
    }

    private void AddOptions()
    {
        var instanceOptions = NetworkUsage.GetInstanceOptions();
        foreach (var instanceOption in instanceOptions)
        {
            var networkOption = new ToolStripMenuItem(instanceOption.description);
            networkOption.Tag = instanceOption.instanceName;
            networkOption.Click += NetworkOption_Click;
            _networkOptions.Add(networkOption);
            _menuStrip.Items.Add(networkOption);
        }
        _cachedOptionInstanceNames.UnionWith(instanceOptions.Select(n => n.instanceName));
    }

    private void RemoveOptions()
    {
        foreach (var networkOption in _networkOptions)
        {
            _menuStrip.Items.Remove(networkOption);
            networkOption.Dispose();
        }
        _networkOptions.Clear();
        _cachedOptionInstanceNames.Clear();
    }

    private void NetworkOption_Click(object? sender, EventArgs e)
    {
        foreach (var networkOption in _networkOptions)
            networkOption.Checked = false;

        if (sender is ToolStripMenuItem toolStripMenuItem)
        {
            _selectedNetworkOption = (string)toolStripMenuItem.Tag;
            toolStripMenuItem.Checked = true;
        }

        NetworkUsage.SetPerformanceCounter(_selectedNetworkOption);
    }

}
