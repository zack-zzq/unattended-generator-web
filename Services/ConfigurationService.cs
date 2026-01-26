using System.Collections.Immutable;
using System.Drawing;
using Schneegans.Unattend;

namespace unattended_generator_web.Services;

/// <summary>
/// 配置状态服务 - 管理所有用户配置选项
/// </summary>
public class ConfigurationService
{
    private readonly UnattendGenerator _generator;
    
    public ConfigurationService()
    {
        _generator = new UnattendGenerator();
    }

    #region Windows 版本设置
    
    public IEditionSettings EditionSettings { get; set; } = new InteractiveEditionSettings();
    public IInstallFromSettings InstallFromSettings { get; set; } = new AutomaticInstallFromSettings();
    
    public IEnumerable<WindowsEdition> AvailableEditions => _generator.WindowsEditions.Values;
    
    #endregion

    #region 区域语言设置
    
    public ILanguageSettings LanguageSettings { get; set; } = new InteractiveLanguageSettings();
    
    public IReadOnlyDictionary<string, ImageLanguage> AvailableImageLanguages => _generator.ImageLanguages;
    public IReadOnlyDictionary<string, UserLocale> AvailableUserLocales => _generator.UserLocales;
    public IReadOnlyDictionary<string, KeyboardIdentifier> AvailableKeyboards => _generator.KeyboardIdentifiers;
    public IReadOnlyDictionary<string, GeoLocation> AvailableGeoLocations => _generator.GeoLocations;
    
    #endregion

    #region 时区设置
    
    public ITimeZoneSettings TimeZoneSettings { get; set; } = new ImplicitTimeZoneSettings();
    
    public IReadOnlyDictionary<string, TimeOffset> AvailableTimeZones => _generator.TimeOffsets;
    
    #endregion

    #region 磁盘分区设置
    
    public IPartitionSettings PartitionSettings { get; set; } = new InteractivePartitionSettings();
    public IPESettings PESettings { get; set; } = new DefaultPESettings();
    public IDiskAssertionSettings DiskAssertionSettings { get; set; } = new SkipDiskAssertionSettings();
    public CompactOsModes CompactOsMode { get; set; } = CompactOsModes.Default;
    
    #endregion

    #region 用户账户设置
    
    public IAccountSettings AccountSettings { get; set; } = new InteractiveLocalAccountSettings();
    
    #endregion

    #region 个性化设置
    
    public IWallpaperSettings WallpaperSettings { get; set; } = new DefaultWallpaperSettings();
    public IColorSettings ColorSettings { get; set; } = new DefaultColorSettings();
    public ILockScreenSettings LockScreenSettings { get; set; } = new DefaultLockScreenSettings();
    
    #endregion

    #region 系统优化设置
    
    public bool ShowFileExtensions { get; set; } = false;
    public HideModes HideFiles { get; set; } = HideModes.Hidden;
    public bool DisableWindowsUpdate { get; set; } = false;
    public bool ShowAllTrayIcons { get; set; } = false;
    public bool HideTaskViewButton { get; set; } = false;
    public bool DisableDefender { get; set; } = false;
    public bool DisableSac { get; set; } = false;
    public bool DisableSmartScreen { get; set; } = false;
    public bool DisableUac { get; set; } = false;
    public bool EnableLongPaths { get; set; } = false;
    public bool EnableRemoteDesktop { get; set; } = false;
    public bool HardenSystemDriveAcl { get; set; } = false;
    public bool AllowPowerShellScripts { get; set; } = false;
    public bool DisableLastAccess { get; set; } = false;
    public bool PreventAutomaticReboot { get; set; } = false;
    public bool DisableFastStartup { get; set; } = false;
    public bool DisableSystemRestore { get; set; } = false;
    public bool DisableWidgets { get; set; } = false;
    public bool TurnOffSystemSounds { get; set; } = false;
    public bool DisableAppSuggestions { get; set; } = false;
    public bool PreventDeviceEncryption { get; set; } = false;
    public bool ClassicContextMenu { get; set; } = false;
    public bool LeftTaskbar { get; set; } = false;
    public bool HideEdgeFre { get; set; } = false;
    public bool DisableEdgeStartupBoost { get; set; } = false;
    public bool MakeEdgeUninstallable { get; set; } = false;
    public bool LaunchToThisPC { get; set; } = false;
    public TaskbarSearchMode TaskbarSearch { get; set; } = TaskbarSearchMode.Box;
    public bool DeleteWindowsOld { get; set; } = false;
    public bool DisablePointerPrecision { get; set; } = false;
    public bool DisableBingResults { get; set; } = false;
    public bool DeleteJunctions { get; set; } = false;
    public bool DeleteEdgeDesktopIcon { get; set; } = false;
    public bool ShowEndTask { get; set; } = false;
    
