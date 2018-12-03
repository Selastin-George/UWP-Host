# UWP-Host
UWP Host allows you to integrate UWP controls and windows to your wpf applications
```diff
! Note : This project is under development, more updates will be available soon.
```
<br>
<h2>Overview</h2>
<ul>
  <li><h3>UWP Window</h3></li>
</ul>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
The UWP Host library provides you coustom UWP application window layout for your WPF applications.
<h2>Features</h2>
<ul>
<li>No flickering on resizing window (available only on windows 10 redstone update)</li>
<li>Builtin ControlBox</li>
<li>Extented Content Area</li>
</ul>
<h2>Install</h2>

*NuGet Package*
```
Install-Package UWPHost -Version 1.0.0
```
https://nuget.org/packages/FluentWPF

### Preparation

Add XAML namespace.

```xml
xmlns:uwp="clr-namespace:UWPHost;assembly=UWPHost"
```

Add ResourceDictionary to App.xaml.

```xml
<Application.Resources>
      <ResourceDictionary>
           <ResourceDictionary.MergedDictionaries>
               <ResourceDictionary Source="pack://application:,,,/UWPHost;component/Themes/Generic.xaml" />
           </ResourceDictionary.MergedDictionaries>
      </ResourceDictionary>
</Application.Resources>
```

## Usage

### UWP Window

MainWindow.xaml

```xml
<upw:Window x:Class="WpfApp1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp1"
        xmlns:uwp="clr-namespace:UWPHost;assembly=UWPHost"
        mc:Ignorable="d"
        ShowTitlebar="true" Theme="Light"
        Title="MainWindow" Height="300" Width="300">

</uwp:Window>
```
 MainWindow.xaml.cs
 
 ```cs
public partial class MainWindow : UWPHost.Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
}
```
##### Properties

|Property Name|Type|Description|
|-----|-----|-----|
|ShowTitlebar|bool|Show or Hide the titlebar of the window.|
|TitlebarBrush|SolidColorBrush|Sets the color of the titlebar.|
|Theme|String|Set the theme of window. ie; Light or Dark. |

<br>
<br>

<h2>Screenshots</h2>
<br>
<h3>Dark Theme</h3>
<img src="https://github.com/Selastin-George/UWP-Host/blob/master/Sample/Assets/demo/dark.png" Width="400" alt="Dark Theme"/>
<br>
<h3>Light Theme<h3>
<img src="https://github.com/Selastin-George/UWP-Host/blob/master/Sample/Assets/demo/light.png" Width="400" alt="Light Theme"/>
<br>
<h3>Control Box</h3>
<img src="https://github.com/Selastin-George/UWP-Host/blob/master/Sample/Assets/demo/controls.gif" Width="400" alt="Control Box"/>
<br>
<h3>Flickerless Resize</h3>
<img src="https://github.com/Selastin-George/UWP-Host/blob/master/Sample/Assets/demo/flicker.gif" Width="800" alt="Flickerless Resize"/>
<br>
<h3>Extented Client Area</h3>
<img src="https://github.com/Selastin-George/UWP-Host/blob/master/Sample/Assets/demo/extented client area.jpg" Width="800" alt="Extented Client Area"/>
<br>
<br>
<h2>Donate</h2>

Donate us through paytm.

<img src="https://github.com/Selastin-George/UWP-Host/blob/master/donate.png" Width="200" alt="Donate"/>

