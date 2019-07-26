using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RawDataInfo
{
  /// <summary>
  /// Class to hold information from the rawdata sample scan files from MM2
  /// </summary>
  public class RawDataStuff
  {
    public string FileName;

    public int DroppedLines;

    public int FlashCount;

    public int ReplacedPixels;

    public double CameraTemp;

    public double XrayTemp;

    public double ConveyorSpeed;

    public double StdDevSpeed;

    public string ListSeperator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;

    public string Header =>
      string.Join(ListSeperator, ColumnHeaders);

    public string[] ColumnHeaders =>
      new []{"FileName", "DroppedLines", "FlashCount", "ReplacedPixels", "CameraTemp", "XrayTemp", "ConveyorSpeed", "StdDevSpeed"};

    public int ColumnCount => ColumnHeaders.Length;

    public RawDataStuff(string fileName, int droppedLines, int flashCount, int replacedPixels, double cameraTemp, double xrayTemp, double conveyorSpeed, double stdDevSpeed)
    {
      FileName = fileName;
      DroppedLines = droppedLines;
      FlashCount = flashCount;
      ReplacedPixels = replacedPixels;
      CameraTemp = cameraTemp;
      XrayTemp = xrayTemp;
      ConveyorSpeed = conveyorSpeed;
      StdDevSpeed = stdDevSpeed;
    }

    public override string ToString()
    {
      return
        $"{FileName}{ListSeperator}{DroppedLines}{ListSeperator}{FlashCount}{ListSeperator}{ReplacedPixels}{ListSeperator}{CameraTemp}{ListSeperator}{XrayTemp}{ListSeperator}{ConveyorSpeed}{ListSeperator}{StdDevSpeed}";
    }
  }
}