    public IStartPinsSettings StartPinsSettings { get; set; } = new DefaultStartPinsSettings();
    public IStartTilesSettings StartTilesSettings { get; set; } = new DefaultStartTilesSettings();
    public ITaskbarIcons TaskbarIcons { get; set; } = new DefaultTaskbarIcons();
    public IEffects Effects { get; set; } = new DefaultEffects();
    public IDesktopIconSettings DesktopIcons { get; set; } = new DefaultDesktopIconSettings();
    public IStartFolderSettings StartFolderSettings { get; set; } = new DefaultStartFolderSettings();
    public IStickyKeysSettings StickyKeysSettings { get; set; } = new DefaultStickyKeysSettings();
    public IProcessAuditSettings ProcessAuditSettings { get; set; } = new DisabledProcessAuditSettings();
    public ILockKeySettings LockKeySettings { get; set; } = new SkipLockKeySettings();
    
    #endregion

    #region VM工具设置
    
    public bool VBoxGuestAdditions { get; set; } = false;
    public bool VMwareTools { get; set; } = false;
    public bool VirtIoGuestTools { get; set; } = false;
    public bool ParallelsTools { get; set; } = false;
    
    #endregion

    #region 预装软件删除
    
    public ImmutableList<Bloatware> SelectedBloatwares { get; set; } = [];
    
    public IEnumerable<Bloatware> AvailableBloatwares => _generator.Bloatwares.Values;
    
    #endregion

    #region Wi-Fi设置
    
    public IWifiSettings WifiSettings { get; set; } = new SkipWifiSettings();
    
    #endregion

    #region 安全设置
    
    public IWdacSettings WdacSettings { get; set; } = new SkipWdacSettings();
    public ILockoutSettings LockoutSettings { get; set; } = new DefaultLockoutSettings();
    public IPasswordExpirationSettings PasswordExpirationSettings { get; set; } = new DefaultPasswordExpirationSettings();
    
    #endregion

    #region 高级设置
    
    public IComputerNameSettings ComputerNameSettings { get; set; } = new RandomComputerNameSettings();
    public bool BypassRequirementsCheck { get; set; } = false;
    public bool BypassNetworkCheck { get; set; } = false;
    public ExpressSettingsMode ExpressSettings { get; set; } = ExpressSettingsMode.DisableAll;
    public ProcessorArchitecture ProcessorArchitecture { get; set; } = ProcessorArchitecture.amd64;
    public bool UseNarrator { get; set; } = false;
    public bool UseConfigurationSet { get; set; } = false;
    
    #endregion

    #region 自定义脚本
    
    public ScriptSettings ScriptSettings { get; set; } = new ScriptSettings([], false);
    
    #endregion

    #region 自定义组件
    
    public ImmutableDictionary<ComponentAndPass, string> Components { get; set; } = 
        ImmutableDictionary<ComponentAndPass, string>.Empty;
    
    #endregion

    /// <summary>
    /// 生成 autounattend.xml 内容
    /// </summary>
    public string GenerateXml()
    {
        var configuration = BuildConfiguration();
        var xmlDoc = _generator.GenerateXml(configuration);
        byte[] xmlBytes = UnattendGenerator.Serialize(xmlDoc);
        return System.Text.Encoding.UTF8.GetString(xmlBytes);
    }

    /// <summary>
    /// 生成 autounattend.xml 字节数组
    /// </summary>
    public byte[] GenerateXmlBytes()
    {
        var configuration = BuildConfiguration();
        var xmlDoc = _generator.GenerateXml(configuration);
        return UnattendGenerator.Serialize(xmlDoc);
    }

