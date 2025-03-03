﻿using System;
using System.IO;
using System.Linq;
using Lextm.SharpSnmpLib.Messaging;
using NETworkManager.Models.Export;
using NETworkManager.Models.Network;
using NETworkManager.Models.PowerShell;
using NETworkManager.Models.PuTTY;
using NETworkManager.Utilities;
using NETworkManager.Models.RemoteDesktop;
using DnsClient;
using NETworkManager.Models;

namespace NETworkManager.Settings
{
    public static class GlobalStaticConfiguration
    {
        // Type to search (average type speed --> 187 chars/min)
        public static TimeSpan SearchDispatcherTimerTimeSpan => new(0, 0, 0, 0, 750);
        public static TimeSpan CredentialsUILockTime => new(0, 0, 120);

        // Filter
        public static string ApplicationFileExtensionFilter => "Application (*.exe)|*.exe";
        public static string PuTTYPrivateKeyFileExtensionFilter => "PuTTY Private Key Files (*.ppk)|*.ppk";
        public static string ZipFileExtensionFilter => "ZIP Archive (*.zip)|*.zip";
        public static string XmlFileExtensionFilter => "XML-File (*.xml)|*.xml";

        // Settings
        public static ApplicationName General_DefaultApplicationViewName => ApplicationName.Dashboard;
        public static int General_BackgroundJobInterval => 5;
        public static int General_HistoryListEntries => 10;
        public static bool SplashScreen_Enabled => true;
        public static string Appearance_Theme => "Dark";
        public static string Appearance_Accent => "Lime";
        public static bool Appearance_UseCustomTheme => false;
        public static bool Status_ShowWindowOnNetworkChange => true;
        public static int Status_WindowCloseTime => 10;
        public static string Status_IPAddressToDetectLocalIPAddressBasedOnRouting => "1.1.1.1";

        // Fixes
        public static double FloatPointFix => 1.0;

        // HotKey
        public static int HotKey_ShowWindowKey => 79;
        public static int HotKey_ShowWindowModifier => 3;

        // Profile
        public static double Profile_WidthCollapsed => 40;
        public static double Profile_DefaultWidthExpanded => 250;
        public static double Profile_MaxWidthExpanded => 350;
        public static int Profile_EncryptionKeySize => 256;
        public static int Profile_EncryptionIterations => 1000000;

        // Application: Dashboard
        public static string Dashboard_PublicIPv4Address => "1.1.1.1";
        public static string Dashboard_PublicIPv6Address => "2606:4700:4700::1111";
        public static bool Dashboard_CheckPublicIPAddress => true;
        public static string Dashboard_PublicIPv4AddressAPI => "https://api.ipify.org";
        public static string Dashboard_PublicIPv6AddressAPI => "https://api6.ipify.org";

        // Application: WiFi
        public static bool WiFi_Show2dot4GHzNetworks => true;
        public static bool WiFi_Show5GHzNetworks => true;
        public static AutoRefreshTimeInfo WiFi_AutoRefreshTime => AutoRefreshTime.GetDefaults.First(x => x.Value == 30 && x.TimeUnit == TimeUnit.Second);
        public static ExportManager.ExportFileType WiFi_ExportFileType => ExportManager.ExportFileType.CSV;

        // Application: IP Scanner
        public static int IPScanner_Threads => 256;
        public static int IPScanner_ICMPAttempts => 2;
        public static int IPScanner_ICMPBuffer => 32;
        public static int IPScanner_DNSPort => 53;
        public static bool IPScanner_DNSUseTCPOnly => false;
        public static int IPScanner_DNSTimeout => 2;
        public static int IPScanner_DNSRetries => 3;
        public static bool IPScanner_DNSShowErrorMessage => false;
        public static int IPScanner_ICMPTimeout => 4000;
        public static ExportManager.ExportFileType IPScanner_ExportFileType => ExportManager.ExportFileType.CSV;

        // Application: Port Scanner 
        public static int PortScanner_HostThreads => 5;
        public static int PortScanner_PortThreds => 100;
        public static int PortScanner_Timeout => 4000;
        public static ExportManager.ExportFileType PortScanner_ExportFileType => ExportManager.ExportFileType.CSV;

        // Application: Ping Monitor
        public static int PingMonitor_Buffer => 32;
        public static int PingMonitor_Timeout => 4000;
        public static int PingMonitor_TTL => 64;
        public static int PingMonitor_WaitTime => 1000;
        public static ExportManager.ExportFileType PingMonitor_ExportFileType => ExportManager.ExportFileType.CSV;

        // Application: Traceroute
        public static int Traceroute_MaximumHops => 30;
        public static int Traceroute_Timeout => 4000;
        public static int Traceroute_Buffer => 32;
        public static ExportManager.ExportFileType Traceroute_ExportFileType => ExportManager.ExportFileType.CSV;

        // Application: DNS Lookup
        public static QueryClass DNSLookup_QueryClass => QueryClass.IN;
        public static QueryType DNSLookup_QueryType => QueryType.ANY;
        public static bool DNSLookup_UseTCPOnly => false;
        public static int DNSLookup_Retries => 3;
        public static int DNSLookup_Timeout => 2;
        public static ExportManager.ExportFileType DNSLookup_ExportFileType => ExportManager.ExportFileType.CSV;

        // Application: RemoteDesktop
        public static bool RemoteDesktop_UseCurrentViewSize => true;
        public static int RemoteDesktop_ScreenWidth => 1280;
        public static int RemoteDesktop_ScreenHeight => 768;

