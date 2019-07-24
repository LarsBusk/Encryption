using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawDataInfo
{
  /// <summary>
  /// Class to hold information from the rawdata sample scan files from MM2
  /// </summary>
  public class RawDataStuff
  {
    public int DroppedLines;

    public int FlashCount;

    public int ReplacedPixels;

    public double CameraTemp;

    public double XrayTemp;

    public double ConveyorSpeed;

    public double StdDevSpeed;

    public string Header => "DroppedLines;FlashCount;ReplacedPixels;CameraTemp;XrayTemp;ConveyorSpeed;StdDevSpeed";

    public RawDataStuff(int droppedLines, int flashCount, int replacedPixels, double cameraTemp, double xrayTemp, double conveyorSpeed, double stdDevSpeed)
    {
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
      return $"{DroppedLines};{FlashCount};{ReplacedPixels};{CameraTemp};{XrayTemp};{ConveyorSpeed};{StdDevSpeed}";
    }
  }
}