    private Configuration BuildConfiguration()
    {
        return new Configuration(
            LanguageSettings: this.LanguageSettings,
            AccountSettings: this.AccountSettings,
            PartitionSettings: this.PartitionSettings,
            InstallFromSettings: this.InstallFromSettings,
            DiskAssertionSettings: this.DiskAssertionSettings,
            EditionSettings: this.EditionSettings,
            LockoutSettings: this.LockoutSettings,
            PasswordExpirationSettings: this.PasswordExpirationSettings,
            ProcessAuditSettings: this.ProcessAuditSettings,
            ComputerNameSettings: this.ComputerNameSettings,
            TimeZoneSettings: this.TimeZoneSettings,
            WifiSettings: this.WifiSettings,
            WdacSettings: this.WdacSettings,
            AppLockerSettings: new SkipAppLockerSettings(),
            ProcessorArchitectures: [this.ProcessorArchitecture],
            Components: this.Components,
            Bloatwares: this.SelectedBloatwares,
            ExpressSettings: this.ExpressSettings,
            ScriptSettings: this.ScriptSettings,
            LockKeySettings: this.LockKeySettings,
            WallpaperSettings: this.WallpaperSettings,
            LockScreenSettings: this.LockScreenSettings,
            ColorSettings: this.ColorSettings,
            PESettings: this.PESettings,
            BypassRequirementsCheck: this.BypassRequirementsCheck,
            BypassNetworkCheck: this.BypassNetworkCheck,
            EnableLongPaths: this.EnableLongPaths,
            EnableRemoteDesktop: this.EnableRemoteDesktop,
            HardenSystemDriveAcl: this.HardenSystemDriveAcl,
            DeleteJunctions: this.DeleteJunctions,
            AllowPowerShellScripts: this.AllowPowerShellScripts,
            DisableLastAccess: this.DisableLastAccess,
            PreventAutomaticReboot: this.PreventAutomaticReboot,
            DisableDefender: this.DisableDefender,
            DisableSac: this.DisableSac,
            DisableUac: this.DisableUac,
            DisableSmartScreen: this.DisableSmartScreen,
            DisableSystemRestore: this.DisableSystemRestore,
            DisableFastStartup: this.DisableFastStartup,
            TurnOffSystemSounds: this.TurnOffSystemSounds,
            DisableAppSuggestions: this.DisableAppSuggestions,
            DisableWidgets: this.DisableWidgets,
            VBoxGuestAdditions: this.VBoxGuestAdditions,
            VMwareTools: this.VMwareTools,
            VirtIoGuestTools: this.VirtIoGuestTools,
            ParallelsTools: this.ParallelsTools,
            PreventDeviceEncryption: this.PreventDeviceEncryption,
            ClassicContextMenu: this.ClassicContextMenu,
            LeftTaskbar: this.LeftTaskbar,
            HideTaskViewButton: this.HideTaskViewButton,
            ShowFileExtensions: this.ShowFileExtensions,
            ShowAllTrayIcons: this.ShowAllTrayIcons,
            HideFiles: this.HideFiles,
            HideEdgeFre: this.HideEdgeFre,
            DisableEdgeStartupBoost: this.DisableEdgeStartupBoost,
            MakeEdgeUninstallable: this.MakeEdgeUninstallable,
            DeleteEdgeDesktopIcon: this.DeleteEdgeDesktopIcon,
            LaunchToThisPC: this.LaunchToThisPC,
            DisableWindowsUpdate: this.DisableWindowsUpdate,
            DisablePointerPrecision: this.DisablePointerPrecision,
            DeleteWindowsOld: this.DeleteWindowsOld,
            DisableBingResults: this.DisableBingResults,
            UseConfigurationSet: this.UseConfigurationSet,
            HidePowerShellWindows: false,
            ShowEndTask: this.ShowEndTask,
            KeepSensitiveFiles: false,
            UseNarrator: this.UseNarrator,
            DisableCoreIsolation: false,
            DisableAutomaticRestartSignOn: false,
            TaskbarSearch: this.TaskbarSearch,
            StartPinsSettings: this.StartPinsSettings,
            StartTilesSettings: this.StartTilesSettings,
            CompactOsMode: this.CompactOsMode,
            TaskbarIcons: this.TaskbarIcons,
            Effects: this.Effects,
            DesktopIcons: this.DesktopIcons,
            StickyKeysSettings: this.StickyKeysSettings,
            StartFolderSettings: this.StartFolderSettings
        );
    }
}