        public static int RemoteDesktop_ColorDepth = 32;
        public static int RemoteDesktop_Port => 3389;
        public static AudioRedirectionMode RemoteDesktop_AudioRedirectionMode => AudioRedirectionMode.PlayOnThisComputer;
        public static AudioCaptureRedirectionMode RemoteDesktop_AudioCaptureRedirectionMode => AudioCaptureRedirectionMode.DoNotRecord;
        public static KeyboardHookMode RemoteDesktop_KeyboardHookMode => KeyboardHookMode.OnTheRemoteComputer;
        public static uint RemoteDesktop_AuthenticationLevel => 2;

        public static NetworkConnectionType RemoteDesktop_NetworkConnectionType => NetworkConnectionType.DetectAutomatically;

        // Application: PowerShell
        public static string PowerShell_ApplicationFileLocationPowerShell => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"System32\WindowsPowerShell\v1.0\powershell.exe");
        public static string PowerShell_Command => "Set-Location ~";
        public static PowerShell.ExecutionPolicy PowerShell_ExecutionPolicy => PowerShell.ExecutionPolicy.RemoteSigned;

        // Application: PuTTY
        public static ConnectionMode PuTTY_DefaultConnectionMode => ConnectionMode.SSH;
        public static string PuTTY_DefaultProfile => "NETworkManager";
        public static LogMode PuTTY_LogMode => LogMode.SessionLog;
        public static string PuTTY_LogPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AssemblyManager.Current.Name, "PuTTY_Log");
        public static string PuTTY_LogFileName => "&H_&Y-&M-&D_&T.log";
        public static int PuTTY_SSHPort => 22;
        public static string PuTTY_SerialLine => "COM1";
        public static int PuTTY_TelnetPort => 23;
        public static int PuTTY_RloginPort => 513;
        public static int PuTTY_BaudRate => 9600;
        public static int PuTTY_Raw => 0;

        // Application: AWSSessionManager
        public static string AWSSessionManager_ApplicationFileLocationPowerShell => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"System32\WindowsPowerShell\v1.0\powershell.exe");
        public static bool AWSSessionManager_EnableSyncInstanceIDsFromAWS => false;
        public static bool AWSSessionManager_SyncOnlyRunningInstancesFromAWS => true;

        // Application: TigerVNC
        public static int TigerVNC_DefaultVNCPort => 5900;

        // WebConsole
        public static string WebConsole_Cache => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AssemblyManager.Current.Name, "WebConsole_Cache");

        // Application: SNMP
        public static WalkMode SNMP_WalkMode => WalkMode.WithinSubtree;
        public static int SNMP_Timeout => 60000;
        public static SNMP.SNMPMode SNMP_Mode => SNMP.SNMPMode.Walk;
        public static SNMP.SNMPVersion SNMP_Version => SNMP.SNMPVersion.V2C;
        public static SNMP.SNMPV3Security SNMP_Security => SNMP.SNMPV3Security.AuthPriv;
        public static SNMP.SNMPV3AuthenticationProvider SNMP_AuthenticationProvider => SNMP.SNMPV3AuthenticationProvider.SHA1;
        public static SNMP.SNMPV3PrivacyProvider SNMP_PrivacyProvider => SNMP.SNMPV3PrivacyProvider.AES;
        public static ExportManager.ExportFileType SNMP_ExportFileType => ExportManager.ExportFileType.CSV;

        // Application: Discovery Protocol
        public static DiscoveryProtocol.Protocol DiscoveryProtocol_Protocol => DiscoveryProtocol.Protocol.LLDP_CDP;
        public static int DiscoveryProtocol_Duration => 60;

        // Application: Wake on LAN
        public static int WakeOnLAN_Port => 7;

        // Application: HTTP Header
        public static int HTTPHeaders_Timeout => 10000;
        public static ExportManager.ExportFileType HTTPHeaders_ExportFileType => ExportManager.ExportFileType.CSV;

        // Application: Subnet Calculator
        public static ExportManager.ExportFileType SubnetCalculator_Subnetting_ExportFileType => ExportManager.ExportFileType.CSV;

        // Application: Lookup
        public static ExportManager.ExportFileType Lookup_OUI_ExportFileType => ExportManager.ExportFileType.CSV;
        public static ExportManager.ExportFileType Lookup_Port_ExportFileType => ExportManager.ExportFileType.CSV;

        // Application: Whois
        public static ExportManager.ExportFileType Whois_ExportFileType => ExportManager.ExportFileType.TXT;

        // Application: Connections
        public static ExportManager.ExportFileType Connections_ExportFileType => ExportManager.ExportFileType.CSV;
        public static AutoRefreshTimeInfo Connections_AutoRefreshTime => AutoRefreshTime.GetDefaults.First(x => x.Value == 30 && x.TimeUnit == TimeUnit.Second);

        // Application: Listeners
        public static ExportManager.ExportFileType Listeners_ExportFileType => ExportManager.ExportFileType.CSV;
        public static AutoRefreshTimeInfo Listeners_AutoRefreshTime => AutoRefreshTime.GetDefaults.First(x => x.Value == 30 && x.TimeUnit == TimeUnit.Second);

        // Application: ARP Table
        public static ExportManager.ExportFileType ARPTable_ExportFileType => ExportManager.ExportFileType.CSV;
        public static AutoRefreshTimeInfo ARPTable_AutoRefreshTime => AutoRefreshTime.GetDefaults.First(x => x.Value == 30 && x.TimeUnit == TimeUnit.Second);

    }
}